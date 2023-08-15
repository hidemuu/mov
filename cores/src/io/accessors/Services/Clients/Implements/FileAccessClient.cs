using Mov.Core.Accessors.Services.Serializer;
using Mov.Core.Models.Connections;
using Mov.Core.Models.Texts;
using System;
using System.IO;
using System.Text;

namespace Mov.Core.Accessors.Services.Clients.Implements
{
    /// <inheritdoc/>
    public class FileAccessClient : IAccessClient
    {
        #region field

        private bool disposedValue;

        private ISerializer serializer;

        #endregion field

        #region property

        /// <inheritdoc/>
        public PathValue Path { get; }

        /// <inheritdoc/>
        public EncodingValue Encoding { get; }

        #endregion property

        #region constructor

        public FileAccessClient(PathValue path, EncodingValue encoding, ISerializer serializer)
        {
            this.Path = path;
            this.Encoding = encoding;
            this.serializer = serializer;
        }

        ~FileAccessClient()
        {
            // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
            Dispose(disposing: false);
        }

        #endregion constructor

        #region method

        public string Read(string url)
        {
            using (var stream = GetStreamReader(url))
            {
                if (stream != null)
                {
                    return stream.ReadToEnd();
                }
            }
            return "";
        }

        public void Write(string url, string writeString, bool isappend)
        {
            using (var stream = GetStreamWriter(url, isappend))
            {
                if (stream != null)
                {
                    stream.Write(writeString);
                }
            }
        }

        public StreamReader GetStreamReader(string url)
        {
            return new StreamReader(this.Path.Combine(url), Encoding.Value);
        }


        public StreamWriter GetStreamWriter(string url, bool isAppend)
        {
            return new StreamWriter(this.Path.Combine(url), isAppend, Encoding.Value);
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

        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion private method
    }
}