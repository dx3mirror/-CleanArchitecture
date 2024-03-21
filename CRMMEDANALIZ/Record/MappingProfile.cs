using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PatientModel, Patient>();
        CreateMap<Infrastructure.Data.Patient, Application.DTOs.PatientDTO>();
    }
}