using Common.DataContracts;
using Common.Faults;
using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    
    public interface ICaclulatorService
    {
        [OperationContract]
        [FaultContract(typeof(CalculatationFault))]
        int Square(int inputNumber);

        [OperationContract]
        void ThrowUnhandledException();

        [OperationContract]
        int OverloadingOperation(int inputNumber);

        [OperationContract(Name= "OverloadingOperationFloat")]
        float OverloadingOperation(float inputNumber);

        [OperationContract]
        SomeData DataContractOperation(SomeData input);
    }
}
