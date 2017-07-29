using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Medico.Core.Entities
{
    public class Medication : CommonProperties, IAuditable
    {
        public int MedicationId { get; set; }
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
        public ICollection<MedicationActionTime> CalculatedDoseTime = new Collection<MedicationActionTime>();

        /// <summary>
        /// These can (and will) be calculated from the
        /// <see cref="CalculatedDoseTime"/> collection
        /// </summary>
        [NotMapped]
        public IEnumerable<MedicationActionTime> ActionedDoseTimes
            => CalculatedDoseTime.Where(cdt => cdt.Actioned);
    }
}
