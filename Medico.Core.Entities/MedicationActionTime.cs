using System;

namespace Medico.Core.Entities
{
    public class MedicationActionTime : CommonProperties, IAuditable
    {
        public int MedicationActionTimeId { get; set; }

        public int MedicationId { get; set; }
        public virtual Medication Medication { get; set; }

        public bool Actioned { get; set; }
        public DateTime? TimeActioned { get; set; }
    }
}