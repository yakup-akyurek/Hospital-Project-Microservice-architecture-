using Hospital.Employee.Dtos.DoctorDtos;

namespace Hospital.Employee.Services.DoctorService
{
    public interface IDoctorService
    {
        Task<List<ResultDoctorDto>>GetAllDoctorAsync();
        Task CreateDoctorAsync(CreateDoctorDto createDoctorDto);
        Task UpdateDoctorAsync(UpdateDoctorDto updateDoctorDto);
        Task DeleteDoctorAsync(int doctorId);
        Task <GetByIdDoctorDto> GetByIdDoctor(int doctorId);

    }
}
