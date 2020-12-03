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
    public class ClientController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ClientService _clientService;
        public ClientController(AppDbContext appDbContext, ClientService clientService)
        {
            _appDbContext = appDbContext;
            _clientService = clientService;
        }

        public IActionResult Index()
        {
            return View(_clientService.List());
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
                _clientService.Create(client);
                return RedirectToAction("Index");
            }
            return View(client);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Client client = _appDbContext.client.Find(Id);
            return View(client);
        }

        [HttpPost]
        public IActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                _clientService.Edit(client);
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
            _clientService.Delete(client);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            return View(_clientService.Details(Id));
        }
    }
}
