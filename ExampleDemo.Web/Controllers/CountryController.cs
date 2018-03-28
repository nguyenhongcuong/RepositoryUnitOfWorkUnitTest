using System.Web.Mvc;
using ExampleDemo.Model;
using ExampleDemo.Service;

namespace ExampleDemo.Web.Controllers
{
    public class CountryController : Controller
    {
        private ICountryService _countryService;
        //private IUnitOfWork _unitOfWork;
        //private ICountryRepository _countryRepository;
        //private ExampleDemoDbContext _context;

        public CountryController(ICountryService countryService)
        {
            //_context = new ExampleDemoDbContext();
            //_unitOfWork = new UnitOfWork(_context);
            //_countryRepository = new CountryRepository(_context);
            //_countryService = new CountryService(_unitOfWork, _countryRepository);
            _countryService = countryService;
        }
        // GET: Country
        public ActionResult Index()
        {
            var countries = _countryService.GetAll();
            return View(countries);
        }

        // GET: Country/Details/5
        public ActionResult Details(int? id)
        {
            var country = _countryService.GetById(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Country country)
        {
            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                _countryService.Create(country);
                return RedirectToAction("Index");
            }
            return View(country);
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int? id)
        {
            var country = _countryService.GetById(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Country/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                _countryService.Update(country);
                return RedirectToAction("Index");
            }
            return View(country);
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            var country = _countryService.GetById(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Country/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var country = _countryService.GetById(id);
            _countryService.Delete(country);
            return RedirectToAction("Index");
        }
    }
}
