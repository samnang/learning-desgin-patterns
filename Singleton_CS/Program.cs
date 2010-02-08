/*
Adapter Pattern:

Ensure that only one instance of a class is created.
Provide a global point of access to the object.
*/

using System;

namespace Singleton_CS {
    public class ApplicationSettings
    {
        static ApplicationSettings _instance;

        public static ApplicationSettings GetInstance()
        {
            if (_instance == null)
            {
                lock (typeof(ApplicationSettings))
                {
                    _instance = new ApplicationSettings();  
                }                
            }               

            return _instance;
        }

        public string ApplicationName { get { return "Singleton in Practice."; } }
        public string DatabaseConnection { get { return "DB Connection."; } }
    }

    class Program {
        static void Main(string[] args) {

            var appSetting = ApplicationSettings.GetInstance();
            var appSetting2 = ApplicationSettings.GetInstance();

            if(appSetting == appSetting2)
            {
                Console.WriteLine("Application name: " + appSetting.ApplicationName);
                Console.WriteLine("DB Connection: " + appSetting.DatabaseConnection);
            }

            Console.ReadKey();
        }
    }
}
