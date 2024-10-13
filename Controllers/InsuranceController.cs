using BLL.Insurance;
using ConsultorioSeguros.ApiRoutes;
using Entities;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioSeguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : Controller
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        [HttpPost(ApiRoutes.ApiRoutes.Insurance.Add)]
        public async Task<IActionResult> AddInsurance([FromBody] InsuranceDTO insurance)
        {
            ResponseJson response = await _insuranceService.Insert(insurance);

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetInsurance(int id)
        {
            ResponseJson response = await _insuranceService.Get(id);

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetAllInsurances")]
        public async Task<IActionResult> GetInsurances()
        {
            ResponseJson response = await _insuranceService.GetAll();

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateInsurance(int id, [FromBody] InsuranceDTO insurance)
        {
            ResponseJson response = await _insuranceService.Update(id, insurance);

            if (response.Error) return BadRequest(Response);

            return Ok(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteInsurance(int id)
        {
            ResponseJson response = await _insuranceService.Delete(id);

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetByCode/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            ResponseJson response = await _insuranceService.GetByCode(code);

            if (response.Error) return BadRequest(response);

            return Ok(response);
        }
    }
}
