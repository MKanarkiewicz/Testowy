using ICollege_WebApp.DAL;
using ICollege_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICollege_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private ICollegeDbContext context = new ICollegeDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            GenerateData generateData = new GenerateData();

            //Address address = generateData.RandomAddress();
            Student student = generateData.RandomPerson();

            ViewBag.ID = student.ID;
            ViewBag.Imie = student.FirstName;
            ViewBag.Nazwisko = student.LastName;
            ViewBag.Pesel = student.Pesel;
            ViewBag.DataUrodzenia = student.DateBirth;
            ViewBag.Ulica = student.Address.Street;
            ViewBag.Numer = student.Address.Number;
            ViewBag.Kod = student.Address.ZipCode;
            ViewBag.Miasto = student.Address.Town;
            ViewBag.Login = student.Login.Mail;
            ViewBag.Haslo = student.Login.Password;

            return View();
        }
    }
}