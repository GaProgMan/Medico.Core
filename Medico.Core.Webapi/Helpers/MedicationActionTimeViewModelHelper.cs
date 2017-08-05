using System.Collections.Generic;
using System.Linq;
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
                TimeToAction = dbModel.TimeToAction,
                Notes = dbModel.Notes ?? string.Empty,
            };
        }

        public static List<MedicationActionTimeViewModel> ConvertToViewModels(IEnumerable<MedicationActionTime> dbModels)
        {
            return dbModels.Select(mat => ConvertToViewModel(mat)).ToList();
        }
    }
}