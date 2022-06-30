using System.Linq;
using ZavrsniTest.Models;

namespace ZavrsniTest.Interfaces
{
    public interface IAlbumRepository
    {
        public IQueryable<Album> GetAll();

        Album Get(int id);


        void Add(Album album);

        void Update(Album album);

        void Delete(Album album);
    }
}
