using ExampleDemo.Model;
using ExampleDemo.Repository;
using ExampleDemo.Repository.Common;
using ExampleDemo.Service.Common;

namespace ExampleDemo.Service
{
    public class PersonService : EntityService<Person>, IPersonService
    {
        private IUnitOfWork _unitOfWork;
        private IPersonRepository _personRepository;
        public PersonService(IUnitOfWork unitOfWork, IPersonRepository repository) : base(unitOfWork, repository)
        {
            _unitOfWork = unitOfWork;
            _personRepository = repository;
        }

        public Person GetById(long? id)
        {
            return _personRepository.GetById(id);
        }
    }
}
