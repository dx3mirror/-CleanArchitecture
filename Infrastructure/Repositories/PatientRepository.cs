using AutoMapper;
using Application.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly CrminvitroContext _context;
        private readonly IMapper _mapper;

        public PatientRepository(CrminvitroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Patient>> GetAllPatients() => await _context.Patients.ToListAsync();
        

        public async Task<Patient> GetPatientById(int id) => await _context.Patients.FindAsync(id);
        

        public async Task<int> CreatePatient(PatientDTO dto)
        {
            var patientModel = _mapper.Map<PatientModel>(dto);
            var genderString = dto.Gender.ToString();

            var patient = new Patient
            {
                Name = patientModel.Name,
                Surname = patientModel.Surname,
                DateOfBirth = patientModel.DateOfBirth,
                Gender = genderString,
                Address = patientModel.Address,
                PhoneNumber = patientModel.PhoneNumber
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return patient.PatientId;
        }

        public async Task UpdatePatient(int id, PatientDTO dto)
        {
            var existingPatient = await _context.Patients.FindAsync(id);
            if (existingPatient == null)
            {
                throw new KeyNotFoundException($"Patient with ID {id} not found.");
            }

            var patientModel = _mapper.Map<PatientModel>(dto);
            var genderString = dto.Gender.ToString();

            existingPatient.Name = patientModel.Name;
            existingPatient.Surname = patientModel.Surname;
            existingPatient.DateOfBirth = patientModel.DateOfBirth;
            existingPatient.Gender = genderString;
            existingPatient.Address = patientModel.Address;
            existingPatient.PhoneNumber = patientModel.PhoneNumber;

            await _context.SaveChangesAsync();
        }

        public async Task DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                throw new KeyNotFoundException($"Patient with ID {id} not found.");
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }
    }
}
