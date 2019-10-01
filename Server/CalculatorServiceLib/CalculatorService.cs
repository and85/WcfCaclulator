using CalculatorServiceLib.ErrorHandling;
using Common;
using Common.Faults;
using System;
using System.ServiceModel;

namespace CalculatorServiceLib
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [GlobalErrorBehavior(typeof(GlobalErrorHandler))]
    public class CalculatorService : ICaclulatorService
    {
        private const string FunnyErrorMessage = "What Could Possibly Go Wrong?";

        public int Square(int inputNumber) 
        {
            int result;
            try
            {
                result = checked(inputNumber * inputNumber);
            }
            catch (OverflowException)
            {
                var fault = new CalculatationFault(FunnyErrorMessage);
                throw new FaultException<CalculatationFault>(fault, new FaultReason(fault.Message));
            }

            return result;
        }

        public void ThrowUnhandledException()
        {
            throw new Exception("UnhandledException");
        }

        public int OverloadingOperation(int inputNumber)
        {
            return inputNumber;
        }

        public float OverloadingOperation(float inputNumber)
        {
            return inputNumber;
        }
    }
}
