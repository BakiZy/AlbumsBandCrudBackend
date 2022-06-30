using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZavrsniTest.Interfaces;
using ZavrsniTest.Models;

namespace ZavrsniTest.Controllers
{   
    [AllowAnonymous]
    [Route("api/bendovi")]
    [Produces("application/json")]
    [ApiController]
    public class BandsController : ControllerBase
    {
        private readonly IBandRepository _bandRepository;

        private readonly IMapper _mapper;

        public BandsController(IBandRepository bandRepository, IMapper mapper)
        {
            _bandRepository = bandRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBands()
        {
            return Ok(_bandRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetBand(int id)
        {
            var band = _bandRepository.Get(id);

            if (band == null)
            {
                return NotFound();
            }
            return Ok(band);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteBand(int id)
        {
            var band = _bandRepository.Get(id);

            if (band == null)
            {
                return NotFound();
            }

            _bandRepository.Delete(band);
            return NoContent();
        }

        [HttpPost]

        public IActionResult PostBand(Band band)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _bandRepository.Add(band);

            return CreatedAtAction("GetBand", new { id = band.Id });
        }

    }
}
