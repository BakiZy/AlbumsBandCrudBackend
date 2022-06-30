using System.Collections.Generic;
using System.Linq;
using ZavrsniTest.Models;
using ZavrsniTest.Models.DTO;

namespace ZavrsniTest.Interfaces
{
    public interface IStatisticsRepository
    {
        public IQueryable<Band> SearchBandByName(string name);

        public IQueryable<Album> SearchAlbumByName(string name);

        public IQueryable<Album> SearchByYear(int yearMin, int yearMax);

        public List<BandAlbumPublishDTO> Brojnost();

        public List<BandsTotalAlbumSaleDTO> Granica(int salesMin);
    }
}
