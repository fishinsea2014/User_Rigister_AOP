using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP.MVCFilter
{
    public class MVCFilterShow
    {
        public static void Show()
        {
            {
                IOrderService service = new OrderService();
                service.Index(123, "Jason");
            }

            {
                //MVC request:   Name of Controller   Name of Method  Parameters,e.g. url, form
                AOPManager.Invoke("OrderService",      "Index",        new object[] { 234, "Amy" });
            }
        }
    }
}
