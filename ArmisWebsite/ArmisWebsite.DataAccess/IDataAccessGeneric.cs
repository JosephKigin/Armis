using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess
{
    public interface IDataAccessGeneric
    {
        Task<string> HttpGetRequest(string aPath);
    }
}
