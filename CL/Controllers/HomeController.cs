using CL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CL.Controllers
{ 
    public class HomeController : Controller
    {
        ContactsContext db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ContactsContext context)
        {
            _logger = logger;
            db = context;
        }

        public async Task<IActionResult> IndexAsync(string searchString)
        {
            ContactsPeople people = new ContactsPeople();
            var search = from m in db.ContactsPeople
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                search = search.Where(s => s.Name.Contains(searchString) || s.Surname.Contains(searchString)
                || s.Middlename.Contains(searchString) || s.PhoneNumber.Contains(searchString)
                || s.Birthdate.Contains(searchString) || s.Organization.Contains(searchString)
                || s.Post.Contains(searchString) || s.Email.Contains(searchString)
                || s.Skype.Contains(searchString) || s.Other.Contains(searchString));
            }
            return View(await search.ToListAsync());
 
        }
        //Поиск по всем полям
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            
            return "Контакта с полем: " + searchString +" не найдено";
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                ContactsPeople user = await db.ContactsPeople.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ContactsPeople user)
        {
            if (ModelState.IsValid)
            {
                db.ContactsPeople.Update(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(user);
        }
        //Редактирование контакта
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ContactsPeople user)
        {
            
            db.ContactsPeople.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        //Добавление контакта
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                ContactsPeople user = await db.ContactsPeople.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        //Подтверждение удаления
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                ContactsPeople user = await db.ContactsPeople.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                {
                    db.ContactsPeople.Remove(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
        //Удаление
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
