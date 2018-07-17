using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP.MVCFilter
{
    public class OrderService : BaseController, IOrderService
    {
        [LogFilter]
        public void Index(int id, string name)
        {
            //throw new NotImplementedException();
            Console.WriteLine($"This is home page , you are{name}, id is {id}");
        }

        public void Contact(int id, string name)
        {
            Console.WriteLine($"This is method contact,  {id} : {name}");
        }
    }
}
