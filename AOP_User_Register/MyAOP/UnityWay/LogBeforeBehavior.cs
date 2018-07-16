using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace MyAOP.UnityWay
{
    public class LogBeforeBehavior: IInterceptionBehavior
    {

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("LogBeforeBehavior");
            Console.WriteLine(input.MethodBase.Name);
            foreach (var item in input.Inputs)
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(item));
                //TODO: get more info by reflection and serialization
            }
            //return getNext().Invoke(input, getNext);//
            return getNext()(input, getNext); // Equal to the line above
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}
