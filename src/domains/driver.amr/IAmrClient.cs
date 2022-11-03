using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Driver.Amr
{
    public interface IAmrClient
    {
        bool Connect(string host, string password, int mode = 0);
        bool Connected();
        bool Negotiate(int mode = 0);
        bool Close();
        string Read(int mode = 0);
        string ReadAll(out bool isSuccess, int mode = 0);
        string ReadFound(out bool isSuccess, out int foundIndex, string key, StringComparison stringComparison = StringComparison.Ordinal);
        bool Write(string msg, int mode = 0);
        string Receive(string arclCommand, out bool isTimeOut);
        string WriteReceive(string command, string param = "");
    }
}
