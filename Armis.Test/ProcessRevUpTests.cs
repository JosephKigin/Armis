using Armis.BusinessModels.QualityModels.Process;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.Services.QualityServices;
using Armis.DataLogic.Services.QualityServices.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Armis.Test
{
    [TestClass]
    public class ProcessRevUpTests
    {
        private ARMISContext _context;
        private const string TEST_CODE = "[TEST]RevUp";

        public ARMISContext Context
        {
            get
            {
                if (_context == null) { _context = new ARMISContext(); }
                return _context;
            }
            set { _context = value; }
        }

        private IProcessService _processService;
        private IStepService _stepService;

        public IProcessService ProcessService
        {
            get
            {
                if (_processService == null) { _processService = new ProcessService(Context); }
                return _processService;
            }
            set { _processService = value; }
        }

        public IStepService StepService
        {
            get
            {
                if (_stepService == null) { _stepService = new StepService(Context); }
                return _stepService;
            }
            set { _stepService = value; }
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task FailToDeleteOrRevUpALOCKEDProcessRevision()
        {
            var theReturnHydratedProcessModels = await ProcessService.GetHydratedProcessRevs();
           
            var theProcessRevisionModelToAttemptDelete = new ProcessRevisionModel();

            foreach (var aProcessModel in theReturnHydratedProcessModels)
            {
                foreach (var aProcessRevModel in aProcessModel.Revisions)
                {
                    if (aProcessRevModel.RevStatusCd == "LOCKED")
                    {
                        theProcessRevisionModelToAttemptDelete = aProcessRevModel;
                        break;
                    }
                }
                if(theProcessRevisionModelToAttemptDelete.ProcessId != 0) { break; }
            }

            if(theProcessRevisionModelToAttemptDelete.ProcessId == 0) { throw new Exception("No Process Revs with LOCKED status exist"); }

            var theProcessID = theProcessRevisionModelToAttemptDelete.ProcessId;
            var theProcessRevID = theProcessRevisionModelToAttemptDelete.ProcessRevId;

            await ProcessService.DeleteProcessRev(theProcessID, theProcessRevID);

            await ProcessService.UpdateUnlockToLockRev(theProcessRevisionModelToAttemptDelete.ProcessId, theProcessRevisionModelToAttemptDelete.ProcessRevId);    
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task FailToDeleteOrRevUpAnINACTIVEProcessRevision()
        {
            var theReturnHydratedProcessModels = await ProcessService.GetHydratedProcessRevs();

            var theProcessRevisionModelToAttemptDelete = new ProcessRevisionModel();

            foreach (var aProcessModel in theReturnHydratedProcessModels)
            {
                foreach (var aProcessRevModel in aProcessModel.Revisions)
                {
                    if (aProcessRevModel.RevStatusCd == "INACTIVE")
                    {
                        theProcessRevisionModelToAttemptDelete = aProcessRevModel;
                        break;
                    }
                }
                if (theProcessRevisionModelToAttemptDelete.ProcessId != 0) { break; }
            }

            if (theProcessRevisionModelToAttemptDelete.ProcessId == 0) { throw new Exception("No Process Revs with LOCKED status exist"); }

            var theProcessID = theProcessRevisionModelToAttemptDelete.ProcessId;
            var theProcessRevID = theProcessRevisionModelToAttemptDelete.ProcessRevId;

            await ProcessService.DeleteProcessRev(theProcessID, theProcessRevID);

            await ProcessService.UpdateUnlockToLockRev(theProcessRevisionModelToAttemptDelete.ProcessId, theProcessRevisionModelToAttemptDelete.ProcessRevId);

        }
        [TestMethod]
        public async Task CreateNewProcessRevStepsAndRevUp()
        {
            short theArbitraryEmpID = 941; //Ed Wakefield
            short theArbitraryOprID = 5;
            int theArbitraryNumSteps = 4;

            var theArbitraryStepIDList = new List<int>();

            var theBaselineProcessModel = CreateBaselineProcessModel();
            var theNewAddedProcessID = (await ProcessService.CreateNewProcess(theBaselineProcessModel)).ProcessId;

            var theBaselineProcessRevisionModel = CreateBaselineProcessRevisionModel(theNewAddedProcessID, theArbitraryEmpID);

            _ = await ProcessService.CreateNewRevForExistingProcess(theBaselineProcessRevisionModel); //TODO: test that return model validates

            var theReturnHydratedProcessModel = await ProcessService.GetHydratedProcess(theNewAddedProcessID);
            var theReturnedProcessRevisionID = theReturnHydratedProcessModel.Revisions.ElementAt(0).ProcessRevId;


            for (int i = 0; i < theArbitraryNumSteps; i++)
            {
                var theBaselineStepModel = CreateBaselineStepModel((i + 1).ToString(), theNewAddedProcessID, theReturnedProcessRevisionID);
                var theReturnStepID = await StepService.CreateStep(theBaselineStepModel);

                theArbitraryStepIDList.Add(theReturnStepID.StepId);
            }

            var theBaselineStepSeqModelList = new List<StepSeqModel>();
            for (int i = 0; i < theArbitraryStepIDList.Count; i++)
            {
                theBaselineStepSeqModelList.Add(
                    CreateBaselineStepSeqModel(theNewAddedProcessID, theReturnedProcessRevisionID, theArbitraryStepIDList[i], theArbitraryOprID, i + 1));
            }
            //update steps but get return process rev model for validation purposes later
            var theReturnProcessRevisionModelToValidate = await ProcessService.UpdateStepsForRev(theBaselineStepSeqModelList);
            //requery db with processID and return all revisions (but expecting 1)
            var theReturnProcessRevisionModelList = (await ProcessService.GetHydratedProcess(theNewAddedProcessID)).Revisions;
            var theReturnProcessRevision = theReturnProcessRevisionModelList.ElementAt(0);

            //assert ProcessService.UpdateStepsForRev returned model correctly (not testing steps!)

            Validate.ValidateModelCompleteness(theReturnProcessRevision, theReturnProcessRevisionModelToValidate,
                new List<Object>() { "StepSeqs" }); //TODO: Remove exclusions and Test!

            //extract steps from hydrated model from query
            var theReturnStepModelList = theReturnProcessRevision.StepSeqs;

            //does the return revision have the correct number of steps that we tested with?
            Assert.AreEqual(theArbitraryNumSteps, theReturnStepModelList.Count());
            //check if Step Name is representative of where it was initialized
            string theStrToCheckStepName = TEST_CODE + "1";
            Assert.AreEqual(theStrToCheckStepName, theReturnStepModelList.ElementAt(0).Step.StepName.Substring(0, theStrToCheckStepName.Length));

            //lock the rev and get a new Procees rev model to validate
            theReturnProcessRevisionModelToValidate = await ProcessService.UpdateUnlockToLockRev(theReturnProcessRevision.ProcessId, theReturnProcessRevision.ProcessRevId);
            var theCurrProcessRevisionModelWithSteps = await ProcessService.GetHydratedCurrentProcessRev(theNewAddedProcessID);

            //assert ProcessService.UpdateUnlockToLockRev returned model correctly (not testing steps!)
            Validate.ValidateModelCompleteness(theCurrProcessRevisionModelWithSteps, theReturnProcessRevisionModelToValidate,
                new List<Object>() { "StepSeqs" }); //TODO: Remove exclusions and Test!

            //validate the current rev is now locked, has the required steps, and first step name is still in right spot
            Assert.AreEqual("LOCKED", theCurrProcessRevisionModelWithSteps.RevStatusCd);
            Assert.AreEqual(theArbitraryNumSteps, theCurrProcessRevisionModelWithSteps.StepSeqs.Count());
            Assert.AreEqual(theStrToCheckStepName, theCurrProcessRevisionModelWithSteps.StepSeqs.ElementAt(0).Step.StepName.Substring(0, theStrToCheckStepName.Length));

        }
        [TestMethod]
        public async Task CreateNewLockedRevAndRevUpWithDiffStepSeq()
        {
            const int REV1ID = 1;
            const int REV2ID = 2;
            short theArbitraryRev1EmpID = 941; //Ed Wakefield
            short theArbitraryRev2EmpID = 991; //Ben Johnson

            short theArbitraryRev1OprID = 6;
            short theArbitraryRev2OprID = 4;

            int theArbitraryNumStepsForRev1 = 4;

            var theArbitraryStepIdListForRev1 = new List<int>(); //remove later!

            var theBaselineProcessModel = CreateBaselineProcessModel();
            var theNewProcessID = (await ProcessService.CreateNewProcess(theBaselineProcessModel)).ProcessId;

            /******************************** make Revision 1 ********************************/
            var theBaselineProcessRevision1Model = CreateBaselineProcessRevisionModel(theNewProcessID, theArbitraryRev1EmpID);

            _ = await ProcessService.CreateNewRevForExistingProcess(theBaselineProcessRevision1Model); //TODO: test that return model validates

            var theReturnHydratedProcessModel = await ProcessService.GetHydratedProcess(theNewProcessID);

            var theStepSeqTestModelListForRev1 = new List<StepSeqModel>();

            for (int i = 0; i < theArbitraryNumStepsForRev1; i++)
            {
                var theBaselineStepModel = CreateBaselineStepModel((i + 1).ToString(), theNewProcessID, REV1ID);
                var theReturnStepModel = await StepService.CreateStep(theBaselineStepModel);
                
                theArbitraryStepIdListForRev1.Add(theReturnStepModel.StepId);

                //set test data
                theStepSeqTestModelListForRev1.Add(
                    new StepSeqModel()
                    {
                        StepId = theReturnStepModel.StepId,
                        Sequence = Convert.ToInt16(i + 1),
                        ProcessId = theNewProcessID, //change?
                        RevisionId = REV1ID,
                        OperationId = theArbitraryRev1OprID
                    });
            }

            var theBaselineStepSeqModelList = new List<StepSeqModel>();
            for (int i = 0; i < theArbitraryStepIdListForRev1.Count; i++)
            {
                theBaselineStepSeqModelList.Add(
                    CreateBaselineStepSeqModel(theNewProcessID, REV1ID, theArbitraryStepIdListForRev1[i], theArbitraryRev1OprID, i + 1));
            }

            _ = await ProcessService.UpdateStepsForRev(theBaselineStepSeqModelList);
            //requery db with processID and return all revisions (but expecting 1)
            var theReturnProcessRevision1 = (await ProcessService.GetHydratedProcess(theNewProcessID)).Revisions.ElementAt(0);

            //lock the rev and get a new Procees rev model to validate
            _ = await ProcessService.UpdateUnlockToLockRev(theReturnProcessRevision1.ProcessId, theReturnProcessRevision1.ProcessRevId);
            _ = await ProcessService.GetHydratedCurrentProcessRev(theNewProcessID);

            /******************************** make Revision 2 ********************************/
            var theBaselineProcessRevision2Model = CreateBaselineProcessRevisionModel(theNewProcessID, theArbitraryRev2EmpID);
            
            var theReturnedNewRevision2Model = await ProcessService.CreateNewRevForExistingProcess(theBaselineProcessRevision2Model);
            var theRev2ID = theReturnedNewRevision2Model.ProcessRevId;

            //*** create new step sequence based on old ***
            // 1. remove the first step
            // 2. insert 2 new step into the first location
            // 3. reverse order
            //*********************************************

            var theStepSeqTestModelListForRev2 = DeepCopyStepSeqModel(theStepSeqTestModelListForRev1);
            
            theStepSeqTestModelListForRev2.RemoveAt(0);
            var theReturnStepIDA = await StepService.CreateStep(CreateBaselineStepModel("a", theNewProcessID, REV2ID));
            var theReturnStepIDB = await StepService.CreateStep(CreateBaselineStepModel("b", theNewProcessID, REV2ID));

            theStepSeqTestModelListForRev2.Insert(0, new StepSeqModel()
            {
                StepId = theReturnStepIDA.StepId,
                ProcessId = theNewProcessID,
                OperationId = theArbitraryRev2OprID
            });
            theStepSeqTestModelListForRev2.Insert(1, new StepSeqModel()
            {
                StepId = theReturnStepIDB.StepId,
                ProcessId = theNewProcessID,
                OperationId = theArbitraryRev2OprID
            });
            theStepSeqTestModelListForRev2.Reverse();

            var theNewArbitraryStepIdListForRev2 = new List<int>();

            for (int i = 0; i < theStepSeqTestModelListForRev2.Count; i++)
            { 
                theStepSeqTestModelListForRev2[i].Sequence = Convert.ToInt16(i + 1); 
                theStepSeqTestModelListForRev2[i].RevisionId = REV2ID;
                theNewArbitraryStepIdListForRev2.Add(theStepSeqTestModelListForRev2[i].StepId);
            } //resequence

            var theBaselineStepSeqModelListRev2 = new List<StepSeqModel>();
            for (int i = 0; i < theNewArbitraryStepIdListForRev2.Count; i++)
            {
                theBaselineStepSeqModelListRev2.Add(
                    CreateBaselineStepSeqModel(theNewProcessID, REV2ID, theNewArbitraryStepIdListForRev2[i], 
                    theStepSeqTestModelListForRev2[i].OperationId, i + 1));
            }

            _ = await ProcessService.UpdateStepsForRev(theBaselineStepSeqModelListRev2);

            var theReturnProcessRevisionModelList = (await ProcessService.GetHydratedProcess(theNewProcessID)).Revisions;
            Assert.AreEqual(2, theReturnProcessRevisionModelList.Count());
            Assert.AreEqual(theNewArbitraryStepIdListForRev2.Count(), theReturnProcessRevisionModelList.ElementAt(1).StepSeqs.Count());

            // validate step sequences are as expected
            for (int i = 0; i < theStepSeqTestModelListForRev1.Count(); i++) //rev 1
            {
                Validate.ValidateModelCompleteness(
                    theStepSeqTestModelListForRev1[i], theReturnProcessRevisionModelList.ElementAt(REV1ID - 1).StepSeqs.ElementAt(i),
                    new List<object>() { "Step", "Operation", "Sequence" });
            }
            for (int i = 0; i < theStepSeqTestModelListForRev2.Count(); i++) //rev 2
            {
                Validate.ValidateModelCompleteness(
                    theStepSeqTestModelListForRev2[i], theReturnProcessRevisionModelList.ElementAt(REV2ID - 1).StepSeqs.ElementAt(i),
                    new List<object>() { "Step", "Operation" });
            }

            //LOCK and Validate
            var theReturnedLockedRevision2Model = await ProcessService.UpdateUnlockToLockRev(theReturnedNewRevision2Model.ProcessId, theReturnedNewRevision2Model.ProcessRevId);
            Assert.AreEqual("LOCKED", theReturnedLockedRevision2Model.RevStatusCd);
            ProcessRevisionModel theCurrProcessRevisionModelWithSteps = await ProcessService.GetHydratedCurrentProcessRev(theNewProcessID);
            Assert.AreEqual("LOCKED", theCurrProcessRevisionModelWithSteps.RevStatusCd);

            var theReturnProcessRevisionModelListPostLock = (await ProcessService.GetHydratedProcess(theNewProcessID)).Revisions;
            Assert.AreEqual(2, theReturnProcessRevisionModelListPostLock.Count());

            var theRevision1Data = theReturnProcessRevisionModelListPostLock.ElementAt(0);
            var theRevision2Data = theReturnProcessRevisionModelListPostLock.ElementAt(1);

            Assert.AreEqual("INACTIVE", theRevision1Data.RevStatusCd);
            Assert.AreEqual("LOCKED", theRevision2Data.RevStatusCd);

            // validate step sequences are as expected POST-LOCK
            for (int i = 0; i < theArbitraryStepIdListForRev1.Count(); i++) //rev 1
            {
                Assert.AreEqual(theArbitraryStepIdListForRev1[i], theRevision1Data.StepSeqs.ElementAt(i).StepId);
            }
            for (int i = 0; i < theNewArbitraryStepIdListForRev2.Count(); i++) //rev 2
            {
                Assert.AreEqual(theNewArbitraryStepIdListForRev2[i], theRevision2Data.StepSeqs.ElementAt(i).StepId);
            }

        }
        private List<StepSeqModel> DeepCopyStepSeqModel(List<StepSeqModel> aStepSeqModelList)
        {
            var returnStepSeqModelList = new List<StepSeqModel>();

            foreach (StepSeqModel sseqMdl in aStepSeqModelList)
            {
                returnStepSeqModelList.Add(new StepSeqModel() {
                    StepId = sseqMdl.StepId,
                    Sequence = sseqMdl.Sequence,
                    ProcessId = sseqMdl.ProcessId,
                    RevisionId = sseqMdl.RevisionId,
                    OperationId = sseqMdl.OperationId
                });
            }

            return returnStepSeqModelList;
        }
        private ProcessModel CreateBaselineProcessModel()
        {
            var theTimeStamp = DateTime.Now.ToString("yyyy/MM/dd/hh:mm:ss");
            return new ProcessModel() { Name = TEST_CODE + theTimeStamp };
        }
        private ProcessRevisionModel CreateBaselineProcessRevisionModel(int aProcessID, short aEmpID)
        {
            var theTimeStamp = DateTime.Now.ToString("yyyy/MM/dd/hh:mm:ss:ffff");
            return new ProcessRevisionModel()
            {
                ProcessId = aProcessID,
                CreatedByEmp = aEmpID,
                Comments = TEST_CODE + "(comment)" + theTimeStamp + "-PID: " + aProcessID.ToString()
            };
        }
        private StepModel CreateBaselineStepModel(string aSeqID, int aProcessID, int aRevID)
        {
            var theTimeStamp = DateTime.Now.ToString("yyyy/MM/dd/hh:mm:ss:ffff");

            return new StepModel()
            {
                StepCategory = new StepCategoryModel { Name = "None", Code="NONE", Type="Other"},
                Inactive = false,
                StepName = TEST_CODE + aSeqID + "-PID:" + aProcessID.ToString() + "-RevID:" + aRevID,
                SignOffIsRequired = true,
                Instructions = "Test data - (" + theTimeStamp + ")"
            };
        }

        private StepSeqModel CreateBaselineStepSeqModel(int aProcessID, int aProcessRevID, int aStepId, int aOperationID, int aSequence)
        {
            return new StepSeqModel()
            {
                ProcessId = aProcessID,
                RevisionId = aProcessRevID,
                Sequence = Convert.ToInt16(aSequence),
                StepId = aStepId,
                OperationId = aOperationID
            };
        }
    }
}
