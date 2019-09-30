using System.Runtime.Serialization;

namespace Common.Faults
{
    [DataContract]
    public class CalculatationFault
    {
        public CalculatationFault(string message)
        {
            Message = message;
        }

        [DataMember]
        public string Message { get; private set; }
    }
}
