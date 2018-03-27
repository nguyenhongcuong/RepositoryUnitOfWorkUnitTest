using ExampleDemo.Model;
using ExampleDemo.Service.Common;

namespace ExampleDemo.Service
{
    public interface ICountryService : IEntityService<Country>
    {
        Country GetById(int? id);
    }
}
