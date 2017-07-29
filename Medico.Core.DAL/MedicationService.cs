using System.Collections.Generic;
using System.Linq;
using Medico.Core.Entities;
using Medico.Core.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Medico.Core.DAL
{
    public class MedicationService : IMedicationService
    {
        private readonly MedicoContext _medicoContext;

        public MedicationService(MedicoContext medicoContext)
        {
            _medicoContext = medicoContext;
        }

        public Medication GetOrCreate(int? id)
        {
            var medication = _medicoContext.Medications.Find(id);
            return medication ?? new Medication();
        }

        public Medication FindById(int id)
        {
            return BaseReadOnlyQuery().FirstOrDefault(med => med.MedicationId == id);
        }

        /// <summary>
        /// Used to ensure that we have a read only query
        /// </summary>
        /// <returns>
        /// The <see cref="Medication"/> DbSet with no tracking (essentially, read only)
        /// </returns>
        /// <remarks>
        /// The returned DbSet has tracking disabled, thus any changes cannot be saved
        /// to back to the database 
        /// </remarks>
        private IEnumerable<Medication> BaseReadOnlyQuery()
        {
            return _medicoContext.Medications.AsNoTracking();
        }
    }
}
