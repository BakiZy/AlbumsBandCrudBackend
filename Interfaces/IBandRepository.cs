using System.Linq;
using ZavrsniTest.Models;

namespace ZavrsniTest.Interfaces
{
    public interface IBandRepository
    {
        public IQueryable<Band> GetAll();

        Band Get(int id);

        void Delete(Band band);

        void Add(Band band);



    }
}
