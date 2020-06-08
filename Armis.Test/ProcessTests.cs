using Armis.BusinessModels.QualityModels.Process;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.Services.QualityServices;
using Armis.DataLogic.Services.QualityServices.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Armis.Test
{
    [TestClass]
    public class ProcessTests
    {
        private ARMISContext _context;
        private const string TEST_CODE = "[TEST]Process";

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
                if(_processService == null) { _processService = new ProcessService(Context); }
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
        public async Task CheckProcessNameUniqueness()
        {
            var theTimeStamp = DateTime.Now.ToString("yyyy/MM/dd/hh:mm:ss:ffff");

            var theTestProcessModel = CreateTestProcessModel(991, theTimeStamp);
            var thePostAddProcess = await ProcessService.CreateNewProcess(theTestProcessModel);

            var theNewExistingProcessName = thePostAddProcess.Name;

            bool theNameIsUnique = await ProcessService.CheckIfNameIsUnique(theNewExistingProcessName);
            Assert.IsFalse(theNameIsUnique, "'" + theNewExistingProcessName + "' was expected to be NOT unique but this is the first instance of this name.");

            theNameIsUnique = await ProcessService.CheckIfNameIsUnique(theNewExistingProcessName + "x");
            Assert.IsTrue(theNameIsUnique, "'" + theNewExistingProcessName + "x' was expected to be unique but there is already a process name.");
        }

        [TestMethod]
        public async Task CreateNewRevOnNewProcessAndThenDeleteRev()
        {
            var theTimeStamp = DateTime.Now.ToString("yyyy/MM/dd/hh:mm:ss:ffff");
            short theArbitraryEmpId = 941;

            var thePreAddProcessListForCount = await ProcessService.GetAllProcesses();

            var theTestProcessModel = CreateTestProcessModel(theArbitraryEmpId, theTimeStamp);

            var theCreatedProcess = await ProcessService.CreateNewProcess(theTestProcessModel);

            var thePostAddProcessListForCount = await ProcessService.GetAllProcesses();

            //confirm new process created
            Assert.AreEqual(thePostAddProcessListForCount.Count(), thePreAddProcessListForCount.Count() + 1);

            var theCreatedProcessId = theCreatedProcess.ProcessId;

            var theTestProcessRevision = theTestProcessModel.Revisions.ElementAt(0);

            theTestProcessRevision.ProcessRevId = 1; //for test
            theTestProcessRevision.RevStatusId = 2; //2=unlocked

            var theCreatedHydratedProcessModel = await ProcessService.GetHydratedProcess(theCreatedProcessId);
            var theCreatedProcessRevisionModel = theCreatedHydratedProcessModel.Revisions.ElementAt(0);


            Validate.ValidateModelCompleteness(theTestProcessRevision, theCreatedProcessRevisionModel,
                new List<Object>() { "DateTimeCreated", "StepSeqs" }); //time is to iffy to test

            Assert.AreEqual(0, theCreatedProcessRevisionModel.StepSeqs.Count());

            await ProcessService.DeleteProcessRev(theCreatedProcessId, 1); //delete process rev

            theCreatedHydratedProcessModel = await ProcessService.GetHydratedProcess(theCreatedProcessId);
            //verify deletion of unlocked rev works
            Assert.AreEqual(0, theCreatedHydratedProcessModel.Revisions.Count());
        }

        [TestMethod]
        private async Task ValidateProcessRevisionStatusCodes()
        {
            //TODO!!!
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
                    if (aProcessRevModel.RevStatusId == 1) //1=locked
                    {
                        theProcessRevisionModelToAttemptDelete = aProcessRevModel;
                        break;
                    }
                }
                if (theProcessRevisionModelToAttemptDelete.ProcessId != 0) { break; }
            }

            if (theProcessRevisionModelToAttemptDelete.ProcessId == 0) { throw new Exception("No Process Revs with LOCKED status exist"); }

            var theProcessId = theProcessRevisionModelToAttemptDelete.ProcessId;
            var theProcessRevId = theProcessRevisionModelToAttemptDelete.ProcessRevId;

            await ProcessService.DeleteProcessRev(theProcessId, theProcessRevId);

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
                    if (aProcessRevModel.RevStatusId == 3) //3=inactive
                    {
                        theProcessRevisionModelToAttemptDelete = aProcessRevModel;
                        break;
                    }
                }
                if (theProcessRevisionModelToAttemptDelete.ProcessId != 0) { break; }
            }

            if (theProcessRevisionModelToAttemptDelete.ProcessId == 0) { throw new Exception("No Process Revs with LOCKED status exist"); }

            var theProcessId = theProcessRevisionModelToAttemptDelete.ProcessId;
            var theProcessRevId = theProcessRevisionModelToAttemptDelete.ProcessRevId;

            await ProcessService.DeleteProcessRev(theProcessId, theProcessRevId);

            await ProcessService.UpdateUnlockToLockRev(theProcessRevisionModelToAttemptDelete.ProcessId, theProcessRevisionModelToAttemptDelete.ProcessRevId);

        }
        [TestMethod]
        public async Task CreateNewProcessRevStepsAndRevUp()
        {
            var theTimeStamp = DateTime.Now.ToString("yyyy/MM/dd/hh:mm:ss:ffff");
            short theArbitraryEmpId = 941; //Ed Wakefield
            short theArbitraryOprId = 5;
            int theArbitraryNumSteps = 4;

            var theArbitraryStepIdList = new List<int>();

            var theTestProcessModel = CreateTestProcessModel(theArbitraryEmpId, theTimeStamp);
            var theCreatedProcessModel = await ProcessService.CreateNewProcess(theTestProcessModel);
            var theCreatedProcessId = theCreatedProcessModel.ProcessId;

            var theCreatedHydratedProcessModel = await ProcessService.GetHydratedProcess(theCreatedProcessId);
            var theCreatedProcessRevisionId = theCreatedHydratedProcessModel.Revisions.ElementAt(0).ProcessRevId;


            for (int i = 0; i < theArbitraryNumSteps; i++)
            {
                var theTestStepModel = CreateTestStepModel((i + 1).ToString(), theCreatedProcessId, theCreatedProcessRevisionId);
                var theCreatedStepId = await StepService.CreateStep(theTestStepModel);

                theArbitraryStepIdList.Add(theCreatedStepId.StepId);
            }

            var theTestStepSeqModelList = new List<StepSeqModel>();
            for (int i = 0; i < theArbitraryStepIdList.Count; i++)
            {
                theTestStepSeqModelList.Add(
                    CreateTestStepSeqModel(theCreatedProcessId, theCreatedProcessRevisionId, theArbitraryStepIdList[i], theArbitraryOprId, i + 1));
            }
            //update steps but get return process rev model for validation purposes later
            var theReturnProcessRevisionModelToValidate = await ProcessService.UpdateStepsForRev(theTestStepSeqModelList);
            //requery db with processID and return all revisions (but expecting 1)
            var theReturnProcessRevisionModelList = (await ProcessService.GetHydratedProcess(theCreatedProcessId)).Revisions;
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
            var theCurrProcessRevisionModelWithSteps = await ProcessService.GetHydratedCurrentProcessRev(theCreatedProcessId);

            //assert ProcessService.UpdateUnlockToLockRev returned model correctly (not testing steps!)
            Validate.ValidateModelCompleteness(theCurrProcessRevisionModelWithSteps, theReturnProcessRevisionModelToValidate,
                new List<Object>() { "StepSeqs" }); //TODO: Remove exclusions and Test!

            //validate the current rev is now locked, has the required steps, and first step name is still in right spot
            Assert.AreEqual(1, theCurrProcessRevisionModelWithSteps.RevStatusId); //1=locked
            Assert.AreEqual(theArbitraryNumSteps, theCurrProcessRevisionModelWithSteps.StepSeqs.Count());
            Assert.AreEqual(theStrToCheckStepName, theCurrProcessRevisionModelWithSteps.StepSeqs.ElementAt(0).Step.StepName.Substring(0, theStrToCheckStepName.Length));

        }
        [TestMethod]
        public async Task CreateNewLockedRevAndRevUpWithDiffStepSeq()
        {
            var theTimeStamp = DateTime.Now.ToString("yyyy/MM/dd/hh:mm:ss:ffff");
            const int REV1ID = 1;
            const int REV2ID = 2;
            short theArbitraryRev1EmpId = 941; //Ed Wakefield
            short theArbitraryRev2EmpId = 991; //Ben Johnson

            short theArbitraryRev1OprId = 6;
            short theArbitraryRev2OprId = 4;

            int theArbitraryNumStepsForRev1 = 4;

            var theArbitraryStepIdListForRev1 = new List<int>(); //remove later!

            var theTestProcessModel = CreateTestProcessModel(theArbitraryRev1EmpId, theTimeStamp);
            var theNewProcessModel = await ProcessService.CreateNewProcess(theTestProcessModel);
            var theNewProcessId = theNewProcessModel.ProcessId;

            /******************************** make Revision 1 ********************************/

            var theStepSeqTestModelListForRev1 = new List<StepSeqModel>();

            for (int i = 0; i < theArbitraryNumStepsForRev1; i++)
            {
                var theTestStepModel = CreateTestStepModel((i + 1).ToString(), theNewProcessId, REV1ID);
                var theCreatedStepModel = await StepService.CreateStep(theTestStepModel);

                theArbitraryStepIdListForRev1.Add(theCreatedStepModel.StepId);

                //set test data
                theStepSeqTestModelListForRev1.Add(
                    new StepSeqModel()
                    {
                        StepId = theCreatedStepModel.StepId,
                        Sequence = Convert.ToInt16(i + 1),
                        ProcessId = theNewProcessId, //change?
                        RevisionId = REV1ID,
                        OperationId = theArbitraryRev1OprId
                    });
            }

            var theTestStepSeqModelList = new List<StepSeqModel>();
            for (int i = 0; i < theArbitraryStepIdListForRev1.Count; i++)
            {
                theTestStepSeqModelList.Add(
                    CreateTestStepSeqModel(theNewProcessId, REV1ID, theArbitraryStepIdListForRev1[i], theArbitraryRev1OprId, i + 1));
            }

            _ = await ProcessService.UpdateStepsForRev(theTestStepSeqModelList);
            //requery db with processID and return all revisions (but expecting 1)
            var theCreatedProcessRevision1 = (await ProcessService.GetHydratedProcess(theNewProcessId)).Revisions.ElementAt(0);

            //lock the rev and get a new Procees rev model to validate
            _ = await ProcessService.UpdateUnlockToLockRev(theCreatedProcessRevision1.ProcessId, theCreatedProcessRevision1.ProcessRevId);
            _ = await ProcessService.GetHydratedCurrentProcessRev(theNewProcessId);

            /******************************** make Revision 2 ********************************/
            var theBaselineProcessRevision2Model = CreateBaselineProcessRevisionModel(theNewProcessId, theArbitraryRev2EmpId, theTimeStamp);

            var theReturnedNewRevision2Model = await ProcessService.CreateNewRevForExistingProcess(theBaselineProcessRevision2Model);

            //*** create new step sequence based on old ***
            // 1. remove the first step
            // 2. insert 2 new step into the first location
            // 3. reverse order
            //*********************************************

            var theStepSeqTestModelListForRev2 = DeepCopyStepSeqModel(theStepSeqTestModelListForRev1);

            theStepSeqTestModelListForRev2.RemoveAt(0);
            var theReturnStepIdA = await StepService.CreateStep(CreateTestStepModel("a", theNewProcessId, REV2ID));
            var theReturnStepIdB = await StepService.CreateStep(CreateTestStepModel("b", theNewProcessId, REV2ID));

            theStepSeqTestModelListForRev2.Insert(0, new StepSeqModel()
            {
                StepId = theReturnStepIdA.StepId,
                ProcessId = theNewProcessId,
                OperationId = theArbitraryRev2OprId
            });
            theStepSeqTestModelListForRev2.Insert(1, new StepSeqModel()
            {
                StepId = theReturnStepIdB.StepId,
                ProcessId = theNewProcessId,
                OperationId = theArbitraryRev2OprId
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
                    CreateTestStepSeqModel(theNewProcessId, REV2ID, theNewArbitraryStepIdListForRev2[i],
                    theStepSeqTestModelListForRev2[i].OperationId, i + 1));
            }

            _ = await ProcessService.UpdateStepsForRev(theBaselineStepSeqModelListRev2);

            var theReturnProcessRevisionModelList = (await ProcessService.GetHydratedProcess(theNewProcessId)).Revisions;
            Assert.AreEqual(2, theReturnProcessRevisionModelList.Count());
            Assert.AreEqual(theNewArbitraryStepIdListForRev2.Count(), theReturnProcessRevisionModelList.ElementAt(1).StepSeqs.Count());

            // validate step sequences are as expected
            for (int i = 0; i < theStepSeqTestModelListForRev1.Count(); i++) //rev 1
            {
                Validate.ValidateModelCompleteness(
                    theStepSeqTestModelListForRev1[i], theReturnProcessRevisionModelList.ElementAt(REV1ID - 1).StepSeqs.ElementAt(i),
                    new List<object>() { "Step", "Operation" });
            }
            for (int i = 0; i < theStepSeqTestModelListForRev2.Count(); i++) //rev 2
            {
                Validate.ValidateModelCompleteness(
                    theStepSeqTestModelListForRev2[i], theReturnProcessRevisionModelList.ElementAt(REV2ID - 1).StepSeqs.ElementAt(i),
                    new List<object>() { "Step", "Operation" });
            }

            //LOCK and Validate
            var theReturnedLockedRevision2Model = await ProcessService.UpdateUnlockToLockRev(theReturnedNewRevision2Model.ProcessId, theReturnedNewRevision2Model.ProcessRevId);
            Assert.AreEqual(1, theReturnedLockedRevision2Model.RevStatusId); //1=locked
            ProcessRevisionModel theCurrProcessRevisionModelWithSteps = await ProcessService.GetHydratedCurrentProcessRev(theNewProcessId);
            Assert.AreEqual(1, theCurrProcessRevisionModelWithSteps.RevStatusId); //1=locked

            var theReturnProcessRevisionModelListPostLock = (await ProcessService.GetHydratedProcess(theNewProcessId)).Revisions;
            Assert.AreEqual(2, theReturnProcessRevisionModelListPostLock.Count());

            var theRevision1Data = theReturnProcessRevisionModelListPostLock.ElementAt(0);
            var theRevision2Data = theReturnProcessRevisionModelListPostLock.ElementAt(1);

            Assert.AreEqual(3, theRevision1Data.RevStatusId); //3=inactive
            Assert.AreEqual(1, theRevision2Data.RevStatusId); //1=locked

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
        private ProcessModel CreateTestProcessModel(short aEmpID, string aTimeStamp)
        {
            //creates Process AND ProcessRevision since a process should always have a revision
            var processRevModel = new ProcessRevisionModel()
            {
                CreatedByEmp = aEmpID,
                Comments = TEST_CODE + aTimeStamp
            };
            var processModel = new ProcessModel()
            {
                Name = TEST_CODE + aTimeStamp,
                Revisions = new List<ProcessRevisionModel>() { processRevModel }
            };
            return processModel;
        }

        private ProcessRevisionModel CreateBaselineProcessRevisionModel(int aProcessId, short aEmpId, string aTimeStamp)
        {
            var theTimeStamp = DateTime.Now.ToString("yyyy/MM/dd/hh:mm:ss:ffff");
            return new ProcessRevisionModel()
            {
                ProcessId = aProcessId,
                CreatedByEmp = aEmpId,
                Comments = TEST_CODE + aTimeStamp
            };
        }
        private StepModel CreateTestStepModel(string aSeqId, int aProcessId, int aRevId)
        {
            var theTimeStamp = DateTime.Now.ToString("yyyy/MM/dd/hh:mm:ss:ffff");

            return new StepModel()
            {
                StepCategory = new StepCategoryModel { Id = 4, Name = "None", Code = "NONE", Type = "Other" },
                Inactive = false,
                StepName = TEST_CODE + aSeqId + "-PId:" + aProcessId.ToString() + "-RevId:" + aRevId,
                SignOffIsRequired = true,
                Instructions = "Test data - (" + theTimeStamp + ")"
            };
        }
        private List<StepSeqModel> DeepCopyStepSeqModel(List<StepSeqModel> aStepSeqModelList)
        {
            var returnStepSeqModelList = new List<StepSeqModel>();

            foreach (StepSeqModel sseqMdl in aStepSeqModelList)
            {
                returnStepSeqModelList.Add(new StepSeqModel()
                {
                    StepId = sseqMdl.StepId,
                    Sequence = sseqMdl.Sequence,
                    ProcessId = sseqMdl.ProcessId,
                    RevisionId = sseqMdl.RevisionId,
                    OperationId = sseqMdl.OperationId
                });
            }

            return returnStepSeqModelList;
        }
        private StepSeqModel CreateTestStepSeqModel(int aProcessId, int aProcessRevId, int aStepId, int aOperationId, int aSequence)
        {
            return new StepSeqModel()
            {
                ProcessId = aProcessId,
                RevisionId = aProcessRevId,
                Sequence = Convert.ToInt16(aSequence),
                StepId = aStepId,
                OperationId = aOperationId
            };
        }
    }
}
