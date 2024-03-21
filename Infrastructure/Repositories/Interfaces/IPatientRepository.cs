using Application.DTOs;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatients();
        Task<Patient> GetPatientById(int id);
        Task<int> CreatePatient(PatientDTO dto);
        Task UpdatePatient(int id, PatientDTO dto);
        Task DeletePatient(int id);
    }
}
