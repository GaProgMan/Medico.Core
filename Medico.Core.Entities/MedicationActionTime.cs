using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medico.Core.Entities
{
    public class MedicationActionTime : CommonProperties, IAuditable, IBaseMedicoEntity
    {
        public int MedicationActionTimeId { get; set; }

        public int MedicationId { get; set; }
        public virtual Medication Medication { get; set; }

        public DateTime TimeToAction { get; set; }
        public DateTime? TimeActioned { get; set; }

        [NotMapped]
        public bool Actioned => TimeActioned.HasValue;
    }
}