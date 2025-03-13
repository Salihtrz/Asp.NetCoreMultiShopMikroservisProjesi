using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }
        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _cargoOperationService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate,
            };
            _cargoOperationService.TInsert(cargoOperation);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoOperation(int id)
        {
            var value = _cargoOperationService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                OperationDate = updateCargoOperationDto.OperationDate,
                Description = updateCargoOperationDto.Description,
                Barcode = updateCargoOperationDto.Barcode,
                CargoOperationID = updateCargoOperationDto.CargoOperationID
            };
            _cargoOperationService.TUpdate(cargoOperation);
            return Ok();
        }
    }
}
