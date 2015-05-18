using System.ServiceModel;

namespace Cloud
{
    [ServiceContract]
    public interface ICloudService
    {
        [OperationContract]
        string IncommingRead(string number, string macAddres);
    }
}
