using Medico.Core.Entities;
using Medico.Core.Webapi.ViewModels;

namespace Medico.Core.Webapi.Helpers
{
    public static class MedicationActionTimeViewModelHelper
    {
        public static MedicationActionTimeViewModel ConvertToViewModel(MedicationActionTime dbModel)
        {
            return new MedicationActionTimeViewModel
            {
                Actioned = dbModel.Actioned,
                TimeActioned = dbModel.TimeActioned,

                Notes = dbModel.Notes ?? string.Empty,
            };
        }
    }
}