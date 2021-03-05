using System;
using System.Collections.Generic;
using System.Text;
using PizzaTime.Controller;

namespace PizzaTime.View
{
    class PizzaView
    {

        public static void Welcome()
        {
            Console.WriteLine("Welcome to Abuhassans Pizzeria");
            Console.Write("Type in the name of the pizza you want to create: ");
            var pizzaName = Console.ReadLine();
            PizzaController.CreateRandomPizza(pizzaName);

            PizzaController.WriteOutPizza();
        }
    }
}
