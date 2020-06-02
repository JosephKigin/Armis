using Armis.BusinessModels.ShippingModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ShippingService.Interfaces
{
    public interface IShipViaService
    {
        Task<IEnumerable<ShipViaModel>> GetAllShipVias();
    }
}
