using Armis.BusinessModels.ARModels;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ARServices.Interfaces
{
    public interface ICertificationChargeService
    {
        Task<IEnumerable<CertificationChargeModel>> GetAllCertCharges();
    }
}
