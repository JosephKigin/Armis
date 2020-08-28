using Armis.BusinessModels.CustomerModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Customer.Interfaces
{
    public interface IBillToDataAccess
    {
        Task<BillToModel> GetBillToForCustId(int aCustId);
    }
}
