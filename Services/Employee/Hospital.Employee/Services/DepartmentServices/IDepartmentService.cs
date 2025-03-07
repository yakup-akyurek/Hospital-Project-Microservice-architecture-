using Hospital.Employee.Dtos.DepartmentDtos;

namespace Hospital.Employee.Services.DepartmentServices
{
    public interface IDepartmentService
    {
        Task<List<ResultDepartmentDto>> GetAllDepartmentAsync();
        Task CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto);
        Task UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto);
        Task DeleteDepartmentAsync(int DepartmentId);
        Task<GetByIdDepartmentDto> GetByIdDepartment(int DepartmentId);
    }
}
