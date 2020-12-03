using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudClientProd.Context;
using CrudClientProd.Models;

namespace CrudClientProd.Services
{
    public class ClientService
    {
        private readonly AppDbContext _appDbContext;
        public ClientService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Client> List()
        {
            return _appDbContext.client.ToList();
        }

        public void Create(Client client)
        {
            try
            {
                _appDbContext.client.Add(client);
                _appDbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Edit(Client client)
        {
            try
            {
                _appDbContext.client.Update(client);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Delete(Client client)
        {
            try
            {
                Client _client = _appDbContext.client.Find(client.Id);
                if (_client != null)
                {
                    _appDbContext.client.Remove(_client);
                    _appDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Client Details(int Id)
        {
            return _appDbContext.client.Find(Id);
        }
    }
}
