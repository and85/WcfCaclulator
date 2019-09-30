using Common;
using Common.Faults;
using System;
using System.ServiceModel;

namespace CalculatorServiceLib
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class CalculatorService : ICaclulatorService
    {
        private const string FunnyErrorMessage = "What Could Possibly Go Wrong?";

        public int RevertSign(int inputNumber)
        {
            return checked(-1 * inputNumber);
        }

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

        public float Square(float inputNumber)
        {
            return inputNumber * inputNumber;
        }
    }
}
