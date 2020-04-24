using Armis.Data.DatabaseContext;
using Armis.DataLogic.Services.QualityServices;
using Armis.DataLogic.Services.QualityServices.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.QualityModels.Spec;
using System.Collections.Generic;

namespace Armis.Test
{
    [TestClass]
    public class SpecificationTests
    {
        private ARMISContext _context;
        private const string TEST_CODE = "[TEST]Spec";

        private ISpecService _specService;

        public ARMISContext Context
        {
            get
            {
                if (_context == null) { _context = new ARMISContext(); }
                return _context;
            }
            set { _context = value; }
        }

        public ISpecService SpecService
        {
            get
            {
                if (_specService == null) { _specService = new SpecService(Context); }
                return _specService;
            }
            set { _specService = value; }
        }

        private SpecModel CreateBaselineSpecModel(string aExtRev, short aEmpId, int aSamplePlan, int numSubLevels, int numChoicesPerSub)
        {
            //Spec needs a revision even though the DB will allow a spec without a rev
            //SpecRev needs a sublevel even though the DB will allow a specrev without a sublevel

            var theTimeStamp = DateTime.Now.ToString("hh:mm:ss:ffff");

            var theSpecSubLevelList = new List<SpecSubLevelModel>() { };

            for (int i = 0; i < numSubLevels; i++)
            {
                bool isReqTestFlag = false;
                bool isDefaultChoiceSubLevel = false;

                if (((i + 1) % 2) == 0) { isReqTestFlag = true; } //make sublevel required if level is 'even'
                if (((i + 1) % 2) != 0) { isDefaultChoiceSubLevel = true; } //make sublevel have a default choice if level is 'odd'

                theSpecSubLevelList.Add(new SpecSubLevelModel()
                {
                    Name = "level " + (i + 1).ToString(),
                    IsRequired = isReqTestFlag,
                    LevelSeq = Convert.ToByte(i + 1)
                });
                if (isDefaultChoiceSubLevel) { theSpecSubLevelList.ElementAt(i).DefaultChoice = Convert.ToByte(numSubLevels); } //set the default choice to the last choice for that sublevel

                var theSpecSubChoiceList = new List<SpecSubLevelChoiceModel>() { };
                for (int j = 0; j < numChoicesPerSub; j++)
                {

                    theSpecSubChoiceList.Add(new SpecSubLevelChoiceModel()
                    {
                        ChoiceSeq = Convert.ToByte(j + 1),
                        Name = "choice " + (i + 1).ToString() + " - " + (j + 1).ToString()
                    });
                }
                theSpecSubLevelList.ElementAt(i).Choices = theSpecSubChoiceList;
            }

            return new SpecModel()
            {
                Code = (TEST_CODE + theTimeStamp).Substring(0, 20), //varchar(20)
                SpecRevModels = new List<SpecRevModel>()
                {
                    new SpecRevModel()
                    {
                        Description = DateTime.Now.ToString("yyyy/MM/dd/hh:mm:ss:ffff") + " - This is a test. Rev: " + aExtRev,
                        ExternalRev = aExtRev,
                        EmployeeNumber = aEmpId,
                        DateModified = DateTime.Now,
                        SubLevels = theSpecSubLevelList
                    }
                }
            };
        }

        [TestMethod]
        public async Task CreateNewSpecification()
        {
            short theEmpID = 991; //Ben Johnson
            string theExtRevId = "A";
            int samplePlanID = 1;

            var thePreAddSpecList = await SpecService.GetAllHydratedSpecs();
            var calcNewMaxSpecId = thePreAddSpecList.Max(i => i.Id) + 1;

            var theBaselineSpecModel = CreateBaselineSpecModel(theExtRevId, theEmpID, samplePlanID, 0, 0);
            var theCreatedSpecId = await SpecService.CreateNewSpec(theBaselineSpecModel);
            var theCreatedSpecModel = await SpecService.GetHydratedCurrentRevForSpec(theCreatedSpecId);

            theBaselineSpecModel.Id = calcNewMaxSpecId;
            theBaselineSpecModel.SpecRevModels.ElementAt(0).SpecId = calcNewMaxSpecId;
            theBaselineSpecModel.SpecRevModels.ElementAt(0).InternalRev = 10;

            //total spec count increased by 1
            //Assert.AreEqual(thePostAddSpecList.Count(), thePreAddSpecList.Count() + 1); //TODO - FIX ME

            Validate.ValidateModelCompleteness(theBaselineSpecModel, theCreatedSpecModel, new List<Object>() { "SpecRevModels" });
            Validate.ValidateModelCompleteness(theBaselineSpecModel.SpecRevModels.ElementAt(0), theCreatedSpecModel.SpecRevModels.ElementAt(0),
                new List<Object>() { "DateModified", "TimeModified", "SubLevels" }); //TODO: Remove exclusions and Test!
        }
        
        [TestMethod]
        public async Task CreateNewSpecificationWithSubLevelChoices()
        {
            short theEmpID = 991; //Ben Johnson
            string theExtRevId = "AA";
            int samplePlanID = 1;
            int numSublevels = 6;
            int numSubChoices = 6;

            var thePreAddSpecList = await SpecService.GetAllHydratedSpecs();

            var theBaselineSpecModel = CreateBaselineSpecModel(theExtRevId, theEmpID, samplePlanID, numSublevels, numSubChoices);
            int theCreatedSpecId = await SpecService.CreateNewSpec(theBaselineSpecModel);
            var theCreatedSpecModel = await SpecService.GetHydratedCurrentRevForSpec(theCreatedSpecId);

            //only 1 rev created
            var theCreatedSpecSubLevelModels = theCreatedSpecModel.SpecRevModels.ElementAt(0).SubLevels;
            var theBaselineSpecSubLevelModels = theBaselineSpecModel.SpecRevModels.ElementAt(0).SubLevels;


            for (int i = 0; i < numSublevels; i++)
            {
                Validate.ValidateModelCompleteness(theBaselineSpecSubLevelModels.ElementAt(i), theCreatedSpecSubLevelModels.ElementAt(i),
                    new List<Object>() { "Choices" }); //TODO: Remove exclusions and Test!

                var theCreatedSpecChoiceList = theCreatedSpecSubLevelModels.ElementAt(i).Choices;
                var theBaselineSpecChoiceList = theBaselineSpecSubLevelModels.ElementAt(i).Choices;

                for (int j = 0; j < numSubChoices; j++)
                {
                    Validate.ValidateModelCompleteness(theBaselineSpecChoiceList.ElementAt(j), theCreatedSpecChoiceList.ElementAt(j),
                        new List<Object>() { }); //TODO: Remove exclusions and Test!
                }
            }
        }

        [TestMethod]
        private async Task RevUpASpecification()
        {
            short theEmpID = 991; //Ben Johnson
            string theExtRevId = "X";
            int samplePlanId = 1;
            int numSublevels = 2;
            int numSubChoices = 3;

            var thePreAddSpecList = await SpecService.GetAllHydratedSpecs();

            var theBaselineSpecModel = CreateBaselineSpecModel(theExtRevId, theEmpID, samplePlanId, numSublevels, numSubChoices);
            int theCreatedSpecId = await SpecService.CreateNewSpec(theBaselineSpecModel);
            var theCreatedSpecModel = await SpecService.GetHydratedCurrentRevForSpec(theCreatedSpecId);
            ////END SET UP////

            int theRevUpSpecId = await SpecService.RevUpSpec(theCreatedSpecModel.SpecRevModels.ElementAt(0));
            var theRevUpSpecModel = await SpecService.GetHydratedCurrentRevForSpec(theRevUpSpecId);


        }
    }
}
