using Armis.Data.DatabaseContext;
using Armis.Data.DatabaseContext.Entities;
using Armis.Services.ProcessServices;
using Armis.Services.ProcessServices.Interfaces;
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
        public async Task PostAProcess()
        {
            //var aProcessRev = new ProcessRevision()
            //{
            //    ProcessId = 10000,
            //    ProcessRevId = 1,
            //    CreatedByEmp = 1,
            //    DateCreated = DateTime.Now.Date,
            //    TimeCreated = DateTime.Now.TimeOfDay,
            //    RevStatusCd = "INACTIVE",
            //    DueDays = 3,
            //    Notes = "This is test data.  Do not run this process."
            //};

            //var a2ProcessRev = new ProcessRevision()
            //{
            //    ProcessId = 10000,
            //    ProcessRevId = 2,
            //    CreatedByEmp = 1,
            //    DateCreated = DateTime.Now.Date,
            //    TimeCreated = DateTime.Now.TimeOfDay,
            //    RevStatusCd = "LOCKED",
            //    DueDays = 3,
            //    Notes = "This is test data again.  Do not run this process."
            //};

            //var aProcess = new Process
            //{
            //    ProcessId = 10000,
            //    Name = "TEST-1"
            //};

            //var aProcessSubOpSeq = new ProcessSubOprSeq()
            //{
            //    ProcessId = 10000,
            //    ProcessRevId = 2,
            //    SubOpSeq = 1,
            //    SubOpId = 5,
            //    SubOpRevId = 2,
            //    OperationSeq = 0,
            //    OperationId = 22
            //};

            //var a2ProcessSubOpSeq = new ProcessSubOprSeq()
            //{
            //    ProcessId = 10000,
            //    ProcessRevId = 2,
            //    SubOpSeq = 2,
            //    SubOpId = 2,
            //    SubOpRevId = 1,
            //    OperationSeq = 0,
            //    OperationId = 58
            //};

            //var a3ProcessSubOpSeq = new ProcessSubOprSeq()
            //{
            //    ProcessId = 10000,
            //    ProcessRevId = 2,
            //    SubOpSeq = 3,RT
            //    SubOpId = 2,
            //    SubOpRevId = 1,
            //    OperationSeq = 0,
            //    OperationId = 22
            //};

            var processEntities = await ProcessService.GetCompleteProcess(10000, 2);

            Assert.IsNotNull(processEntities);
        }
    }
}
