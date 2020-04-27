using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Armis.Test
{
    public static class Validate
    {
        public static void ValidateModelCompleteness(Object anExpectedModel, Object anActuaModel, List<Object> anExcludeModelList)
        {
            var expectedModelProperties = anExpectedModel.GetType().GetProperties();
            var actualModelProperties = anActuaModel.GetType().GetProperties();

            Assert.AreEqual(expectedModelProperties.Length, actualModelProperties.Length, "Property mismatch");

            for (int i = 0; i < actualModelProperties.Length; i++)
            {
                var actValueName = actualModelProperties.ElementAt(i).Name;
                var expValueName = expectedModelProperties.ElementAt(i).Name;

                if (anExcludeModelList.Contains(actValueName))
                {
                    continue;
                } //allows the option to ignore sub-models

                var actValue = actualModelProperties.ElementAt(i).GetValue(anActuaModel);
                var expValue = expectedModelProperties.ElementAt(i).GetValue(anExpectedModel);

                //if (actValue.ToString() != expValue.ToString())
                //{ } //uncomment for testing                }
                
                Assert.AreEqual(expValueName, actValueName, anActuaModel.GetType().ToString());
                Assert.AreEqual(expValue, actValue, actValueName);
            }
        }
        public static void ValidateModelCompleteness(Object anExpectedModel, Object anActuaModel)
        {
            ValidateModelCompleteness(anExpectedModel, anActuaModel, new List<Object>() { });
        }
    }
}
