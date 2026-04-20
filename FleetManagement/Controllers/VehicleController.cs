using FleetManagement.Entity;
using FleetManagement.Model;
using FleetManagement.Service;
using FleetManagement.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController(VehicleService vehicleService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await vehicleService.GetAll();

            var data =  result.Data!.Select(v => new VehicleDto
            {
                Id = v.Id,
                Brand = v.Brand,
                Model = v.Model,
                Year = v.Year,
                LicensePlate = v.LicensePlate
            });

            return (Ok(ApiResponse<IEnumerable<VehicleDto>>.Success(data)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVehicleDto dto)
        {
            var vehicle = new Vehicle
            {
                Brand = dto.Brand,
                Model = dto.Model,
                Year = dto.Year,
                LicensePlate = dto.LicensePlate
            };

            var result = await vehicleService.Create(vehicle);

            if (!result.IsSuccess)
            {
                return BadRequest(ApiResponse<object>.Failure(result.Error!));
            }

            var response = new VehicleDto
            {
                Id = result.Data!.Id,
                Brand = result.Data.Brand,
                Model = result.Data.Model,
                Year = result.Data.Year,
                LicensePlate = result.Data.LicensePlate
            };

            return Ok(ApiResponse<VehicleDto>.Success(response));
        }
    }
}
