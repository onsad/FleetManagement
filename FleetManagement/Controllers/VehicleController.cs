using FleetManagement.Entity;
using FleetManagement.Model;
using FleetManagement.Service;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController(VehicleService vehicleService) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<VehicleDto>> Get()
        {
            var result = await vehicleService.GetAll();

            return result.Select(v => new VehicleDto
            {
                Id = v.Id,
                Brand = v.Brand,
                Model = v.Model,
                Year = v.Year,
                LicensePlate = v.LicensePlate
            });
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

            var created = await vehicleService.Create(vehicle);

            var result = new VehicleDto
            {
                Id = created.Id,
                Brand = created.Brand,
                Model = created.Model,
                Year = created.Year,
                LicensePlate = created.LicensePlate
            };

            return Ok(result);
        }
    }
}
