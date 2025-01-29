using SistemaMedico.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaMedico.Core.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetDoctores();
        Task<Doctor> GetDoctor(int doctorId);
        Task InsertDoctor(Doctor doctor);
        Task<bool> UpdateDoctor(Doctor doctor);
        Task<bool> DeleteDoctor(int doctorId);
    }
}
