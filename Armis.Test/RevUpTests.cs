using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.Services.ProcessServices;
using Armis.DataLogic.Services.ProcessServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Armis.Test
{
    [TestClass]
    public class RevUpTests
    {
        private ARMISContext _context;
        private const string TESTPREFIX = "TEST-REVUP";
        private const string STEPPREFIX = "-Step-";

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
        public async Task CreateNewProcessRevStepsAndRevUp()
        {
            short theArbitraryEmpID = 941; //Ed Wakefield
            short theArbitraryOprID = 5;
            int theArbitraryNumSteps = 4;

            var theArbitraryStepIDList = new List<int>();

            var theGeneratedProcessModel = GenerateProcessModel();
            var theNewAddedProcessID = (await ProcessService.CreateNewProcess(theGeneratedProcessModel)).ProcessId;

            var theGeneratedProcessRevisionModel = GenerateProcessRevisionModel(theNewAddedProcessID, theArbitraryEmpID);

            _ = await ProcessService.CreateNewRevForExistingProcess(theGeneratedProcessRevisionModel); //TODO: test that return model validates

            var theReturnHydratedProcessModel = await ProcessService.GetHydratedProcess(theNewAddedProcessID);
            var theReturnedProcessRevisionID = theReturnHydratedProcessModel.Revisions.ElementAt(0).ProcessRevId;


            for (int i = 0; i < theArbitraryNumSteps; i++)
            {
                var theGeneratedStepModel = GenerateStepModel((i + 1).ToString(), theNewAddedProcessID, theReturnedProcessRevisionID);
                var theReturnStepID = await StepService.CreateStep(theGeneratedStepModel);

                theArbitraryStepIDList.Add(theReturnStepID);
            }

            var theGeneratedStepSeqModel = GenerateStepSeqModel(theNewAddedProcessID, theReturnedProcessRevisionID, theArbitraryStepIDList, theArbitraryOprID);

            //update steps but get return process rev model for validation purposes later
            var theReturnProcessRevisionModelToValidate = await ProcessService.UpdateStepsForRev(theGeneratedStepSeqModel);
            //requery db with processID and return all revisions (but expecting 1)
            var theReturnProcessRevisionModelList = (await ProcessService.GetHydratedProcess(theNewAddedProcessID)).Revisions;
            var theReturnProcessRevision = theReturnProcessRevisionModelList.ElementAt(0);

            //assert ProcessService.UpdateStepsForRev returned model correctly (not testing steps!)
            Assert.AreEqual(theReturnProcessRevision.Comments, theReturnProcessRevisionModelToValidate.Comments);
            Assert.AreEqual(theReturnProcessRevision.ProcessId, theReturnProcessRevisionModelToValidate.ProcessId);
            Assert.AreEqual(theReturnProcessRevision.RevStatusCd, theReturnProcessRevisionModelToValidate.RevStatusCd);
            Assert.AreEqual(theReturnProcessRevision.DateCreated, theReturnProcessRevisionModelToValidate.DateCreated);

            //extract steps from hydrated model from query
            var theReturnStepModelList = theReturnProcessRevision.Steps;

            //does the return revision have the correct number of steps that we tested with?
            Assert.AreEqual(theArbitraryNumSteps, theReturnStepModelList.Count());
            //check if Step Name is representative of where it was initialized
            string theStrToCheckStepName = TESTPREFIX + STEPPREFIX + "1";
            Assert.AreEqual(theStrToCheckStepName, theReturnStepModelList.ElementAt(0).StepName.Substring(0, theStrToCheckStepName.Length));

            //lock the rev and get a new Procees rev model to validate
            theReturnProcessRevisionModelToValidate = await ProcessService.UpdateUnlockToLockRev(theReturnProcessRevision.ProcessId, theReturnProcessRevision.ProcessRevId);
            var theCurrProcessRevisionModelWithSteps = await ProcessService.GetCurrentProcessRevWithSteps(theNewAddedProcessID);

            //assert ProcessService.UpdateUnlockToLockRev returned model correctly (not testing steps!)
            Assert.AreEqual(theCurrProcessRevisionModelWithSteps.Comments, theReturnProcessRevisionModelToValidate.Comments);
            Assert.AreEqual(theCurrProcessRevisionModelWithSteps.ProcessId, theReturnProcessRevisionModelToValidate.ProcessId);
            Assert.AreEqual(theCurrProcessRevisionModelWithSteps.RevStatusCd, theReturnProcessRevisionModelToValidate.RevStatusCd);
            Assert.AreEqual(theCurrProcessRevisionModelWithSteps.DateCreated, theReturnProcessRevisionModelToValidate.DateCreated);

            //validate the current rev is now locked, has the required steps, and first step name is still in right spot
            Assert.AreEqual("LOCKED", theCurrProcessRevisionModelWithSteps.RevStatusCd);
            Assert.AreEqual(theArbitraryNumSteps, theCurrProcessRevisionModelWithSteps.Steps.Count());
            Assert.AreEqual(theStrToCheckStepName, theCurrProcessRevisionModelWithSteps.Steps.ElementAt(0).StepName.Substring(0, theStrToCheckStepName.Length));

        }
        [TestMethod]
        public async Task CreateNewLockedRevAndRevUpWithDiffStepSeq()
        {
            short theArbitraryRev1EmpID = 941; //Ed Wakefield
            short theArbitraryRev2EmpID = 991; //Ben Johnson

            short theArbitraryRev1OprID = 5;
            short theArbitraryRev2OprID = 1;

            int theArbitraryNumStepsForRev1 = 4;

            var theArbitraryStepIDListForRev1 = new List<int>();

            var theGeneratedProcessModel = GenerateProcessModel();
            var theNewProcessID = (await ProcessService.CreateNewProcess(theGeneratedProcessModel)).ProcessId;

            /******************************** make Revision 1 ********************************/
            var theGeneratedProcessRevision1Model = GenerateProcessRevisionModel(theNewProcessID, theArbitraryRev1EmpID);

            _ = await ProcessService.CreateNewRevForExistingProcess(theGeneratedProcessRevision1Model); //TODO: test that return model validates

            var theReturnHydratedProcessModel = await ProcessService.GetHydratedProcess(theNewProcessID);
            var theReturnedProcessRevision1ID = theReturnHydratedProcessModel.Revisions.ElementAt(0).ProcessRevId; //change this index 0

            for (int i = 0; i < theArbitraryNumStepsForRev1; i++)
            {
                var theGeneratedStepModel = GenerateStepModel((i + 1).ToString(), theNewProcessID, theReturnedProcessRevision1ID);
                var theReturnStepID = await StepService.CreateStep(theGeneratedStepModel);

                theArbitraryStepIDListForRev1.Add(theReturnStepID);
            }

            var theGeneratedStepSeqModel = GenerateStepSeqModel(theNewProcessID, theReturnedProcessRevision1ID, theArbitraryStepIDListForRev1, theArbitraryRev1OprID);

            _ = await ProcessService.UpdateStepsForRev(theGeneratedStepSeqModel);
            //requery db with processID and return all revisions (but expecting 1)
            var theReturnProcessRevision1 = (await ProcessService.GetHydratedProcess(theNewProcessID)).Revisions.ElementAt(0);

            //lock the rev and get a new Procees rev model to validate
            _ = await ProcessService.UpdateUnlockToLockRev(theReturnProcessRevision1.ProcessId, theReturnProcessRevision1.ProcessRevId);
            _ = await ProcessService.GetCurrentProcessRevWithSteps(theNewProcessID);

            /******************************** make Revision 2 ********************************/
            var theGeneratedProcessRevision2Model = GenerateProcessRevisionModel(theNewProcessID, theArbitraryRev2EmpID);
            
            var theReturnedNewRevision2Model = await ProcessService.CreateNewRevForExistingProcess(theGeneratedProcessRevision2Model);
            var theRev2ID = theReturnedNewRevision2Model.ProcessRevId;

            //*** create new step sequence based on old ***
            // 1. remove the first step
            // 2. insert 2 new step into the first location
            // 3. reverse order
            //*********************************************

            var theNewArbitraryStepIDListForRev2 = theArbitraryStepIDListForRev1.ToList();
            theNewArbitraryStepIDListForRev2.RemoveAt(0);
            var theReturnStepIDA = await StepService.CreateStep(GenerateStepModel("a", theNewProcessID, theRev2ID));
            var theReturnStepIDB = await StepService.CreateStep(GenerateStepModel("b", theNewProcessID, theRev2ID));
            theNewArbitraryStepIDListForRev2.Insert(0, theReturnStepIDA);
            theNewArbitraryStepIDListForRev2.Insert(1, theReturnStepIDB);
            theNewArbitraryStepIDListForRev2.Reverse();

            // TODO: Fix OPERATION ID copying
            theGeneratedStepSeqModel = GenerateStepSeqModel(theNewProcessID, theRev2ID, theNewArbitraryStepIDListForRev2, theArbitraryRev2OprID); //TODO: Fix overriding operationID

            var theReturnProcessRevision2ModelToValidate = await ProcessService.UpdateStepsForRev(theGeneratedStepSeqModel);

            var theReturnProcessRevisionModelList = (await ProcessService.GetHydratedProcess(theNewProcessID)).Revisions;
            Assert.AreEqual(2, theReturnProcessRevisionModelList.Count());
            Assert.AreEqual(theNewArbitraryStepIDListForRev2.Count(), theReturnProcessRevisionModelList.ElementAt(1).Steps.Count());

            // validate step sequences are as expected
            for (int i = 0; i < theArbitraryStepIDListForRev1.Count(); i++) //rev 1
            {
                Assert.AreEqual(theArbitraryStepIDListForRev1[i], theReturnProcessRevisionModelList.ElementAt(0).Steps.ElementAt(i).StepId);
            }
            for (int i = 0; i < theNewArbitraryStepIDListForRev2.Count(); i++) //rev 2
            {
                Assert.AreEqual(theNewArbitraryStepIDListForRev2[i], theReturnProcessRevisionModelList.ElementAt(1).Steps.ElementAt(i).StepId);
            }

            //LOCK and Validate
            var theReturnedLockedRevision2Model = await ProcessService.UpdateUnlockToLockRev(theReturnedNewRevision2Model.ProcessId, theReturnedNewRevision2Model.ProcessRevId);
            Assert.AreEqual("LOCKED", theReturnedLockedRevision2Model.RevStatusCd);
            ProcessRevisionModel theCurrProcessRevisionModelWithSteps = await ProcessService.GetCurrentProcessRevWithSteps(theNewProcessID);
            Assert.AreEqual("LOCKED", theCurrProcessRevisionModelWithSteps.RevStatusCd);

            var theReturnProcessRevisionModelListPostLock = (await ProcessService.GetHydratedProcess(theNewProcessID)).Revisions;
            Assert.AreEqual(2, theReturnProcessRevisionModelListPostLock.Count());

            var theRevision1Data = theReturnProcessRevisionModelListPostLock.ElementAt(0);
            var theRevision2Data = theReturnProcessRevisionModelListPostLock.ElementAt(1);

            Assert.AreEqual("INACTIVE", theRevision1Data.RevStatusCd);
            Assert.AreEqual("LOCKED", theRevision2Data.RevStatusCd);

            // validate step sequences are as expected POST-LOCK
            for (int i = 0; i < theArbitraryStepIDListForRev1.Count(); i++) //rev 1
            {
                Assert.AreEqual(theArbitraryStepIDListForRev1[i], theRevision1Data.Steps.ElementAt(i).StepId);
            }
            for (int i = 0; i < theNewArbitraryStepIDListForRev2.Count(); i++) //rev 2
            {
                Assert.AreEqual(theNewArbitraryStepIDListForRev2[i], theRevision2Data.Steps.ElementAt(i).StepId);
            }

        }
        private ProcessModel GenerateProcessModel()
        {
            var theTimeStamp = DateTime.Now.ToString("yyyyMMddhhmmss");
            return new ProcessModel() { Name = TESTPREFIX + "-Process-" + theTimeStamp };
        }
        private ProcessRevisionModel GenerateProcessRevisionModel(int aProcessID, short aEmpID)
        {
            var theTimeStamp = DateTime.Now.ToString("yyyyMMddhhmmssffff");
            return new ProcessRevisionModel()
            {
                ProcessId = aProcessID,
                CreatedByEmp = aEmpID,
                Comments = TESTPREFIX + "-comment-" + theTimeStamp + "-PID: " + aProcessID.ToString()
            };
        }
        private StepModel GenerateStepModel(string aSeqID, int aProcessID, int aRevID)
        {
            var theTimeStamp = DateTime.Now.ToString("yyyyMMddhhmmssffff");

            return new StepModel()
            {
                StepCategoryCd = "NONE",
                Inactive = false,
                StepName = TESTPREFIX + STEPPREFIX + aSeqID + "-PID:" + aProcessID.ToString() + "-RevID:" + aRevID,
                SignOffIsRequired = true,
                Instructions = "Test data - ignore - (" + theTimeStamp + ")"
            };
        }

        private IEnumerable<StepSeqModel> GenerateStepSeqModel(int aProcessID, int aProcessRevID, List<int> aStepIDList, int aOperationID)
        {
            var theStepSeqModel = new List<StepSeqModel>();
            //foreach (var stepID in aStepIDList)
            for (int i = 0; i < aStepIDList.Count(); i++)
            {
                theStepSeqModel.Add(
                    new StepSeqModel()
                    {
                        ProcessId = aProcessID,
                        RevisionId = aProcessRevID,
                        Sequence = Convert.ToInt16(i + 1),
                        StepId = aStepIDList[i],
                        OperationId = aOperationID
                    });
            }
            return theStepSeqModel;
        }
    }
}
