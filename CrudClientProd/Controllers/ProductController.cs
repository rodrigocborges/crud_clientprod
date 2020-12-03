using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudClientProd.Context;
using CrudClientProd.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientProd.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;
        
        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            List<Product> products = _appDbContext.product.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            //Verifica se todos os campos estão preenchidos
            if (ModelState.IsValid)
            {
                _appDbContext.product.Add(product);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Product product = _appDbContext.product.Find(Id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.product.Update(product);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Product product = _appDbContext.product.Find(Id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            Product _product = _appDbContext.product.Find(product.Id);
            if (_product != null)
            {
                _appDbContext.product.Remove(_product);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(_product);
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Product product = _appDbContext.product.Find(Id);
            return View(product);
        }
    }
}
