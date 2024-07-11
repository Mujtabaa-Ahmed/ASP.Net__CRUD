using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CrudContext bd;

        public HomeController(CrudContext a)
        {
            this.bd = a;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ADD()
        {
            ViewBag.Department = new SelectList(bd.Departments, "DId", "Department1");
            return View();
        }
        public IActionResult adding(Employee b)
        {
            bd.Add(b);
            bd.SaveChanges();
            return RedirectToAction(nameof(ADD));
        }
        public IActionResult edit(int? Id)
        {
            return View(bd.Employees.Find(Id));
        }
        public IActionResult delete(int? Id)
        {
            var del = bd.Employees.FirstOrDefault(d => d.Id == Id);
            bd.Remove(del);
            bd.SaveChanges();
            return RedirectToAction(nameof(show));
        }
            public IActionResult update(Employee e)
        {
            bd.Update(e);
            bd.SaveChanges();
            return RedirectToAction(nameof(show));
        }
        public IActionResult show()
        {
            return View(bd.Employees.ToList());
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}