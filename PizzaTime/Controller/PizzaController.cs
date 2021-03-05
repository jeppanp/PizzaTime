using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PizzaTime.Database;
using PizzaTime.Model;

namespace PizzaTime.Controller
{
    class PizzaController
    {
        public static void CreateRandomPizza(string pizzname)
        {
            var myPizza = CreatePizza(pizzname);

            myPizza = AddMeat(myPizza, NewId("Meats"));
            myPizza = AddDough(myPizza, NewId("Doughs"));
            myPizza = AddTop(myPizza, NewId("Toppings"));
            myPizza = AddVegteble(myPizza, NewId("Vegetables"));
            myPizza = AddVego(myPizza, NewId("Vegos"));
            
        }

        private static int NewId(string input)
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Meats.FromSqlRaw($"Select Top 1 * from {input} Order By NewId()");


                return query.First().Id;
            }
        }

        private static Pizza AddVego(Pizza pizza, int id)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Attach(pizza);
                var vego = db.Vegos.FirstOrDefault(v => v.Id == id);

                if (pizza.Vegos == null) pizza.Vegos = new List<Vego>();

                pizza.Vegos.Add(vego);

                db.Pizzas.Update(pizza);
                db.SaveChanges();

                return pizza;

            }
        }

        private static Pizza AddVegteble(Pizza pizza, int id)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Attach(pizza);
                var vegtebeles = db.Vegetables.FirstOrDefault(v => v.Id == id);

                if (pizza.Vegetables == null) pizza.Vegetables = new List<Vegetable>();

                pizza.Vegetables.Add(vegtebeles);

                db.Update(pizza);
                db.SaveChanges();

                return pizza;
            }
        }

        private static Pizza AddTop(Pizza pizza, int id)
        {

            using (var db = new ApplicationDbContext())
            {
                db.Attach(pizza);
                var myTopping = db.Toppings.FirstOrDefault(t => t.Id == id);

                if (pizza.Toppings == null) pizza.Toppings = new List<Top>();

                pizza.Toppings.Add(myTopping);

                db.Pizzas.Update(pizza);
                db.SaveChanges();

                return pizza;
            }
        }

        private static Pizza CreatePizza(string name)
        {

            using (var db = new ApplicationDbContext())
            {
                var pizza = db.Pizzas.FirstOrDefault(p => p.Name == name);
                if (pizza == null)
                {
                    pizza = new Pizza();
                    pizza.Name = name;
                    db.Pizzas.Add(pizza);
                    db.SaveChanges();
                }

                return pizza;
            }

        }

        private static Pizza AddDough(Pizza pizza, int id)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Attach(pizza);
                var dough = db.Doughs.FirstOrDefault(p => p.Id == id);

                if (pizza.Doughs == null) pizza.Doughs = new List<Dough>();

                pizza.Doughs.Add(dough);

                db.Pizzas.Update(pizza);
                db.SaveChanges();
            }
            return pizza;
        }
        public static void WriteOutPizza()
        {
            using (var db = new ApplicationDbContext())
            {
                foreach (var pirre in db.Pizzas.Include("Meats").Include("Doughs").Include("Toppings").Include("Vegetables").Include("Vegos"))
                {
                    Console.WriteLine($"pizza: {pirre.Name}");

                    {
                        Console.Write("Meat: ");
                        foreach (var meats in pirre.Meats)
                        {
                            Console.Write($"{meats.Decsription},");
                        }
                        Console.Write("\nDough: ");
                        foreach (var dough in pirre.Doughs)
                        {
                            Console.Write($"{dough.Decsription} ");
                        }
                        Console.Write("\nTopping:: ");
                        foreach (var top in pirre.Toppings)
                        {
                            Console.Write($"{top.Decsription} ");
                        }
                        Console.Write("\nVegetables: ");
                        foreach (var veges in pirre.Vegetables)
                        {
                            Console.Write($"{veges.Decsription} ");
                        }
                        Console.Write("\nVego: ");
                        foreach (var vego in pirre.Vegos)
                        {
                            Console.Write($"{vego.Decsription} ");
                        }

                        Console.WriteLine("\n");
                    }
                }
            }
        }

        private static Pizza AddMeat(Pizza pizza, int id)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Attach(pizza);
                var meat = db.Meats.FirstOrDefault(m => m.Id == id);

                if (pizza.Meats == null) pizza.Meats = new List<Meat>();

                pizza.Meats.Add(meat);

                db.Pizzas.Update(pizza);
                db.SaveChanges();
            }
            return pizza;
        }
    }
}
