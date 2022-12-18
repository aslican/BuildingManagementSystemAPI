using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ContextDb
{
    public class BMSContextDb:DbContext
    {
        private readonly IConfiguration _configuration; 
        public BMSContextDb(IConfiguration configuration) 
        { _configuration = configuration; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            base.OnConfiguring(optionsBuilder.UseSqlServer(connectionString)); ;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Message> Messages { get; set; }

    }

}
