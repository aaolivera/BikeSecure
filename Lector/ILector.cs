using System.ServiceModel;

namespace Lector
{
    [ServiceContract]
    public interface ILector
    {

        [OperationContract]
        string GetData();

    }

}