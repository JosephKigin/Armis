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

        public IProcessService ProcessService
        {
            get 
            {
                if(_processService == null) { _processService = new ProcessService(Context); }
                return _processService; 
            }
            set { _processService = value; }
        }

        [TestMethod]
        public async Task CheckProcessNameUniqueness()
        {
            var theBaselineProcessModel = CreateBaselineProcessModel();
            var thePostAddProcess = await ProcessService.CreateNewProcess(theBaselineProcessModel);

            var theNewExistingProcessName = thePostAddProcess.Name;

            bool theNameIsUnique = await ProcessService.CheckIfNameIsUnique(theNewExistingProcessName);
            Assert.IsFalse(theNameIsUnique, "'" + theNewExistingProcessName + "' was expected to be NOT unique but this is the first instance of this name.");

            theNameIsUnique = await ProcessService.CheckIfNameIsUnique(theNewExistingProcessName + "x");
            Assert.IsTrue(theNameIsUnique, "'" + theNewExistingProcessName + "x' was expected to be unique but there is already a process name.");
        }

        [TestMethod]
        public async Task CreateNewProcess()
        {
            var thePreAddProcessList = await ProcessService.GetAllProcesses();
            var calcNewMaxProcessId = thePreAddProcessList.Max(i => i.ProcessId) + 1;

            var theBaselineProcessModel = CreateBaselineProcessModel();
            var thePostAddProcess = await ProcessService.CreateNewProcess(theBaselineProcessModel);

            theBaselineProcessModel.ProcessId = calcNewMaxProcessId;

            var thePostAddProcessList = await ProcessService.GetAllProcesses();

            Assert.AreEqual(thePostAddProcessList.Count(), thePreAddProcessList.Count() + 1);

            Validate.ValidateModelCompleteness(theBaselineProcessModel, thePostAddProcess);
        }

        [TestMethod]
        public async Task CreateNewRevOnNewProcessAndThenDeleteRev()
        {
            short theArbitraryEmpId = 941;

            var theBaselineProcessModel = CreateBaselineProcessModel();

            var thePostAddProcess = await ProcessService.CreateNewProcess(theBaselineProcessModel);
            var theNewAddedProcessId = thePostAddProcess.ProcessId;

            var theBaselineProcessRevisionModel = CreateBaselineProcessRevisionModel(theNewAddedProcessId, theArbitraryEmpId);

            _ = await ProcessService.CreateNewRevForExistingProcess(theBaselineProcessRevisionModel);

            theBaselineProcessRevisionModel.ProcessRevId = 1; //for test
            theBaselineProcessRevisionModel.RevStatusId = 2; //2=unlocked

            var theReturnHydratedProcessModel = await ProcessService.GetHydratedProcess(theNewAddedProcessId);
            var theReturnedProcessRevisionModel = theReturnHydratedProcessModel.Revisions.ElementAt(0);


            Validate.ValidateModelCompleteness(theBaselineProcessRevisionModel, theReturnedProcessRevisionModel,
                new List<Object>() { "DateTimeCreated", "StepSeqs" }); //TODO: Remove exclusions and Test!

            Assert.AreEqual(0, theReturnedProcessRevisionModel.StepSeqs.Count());

            await ProcessService.DeleteProcessRev(theNewAddedProcessId, 1); //delete process rev

            theReturnHydratedProcessModel = await ProcessService.GetHydratedProcess(theNewAddedProcessId);
            Assert.AreEqual(0, theReturnHydratedProcessModel.Revisions.Count());
        }

        [TestMethod]
        private async Task ValidateProcessRevisionStatusCodes()
        {
            //TODO!!!
        }

        private ProcessModel CreateBaselineProcessModel()
        {
            var theTimeStamp = DateTime.Now.ToString("yyyy/MM/dd/hh:mm:ss");
            return new ProcessModel() { Name = TEST_CODE + theTimeStamp };
        }

        private ProcessRevisionModel CreateBaselineProcessRevisionModel(int aProcessID, short aEmpID)
        {
            var theTimeStamp = DateTime.Now.ToString("yyyy/MM/dd/hh:mm:ss");
            return new ProcessRevisionModel()
            {
                ProcessId = aProcessID,
                CreatedByEmp = aEmpID,
                Comments = TEST_CODE + theTimeStamp
            };
        }
    }
}
