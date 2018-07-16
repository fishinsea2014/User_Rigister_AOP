using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace MyAOP.UnityWay
{
    public class ExceptionLoggingBehavior: IInterceptionBehavior
    {

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            IMethodReturn methodReturn = getNext()(input, getNext);

            Console.WriteLine("=========Exception Logging Behavior====");
            if (methodReturn.Exception == null)
            {
                Console.WriteLine("No exception");
            }
            else
            {
                Console.WriteLine($"Exception: {methodReturn.Exception.Message}");
            }

            Console.WriteLine("=========End of Exception Logging Behavior====");

            return methodReturn;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}
