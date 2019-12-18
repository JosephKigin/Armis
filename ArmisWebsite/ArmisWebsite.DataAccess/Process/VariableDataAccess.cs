using Armis.BusinessModels.ProcessModels;
using ArmisWebsite.DataAccess.Process.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ArmisWebsite.DataAccess.Process
{
    public class VariableDataAccess : IVariableDataAccess
    {
        public int CreateVaribale(VariableModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VariableTemplateModel> GetAllTemplates()
        {
            var result = new List<VariableTemplateModel>();
            for (int i = 0; i < 10; i++)
            {
                var tempTemplate = new VariableTemplateModel()
                {
                    Code = "TEST",
                    Id = 0,
                    Name = "Test - " + i,
                    Type = "Test Type"
                };

                result.Add(tempTemplate);
            }

            return result;
        }
    }
}
