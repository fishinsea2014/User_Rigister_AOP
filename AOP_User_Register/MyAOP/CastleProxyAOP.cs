using Castle.DynamicProxy;
using MyAOP.UnityWay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP
{
    class CastleProxyAOP
    {
        

        public static void Show()
        {
            User user = new User()
            {
                Name = "Eleven",
                Password = "123456"
            };

            ProxyGenerator generator = new ProxyGenerator();
            MyInterceptor interceptor = new MyInterceptor();
            UserProcessor userProcessor = generator.CreateClassProxy<UserProcessor>(interceptor);
            userProcessor.RegUser(user);

        }
    }

    

    public class MyInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            PreProcess(invocation);
            invocation.Proceed();
            PostProcess(invocation);
        }

        private void PostProcess(IInvocation invocation)
        {
            //throw new NotImplementedException();
            Console.WriteLine("Do something after the method in castle AOP");
        }

        private void PreProcess(IInvocation invocation)
        {
            //throw new NotImplementedException();
            Console.WriteLine("Do something before the method in castle AOP");
        }
    }
}
