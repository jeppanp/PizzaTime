using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using PizzaTime.Database;
using PizzaTime.Model;
using PizzaTime.View;

namespace PizzaTime
{
    class Program
    {
        static void Main(string[] args)
        {
            PizzaView.Welcome();

        }

    }
}



