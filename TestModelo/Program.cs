using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModelo
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository Repository = new TestModelo.Repository();

            var product = Repository.FindEntitySet<product_product>(c => true);

            Console.Write("Presione enter para terminar");
            Console.ReadLine();
        }
    }
}
