﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace MyAOP.UnityWay
{
    public class AuthorizeBehavior : IInterceptionBehavior
    {
        public bool WillExecute { get { return true; } }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            //throw new NotImplementedException();
            User user = input.Inputs[0] as User;
            if (user == null || user.Name.Equals("Anonymous"))
            {
                return input.CreateExceptionMethodReturn(new Exception("Invalid user"));
            }
            else
            {
                return getNext().Invoke(input, getNext);
                //return getNext()(input, getNext);
            }


        }
    }
}
