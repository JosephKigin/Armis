using Armis.BusinessModels.ProcessModels;
using Armis.BusinessModels.Customer;
using Armis.Data.DatabaseContext;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.Services.ProcessServices;
using Armis.DataLogic.Services.ProcessServices.Interfaces;
using Armis.DataLogic.Services.CustomerServices;
using Armis.DataLogic.Services.CustomerServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
//using Armis.Api;
//using Microsoft.Extensions.Configuration;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Logging;

namespace Armis.Test
{
    [TestClass]
    public class ProcessTests
    {
        private ARMISContext _context;
        private const string TESTPREFIX = "ARMISTEST";
        //private ProcessModel _testProcessNoCustomer;
        //private ProcessModel _testProcessWithCustomer;
        //private IEnumerable<CustomerModel> _customerModel;

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
        public async Task CreateNewProcessNoCust()
        {
            var theProcessModel = GenerateProcessModel();
            var returnData = await ProcessService.CreateNewProcess(theProcessModel);
            Assert.AreEqual(theProcessModel.Name, returnData.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateException))]
        public async Task CreateNewProcessWithBADCustID()
        {
            var theCustomerList = await CustomerService.GetAllCustomers();

            //should throw exception (FK violation) since Customer ID doesn't exist
            var theNonExistCustID = theCustomerList.Count() + 1;
            var theProcessModel = GenerateProcessModel(theNonExistCustID);

            _ = await ProcessService.CreateNewProcess(theProcessModel);
        }

        [TestMethod]
        public async Task CreateNewProcessWithValidCustomer()
        {
            //_customerModel = await GenerateCustomerList();
            var theCustomerList = await CustomerService.GetAllCustomers();

            var theCustID = 2389;
            var theCustIDExists = false;

            foreach(var theCustModel in theCustomerList)
            { 
                if(theCustModel.Id == theCustID)
                { 
                    theCustIDExists = true;
                    break;
                }
            }
            Assert.IsTrue(theCustIDExists, "Cust ID: " + theCustID.ToString() + " doesn't exist.");
            
            var theProcessModelWithCust = GenerateProcessModel(theCustID);

            var returnData = await ProcessService.CreateNewProcess(theProcessModelWithCust);

            Assert.AreEqual(theProcessModelWithCust.Name, returnData.Name);
            Assert.AreEqual(theCustID, returnData.CustId);

        }
        private ProcessModel GenerateProcessModel()
        {
            var theTimeStamp = DateTime.Now.ToString("yyyyMMddhhmmss");
            return new ProcessModel() { Name = TESTPREFIX + "-Process-NoC-" + theTimeStamp };
        }
        private ProcessModel GenerateProcessModel(int aCustID)
        {
            var theTimeStamp = DateTime.Now.ToString("yyyyMMddhhmmss");
            return new ProcessModel() { Name = TESTPREFIX + "-Process-Cust-" + theTimeStamp, CustId = aCustID };
        }

    }
}
