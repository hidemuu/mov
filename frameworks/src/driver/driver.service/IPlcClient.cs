using System.Threading.Tasks;

namespace Mov.Driver.Service
{
    public interface IPlcClient
    {
        Task<int> ConnectAsync(int id, int protocol, string password, int timeOut);
        Task<int> DisConnectAsync();
        Task<int> WriteAdressAsync(string[] names, int size, bool isBlock, short[] setValues);
        Task<(int response, short[] results)> ReadAddressTupleAsync(string[] names, int size, bool isBlock);
        int GetHandler();
    }
}
