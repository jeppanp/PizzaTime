using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PizzaTime.Model
{
    class Vegetable
    {
        [Key]
        public int Id { get; set; }

        public string Decsription { get; set; }

        public List<Pizza> Pizzas { get; set; }
    }
}
