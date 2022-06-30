using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZavrsniTest.Interfaces;
using ZavrsniTest.Models;
using ZavrsniTest.Models.DTO;

namespace ZavrsniTest.Controllers
{
    [AllowAnonymous]
    [Route("api/albumi")]
    [Produces("application/json")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumRepository _albumRepository;

        private readonly IMapper _mapper;

        public AlbumsController(IAlbumRepository albumRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAlbums()
        {
            return Ok(_albumRepository.GetAll().ProjectTo<AlbumDTO>(_mapper.ConfigurationProvider));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public IActionResult GetAlbum(int id)
        {
           var album = _albumRepository.Get(id);
            if (album == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<AlbumDTO>(album));
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteAlbum(int id)
        {
            var album = _albumRepository.Get(id);

            if(album == null)
            {
                return NotFound();
            }

            
                _albumRepository.Delete(album);
            
           


            return NoContent();
        }

        [HttpPost]

        public IActionResult PostAlbum(Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _albumRepository.Add(album);
            return CreatedAtAction("GetAlbum", new { id = album.Id }, album);
        }

        [HttpPut("{id}")]

        public IActionResult PutAlbum(int id, Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != album.Id)
            {
                return BadRequest();
            }

            try
            {
                _albumRepository.Update(album);
            }
            catch
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<AlbumDTO>(album));
        }

        

    }
}
