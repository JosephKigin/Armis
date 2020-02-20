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
        public async Task CreateStepsOnNewRevOnNewProcess()
        {
            short theArbitraryEmpID = 941;
            short theArbitraryOprID = 5;
            int theArbitraryNumSteps = 4;
            var theArbitraryStepIDList = new List<int>();

            var theGeneratedProcessModel = GenerateProcessModel();
            var theNewAddedProcessID = (await ProcessService.CreateNewProcess(theGeneratedProcessModel)).ProcessId;

            var theGeneratedProcessRevisionModel = GenerateProcessRevisionModel(theNewAddedProcessID, theArbitraryEmpID);

            _ = await ProcessService.CreateNewRevForExistingProcess(theGeneratedProcessRevisionModel);

            var theReturnHydratedProcessModel = await ProcessService.GetHydratedProcess(theNewAddedProcessID);
            //var theReturnedProcessRevisionModel = theReturnHydratedProcessModel.Revisions.ElementAt(0);
            var theReturnedProcessRevisionID = theReturnHydratedProcessModel.Revisions.ElementAt(0).ProcessRevId;


            for (int i = 0; i < theArbitraryNumSteps; i++)
            {
                var theGeneratedStepModel = GenerateStepModel(i + 1);
                var theReturnStepModel = await StepService.CreateStep(theGeneratedStepModel);

                theArbitraryStepIDList.Add(theReturnStepModel);
            }

            var theGeneratedStepSeqModel = GenerateStepSeqModel(theNewAddedProcessID, theReturnedProcessRevisionID, theArbitraryStepIDList, theArbitraryOprID);

            var theReturnUpdatedProcessRevisionModel = ProcessService.UpdateStepsForRev(theGeneratedStepSeqModel);

            //Assert.AreEqual("UNLOCKED", theReturnedProcessRevisionModel.RevStatusCd);
            //Assert.AreEqual(1, theReturnedProcessRevisionModel.ProcessRevId);
            //Assert.AreEqual(theArbitraryEmpID, theReturnedProcessRevisionModel.CreatedByEmp);
            //Assert.AreEqual(0, theReturnedProcessRevisionModel.Steps.Count());

            //await ProcessService.DeleteProcessRev(theNewAddedProcessID, 1); //delete process rev

            //theReturnHydratedProcessModel = await ProcessService.GetHydratedProcess(theNewAddedProcessID);
            //Assert.AreEqual(0, theReturnHydratedProcessModel.Revisions.Count());
        }
        private ProcessModel GenerateProcessModel()
        {
            var theTimeStamp = DateTime.Now.ToString("yyyyMMddhhmmss");
            return new ProcessModel() { Name = TESTPREFIX + "-Process-" + theTimeStamp };
        }
        private ProcessRevisionModel GenerateProcessRevisionModel(int aProcessID, short aEmpID)
        {
            var theTimeStamp = DateTime.Now.ToString("yyyyMMddhhmmss");
            return new ProcessRevisionModel()
            {
                ProcessId = aProcessID,
                CreatedByEmp = aEmpID,
                Comments = TESTPREFIX + "-comment-" + theTimeStamp
            };
        }
        private StepModel GenerateStepModel(int aID)
        {
            var theTimeStamp = DateTime.Now.ToString("yyyyMMddhhmmss");
            return new StepModel()
            {
                StepCategoryCd = "NONE",
                Inactive = false,
                StepName = TESTPREFIX + "-Step-" + aID.ToString() + "-" + theTimeStamp,
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
