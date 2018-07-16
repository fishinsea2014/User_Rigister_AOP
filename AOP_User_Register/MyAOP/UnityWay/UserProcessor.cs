using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace MyAOP.UnityWay
{
    public class UserProcessor : MarshalByRefObject, IUserProcessor
    {
        public User GetUser(User user)
        {
            //throw new NotImplementedException();
            return user;
            
        }

        public virtual void RegUser(User user) //Must has virtual in case of CrastleProxy
        {
            //throw new NotImplementedException();
            Console.WriteLine("----The main RegUser-----");
            Console.WriteLine($"User {user.Name} has been registed with pw {user.Password}");
        }
    }
}
