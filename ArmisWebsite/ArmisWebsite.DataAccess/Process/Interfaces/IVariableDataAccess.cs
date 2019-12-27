using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Armis.BusinessModels.ProcessModels;

namespace ArmisWebsite.DataAccess.Process.Interfaces
{
   public interface IVariableDataAccess
    {
        Task<IEnumerable<VariableTemplateModel>> GetAllTemplates();
        Task<IEnumerable<VariableTypeModel>> GetAllVarTypes();
        Task<HttpResponseMessage> PostVariableTemplate(VariableTemplateModel aVariableTemplateModel);
    }
}
