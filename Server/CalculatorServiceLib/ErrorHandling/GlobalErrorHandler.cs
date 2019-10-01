using Common.Faults;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace CalculatorServiceLib.ErrorHandling
{
    public class GlobalErrorHandler : IErrorHandler
    {
        private const string ActionMessage = "Just Do It!";

        public bool HandleError(Exception error)
        {
            Console.WriteLine($"Global exception handler: {error.Message}");
            return true;
        }

        public void ProvideFault(Exception error,
            MessageVersion version,
            ref Message message)
        {
            Console.WriteLine($"{nameof(ProvideFault)}:{message}");
        }
    }
}
