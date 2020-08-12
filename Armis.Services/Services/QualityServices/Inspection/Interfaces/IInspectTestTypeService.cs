using Armis.BusinessModels.QualityModels.InspectionModels;
using Armis.BusinessModels.QualityModels.Spec;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.QualityServices.Inspection.Interfaces
{
    public interface IInspectTestTypeService
    {
        Task<IEnumerable<InspectTestTypeModel>> GetAllInspectTestType();
        Task<InspectTestTypeModel> CreateInspectTestType(InspectTestTypeModel anInspectTestTypeModel);
    }
}
