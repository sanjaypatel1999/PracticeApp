using ApplicationName.Data;
using ApplicationName.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ApplicationName.Controllers
{
    public class UploadController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IHostingEnvironment environment;

        public UploadController(ApplicationDbContext context,IHostingEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        [HttpGet]
        public IActionResult UploadImage()
        {
            return View();
        }
        
      [HttpPost]
      public IActionResult UploadImage(ImageCreateModel model)
      {

          if (ModelState.IsValid)
          {
                var path = environment.WebRootPath;
              var filePath = "Content/Image/" + model.ImagePath.FileName;
              var fullPath=Path.Combine(path, filePath);
              UploadFile(model.ImagePath, fullPath);
               /* 
                var data = new Image()
                {
                    Name = model.Name,
                    ImagePath = filePath
                };

                context.Add(data);
                */
                context.SaveChanges();
                return RedirectToAction("Index");
          }
          else
          {
              return View(model);
          }
          
    }
        // create a uplaodfile method
        public void UploadFile(IFormFile file,string path)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
        }
        
        public IActionResult Index()
        {
            var data=context.Images.ToList();
            return View(data);
        }
    }
}
