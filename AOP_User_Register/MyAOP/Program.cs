using MyAOP.MVCFilter;
using MyAOP.UnityWay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //AOP by decorator pattern
            // DecoratorAOP.Show();

            //AOP by proxy pattern
            //ProxyAOP.Show();

            //AOP by real proxy AOP
            //RealProxyAOP.Show();

            //AOP by castle proxy AOP
            //CastleProxyAOP.Show();

            //AOP by Unity
            //UnityConfigAOP.Show();

            //MVC filter
            MVCFilterShow.Show();

            Console.Read();
        }
    }
}
