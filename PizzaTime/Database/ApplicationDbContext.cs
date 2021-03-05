using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PizzaTime.Model;

namespace PizzaTime.Database
{
    class ApplicationDbContext :DbContext
    {
        private const string DatabaseName = "PizzaTime";

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Meat> Meats { get; set; }

        public DbSet<Dough> Doughs { get; set; }
        public DbSet<Top> Toppings { get; set; }

        public DbSet<Vegetable> Vegetables { get; set; }
        public DbSet<Vego> Vegos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            optionsbuilder.UseSqlServer($@"Server= .\SQLEXPRESS;Database={DatabaseName}; trusted_connection=true");

        }


      
   
    }
}
