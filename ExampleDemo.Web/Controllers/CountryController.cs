using System.Web.Mvc;
using ExampleDemo.Model;
using ExampleDemo.Repository;
using ExampleDemo.Repository.Common;
using ExampleDemo.Service;

namespace ExampleDemo.Web.Controllers
{
    public class CountryController : Controller
    {
        private ICountryService _countryService;
        private IUnitOfWork _unitOfWork;
        private ICountryRepository _countryRepository;
        private ExampleDemoDbContext _context;

        public CountryController()
        {
            _context = new ExampleDemoDbContext();
            _unitOfWork = new UnitOfWork(_context);
            _countryRepository = new CountryRepository(_context);
            _countryService = new CountryService(_unitOfWork, _countryRepository);
        }
        // GET: Country
        public ActionResult Index()
        {
            var countries = _countryService.GetAll();
            return View(countries);
        }

        // GET: Country/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Country/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Country/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
