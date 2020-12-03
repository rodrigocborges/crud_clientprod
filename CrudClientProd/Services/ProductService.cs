using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudClientProd.Context;
using CrudClientProd.Models;

namespace CrudClientProd.Services
{
    public class ProductService
    {
        private readonly AppDbContext _appDbContext;
        public ProductService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Product> List()
        {
            return _appDbContext.product.ToList();
        }

        public void Create(Product product)
        {
            try
            {
                _appDbContext.product.Add(product);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Edit(Product product)
        {
            try
            {
                _appDbContext.product.Update(product);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Delete(Product product)
        {
            try
            {
                Product _product = _appDbContext.product.Find(product.Id);
                if (_product != null)
                {
                    _appDbContext.product.Remove(_product);
                    _appDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Product Details(int Id)
        {
            return _appDbContext.product.Find(Id);
        }
    }
}
