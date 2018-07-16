using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace MyAOP.UnityWay
{
    public class CachingBehavior : IInterceptionBehavior
    {
        private static Dictionary<string, object> CachingBehaviorDictionary = new Dictionary<string, object>();
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("==========Caching behavior=======");
            string key = $"{input.MethodBase.Name}_{Newtonsoft.Json.JsonConvert.SerializeObject(input.Inputs)}";
            if (CachingBehaviorDictionary.ContainsKey(key))
            {
                return input.CreateMethodReturn(CachingBehaviorDictionary[key]);
            }
            else
            {
                IMethodReturn result = getNext().Invoke(input, getNext);
                if (result.ReturnValue != null) CachingBehaviorDictionary.Add(key, result.ReturnValue);
                return result;
            }
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}
