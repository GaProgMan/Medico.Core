using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Medico.Core.Persistence
{
    /// <summary>
    /// This factory is provided so that the EF Core tools can build a full context
    /// without having to have access to where the DbContext is being created (i.e.
    /// in the UI layer).
    /// </summary>
    /// <remarks>
    /// Please see the following URL for more information:
    /// https://docs.microsoft.com/en-us/ef/core/miscellaneous/configuring-dbcontext#using-idbcontextfactorytcontext
    /// </remarks>
    public class MedicoContextFactory : IDbContextFactory<MedicoContext>
    {
        public MedicoContext Create(DbContextFactoryOptions options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MedicoContext>();
            optionsBuilder.UseSqlite("Data Source=Medico.Core.db");
            
            return new MedicoContext(optionsBuilder.Options);
        }
    }
}