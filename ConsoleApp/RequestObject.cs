using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class RequestObject
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<Empleado> data { get; set; }
    }
}
