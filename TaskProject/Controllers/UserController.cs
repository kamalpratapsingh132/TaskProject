using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProject.Models;

namespace TaskProject.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDBContext context;

        public UserController(ApplicationDBContext _Context)
        {
            context = _Context;
        }


        public IActionResult Index()
        {
           


            var emp = context.User.ToList();
            var cits = context.City.ToList();
            ViewBag.cits = cits;
            var zip = context.City.ToList();
            ViewBag.Zip = zip;
            return View(emp);
        }

        public IActionResult Create()
        {
            var cits = context.City.ToList();
            ViewBag.cits = cits;
            var zip = context.City.ToList();
            ViewBag.Zip = zip;
            
            return View();
        }

        [HttpPost]

        public IActionResult Create(UserModel model)

        {
            
            string nn = model.CityName;
            var cept = context.City.SingleOrDefault(e => e.CityName == nn);      
            int ID = model.ZipCode;
            var Zipt = context.City.SingleOrDefault(e => e.Zipcode == ID);


            User use = new User()
            {
                Name = model.Name,
                Zipcode = Zipt ,
                CityName = cept

            };
            context.User.Add(use);
            context.SaveChanges();
            return RedirectToAction("Create");

        }



        public JsonResult BindZip(string term)
        {
            SelectList City = new SelectList(this.context.City.ToList(), "CityId", "ZipCode");
            return Json(new { items = this.context.City.Select(a => new { text = a.Zipcode, id = a.ID }).ToList() });
        }




        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            var Use = (from City in context.City
                       where City.CityName.StartsWith(prefix)
                       select new
                       {
                           label = City.CityName,
                           var = City.ID

                       }).ToList();
            return Json(Use);
            
        }



        [HttpPost]
        public JsonResult AutoZipComplete(string prefix)
        {
            var Use = (from City in context.City
                       where City.Zipcode.ToString().StartsWith(prefix)
                       select new
                       {
                           label = City.Zipcode,
                           var = City.ID

                       }).ToList();
            return Json(Use);

        }

    }
}
