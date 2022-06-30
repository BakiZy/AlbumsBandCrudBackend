using Microsoft.EntityFrameworkCore;
using System.Linq;
using ZavrsniTest.Interfaces;
using ZavrsniTest.Models;

namespace ZavrsniTest.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly AppDbContext _context;

        public AlbumRepository(AppDbContext context)
        {
            this._context = context;
        }

        public void Add(Album album)
        {
            _context.Albums.Add(album);
            _context.SaveChanges();
        }

        public void Delete(Album album)
        {
            _context.Albums.Remove(album);
            _context.SaveChanges();
        }

        public Album Get(int id)
        {
           return _context.Albums.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Album> GetAll()
        {
            return _context.Albums.OrderBy(x => x.Name).AsQueryable();
        }

        public void Update(Album album)
        {
            _context.Entry(album).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
