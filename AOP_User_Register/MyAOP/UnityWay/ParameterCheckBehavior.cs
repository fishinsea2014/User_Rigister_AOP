using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace MyAOP.UnityWay
{
    public class ParameterCheckBehavior : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            //throw new NotImplementedException();
            Console.WriteLine("parameter Check behavior");
            User user = input.Inputs[0] as User; //May also constraint to User, use relection+attribute to implement data validation
            if (user.Password.Length < 10) // Check the length of the password, should over 10
            {
                //Return an exception
                return input.CreateExceptionMethodReturn(new Exception("Length of password should over 10."));
            }
            else
            {
                Console.WriteLine("The length of the password is valid");
                return getNext().Invoke(input, getNext);
            }
        }



        public bool WillExecute
        {
            get { return true; }
        }

        

        
    }
}
