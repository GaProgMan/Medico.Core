using System;
using System.Collections.Generic;
using System.Linq;
using Medico.Core.Entities;

namespace Medico.Core.Webapi.ViewModels
{
    public class MedicationViewModel : BaseViewModel, ICommonProperties
    {
        public string HumanReadableName { get; set; }
        public string MedicalName { get; set; }
        
        /// <summary>
        /// Most likely to be a whole number, and in mg
        /// </summary>
        public int PerscribedDosage { get; set; }

        /// <summary>
        /// This is used to calculate the <see cref="CalculatedDoseTime"/>
        /// </summary>
        /// <remarks>Will be stored as the number of whole minutes between doses</remarks>
        public int TimeBetweenDoses { get; set; }

        /// <summary>
        /// Used with <see cref="TimeBetweenDoses"/> to calculate the number of
        /// entries in <see cref="CalculatedDoseTime"/> for a single 24 hour period
        /// </summary>
        public int MaximumNumberOfDoses { get; set; }

        public DateTime? InitialDoseTime { get; set; }
        
        public DateTime? MedicationNoLongerActiveDate { get; set; }
  
        public bool MedicationActive { get; set; }
        
        // contains a list of calculated times
        public List<MedicationActionTimeViewModel> CalculatedDoseTime;

        /// <summary>
        /// These can (and will) be calculated from the
        /// <see cref="CalculatedDoseTime"/> collection
        /// </summary>
        public List<MedicationActionTimeViewModel> ActionedDoseTimes;
        
        public string Notes { get; set; }

        public MedicationViewModel()
        {
            CalculatedDoseTime = new List<MedicationActionTimeViewModel>();
            ActionedDoseTimes = new List<MedicationActionTimeViewModel>();
        }
    }
}