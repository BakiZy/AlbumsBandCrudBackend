using System.Linq;
using ZavrsniTest.Interfaces;
using ZavrsniTest.Models;

namespace ZavrsniTest.Repository
{
    public class BandRepository : IBandRepository
    {
        private readonly AppDbContext _context;

        public BandRepository(AppDbContext context)
        {
            this._context = context;
        }

        public void Add(Band band)
        {
            _context.Bands.Add(band);
            _context.SaveChanges();
        }

        public void Delete(Band band)
        {
           _context.Bands.Remove(band);
            _context.SaveChanges();
        }

        public Band Get(int id)
        {
           return _context.Bands.FirstOrDefault(b => b.Id == id);
        }

        public IQueryable<Band> GetAll()
        {

            return _context.Bands.AsQueryable();
        }

        
    }
}
