using MyAOP.UnityWay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP
{
    /// <summary>
    /// Use decorator to implements static proxies
    /// AOP adds custom methods before and after a methods
    /// </summary>
    class DecoratorAOP
    {
        public static void Show()
        {
            User user = new User()
            {
                Name = "Jason",
                Password = "abcdedg"
            };

            IUserProcessor processor = new UserProcessor();
            processor.RegUser(user);
            Console.WriteLine("************************");

            processor = new UserProcessorDecorator(processor);

            processor.RegUser(user);
        }

        public interface IUserProcessor
        {
            void RegUser(User user);
        }

        public class UserProcessor : IUserProcessor
        {
            public void RegUser(User user)
            {
                //throw new NotImplementedException();
                Console.WriteLine($"User has been regestered. Name: {user.Name} and Passwork: {user.Password} ");
            }
        }

        public class UserProcessorDecorator : IUserProcessor
        {
            private IUserProcessor _userProcessor { get; set; }

            public UserProcessorDecorator(IUserProcessor userpocessor)
            {
                this._userProcessor = userpocessor;
            }

            public void RegUser(User user)
            {
                BeforeProceed(user);
                this._userProcessor.RegUser(user);
                AfterProceed(user);
                //throw new NotImplementedException();

            }

            private void BeforeProceed(User user)
            {
                Console.WriteLine("Do something before the method");
            }

            private void AfterProceed(User user)
            {
                Console.WriteLine("Do something after the method");
            }
        }

    }
}
