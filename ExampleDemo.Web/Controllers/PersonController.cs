using System.Net;
using System.Web.Mvc;
using ExampleDemo.Model;
using ExampleDemo.Service;

namespace ExampleDemo.Web.Controllers
{
    public class PersonController : Controller
    {
        private IPersonService _personService;
        private ICountryService _countryService;

        public PersonController(IPersonService personService, ICountryService countryService)
        {
            _personService = personService;
            _countryService = countryService;
        }
        // GET: Person
        public ActionResult Index()
        {
            var persons = _personService.GetAll();
            return View(persons);
        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var person = _personService.GetById(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            SetDropDownList();
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _personService.Create(person);
                return RedirectToAction("Index");
            }
            SetDropDownList(person.CountryId);
            return View(person);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _personService.GetById(id);
            if (person == null)
            {
                return HttpNotFound();
            }

            SetDropDownList();
            return View(person);
        }

        // POST: Person/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                _personService.Update(person);
                return RedirectToAction("Index");
            }

            SetDropDownList(person.CountryId);
            return View(person);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var person = _personService.GetById(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Person/Delete/5
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var person = _personService.GetById(id);
            _personService.Delete(person);
            return RedirectToAction("Index");
        }

        private void SetDropDownList(object countrySelected = null)
        {
            var countries = _countryService.GetAll();
            ViewBag.CountryId = new SelectList(countries, "Id", "Name", countrySelected);
        }
    }
}
