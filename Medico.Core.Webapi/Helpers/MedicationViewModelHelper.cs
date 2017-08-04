using System.Linq;
using Medico.Core.Entities;
using Medico.Core.Webapi.ViewModels;

namespace Medico.Core.Webapi.Helpers
{
    public static class MedicationViewModelHelper
    {
        public static MedicationViewModel ConvertToViewModel(Medication dbModel)
        {
            return new MedicationViewModel()
            {
                HumanReadableName = dbModel.HumanReadableName,
                MedicalName = dbModel.MedicalName,

                PerscribedDosage = dbModel.PerscribedDosage,
                TimeBetweenDoses = dbModel.TimeBetweenDoses,
                MaximumNumberOfDoses = dbModel.MaximumNumberOfDoses,

                InitialDoseTime = dbModel.InitialDoseTime,
                MedicationNoLongerActiveDate = dbModel.MedicationNoLongerActiveDate,
                MedicationActive = dbModel.MedicationActive,

                CalculatedDoseTime = dbModel.MedicationActionTimes
                    .Select(MedicationActionTimeViewModelHelper.ConvertToViewModel).ToList(),

                ActionedDoseTimes = dbModel.ActionedDoseTimes
                    .Select(MedicationActionTimeViewModelHelper.ConvertToViewModel).ToList(),

                Notes = dbModel.Notes ?? string.Empty,
            };
        }
    }
}