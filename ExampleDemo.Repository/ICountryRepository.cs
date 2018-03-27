using ExampleDemo.Model;
using ExampleDemo.Repository.Common;

namespace ExampleDemo.Repository
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Country GetById(int? id);
    }
}
