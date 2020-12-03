using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudClientProd.Context;
using CrudClientProd.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientProd.Controllers
{
    public class ClientController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public ClientController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            List<Client> clients = _appDbContext.client.ToList();
            return View(clients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Client client = new Client();
            return View(client);
        }

        [HttpPost]
        public IActionResult Create(Client client)
        {
            //Verifica se todos os campos estão preenchidos
            if (ModelState.IsValid)
            {
                _appDbContext.client.Add(client);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Client client = _appDbContext.client.Find(Id);
            if(client != null)
            {

            }
            return View(client);
        }

        [HttpPost]
        public IActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.client.Update(client);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(client);
            }
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Client client = _appDbContext.client.Find(Id);
            return View(client);
        }

        [HttpPost]
        public IActionResult Delete(Client client)
        {
            Client _client = _appDbContext.client.Find(client.Id);
            if (_client != null)
            {
                _appDbContext.client.Remove(_client);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(_client);
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Client client = _appDbContext.client.Find(Id);
            return View(client);
        }
    }
}
