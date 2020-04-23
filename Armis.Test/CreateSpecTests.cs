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
    public class CreateSpecTests
    {
        private ARMISContext _context;
        private const string TESTPREFIX = "T-";
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
        private SpecModel CreateBaselineSpecModel(string aExtRev, short aEmpId, int numSubLevels, int numChoicesPerSub)
        {
            //Spec needs a revision even though the DB will allow a spec without a rev
            //SpecRev needs a sublevel even though the DB will allow a specrev without a sublevel

            var theTimeStamp = DateTime.Now.ToString("yyyyMMddhhmmssffff");

            var theSpecSubLevelList = new List<SpecSubLevelModel>() { };

            for (int i = 0; i < numSubLevels; i++)
            {
                bool isReqTestFlag = false;
                if(((i + 1) % 2) == 0) { isReqTestFlag = true; } //make 'even' sublevels tested for required

                theSpecSubLevelList.Add(new SpecSubLevelModel()
                {
                    Name = "level " + ( i + 1).ToString(),
                    IsRequired = isReqTestFlag,
                    LevelSeq = Convert.ToByte(i + 1)
                });

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
                Code = TESTPREFIX + theTimeStamp,
                SpecRevModels = new List<SpecRevModel>()
                {
                    new SpecRevModel()
                    {
                        Description = DateTime.Now.ToString("hh:mm:ss") + " - This is a test. Rev: " + aExtRev,
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

            var thePreAddSpecList = await SpecService.GetAllHydratedSpecs();

            var theBaselineSpecModel = CreateBaselineSpecModel(theExtRevId, theEmpID, 0, 0);
            _ = await SpecService.CreateNewSpec(theBaselineSpecModel);
            var thePostAddSpecList = await SpecService.GetAllHydratedSpecs();

            //total spec count increased by 1
            Assert.AreEqual(thePostAddSpecList.Count(), thePreAddSpecList.Count() + 1);
            Assert.AreEqual(1, thePostAddSpecList.ElementAt(0).SpecRevModels.Count());
        }

        [TestMethod]
        public async Task CreateNewSpecificationWithSubLevelChoices()
        {
            short theEmpID = 991; //Ben Johnson
            string theExtRevId = "AA";
            int numSublevels = 6;
            int numSubChoices = 6;

            var thePreAddSpecList = await SpecService.GetAllHydratedSpecs();

            var theBaselineSpecModel = CreateBaselineSpecModel(theExtRevId, theEmpID, numSublevels, numSubChoices);
            int theCreatedSpecId = await SpecService.CreateNewSpec(theBaselineSpecModel);
            var theCreatedSpecModel = await SpecService.GetHydratedCurrentRevForSpec(theCreatedSpecId);

            //only 1 rev created
            var theCreatedSpecSubLevelModels = theCreatedSpecModel.SpecRevModels.ElementAt(0).SubLevels;
            var theBaselineSpecSubLevelModels = theBaselineSpecModel.SpecRevModels.ElementAt(0).SubLevels;

            for (int i = 0; i < numSublevels; i++)
            {
                Assert.AreEqual(theBaselineSpecSubLevelModels.ElementAt(i).IsRequired, theCreatedSpecSubLevelModels.ElementAt(i).IsRequired);
                Assert.AreEqual(theBaselineSpecSubLevelModels.ElementAt(i).Name, theCreatedSpecSubLevelModels.ElementAt(i).Name);

                var theCreatedSpecChoiceList = theCreatedSpecSubLevelModels.ElementAt(i).Choices;
                var theBaselineSpecChoiceList = theBaselineSpecSubLevelModels.ElementAt(i).Choices;

                for (int j = 0; j < numSubChoices; j++)
                {
                    Assert.AreEqual(theBaselineSpecChoiceList.ElementAt(j).ChoiceSeq, theCreatedSpecChoiceList.ElementAt(j).ChoiceSeq);
                    Assert.AreEqual(theBaselineSpecChoiceList.ElementAt(j).Name, theCreatedSpecChoiceList.ElementAt(j).Name);
                }
            }
        }
    }
}
