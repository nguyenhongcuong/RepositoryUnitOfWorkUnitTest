using System.Diagnostics.Eventing.Reader;
using ExampleDemo.Model;
using ExampleDemo.Service.Common;

namespace ExampleDemo.Service
{
    public interface IPersonService : IEntityService<Person>
    {
        Person GetById(long? id);
    }
}
