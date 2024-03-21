using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientDTO>> GetAllPatients()
        {
            var patients = await _patientRepository.GetAllPatients();
            return _mapper.Map<IEnumerable<PatientDTO>>(patients);
        }

        public async Task<PatientDTO> GetPatientById(int id)
        {
            var patient = await _patientRepository.GetPatientById(id);
            return _mapper.Map<PatientDTO>(patient);
        }

        public async Task<int> CreatePatient(PatientDTO dto)
        {
            var patientId = await _patientRepository.CreatePatient(dto);
            return patientId;
        }

        public async Task UpdatePatient(int id, PatientDTO dto)
        {
            await _patientRepository.UpdatePatient(id, dto);
        }

        public async Task DeletePatient(int id)
        {
            await _patientRepository.DeletePatient(id);
        }
    }
}
