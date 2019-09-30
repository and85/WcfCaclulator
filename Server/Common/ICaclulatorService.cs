using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface ICaclulatorService
    {
        [OperationContract]
        int Square(int inputNumber);

        //[OperationContract(Name = "SquareFloat")]
        //float Square(float inputNumber);

        [OperationContract]
        int RevertSign(int inputNumber);
    }
}
