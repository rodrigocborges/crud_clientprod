using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudClientProd.Models;

namespace CrudClientProd.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Client> client { get; set; }
        public DbSet<Product> product { get; set; }
        //Classe responsável por administrar as entidades e persistir dados para o banco de dados
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
