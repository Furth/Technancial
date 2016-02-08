using Repository;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository Repository = new Modelo.Repository();

            var Products = Repository.FindEntitySet<product_product>(p => true);

            Console.WriteLine("Ingrese");
            Console.ReadLine();
        }
    }
}
