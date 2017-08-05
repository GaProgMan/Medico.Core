using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Medico.Core.DAL.Extentions;
using Medico.Core.Entities;
using Medico.Core.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Medico.Core.DAL
{
    public class BaseMedicoService : IBaseMedicoService
    {
        public readonly MedicoContext _medicoContext;

        public BaseMedicoService(MedicoContext medicoContext)
        {
            _medicoContext = medicoContext;
        }

        /// <summary>
        /// Used to perform a trackable query on any dbset of entities which extend
        /// the <see cref="BaseMedicoEntity" /> - i.e. any changes made to the context
        /// will be tracked.
        /// </summary>
        /// <param name="includeNavigationProperties">
        /// Indicates whether all navigation properties should be traversed in order
        /// to get all related entities
        /// </param>
        /// <returns>
        /// The set of all entities which match the passed in <see cref="T"/>
        /// with change tracking enabled
        /// </returns>
        public IEnumerable<T> BaseQuery<T>(bool includeNavigationProperties = false)
                where T : BaseMedicoEntity, new()
        {
            var query = _medicoContext.Set<T>().AsQueryable();
            
            if (includeNavigationProperties)
            {
                query = query.IncludeAll<T>();
            }
            return query;
        }

        /// <summary>
        /// Used to perform a read only query on any dbset of entities which extend
        /// the <see cref="BaseMedicoEntity" />.
        /// </summary>
        /// <param name="includeNavigationProperties">
        /// Indicates whether all navigation properties should be traversed in order
        /// to get all related entities
        /// </param>
        /// <returns>
        /// The set of all entities which match the passed in <see cref="T"/>
        /// with change tracking disabled
        /// </returns>
        public IEnumerable<T> BaseReadOnlyQuery<T>(bool includeNavigationProperties = false)
                where T : BaseMedicoEntity, new()
        {
            var query = _medicoContext.Set<T>().AsNoTracking().AsQueryable();
            
            if (includeNavigationProperties)
            {
                query = query.IncludeAll<T>();
            }
            return query;
        }
    }
}
