using Medico.Core.Entities;

namespace Medico.Core.DAL
{
    public interface IMedicationService
    {
        Medication GetOrCreate(int? id);
        Medication FindById(int id);
    }
}