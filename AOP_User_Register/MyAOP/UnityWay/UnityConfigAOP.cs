using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace MyAOP.UnityWay
{
    /// <summary>
    /// This is an example of unity AOP, which get the actions from a config file.
    /// </summary>
    public class UnityConfigAOP
    {
        public static void Show()
        {
            User user = new User()
            {
                Name = "Eleven",
                Password = "123456789"
            };

            {
                IUnityContainer container = new UnityContainer();
                container.RegisterType<IUserProcessor, UserProcessor>();
                IUserProcessor processor = container.Resolve<IUserProcessor>();
                processor.RegUser(user);
                Console.WriteLine("=============");

            }

            {
                //Config unitycontainer
                IUnityContainer container = new UnityContainer();
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config");
                Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                UnityConfigurationSection configSection = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
                configSection.Configure(container, "aopContainer"); //aopContainer is the name of container in configruation file.
               
                IUserProcessor processor = container.Resolve<IUserProcessor>();
                processor.RegUser(user);
                //processor.GetUser(user);
                Console.WriteLine("==============");
                //User userNew1 = processor.GetUser(user);
                //Console.WriteLine("==============");
                //User userNew2 = processor.GetUser(user);
                //Console.WriteLine("==============");

            }
        }

        

        

        

    }
}
