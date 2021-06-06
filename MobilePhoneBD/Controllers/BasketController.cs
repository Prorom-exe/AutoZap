using Microsoft.AspNetCore.Mvc;
using MobilePhoneBD.Data;
using MobilePhoneBD.Models;
using MobilePhoneBD.Models.ViewMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilePhoneBD.Controllers
{
    public class BasketController:Controller
    {
        ApplicationDbContext db;

        public BasketController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index(int? catId, int? manId)
        {
            var ids = db.Baskets.Where(x => x.Quality != 0).Select(x => x.ProductId).ToList();
            var product = db.Products.Where(x => ids.Contains(x.Id));
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
                Products = product.ToList(),
                Category = db.Category.ToList(),
            };
            decimal buySum = 0;
            foreach (var t in model.Products)
            {
                var bas = db.Baskets.FirstOrDefault(x => x.ProductId == t.Id);
                t.Quality = bas.Quality;
                buySum += t.Quality * t.Price;
            }
            ViewBag.Sum = buySum;
            return View(model);
        }

        public IActionResult Add(int id, int quantity)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            if(product == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var basket = new Basket();
            basket.ProductId = id;
            if(quantity > product.Quality)
            {
                basket.Quality = product.Quality;
            }
            else
            {
                basket.Quality = quantity;
            }
            product.Quality = product.Quality - basket.Quality;
            db.Products.Update(product);
            db.Baskets.Add(basket);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            var basket = db.Baskets.FirstOrDefault(x => x.ProductId == id);
            if(basket == null)
            {
                return RedirectToAction("Index");
            }
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            product.Quality += basket.Quality;
            db.Baskets.Remove(basket);
            db.Products.Update(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Buy()
        {
            var basket = db.Baskets.ToList();
            db.Baskets.RemoveRange(basket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
