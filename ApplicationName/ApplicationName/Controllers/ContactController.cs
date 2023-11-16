using ApplicationName.Data;
using ApplicationName.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationName.Controllers
{
    public class ContactController : Controller
    {

        private readonly ApplicationDbContext context;

        public ContactController(ApplicationDbContext context)
        {

            this.context = context;


        }
        public IActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ContactUs(Contact contact)
        {
            contact.IsActive = true;
            context.Contacts.Add(contact);
            context.SaveChanges();
           

            return View();
        }
    }
}
