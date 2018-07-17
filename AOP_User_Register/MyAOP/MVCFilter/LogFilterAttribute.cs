using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP.MVCFilter
{
    public class LogFilterAttribute : Attribute
    {
        public void Show(string msg)
        {
            Console.WriteLine($"{nameof(LogFilterAttribute)}_{msg}");
        }
    }
}
