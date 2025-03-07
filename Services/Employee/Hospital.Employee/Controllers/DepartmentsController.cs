using Hospital.Employee.Dtos.DepartmentDtos;
using Hospital.Employee.Services.DepartmentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public async Task<IActionResult> DepartmentList()
        {
            var values = await _departmentService.GetAllDepartmentAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentDto createDepartmentDto)
        {
            await _departmentService.CreateDepartmentAsync(createDepartmentDto);
            return Ok("ekleme başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment(int DepartmentId)
        {
            await _departmentService.DeleteDepartmentAsync(DepartmentId);
            return Ok("silme başarılı");
        }
        [HttpGet("GetDepartment")]
        public async Task<IActionResult> GetDepartment(int DepartmentId)
        {
            return Ok(await _departmentService.GetByIdDepartment(DepartmentId));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentDto updateDepartmentDto)
        {
            await _departmentService.UpdateDepartmentAsync(updateDepartmentDto);
            return Ok("güncelleme başarılı");
        }
    }
}
