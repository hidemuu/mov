using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Driver.Service.PLC.Melsec
{
    public enum PLCHandler
    {
        NoResponse = -9,
        TimeOut = -8,
        Failed = -2,
        DisConnect = -1,
        Connect = 0,
    }

    public class PLCDriver : IPLCDriver
    {
        //----- フィールド ----------------
        private MelsecConnector _connector;
        private int _id = 1;
        private int _protocol = 0;
        private string _password = "";
        private int _timeOut = 5;
        private int _handler = (int)PLCHandler.NoResponse;

        //----- コンストラクタ ------------
        public PLCDriver()
        {
            _connector = new MelsecConnector();
        }

        //----- メソッド群 ----------------

        //----- 接続メソッド --------------
        #region Connector - 接続メソッド

        public async Task<int> ConnectAsync(int id, int protocol, string password, int timeOut)
        {
            _id = id;
            _protocol = protocol;
            _password = password;
            _timeOut = timeOut;
            _handler = (int)PLCHandler.NoResponse;
            //オープン処理
            var task = OpenAsync();
            var taskTimeout = Task.Delay(timeOut * 1000);
            if (await Task.WhenAny(task, taskTimeout) == task)
            {
                if (task.Result == 0) _handler = id;
                else _handler = (int)PLCHandler.Failed;
            }
            else
            {
                _handler = (int)PLCHandler.TimeOut;
            }

            return _handler;
        }
        public async Task<int> DisConnectAsync()
        {
            var result = await Task.Run(() => _connector.Close());
            if (result == 0)
            {
                _handler = (int)PLCHandler.DisConnect;
            }
            else
            {
                _handler = (int)PLCHandler.Failed;
            }
            return _handler;
        }

        public async Task<int> WriteAdressAsync(string[] names, int size, bool isBlock, short[] setValues)
        {
            if (!isBlock)
            {
                return await Task.Run(() => _connector.WriteDevice(names[0], size, setValues));
            }
            else
            {
                return await Task.Run(() => _connector.WriteDeviceBlock(names, size, setValues));
            }
        }
        public async Task<(int response, short[] results)> ReadAddressTupleAsync(string[] names, int size, bool isBlock)
        {
            if (!isBlock)
            {
                return await Task.Run(() => _connector.ReadDeviceTuple(names[0], size));
            }
            else
            {
                return await Task.Run(() => _connector.ReadDeviceBlockTuple(names, size));
            }
        }

        public int ReadAdress(string[] names, int size, bool isBlock, out short[] results)
        {
            if (!isBlock)
            {
                return _connector.ReadDevice(names[0], size, out results);
            }
            else
            {
                return _connector.ReadDeviceBlock(names, size, out results);
            }

        }
        public int GetHandler()
        {
            return _handler;
        }

        #endregion

        //----- 内部ロジック ---------------------------
        private async Task<int> OpenAsync()
        {
            if (_protocol > 0)
            {
                return await Task.Run(() => _connector.OpenOnProg(_id, _protocol, _password));

            }
            else
            {
                return await Task.Run(() => _connector.OpenOnUtl(_id, _password));

            }
        }
    }
}
