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

        private SpecModel CreateBaselineSpecModel(string aExtRev, string aDescPrefix, short aEmpId, int aSamplePlan, int numSubLevels, int numChoicesPerSub)
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
                        Description = DateTime.Now.ToString("yyyy/MM/dd") + aDescPrefix + aExtRev,
                        SamplePlanId = aSamplePlan,
                        ExternalRev = aExtRev,
                        EmployeeNumber = aEmpId,
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
            int samplePlanId = 1;
            string descPrefix = " - This is a test. Rev: ";

            var thePreAddSpecList = await SpecService.GetAllHydratedSpecs();
            var calcNewMaxSpecId = thePreAddSpecList.Max(i => i.Id) + 1;

            var theBaselineSpecModel = CreateBaselineSpecModel(theExtRevId, descPrefix, theEmpID, samplePlanId, 0, 0);
            var theCreatedSpecId = await SpecService.CreateNewSpec(theBaselineSpecModel);
            var theCreatedSpecModel = await SpecService.GetHydratedCurrentRevForSpec(theCreatedSpecId);

            ///set test values
            theBaselineSpecModel.Id = calcNewMaxSpecId;
            theBaselineSpecModel.SpecRevModels.ElementAt(0).DateCreated = DateTime.Now.Date;
            theBaselineSpecModel.SpecRevModels.ElementAt(0).TimeCreated = DateTime.Now.TimeOfDay;
            theBaselineSpecModel.SpecRevModels.ElementAt(0).SpecId = calcNewMaxSpecId;
            theBaselineSpecModel.SpecRevModels.ElementAt(0).InternalRev = 10;
            theBaselineSpecModel.SpecRevModels.ElementAt(0).Description = DateTime.Now.Date.ToString("yyyy/MM/dd") + descPrefix + theExtRevId;

            //total spec count increased by 1

            Validate.ValidateModelCompleteness(theBaselineSpecModel, theCreatedSpecModel, new List<Object>() { "SpecRevModels" });
            Validate.ValidateModelCompleteness(theBaselineSpecModel.SpecRevModels.ElementAt(0), theCreatedSpecModel.SpecRevModels.ElementAt(0),
                new List<Object>() { "TimeModified", "SubLevels" }); // excluded TimeModified because there is a variation in (milli)seconds we can't account for
            //Warning! Testing against DateModified might be problematic if tested within seconds of midnight
        }

        [TestMethod]
        public async Task CreateNewSpecificationWithSubLevelChoices()
        {
            short theEmpID = 991; //Ben Johnson
            string theExtRevId = "AA";
            int samplePlanId = 1;
            int numSublevels = 6;
            int numSubChoices = 6;
            string descPrefix = " - Sublevel test. Rev: ";

            var thePreAddSpecList = await SpecService.GetAllHydratedSpecs();

            var theBaselineSpecModel = CreateBaselineSpecModel(theExtRevId, descPrefix, theEmpID, samplePlanId, numSublevels, numSubChoices);
            int theCreatedSpecId = await SpecService.CreateNewSpec(theBaselineSpecModel);
            var theCreatedSpecModel = await SpecService.GetHydratedCurrentRevForSpec(theCreatedSpecId);

            //only 1 rev created
            var theCreatedSpecSubLevelModels = theCreatedSpecModel.SpecRevModels.ElementAt(0).SubLevels;
            var theBaselineSpecSubLevelModels = theBaselineSpecModel.SpecRevModels.ElementAt(0).SubLevels;


            for (int i = 0; i < numSublevels; i++)
            {
                Validate.ValidateModelCompleteness(theBaselineSpecSubLevelModels.ElementAt(i), theCreatedSpecSubLevelModels.ElementAt(i),
                    new List<Object>() { "Choices" }); 

                var theCreatedSpecChoiceList = theCreatedSpecSubLevelModels.ElementAt(i).Choices;
                var theBaselineSpecChoiceList = theBaselineSpecSubLevelModels.ElementAt(i).Choices;

                for (int j = 0; j < numSubChoices; j++)
                {
                    Validate.ValidateModelCompleteness(theBaselineSpecChoiceList.ElementAt(j), theCreatedSpecChoiceList.ElementAt(j));
                }
            }
        }

        [TestMethod]
        public async Task RevUpASpecification()
        {
            //create a new rev with 2 sublevels with 3 choices each
            //then rev up with 3 sublevels and 4 choices each

            short theEmpIdRev1 = 991; //Ben Johnson
            short theEmpIdRev2 = 941; //Ed Wakefeild
            string theExtRev1Id = "X";
            string theExtRev2Id = "Y";
            int samplePlanIdRev1 = 1;
            int samplePlanIdRev2 = 7;
            int numSublevelsRev1 = 2;
            int numSubChoicesRev1 = 3;
            int numSublevelsRev2 = 3;
            int numSubChoicesRev2 = 4;
            string descPrefixRev1 = " - This is the inital rev. Rev: ";
            string descPrefixRev2 = " - This is the new rev. Rev: ";
            
            var theBaselineSpecModel = CreateBaselineSpecModel(theExtRev1Id, descPrefixRev1, theEmpIdRev1, samplePlanIdRev1, numSublevelsRev1, numSubChoicesRev1);
            int theCreatedSpecId = await SpecService.CreateNewSpec(theBaselineSpecModel);
            
            var theExpectedRev2SpecModel = CreateBaselineSpecModel(theExtRev2Id, descPrefixRev2, theEmpIdRev2, samplePlanIdRev2, numSublevelsRev2, numSubChoicesRev2);
            var theExpectedRev2SpecRevModel = theExpectedRev2SpecModel.SpecRevModels.ElementAt(0);

            theExpectedRev2SpecRevModel.SpecId = theCreatedSpecId;

            int theSpecId = await SpecService.RevUpSpec(theExpectedRev2SpecRevModel);

            //set up test values
            theExpectedRev2SpecRevModel.InternalRev = 11; //rev was incremented
            theExpectedRev2SpecRevModel.DateCreated = DateTime.Now.Date;
            theBaselineSpecModel.Id = theCreatedSpecId;

            var theNewRev2SpecModel = await SpecService.GetHydratedCurrentRevForSpec(theSpecId); //get new model for comparison

            Validate.ValidateModelCompleteness(theBaselineSpecModel, theNewRev2SpecModel, new List<Object>() { "SpecRevModels" });

            var theNewSpecRev2Model = theNewRev2SpecModel.SpecRevModels.ElementAt(1);

            Validate.ValidateModelCompleteness(theExpectedRev2SpecRevModel, theNewSpecRev2Model, new List<Object>() { "TimeModified", "SubLevels", "SamplePlan" });

            /////////////////////////////////////////////////////////////
            //Verify rev2 is accurate
            var theNewRev2SpecSubLevelModels = theNewSpecRev2Model.SubLevels;
            var theExpectedRev2SpecSubLevelModels = theExpectedRev2SpecRevModel.SubLevels;
            
            for (int i = 0; i < numSublevelsRev2; i++)
            {
                Validate.ValidateModelCompleteness(theExpectedRev2SpecSubLevelModels.ElementAt(i), theNewRev2SpecSubLevelModels.ElementAt(i),
                    new List<Object>() { "Choices" });
            
                var theNewRev2SpecChoiceList = theNewRev2SpecSubLevelModels.ElementAt(i).Choices;
                var theExpectedRev2SpecChoiceList = theExpectedRev2SpecSubLevelModels.ElementAt(i).Choices;
            
                for (int j = 0; j < numSubChoicesRev2; j++)
                {
                    Validate.ValidateModelCompleteness(theExpectedRev2SpecChoiceList.ElementAt(j), theNewRev2SpecChoiceList.ElementAt(j));
                }
            }

        }
    }
}
