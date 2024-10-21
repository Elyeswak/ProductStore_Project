using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PS.Domain;
using PS.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PS.Web.Controllers
{
    public class ProductController : Controller
    {
       private readonly IProductService productService;
       private readonly ICategoryService categoryService;
        

        public ProductController(IProductService ips, ICategoryService ics)
        {
            productService = ips;
            categoryService = ics;
        }
        
        // GET: ProductController
        public ActionResult Index()
        {
            return View(productService.GetMany());
        }

        public ActionResult Index2()
        {
            return View(productService.GetMany().ToList()); ;
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View(productService.GetById(id));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var categories = categoryService.GetMany();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name");
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product p, IFormFile file)
        {
            p.Image = file.FileName;
            if (file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",
                file.FileName);
                using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            productService.Add(p);
            productService.Commit();
            return RedirectToAction("Index");
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            if (productService.GetById(id) == null)
            {
                return NotFound();
            }
            var categories = categoryService.GetMany();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name");
            return View(productService.GetById(id));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product p)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    productService.Update(p);
                    productService.Commit();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    var categories = categoryService.GetMany();
                    ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name");
                    return View(p);
                }
            }
            ViewBag.CategoryId = new SelectList(categoryService.GetMany(), "CategoryId","Name");
            return View(p);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            if (productService.GetById(id) == null)
            {
                return NotFound();
            }
            return View(productService.GetById(id));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product p)
        {
            try
            {
                productService.Delete(p);
                productService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(p);
            }
        }

        // POST: Product/Index
        [HttpPost]
        public ActionResult Index(string filter)
        {
            var list = productService.GetMany();
            if (!String.IsNullOrEmpty(filter))
            {
                list = list.Where(p => p.Name.ToString().Equals(filter)).ToList();
            }
            return View(list);
        }
    }
}
