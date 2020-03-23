using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Process.Interfaces
{
    public interface IApiCheckConnectionDataAccess
    {
        Task<bool> CheckApiConntection();
    }
}
