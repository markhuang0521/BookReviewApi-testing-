using BookReview.DTO;
using BookReview.Models;
using BookReview.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;

        }
        //api/countries
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CountryDto>))]
        public IActionResult GetCountries()
        {
            var countries = _countryRepository.GetCountries();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var countriesDto = new List<CountryDto>();
            foreach (var c in countries)
            {
                countriesDto.Add(new CountryDto
                {
                    Id = c.CountryId,
                    Name = c.Name
                });
            }
            return Ok(countriesDto);

        }

        //api/countries/id
        [HttpGet("{countryId}",Name = "GetCountry")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CountryDto))]
        public IActionResult GetCountry(int countryId)
        {
            if (!_countryRepository.CountryExist(countryId))
            {
                return NotFound();
            }
            var c = _countryRepository.GetCountry(countryId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var countriesDto = new CountryDto() { Id = c.CountryId, Name = c.Name };

            return Ok(countriesDto);

        }
        //api/countries/author/authorid
        [HttpGet("authors/{authorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CountryDto))]
        public IActionResult GetCountryOfAuthor(int authorId)
        {
            // valid the author id , check the country within the author obj, return country obj
            var c = _countryRepository.GetCountryOfAuthor(authorId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var countriesDto = new CountryDto() { Id = c.CountryId, Name = c.Name };

            return Ok(countriesDto);

        }

        //to do get  GetAuthorsFromCountry
        //api/countries/countryId/authors
        [HttpGet("{countryId}/authors")]
        public IActionResult GetAuthorsFromCountry(int countryId)
        {
            if (!_countryRepository.CountryExist(countryId))
            {
                return NotFound();
            }
            var authors = _countryRepository.GetAuthorsFromCountry(countryId);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(authors);
        }

        //api/countries
        [HttpPost]
        public IActionResult CreateCountry([FromBody]Country country)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var existingCountry = _countryRepository.GetCountries()
                .Where(c => c.Name.ToLower() == country.Name.ToLower())
                .FirstOrDefault();

            if (existingCountry != null)
            {
                ModelState.AddModelError("", $"country name {country.Name} already exists");
                return StatusCode(422, ModelState);
            }

            if(!_countryRepository.CreateCountry(country))
            {
                ModelState.AddModelError("", $"country{country.Name} fail to create");
                return StatusCode(422, ModelState);

            }

            return CreatedAtRoute("GetCountry", new { CountryId = country.CountryId },country);

        }
        //api/countries
        [HttpPut("{countryId}")]
        public IActionResult UpdateCountry(int countryId,[FromBody]Country country)
        {
            if (country == null)
            {
                return BadRequest(ModelState);
            }
            if (countryId != country.CountryId)
            {
                return BadRequest(ModelState);

            }


            var existingCountry = _countryRepository.GetCountries()
              .Where(c => c.Name.ToLower() == country.Name.ToLower() && c.CountryId!=country.CountryId)
              .FirstOrDefault();

            if (existingCountry!=null)
            {
                ModelState.AddModelError("", $"country name {country.Name} already exists");
                return StatusCode(422, ModelState);
            }

            if (!_countryRepository.UpdateCountry(country))
            {
                ModelState.AddModelError("", $"country{country.Name} fail to update");
                return StatusCode(422, ModelState);

            }
            return NoContent();
        }

        [HttpDelete("{countryId}")]
        public IActionResult DeleteCountry(int countryId)
        {
            if (!_countryRepository.CountryExist(countryId))
            {
                return NotFound();
            }

            var country = _countryRepository.GetCountry(countryId);
            //if (_countryRepository.GetAuthorsFromCountry(countryId).Count()>0)
            //{
            //    ModelState.AddModelError("", $"something went wrong {country.Name} ");
            //    return StatusCode(500, ModelState);

            //}
            if (!_countryRepository.DeleteCountry(country))
            {
                ModelState.AddModelError("", $"country{country.Name} fail to delete");
                return StatusCode(422, ModelState);

            }

            return NoContent();
        }




    }
}
