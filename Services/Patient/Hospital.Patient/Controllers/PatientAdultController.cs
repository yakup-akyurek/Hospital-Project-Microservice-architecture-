using Hospital.Patient.Dtos.PatientAdultDtos;
using Hospital.Patient.Services.PatientAdultServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Patient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAdultController : ControllerBase
    {
        private readonly IPatientAdultServices _patientAdultService;

        public PatientAdultController(IPatientAdultServices patientAdultService)
        {
            _patientAdultService = patientAdultService;
        }
        [HttpGet]
        public async Task<IActionResult> PatientAdultList()
        {
            var value = await _patientAdultService.GetAllPatientAsync();
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePatientAdult(CreatePatientAdultDto createPatientAdultDto)
        {
            await _patientAdultService.CreatePatientAdultAsync(createPatientAdultDto);
            return Ok("ekleme başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePatientAdult(string id)
        {
            await _patientAdultService.DeletePatientAdultAsync(id);
            return Ok("silme başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePatientAdult(UpdatePatientAdultDto updatePatientAdultDto)
        {
            await _patientAdultService.UpdatePatientAdultAsync(updatePatientAdultDto);
            return Ok("güncelleme başarılı");
        }
        [HttpGet("GetPatientAdult")]
        public async Task<IActionResult> GetPatientAdult(string id)
        {
            var value = await _patientAdultService.GetByIdPatientAdultAsync(id);
            return Ok(value);
        }
    }
}
