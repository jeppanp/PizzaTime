using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PizzaTime.Model
{
    class Pizza
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Dough> Doughs { get; set; }

        public List<Top> Toppings { get; set; }

        public List<Meat> Meats { get; set; }

        public List<Vegetable> Vegetables { get; set; }

        public List<Vego> Vegos { get; set; }




    }
}
