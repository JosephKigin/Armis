using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext.Entities;
using System.Collections.Generic;

namespace Armis.DataLogic.ModelExtensions.ProcessExtensions
{
    public static class ProcessExtension
    {
        //TODO: get rid of this and refactor everything that uses it to use the two methods below
        public static ProcessModel ToHydratedModel(this Process aProcess, IEnumerable<ProcessRevisionModel> aProcessRevs) 
        {
            return new ProcessModel()
            {
                CustId = aProcess.CustId,
                Name = aProcess.Name,
                ProcessId = aProcess.ProcessId,
                Revisions = aProcessRevs
            };
        }

        //This method creates a dummy list of processes with only one process in it, and the runs it through ToHydratedModels().  It then takes the first and only entry in the list given back and returns it.  This just prevents a lot of code duplication.
        public static ProcessModel ToHydratedModel(this Process aProcess)
        {
            var dummyProcessList = new List<Process>();
            dummyProcessList.Add(aProcess);

            return dummyProcessList.ToHydratedModels()[0];
        }

        public static List<ProcessModel> ToHydratedModels(this List<Process> aProcesses)
        {
            var result = new List<ProcessModel>();

            foreach (var aProcess in aProcesses)
            {
                var theProcessModel = aProcess.ToModel();
                var theRevs = new List<ProcessRevisionModel>();

                foreach (var aRev in aProcess.ProcessRevision)
                {
                    var theRev = aRev.ToModel();
                    var theSteps = new List<StepModel>();

                    foreach (var aStep in aRev.ProcessStepSeq)
                    {
                        var theStep = aStep.Step.ToModel(aStep.StepSeq, aStep.Operation.ToModel());
                        theSteps.Add(theStep);
                    }

                    theRev.Steps = theSteps;
                    theRevs.Add(theRev);
                }

                theProcessModel.Revisions = theRevs;
                result.Add(theProcessModel);
            }

            return result;
        }

        public static ProcessModel ToModel(this Process aProcess)
        {
            return new ProcessModel()
            {
                CustId = aProcess.CustId,
                Name = aProcess.Name,
                ProcessId = aProcess.ProcessId
            };
        }

        //To entity
        public static Process ToEntity(this ProcessModel aProcessModel)
        {
            return new Process()
            {
                CustId = aProcessModel.CustId,
                Name = aProcessModel.Name
            };
        }
    }
}
