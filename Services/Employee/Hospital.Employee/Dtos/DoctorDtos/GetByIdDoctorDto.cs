﻿using Hospital.Employee.Entites;

namespace Hospital.Employee.Dtos.DoctorDtos
{
    public class GetByIdDoctorDto
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }

        public int DepartmentId { get; set; }
       
    }
}
