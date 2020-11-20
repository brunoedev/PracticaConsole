using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            Service service = new Service();
            var lista=service.GetList();

            if (lista.Count > 0)
            {
                foreach (var item in lista)
                {
                    string result = service.Save(item);
                    Console.WriteLine(result);
                }
            }
        }
    }
}
