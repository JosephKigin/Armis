using Armis.BusinessModels.ShippingModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Shipping.Interfaces
{
    public interface IShipToDataAccess
    {
        Task<IEnumerable<ShipToModel>> GetShipToByCustId(int aCustId);
    }
}
