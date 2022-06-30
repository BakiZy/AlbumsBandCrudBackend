using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZavrsniTest.Interfaces;
using ZavrsniTest.Models.DTO;

namespace ZavrsniTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsRepository _statisticsRepository;

        private readonly IMapper _mapper;

        public StatisticsController(IStatisticsRepository statsRepo, IMapper mapper)
        {
            _statisticsRepository = statsRepo;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("/api/bendovi/trazi")]
        public IActionResult SearchBandByname([FromQuery]SearchBandByNameDTO searchBandByNameDTO)
        {
            return Ok(_statisticsRepository.SearchBandByName(searchBandByNameDTO.Name));
        }

        [HttpGet]
        [Route("/api/albumi/trazi")]

        public IActionResult SearchAlbumByName([FromQuery]SearchAlbumByNameDTO searchAlbumByNameDTO)
        {
            return Ok(_statisticsRepository.SearchAlbumByName(searchAlbumByNameDTO.Name).ProjectTo<AlbumDTO>(_mapper.ConfigurationProvider));
        }

        [HttpPost]
        [Route("/api/pretraga")]
        public IActionResult SearchByYear(int yearMin, int yearMax)
        {
            return Ok(_statisticsRepository.SearchByYear(yearMin,yearMax).ProjectTo<AlbumDTO>(_mapper.ConfigurationProvider));
        }

        [HttpGet]
        [Route("/api/brojnost")]
        public IActionResult GetAlbumSalesByBand()
        {
            return Ok(_statisticsRepository.Brojnost());

        }

        [HttpGet]
        [Route("/api/prodaja")]

        public IActionResult Prodaja([FromQuery]int granica)
        {
            return Ok(_statisticsRepository.Granica(granica));
        }
    }
}
