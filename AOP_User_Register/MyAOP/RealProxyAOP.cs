using MyAOP.UnityWay;
using System;
using System.Runtime.Remoting;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;

namespace MyAOP
{
    class RealProxyAOP
    {

        public static void Show()
        {
            User user = new User()
            {
                Name = "Eleven",
                Password = "123456"
            };

            UserProcessor processor = new UserProcessor();
            processor.RegUser(user);

            Console.WriteLine("********************");
            UserProcessor userProcessor = TransparentProxy.Create<UserProcessor>();
            userProcessor.RegUser(user);
        }
    }

    public class MyRealProxy<T> : RealProxy
    {
        private T tTarget;

        public MyRealProxy(T target) : base(typeof(T))
        {
            this.tTarget = target;
        }
        public override IMessage Invoke(IMessage msg)
        {
            //throw new NotImplementedException();
            BeforeProcess(msg);
            IMethodCallMessage callMessage = (IMethodCallMessage)msg;
            object returnValue = callMessage.MethodBase.Invoke(this.tTarget, callMessage.Args);

            AfterProcess(msg);

            return new ReturnMessage(returnValue, new object[0], 0, null, callMessage);
        }

        private void BeforeProcess(IMessage msg)
        {
            //throw new NotImplementedException();
            Console.WriteLine("Do something beforehand");
        }

        private void AfterProcess(IMessage msg)
        {
            //throw new NotImplementedException();
            Console.WriteLine("Do something afterwords");
        }
    }

    public static class TransparentProxy
    {
        public static T Create<T>()
        {
            T instance = Activator.CreateInstance<T>();
            MyRealProxy<T> realProxy = new MyRealProxy<T>(instance);
            T transparentProxy = (T)realProxy.GetTransparentProxy();
            return transparentProxy;
        }
    }

}
