using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medico.Core.Entities
{
    public class Medication : CommonProperties, IAuditable
    {
        public Medication()
        {
            MedicationActionTimes = new List<MedicationActionTime>();
        }
        
        public int MedicationId { get; set; }
        public string HumanReadableName { get; set; }
        public string MedicalName { get; set; }

        /// <summary>
        /// Most likely to be a whole number, and in mg
        /// </summary>
        public int PerscribedDosage { get; set; }
        
        /// <summary>
        /// This is used to calculate the <see cref="MedicationActionTime"/>
        /// </summary>
        /// <remarks>Will be stored as the number of whole minutes between doses</remarks>
        public int TimeBetweenDoses { get; set; }

        /// <summary>
        /// Used with <see cref="TimeBetweenDoses"/> to calculate the number of
        /// entries in <see cref="MedicationActionTime"/> for a single 24 hour period
        /// </summary>
        public int MaximumNumberOfDoses { get; set; }

        public DateTime? InitialDoseTime { get; set; }
        
        public DateTime? MedicationNoLongerActiveDate { get; set; }
  
        public bool MedicationActive { get; set; }
        
        // contains a list of calculated times
        public ICollection<MedicationActionTime> MedicationActionTimes { get; set; }

        /// <summary>
        /// These can (and will) be calculated from the
        /// <see cref="MedicationActionTime"/> collection
        /// </summary>
        [NotMapped]
        public IEnumerable<MedicationActionTime> ActionedDoseTimes
            => MedicationActionTimes.Where(cdt => cdt.Actioned);
    }
}
