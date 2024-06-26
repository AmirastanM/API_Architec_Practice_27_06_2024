using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Countries;
using Service.Services.Interfaces;

namespace Api_Architecture.Controllers.Admin
{
  
    public class CountryController :BaseController
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var countries = await _countryService.GetAll();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CountryCreateDto request)
        {
            try
            {
                await _countryService.CreateAsync(request);
                return CreatedAtAction(nameof(Create), new { response = "Data successfully created" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] CountryEditDto request)
        {
            try
            {
                await _countryService.EditAsync(id, request);
                return Ok(new { response = "Data successfully updated" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
