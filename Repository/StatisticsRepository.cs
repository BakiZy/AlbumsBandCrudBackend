using System.Collections.Generic;
using System.Linq;
using ZavrsniTest.Interfaces;
using ZavrsniTest.Models;
using ZavrsniTest.Models.DTO;

namespace ZavrsniTest.Repository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly AppDbContext _context;

        public StatisticsRepository(AppDbContext context)
        {
            this._context = context;
        }

        public IQueryable<Band> SearchBandByName(string name)
        {


            return _context.Bands.Where(band => band.Name.Contains(name)).OrderBy(band => band.YearCreate).ThenByDescending(band => band.Name);
        }
        public IQueryable<Band> Granica()
        {
            return null;
        }


        public IQueryable<Album> SearchAlbumByName(string name)
        {
            return _context.Albums.Where(x => x.Name == name).OrderByDescending(x => x.NumberOfSales);
        }

        public IQueryable<Album> SearchByYear(int yearMin, int yearMax)
        {
            return _context.Albums.Where(x => x.YearPublish > yearMin && x.YearPublish <= yearMax).OrderByDescending(x => x.YearPublish);
        }

        public List<BandAlbumPublishDTO> Brojnost()
        {

            return _context.Bands.GroupBy(x => x.Id).Select(x =>
           new BandAlbumPublishDTO()
           {
               Band = _context.Bands.Where(band => band.Id == x.Key).Select(x => x.Name).Single(),
               NumberOfAlbums = _context.Albums.Where(a => a.BandId == x.Key).Count(),
           }).OrderByDescending(x => x.NumberOfAlbums).ToList();
        }

        public List<BandsTotalAlbumSaleDTO> Granica(int salesMin)
        {

            return _context.Bands.GroupBy(x => x.Id).Select(x => 
            new BandsTotalAlbumSaleDTO()
            {
                Band = _context.Bands.Where(band => band.Id == x.Key).Select(x => x.Name).Single(),
                AlbumSalesByBand = _context.Albums.Where(a => a.BandId == x.Key).Select(a => a.NumberOfSales).Sum(),
                TotalAlbumSales = _context.Albums.Where(a => a.NumberOfSales > salesMin).Select(a => a.NumberOfSales).Sum(),

            }).OrderByDescending(x => x.Band).ToList();


        }
    }
}
