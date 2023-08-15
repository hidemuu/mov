using Mov.Core.Models.Connections;
using Mov.Core.Models.Texts;
using System;
using System.Net.Http;

namespace Mov.Core.Accessors.Services.Clients.Implements
{
    public class WebAccessClient : IAccessClient, IDisposable
    {
        #region field

        private bool disposedValue;

        /// <summary>
        /// Constructs the base HTTP client, including correct authorization and API version headers.
        /// </summary>
        private HttpClient baseClient => new HttpClient { BaseAddress = this.Path.GetUri() };

        #endregion field

        #region property

        /// <inheritdoc/>
        public PathValue Path { get; }

        /// <inheritdoc/>
        public EncodingValue Encoding { get; }

        #endregion property

        #region constructor

        public WebAccessClient(PathValue path, EncodingValue encoding)
        {
            this.Path = path;
            this.Encoding = encoding;
        }

        #endregion constructor

        #region method

        public string Read(string url)
        {
            throw new NotImplementedException();
        }

        public void Write(string url, string writeString, bool isappend)
        {
            throw new NotImplementedException();
        }

        #endregion method

        #region private method

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: マネージド状態を破棄します (マネージド オブジェクト)
                }

                // TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
                // TODO: 大きなフィールドを null に設定します
                disposedValue = true;
            }
        }

        // // TODO: 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
        // ~FileAccessClient()
        // {
        //     // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion private method
    }
}