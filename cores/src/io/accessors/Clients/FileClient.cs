using Mov.Core.Accessors.Serializer;
using Mov.Core.Models.Connections;
using Mov.Core.Models.Texts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Accessors.Clients
{
    /// <inheritdoc/>
    public class FileClient : IClient
    {
        #region field

        private bool disposedValue;

        private IFileSerializer serializer;

        #endregion field

        #region property

        /// <inheritdoc/>
        public PathValue Endpoint { get; }

        #endregion property

        #region constructor

        public FileClient(PathValue endpoint, IFileSerializer serializer)
        {
            Endpoint = endpoint;
            this.serializer = serializer;
        }

        public FileClient(PathValue endpoint, EncodingValue encoding, AccessType accessType)
            : this(endpoint, new FileSerializerFactory(encoding).Create(accessType))
        {
        }

        public FileClient(PathValue endpoint, AccessType accessType)
            : this(endpoint, EncodingValue.UTF8, accessType)
        {
        }

        ~FileClient()
        {
            // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
            Dispose(disposing: false);
        }

        #endregion constructor

        #region method

        public async Task<IEnumerable<TEntity>> GetAsync<TEntity>(string url)
        {
            if (serializer is XmlSerializer xmlSerializer)
            {
                return new[] { await Task.Run(() => serializer.Deserialize<TEntity, TEntity>(Endpoint.Combine(url))) };
            }
            return await Task.Run(() => serializer.Deserialize<TEntity, IEnumerable<TEntity>>(Endpoint.Combine(url)));
        }

        public async Task PostAsync<TEntity>(string url, TEntity item)
        {
            await Task.Run(() => serializer.Serialize<TEntity, TEntity>(Endpoint.Combine(url), item));
        }

        public Task DeleteAsync<TEntity>(string url, TEntity item)
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

        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion private method
    }
}