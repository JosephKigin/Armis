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

        //private async Task GenerateCustomerList()
        //{
        //    //if(_customerModel)
        //    //_customerModel = await CustomerService.GetAllCustomers();
        //
        //    if (_customerModel == null) { _customerModel = await CustomerService.GetAllCustomers(); }
        //
        //    return _customerModel;
        //
        //}

        //[TestMethod]
        //public async Task PostAProcess()
        //{
        //    //var aProcessRev = new ProcessRevision()
        //    //{
        //    //    ProcessId = 10000,
        //    //    ProcessRevId = 1,
        //    //    CreatedByEmp = 1,
        //    //    DateCreated = DateTime.Now.Date,
        //    //    TimeCreated = DateTime.Now.TimeOfDay,
        //    //    RevStatusCd = "INACTIVE",
        //    //    DueDays = 3,
        //    //    Notes = "This is test data.  Do not run this process."
        //    //};

        //    //var a2ProcessRev = new ProcessRevision()
        //    //{
        //    //    ProcessId = 10000,
        //    //    ProcessRevId = 2,
        //    //    CreatedByEmp = 1,
        //    //    DateCreated = DateTime.Now.Date,
        //    //    TimeCreated = DateTime.Now.TimeOfDay,
        //    //    RevStatusCd = "LOCKED",
        //    //    DueDays = 3,
        //    //    Notes = "This is test data again.  Do not run this process."
        //    //};

        //    //var aProcess = new Process
        //    //{
        //    //    ProcessId = 10000,
        //    //    Name = "TEST-1"
        //    //};

        //    //var aProcessSubOpSeq = new ProcessSubOprSeq()
        //    //{
        //    //    ProcessId = 10000,
        //    //    ProcessRevId = 2,
        //    //    SubOpSeq = 1,
        //    //    SubOpId = 5,
        //    //    SubOpRevId = 2,
        //    //    OperationSeq = 0,
        //    //    OperationId = 22
        //    //};

        //    //var a2ProcessSubOpSeq = new ProcessSubOprSeq()
        //    //{
        //    //    ProcessId = 10000,
        //    //    ProcessRevId = 2,
        //    //    SubOpSeq = 2,
        //    //    SubOpId = 2,
        //    //    SubOpRevId = 1,
        //    //    OperationSeq = 0,
        //    //    OperationId = 58
        //    //};

        //    //var a3ProcessSubOpSeq = new ProcessSubOprSeq()
        //    //{
        //    //    ProcessId = 10000,
        //    //    ProcessRevId = 2,
        //    //    SubOpSeq = 3,RT
        //    //    SubOpId = 2,
        //    //    SubOpRevId = 1,
        //    //    OperationSeq = 0,
        //    //    OperationId = 22
        //    //};

        //    var processEntities = await ProcessService.GetCompleteProcess(10000, 2);

        //    Assert.IsNotNull(processEntities);
        //}

        //[TestMethod]
        //public void TESTForeach()
        //{
        //    var testList = new List<string>();
        //
        //    for (int i = 0; i < 1000000; i++)
        //    {
        //        testList.Add("Hello! ~ " + i);
        //    }
        //
        //    //testList.ForEach(i => Console.WriteLine(i));
        //
        //    foreach (var test in testList) { Console.WriteLine(test); }
        //}

        //public class FakeStartup : Startup
        //{
        //    public FakeStartup(IConfiguration configuration) : base(configuration)
        //    {
        //    }
        // 
        //    public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //    {
        //        base.Configure(app, env);
        // 
        //        var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
        //        using (var serviceScope = serviceScopeFactory.CreateScope())
        //        {
        //            var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
        // 
        //            if (dbContext.Database.GetDbConnection().ConnectionString.ToLower().Contains("database.windows.net"))
        //            {
        //                throw new Exception("LIVE SETTINGS IN TESTS!");
        //            }
        // 
        //            // Initialize database
        //        }
        //    }
        //}
    }
}
