using SistemaMedico.Core.Entities;
using SistemaMedico.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaMedico.Core.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<Doctor> doctorRepository;

        public DoctorService(IRepository<Doctor> doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public async Task<IEnumerable<Doctor>> GetDoctores()
        {
            return await doctorRepository.GetAll();
        }

        public async Task<Doctor> GetDoctor(int doctorId)
        {
            return await doctorRepository.GetById(doctorId);
        }

        public async Task InsertDoctor(Doctor doctor)
        {
            await doctorRepository.Add(doctor);
        }

        public async Task<bool> UpdateDoctor(Doctor doctor)
        {
            await doctorRepository.Update(doctor);
            return true;
        }

        public async Task<bool> DeleteDoctor(int doctorId)
        {
            await doctorRepository.Delete(doctorId);
            return true;
        }
    }
}
