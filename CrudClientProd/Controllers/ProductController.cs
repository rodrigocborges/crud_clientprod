using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudClientProd.Context;
using CrudClientProd.Models;
using CrudClientProd.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientProd.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ProductService _productService;

        public ProductController(AppDbContext appDbContext, ProductService productService)
        {
            _appDbContext = appDbContext;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(_productService.List());
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
                _productService.Create(product);
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
                _productService.Edit(product);
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
            _productService.Delete(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            return View(_productService.Details(Id));
        }
    }
}
