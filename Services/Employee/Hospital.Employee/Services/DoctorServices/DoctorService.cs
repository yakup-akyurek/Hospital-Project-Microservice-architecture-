using AutoMapper;
using Hospital.Employee.Context;
using Hospital.Employee.Dtos.DoctorDtos;
using Hospital.Employee.Entites;
using Hospital.Employee.Services.DoctorService;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Employee.Services.DoctorServices
{
    public class DoctorService : IDoctorService
    {
        private readonly IMapper _mapper;
        private readonly EmployeeContext _context;

        public DoctorService(IMapper mapper, EmployeeContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task CreateDoctorAsync(CreateDoctorDto createDoctorDto)
        {
            var values = _mapper.Map<Doctor>(createDoctorDto);
            await _context.Doctors.AddAsync(values);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoctorAsync(int doctorId)
        {
           var value= await _context.Doctors.FindAsync(doctorId);
            _context.Doctors.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultDoctorDto>> GetAllDoctorAsync()
        {
            var values = await _context.Doctors.ToListAsync();
            return _mapper.Map<List<ResultDoctorDto>>(values);

        }

        public async  Task<GetByIdDoctorDto> GetByIdDoctor(int doctorId)
        {
            var values = await _context.Doctors.FindAsync(doctorId);
            return _mapper.Map<GetByIdDoctorDto>(values);
        }

        public Task UpdateDoctorAsync(UpdateDoctorDto updateDoctorDto)
        {
            var values= _mapper.Map<Doctor>(updateDoctorDto);
            _context.Doctors.Update(values);
            return _context.SaveChangesAsync();
        }
    }
}
