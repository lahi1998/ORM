using Microsoft.AspNetCore.Mvc;
using ORM.Models;
using System.Linq;

namespace ORM.Controllers
{
    public class PersonController : Controller
    {
        private readonly OrmContext _context;

        public PersonController(OrmContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var people = _context.People.ToList();
            return View(people);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(person);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        public IActionResult Edit(int id)
        {
            var person = _context.People.FirstOrDefault(p => p.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.People.Update(person);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        public IActionResult Delete(int id)
        {
            var person = _context.People.FirstOrDefault(p => p.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var person = _context.People.FirstOrDefault(p => p.PersonId == id);
            if (person != null)
            {
                _context.People.Remove(person);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
