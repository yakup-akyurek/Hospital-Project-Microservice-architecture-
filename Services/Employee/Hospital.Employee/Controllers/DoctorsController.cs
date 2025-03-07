using Hospital.Employee.Dtos.DoctorDtos;
using Hospital.Employee.Services.DoctorService;
using Hospital.Employee.Services.DoctorServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _DoctorService;

        public DoctorsController(IDoctorService DoctorService)
        {
            _DoctorService = DoctorService;
        }
        [HttpGet]
        public async Task<IActionResult> DoctorList()
        {
            var values = await _DoctorService.GetAllDoctorAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateDoctorDto createDoctorDto)
        {
            await _DoctorService.CreateDoctorAsync(createDoctorDto);
            return Ok("ekleme başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDoctor(int DoctorId)
        {
            await _DoctorService.DeleteDoctorAsync(DoctorId);
            return Ok("silme başarılı");
        }
        [HttpGet("GetDoctor")]
        public async Task<IActionResult> GetDoctor(int DoctorId)
        {
            return Ok(await _DoctorService.GetByIdDoctor(DoctorId));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDoctor(UpdateDoctorDto updateDoctorDto)
        {
            await _DoctorService.UpdateDoctorAsync(updateDoctorDto);
            return Ok("güncelleme başarılı");
        }
    }
}
