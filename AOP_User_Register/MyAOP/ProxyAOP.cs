using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyAOP.DecoratorAOP;

namespace MyAOP
{
    class ProxyAOP
    {

        public static void Show()
        {
            User user = new User()
            {
                Name = "Eleven",
                Password = "123123123123"
            };

            IUserProcessor processor = new UserProcessor();
            processor.RegUser(user);

            Console.WriteLine("***********");
            processor = new ProxyUserProcessor();
            processor.RegUser(user);
        }
    }

    internal class ProxyUserProcessor : IUserProcessor
    {
        private IUserProcessor _userProcessor = new UserProcessor();
        public void RegUser(User user)
        {
            //throw new NotImplementedException();
            BeforeProcess(user);
            this._userProcessor.RegUser(user);
            AfterProcess(user);
        }

        private void AfterProcess(User user)
        {
            //throw new NotImplementedException();
            Console.WriteLine("Do something afterwords by proxy AOP");
        }

        private void BeforeProcess(User user)
        {
            //throw new NotImplementedException();
            Console.WriteLine("Do something beforehand by proxy AOP");
        }
    }
}
