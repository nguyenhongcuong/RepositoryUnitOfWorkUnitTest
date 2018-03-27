using ExampleDemo.Model;
using ExampleDemo.Repository.Common;

namespace ExampleDemo.Repository
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Person GetById(long? id);
    }
}
