using Armis.BusinessModels.ARModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.AR.Interfaces
{
    public interface ICertificationChargeDataAccess
    {
        Task<IEnumerable<CertificationChargeModel>> GetAllCertCharges();
    }
}
