using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ProcessServices.Interfaces
{
    public interface IUOMService
    {
        Task<IEnumerable<UOMCodeModel>> GetAllUOMs();
    }
}
