using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using AutoMapper;
using Domain.Entities;
using Application.DTOs;
using Infrastructure.Services.Interfaces;

namespace CRMMEDANALIZ.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> GetAllPatients()
        {
            try
            {
                var patients = await _patientService.GetAllPatients();
                return Ok(patients);
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDTO>> GetPatientById(int id)
        {
            var patient = await _patientService.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreatePatient(PatientDTO dto)
        {
            try
            {
                var patientId = await _patientService.CreatePatient(dto);
                return CreatedAtAction(nameof(GetPatientById), new { id = patientId }, patientId);
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, PatientDTO dto)
        {
            try
            {
                await _patientService.UpdatePatient(id, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            try
            {
                await _patientService.DeletePatient(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
    

}

