using Armis.BusinessModels.QualityModels.Process;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.Services.QualityServices;
using Armis.DataLogic.Services.QualityServices.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Armis.Test
{
    [TestClass]
    public class StepTests
    {
        private ARMISContext _context;
        private const string TESTPREFIX = "TEST-STEP";

        public ARMISContext Context
        {
            get
            {
                if (_context == null) { _context = new ARMISContext(); }
                return _context;
            }
            set { _context = value; }
        }


        private IStepService _stepService;

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
        public async Task CreateNewStepAndVerify()
        {
            var thePreAddStepList = await StepService.GetAll();
            thePreAddStepList.OrderBy(i => i.StepId);
            var thePreAddStepCount = thePreAddStepList.Count();
            var theExpectedStepID = (thePreAddStepList.ElementAt(thePreAddStepCount - 1).StepId) + 1; //calc EXPECTED step id to be created

            var theBaselineStepModel = CreateBaselineStepModel();
            _ = await StepService.CreateStep(theBaselineStepModel);

            var thePostAddStepCount = (await StepService.GetAll()).Count();

            var theReturnStep = await StepService.GetStepById(theExpectedStepID); //find it to prove it was created

            Assert.AreEqual(thePreAddStepCount + 1, thePostAddStepCount);
            Assert.AreEqual(theBaselineStepModel.StepName, theReturnStep.StepName);
        }

        private StepModel CreateBaselineStepModel()
        {
            var theTimeStamp = DateTime.Now.ToString("yyyyMMddhhmmss");
            return new StepModel()
            {
                StepCategory = new StepCategoryModel { Name = "None", Code = "NONE", Type = "Other" },
                Inactive = false,
                StepName = TESTPREFIX + "-Step-" + theTimeStamp,
                SignOffIsRequired = true,
                Instructions = "Test data - ignore - (" + theTimeStamp + ")"
            };
        }
    }
}