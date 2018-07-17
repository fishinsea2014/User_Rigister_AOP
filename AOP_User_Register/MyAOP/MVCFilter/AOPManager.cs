using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP.MVCFilter
{
    public class AOPManager
    {
        /// <summary>
        /// A static construction method, execute at the beginning, and only execute once.
        /// This class simulates MVC "application start"
        /// </summary>
        static AOPManager()
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string[] fileNameList = Directory.GetFiles(directory);
            //Find all the exe and dll files
            //This is the basic way of MVC
            foreach (var item in fileNameList.Where(f => f.EndsWith("exe") || f.EndsWith("dll")))
            { 
                Assembly assembly = Assembly.Load(Path.GetFileNameWithoutExtension(item));
                foreach (var type in assembly.GetTypes())
                {
                    if (typeof(BaseController).IsAssignableFrom(type)) //Find the types inheritate from BaseController
                    {
                       _serviceList.Add(type.Name, type); 
                    }
                }
            }
        }
        private static Dictionary<string, Type> _serviceList = new Dictionary<string, Type>();

        public static void Invoke(string typeName, string methodName, params object[] parameters)
        {
            Type type = _serviceList[typeName];
            object oService = Activator.CreateInstance(type);
            var method = type.GetMethod(methodName);
            if (method.IsDefined(typeof(LogFilterAttribute), true))
            {
                var attribute = (LogFilterAttribute)method.GetCustomAttribute(typeof(LogFilterAttribute), true);
                attribute.Show($"Log something for {parameters}");
            }

            method.Invoke(oService, parameters);
        }
    }
}
