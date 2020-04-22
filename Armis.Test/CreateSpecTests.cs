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
        private SpecModel GenerateSpecificationModel(string aExtRev, short aEmpId, int numSubLevels, int numChoicesPerSub)
        {
            //Spec needs a revision even though the DB will allow a spec without a rev
            //SpecRev needs a sublevel even though the DB will allow a specrev without a sublevel

            var theTimeStamp = DateTime.Now.ToString("yyyyMMddhhmmssffff");

            var theSpecSubLevelList = new List<SpecSubLevelModel>() { };

            for (int i = 0; i < numSubLevels; i++)
            {
                theSpecSubLevelList.Add(new SpecSubLevelModel()
                {
                    Name = "level " + ( i + 1).ToString(),
                    IsRequired = false,
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
                        Description = "This is a test. Rev: " + aExtRev,
                        ExternalRev = aExtRev,
                        EmployeeNumber = aEmpId,
                        DateModified = DateTime.Now,
                        SubLevels = theSpecSubLevelList // new List<SpecSubLevelModel>(){ }
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

            var theGeneratedSpecModel = GenerateSpecificationModel(theExtRevId, theEmpID, 0, 0);
            _ = await SpecService.CreateNewSpec(theGeneratedSpecModel);
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

            var thePreAddSpecList = await SpecService.GetAllHydratedSpecs();

            var theGeneratedSpecModel = GenerateSpecificationModel(theExtRevId, theEmpID, 4, 6);
            _ = await SpecService.CreateNewSpec(theGeneratedSpecModel);
            var thePostAddSpecList = await SpecService.GetAllHydratedSpecs();

            //total spec count increased by 1
            //Assert.AreEqual(thePostAddSpecList.Count(), thePreAddSpecList.Count() + 1);
            //Assert.AreEqual(1, thePostAddSpecList.ElementAt(0).SpecRevModels.Count());
        }
    }
}
