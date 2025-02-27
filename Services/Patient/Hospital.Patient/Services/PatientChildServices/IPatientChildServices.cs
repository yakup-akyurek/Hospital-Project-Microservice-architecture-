using Hospital.Patient.Dtos.PatientChildDtos;

namespace Hospital.Patient.Services.PatientChildServices
{
    public interface IPatientChildServices
    {
        Task<List<ResultPatientChildDto>> GetAllPatientAsync();
        Task CreatePatientChildAsync(CreatePatientChildDto createPatientChildDto);
        Task UpdatePatientChildAsync(UpdatePatientChildDto updatePatientChildDto);
        Task DeletePatientChildAsync(string id);
        Task <GetByIdPatientChildDto> GetByIdPatientChildAsync(string id);
    }
}
