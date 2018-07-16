using MyAOP.UnityWay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.ContainerIntegration;

namespace MyAOP
{
    public class UnityAOP
    {
        public static void Show()
        {
            User user = new User()
            {
                Name = "Eleven",
                Password = "1234567890123456789"
            };

            {
                IUnityContainer container = new UnityContainer(); //Declear an unity container, like create a factory
                container.RegisterType<IUserProcessor, UserProcessor>(); //Register IUserProcessor to unity container, like a factory, create an UserProcessor
                IUserProcessor processor = container.Resolve<IUserProcessor>();// Create an instance by reflection in factory
                processor.RegUser(user); //Call RegUser method

                container.AddNewExtension<Interception>();


            }

        }
    }
}
