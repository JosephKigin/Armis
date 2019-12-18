using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Armis.BusinessModels.ProcessModels;

namespace ArmisWebsite.DataAccess.Process.Interfaces
{
   public interface IVariableDataAccess
    {
        int CreateVaribale(VariableModel model);
        IEnumerable<VariableTemplateModel> GetAllTemplates();
    }
}
