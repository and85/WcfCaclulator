using System;
using System.Reflection;
using System.ServiceModel;
using CalculatorServiceLib;
using log4net;
using log4net.Config;

namespace ServiceHostApp
{
    class Program
    {
        private static readonly ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            // initialise logging
            XmlConfigurator.Configure();

            ServiceHost svcHost;
            try
            {
                svcHost = new ServiceHost(typeof(CalculatorService));
                svcHost.Open();
                Log.Info("Service is running...");
            }
            catch (Exception exception)
            {
                Log.Fatal("Service couln't start!", exception);
                Console.ReadLine();
                return;
            }

            Log.Info("Press Enter to close the service.");
            Console.ReadLine();
            svcHost.Close();
        }
    }
}
