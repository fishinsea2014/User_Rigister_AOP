using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP.UnityWay
{
    public interface IUserProcessor
    {
        //Use this attribute to  implement authorisation check
        [Authorise]
        void RegUser(User user);

        //Use this attribute to ignore authorisation check
        [AllowAnonymous]
        User GetUser(User user); 
    }
}
