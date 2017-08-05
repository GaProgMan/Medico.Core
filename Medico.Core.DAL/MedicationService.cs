using System;
using System.Collections.Generic;
using System.Linq;
using Medico.Core.Entities;
using Medico.Core.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Medico.Core.DAL
{
    public class MedicationService : BaseMedicoService, IMedicationService
    {

        public MedicationService(MedicoContext medicoContext) : base (medicoContext)
        {
        }

        /// <summary>
        /// Used to get a <see cref="Medication"/> entity by the given (nullable)
        /// id, or create one if the id is not supplied (i.e. it is null)
        /// </summary>
        /// <param name="id">The id of the target Medication entity</param>
        /// <returns>
        /// The Medication entity for the supplied ID, or a new instance or a
        /// new instance of a Medication Entity
        /// </returns>
        /// <remarks>
        /// Use this method when it is not know whether a medication entity exists
        /// for the supplied id
        /// </remarks>
        public Medication GetOrCreate(int? id)
        {
            var medication = BaseQuery().FirstOrDefault(med => med.MedicationId == id);
            return medication ?? new Medication();
        }

        /// <summary>
        /// Used to find a <see cref="Medication"/> entity by its ID.
        /// If no Medication entity can be found, this method will return
        /// null (as it uses FirstOrDefault)
        /// </summary>
        /// <param name="id">The ID of the <see cref="Medication"/> entity to find</param>
        /// <returns>The Medication entity for the supplied ID</returns>
        /// <remarks>
        /// Use this method when it is known that there is a Medication entity
        /// with the supplied ID
        /// </remarks>
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
        /// <param name="includeNavigationProperties">
        /// Indicates whether all navigation properties should be traversed in order
        /// to get all related entities
        /// </param>
        /// <remarks>
        /// The returned DbSet has tracking disabled, thus any changes cannot be saved
        /// to back to the database 
        /// </remarks>
        private IEnumerable<Medication> BaseReadOnlyQuery(bool includeNavigationProperties = false)
        {
            return BaseReadOnlyQuery<Medication>(includeNavigationProperties);
        }

        /// <summary>
        /// Used explicitly for a tracked query (i.e. we expect changes to the context)
        /// </summary>
        /// <returns>
        /// The <see cref="Medication"/> DbSet with no tracking (essentially, read only)
        /// </returns>
        /// <param name="includeNavigationProperties">
        /// Indicates whether all navigation properties should be traversed in order
        /// to get all related entities
        /// </param>
        /// <remarks>
        /// The returned DbSet has tracking disabled, thus any changes cannot be saved
        /// to back to the database 
        /// </remarks>
        private IEnumerable<Medication> BaseQuery(bool includeNavigationProperties = false)
        {
            return BaseQuery<Medication>(includeNavigationProperties);
        }
    }
}
