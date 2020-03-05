using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.Services.ProcessServices;
using Armis.DataLogic.Services.ProcessServices.Interfaces;
using Armis.DataLogic.Services.CustomerServices;
using Armis.DataLogic.Services.CustomerServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Armis.Test
{
    [TestClass]
    public class ProcessTests
    {
        private ARMISContext _context;
        private const string TESTPREFIX = "TEST-PROC";

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
        private ICustomerService _customerService;

        public IProcessService ProcessService
        {
            get 
            {
                if(_processService == null) { _processService = new ProcessService(Context); }
                return _processService; 
            }
            set { _processService = value; }
        }

        public ICustomerService CustomerService
        {
            get
            {
                if (_customerService == null) { _customerService = new CustomerService(Context); }
                return _customerService;
            }
            set { _customerService = value; }
        }

        [TestMethod]
        public async Task CheckProcessNameUniqueness()
        {
            var theGeneratedProcessModel = GenerateProcessModel();
            var thePostAddProcess = await ProcessService.CreateNewProcess(theGeneratedProcessModel);

            var theNewExistingProcessName = thePostAddProcess.Name;

            bool theNameIsUnique = await ProcessService.CheckIfNameIsUnique(theNewExistingProcessName);
            Assert.IsFalse(theNameIsUnique, "'" + theNewExistingProcessName + "' was expected to be NOT unique but this is the first instance of this name.");

            theNameIsUnique = await ProcessService.CheckIfNameIsUnique(theNewExistingProcessName + "x");
            Assert.IsTrue(theNameIsUnique, "'" + theNewExistingProcessName + "x' was expected to be unique but there is already a process name.");
        }

        [TestMethod]
        public async Task CreateNewProcessNoCust()
        {
            var thePreAddProcessList = await ProcessService.GetAllProcesses();

            var theGeneratedProcessModel = GenerateProcessModel();
            var thePostAddProcess = await ProcessService.CreateNewProcess(theGeneratedProcessModel);
            var thePostAddProcessList = await ProcessService.GetAllProcesses();

            Assert.AreEqual(thePostAddProcessList.Count(), thePreAddProcessList.Count() + 1);
            Assert.AreEqual(theGeneratedProcessModel.Name, thePostAddProcess.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateException))]
        public async Task CreateNewProcessWithBADCustID()
        {
            var thePreAddProcessList = await ProcessService.GetAllProcesses();

            var theCustomerList = await CustomerService.GetAllCustomers();

            //should throw exception (FK violation) since Customer ID doesn't exist
            var theNonExistCustID = theCustomerList.Count() + 1; //generate invalid CustID
            var theGeneratedProcessModel = GenerateProcessModel(theNonExistCustID);

            _ = await ProcessService.CreateNewProcess(theGeneratedProcessModel);

            var thePostAddProcessList = await ProcessService.GetAllProcesses();
            Assert.AreEqual(thePostAddProcessList.Count(), thePreAddProcessList.Count()); //should be equal since process failed to add non-existant customer
        }

        [TestMethod]
        public async Task CreateNewProcessWithValidCustomer()
        {
            var thePreAddProcessList = await ProcessService.GetAllProcesses();

            //_customerModel = await GenerateCustomerList();
            var theCustomerList = await CustomerService.GetAllCustomers();

            var theArbitraryCustID = 2389;
            var theCustIDExists = false;

            foreach(var theCustModel in theCustomerList)
            { 
                if(theCustModel.Id == theArbitraryCustID)
                { 
                    theCustIDExists = true;
                    break;
                }
            }
            Assert.IsTrue(theCustIDExists, "Cust ID: " + theArbitraryCustID.ToString() + " doesn't exist.");
            
            var theGeneratedProcessModelWithCust = GenerateProcessModel(theArbitraryCustID);

            var theReturnProcessModel = await ProcessService.CreateNewProcess(theGeneratedProcessModelWithCust);

            var thePostAddProcessList = await ProcessService.GetAllProcesses();

            Assert.AreEqual(theGeneratedProcessModelWithCust.Name, theReturnProcessModel.Name);
            Assert.AreEqual(theArbitraryCustID, theReturnProcessModel.CustId);
            Assert.AreEqual(thePostAddProcessList.Count(), thePreAddProcessList.Count() + 1);
        }

        [TestMethod]
        public async Task CreateNewRevOnNewProcessAndThenDeleteRev()
        {
            short theArbitraryEmpID = 941;

            var theGeneratedProcessModel = GenerateProcessModel();
            var thePostAddProcess = await ProcessService.CreateNewProcess(theGeneratedProcessModel);
            var theNewAddedProcessID = thePostAddProcess.ProcessId;

            var theGeneratedProcessRevisionModel = GenerateProcessRevisionModel(theNewAddedProcessID, theArbitraryEmpID);

            _ = await ProcessService.CreateNewRevForExistingProcess(theGeneratedProcessRevisionModel);

            var theReturnHydratedProcessModel = await ProcessService.GetHydratedProcess(theNewAddedProcessID);
            var theReturnedProcessRevisionModel = theReturnHydratedProcessModel.Revisions.ElementAt(0);

            Assert.AreEqual("UNLOCKED", theReturnedProcessRevisionModel.RevStatusCd);
            Assert.AreEqual(1, theReturnedProcessRevisionModel.ProcessRevId);
            Assert.AreEqual(theArbitraryEmpID, theReturnedProcessRevisionModel.CreatedByEmp);
            Assert.AreEqual(0, theReturnedProcessRevisionModel.StepSeqs.Count());

            await ProcessService.DeleteProcessRev(theNewAddedProcessID, 1); //delete process rev

            theReturnHydratedProcessModel = await ProcessService.GetHydratedProcess(theNewAddedProcessID);
            Assert.AreEqual(0, theReturnHydratedProcessModel.Revisions.Count());
        }

        private ProcessModel GenerateProcessModel()
        {
            var theTimeStamp = DateTime.Now.ToString("yyyyMMddhhmmss");
            return new ProcessModel() { Name = TESTPREFIX + "-Process-" + theTimeStamp };
        }
        private ProcessModel GenerateProcessModel(int aCustID)
        {
            var theTimeStamp = DateTime.Now.ToString("yyyyMMddhhmmss");
            return new ProcessModel() { Name = TESTPREFIX + "-Process-Cust-" + theTimeStamp, CustId = aCustID };
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
    }
}
