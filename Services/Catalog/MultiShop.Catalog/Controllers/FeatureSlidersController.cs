using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Services.FeatureSliderServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSlidersController(IFeatureSliderService FeatureSliderService)
        {
            _featureSliderService = FeatureSliderService;
        }
        [HttpGet]
        public async Task<IActionResult> FeatureSliderList()
        {
            var values = await _featureSliderService.GetAllFeatureSliderAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureSliderById(string id)
        {
            var value = await _featureSliderService.GetByIdFeatureSliderAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return Ok();
        }
    }
}
