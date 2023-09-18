using Mov.Core.Accessors.Models;
using Mov.Core.Accessors.Serializer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mov.Core.Accessors.Clients
{
    /// <inheritdoc/>
    public class FileClient : IClient
    {
        #region field

        private bool _disposedValue;

        private IFileSerializer _serializer;

        #endregion field

        #region property

        /// <inheritdoc/>
        public PathValue Endpoint { get; }

        #endregion property

        #region constructor

        public FileClient(PathValue endpoint, IFileSerializer serializer)
        {
            Endpoint = endpoint;
            this._serializer = serializer;
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
            if (_serializer is XmlSerializer xmlSerializer)
            {
                return new[] { await Task.Run(() => _serializer.Deserialize<TEntity, TEntity>(Endpoint.Combine(url))) };
            }
            return await Task.Run(() => _serializer.Deserialize<TEntity, IEnumerable<TEntity>>(Endpoint.Combine(url)));
        }

        public async Task PostAsync<TEntity>(string url, TEntity item)
        {
            await Task.Run(() => _serializer.Serialize<TEntity, TEntity>(Endpoint.Combine(url), item));
        }

        public async Task PutAsync<TEntity>(string url, TEntity entity)
        {
            await Task.Run(() => _serializer.Serialize<TEntity, TEntity>(Endpoint.Combine(url), entity));
        }

        public Task DeleteAsync<TIdentifier>(string url, TIdentifier identifier)
        {
            throw new NotImplementedException();
        }

        #endregion method

        #region private method

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: マネージド状態を破棄します (マネージド オブジェクト)
                }

                // TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
                // TODO: 大きなフィールドを null に設定します
                _disposedValue = true;
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