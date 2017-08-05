using System.Collections.Generic;
using Medico.Core.Entities;

namespace Medico.Core.DAL
{
    public interface IBaseMedicoService
    {
        IEnumerable<T> BaseQuery<T>(bool includeNavigationProperties = false)
                where T : BaseMedicoEntity, new();
        IEnumerable<T> BaseReadOnlyQuery<T>(bool includeNavigationProperties = false)
                where T : BaseMedicoEntity, new ();
    }
}
