using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobilePhoneBD.Data;
using MobilePhoneBD.Models;
using MobilePhoneBD.Models.ViewMode;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MobilePhoneBD.Controllers
{
    public class HomeController : Controller
    {
       
        private ApplicationDbContext db;
        IWebHostEnvironment _appEnvironment;

        public HomeController(ApplicationDbContext db, IWebHostEnvironment appEnvironment)
        {
            this.db = db;
            _appEnvironment = appEnvironment;
        }

        public  IActionResult Index(int? catId, int? manId,IndexViewModel model1)
        {
            if(model1.Count == 0)
            {
                model1.Count = 15;
            }
            var product = db.Products.AsQueryable();
            if (catId != null)
            {
                product = product.Where(x => x.AutoId == catId);
            }
            if (manId != null)
            {
                product = product.Where(x => x.ZapId == manId);
            }
            IndexViewModel model = new IndexViewModel
            {
                Products = product.Take(model1.Count).ToList(),
                Category = db.Category.ToList(),
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateViewModel model = new CreateViewModel
            {
                Category = db.Category.ToList()
            };
            return View(model);
        }


        [HttpGet]
        public IActionResult CreateCat()
        {
            CreateViewModel model = new CreateViewModel
            {
                Category = db.Category.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateCat(IndexViewModel model)
        {
            var cat = new Auto
            {
                Name = model.CreateViewModel.NewCat
            };
            db.Category.Add(cat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CreateMan(IndexViewModel model)
        {
           var man = new Zap
           {
               Name = model.CreateViewModel.NewMan,
               AutoId = model.CreateViewModel.CatId
           };
            db.Мanufacturers.Add(man);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            
            string path = " ";
            if (model.UploadedFile != null)
            {
                // путь к папке Files
                 path = "/Files/" + model.UploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await model.UploadedFile.CopyToAsync(fileStream);
                }
                
            }
            Products product = new Products
            {
                Name = model.Name,
                Description = model.Description,
                AutoId = model.CatId,
                ZapId = model.ManId,
                Price = model.Price,
                Quality = model.Quality,
                Link = path
            };
            db.Products.Add(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
       
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var prod = db.Products.Find(id);
            EditViewModel model = new EditViewModel 
            { 
                Id = prod.Id,
                Name = prod.Name,
                Description = prod.Description,
                Price = prod.Price,
                Quality = prod.Quality
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel model)
        {
            var prod = db.Products.Find(model.Id);
            prod.Name = model.Name;
            prod.Description = model.Description;
            prod.Price = model.Price;
            prod.Quality = model.Quality;
            string path;
            if (model.File != null)
            {
                // путь к папке Files
                path = "/Files/" + model.File.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await model.File.CopyToAsync(fileStream);
                }
                prod.Link = path;
            }
            db.Products.Update(prod);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
