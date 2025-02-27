﻿using AutoMapper;
using Hospital.Patient.Dtos.PatientAdultDtos;
using Hospital.Patient.Dtos.PatientChildDtos;
using Hospital.Patient.Entites;

namespace Hospital.Patient.Mapping
{
    public class GeneralMapping:Profile
    {

        public GeneralMapping()
        {
            
            CreateMap<ResultPatientAdultDto,PatientAdult>().ReverseMap();
            CreateMap<CreatePatientAdultDto,PatientAdult>().ReverseMap();
            CreateMap<GetByIdPatientAdultDto,PatientAdult>().ReverseMap();
            CreateMap<UpdatePatientAdultDto,PatientAdult>().ReverseMap();
            
            
            CreateMap<ResultPatientChildDto,PatientChild>().ReverseMap();
            CreateMap<CreatePatientChildDto,PatientChild>().ReverseMap();
            CreateMap<GetByIdPatientChildDto,PatientChild>().ReverseMap();
            CreateMap<UpdatePatientChildDto,PatientChild>().ReverseMap();
        }
    }
}
