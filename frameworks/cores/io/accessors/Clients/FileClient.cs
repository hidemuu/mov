﻿using Mov.Core.Accessors.Models;
using Mov.Core.Accessors.Serializer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

        public async Task<IEnumerable<TEntity>> GetsAsync<TEntity>(string url)
        {
            var path = Endpoint.Combine(url);
            if (!File.Exists(path.Value))
            {
                return new HashSet<TEntity>();
            }
            if (_serializer is XmlSerializer xmlSerializer)
            {
                return new[] { await Task.Run(() => _serializer.Deserialize<TEntity, TEntity>(path.Value)).ConfigureAwait(false) };
            }
            if (_serializer is CsvSerializer csvSerializer)
            {
                return await Task.Run(() => _serializer.Deserialize<TEntity, IEnumerable<TEntity>>(path.Value)).ConfigureAwait(false);
            }
            if(_serializer is JsonSerializer jsonSerializer)
            {
                return await Task.Run(() => _serializer.Deserialize<IEnumerable<TEntity>, IEnumerable<TEntity>>(path.Value)).ConfigureAwait(false);
            }
            return await Task.Run(() => _serializer.Deserialize<IEnumerable<TEntity>, IEnumerable<TEntity>>(path.Value)).ConfigureAwait(false);
        }

        public async Task<TEntity> GetAsync<TEntity>(string url)
        {
            var path = Endpoint.Combine(url);
            if (!File.Exists(path.Value))
            {
                return default(TEntity);
            }
            if (_serializer is XmlSerializer xmlSerializer)
            {
                return await Task.Run(() => _serializer.Deserialize<TEntity, TEntity>(path.Value)).ConfigureAwait(false);
            }
            if (_serializer is CsvSerializer csvSerializer)
            {
                var results = await Task.Run(() => _serializer.Deserialize<TEntity, IEnumerable<TEntity>>(path.Value)).ConfigureAwait(false);
                return results.ToArray()[0];
            }
            if (_serializer is JsonSerializer jsonSerializer)
            {
                return await Task.Run(() => _serializer.Deserialize<TEntity, TEntity>(path.Value)).ConfigureAwait(false);
            }
            return await Task.Run(() => _serializer.Deserialize<TEntity, TEntity>(path.Value)).ConfigureAwait(false);
        }

        public async Task<ResponseStatus> PostAsync<TEntity>(string url, TEntity entity)
        {
            var entityTypeInterfaces = entity.GetType().GetInterfaces();
			if (entityTypeInterfaces.Any(t =>
						t.IsConstructedGenericType &&
						t.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
            {
                //配列型の場合
                await Task.Run(() => _serializer.Serialize<TEntity, TEntity>(Endpoint.Combine(url).Value, entity));
			}
            else
            {
				var allEntities = (await GetsAsync<TEntity>(url)).ToList();
				var registeredEntity = allEntities.FirstOrDefault(x => x.Equals(entity));
				if (registeredEntity != null)
				{
					allEntities.Remove(registeredEntity);
				}
				allEntities.Add(entity);
				await Task.Run(() => _serializer.Serialize<IEnumerable<TEntity>, IEnumerable<TEntity>>(Endpoint.Combine(url).Value, allEntities));
			}
			return ResponseStatus.Success;
        }

        public async Task<ResponseStatus> PutAsync<TEntity>(string url, TEntity entity)
        {
            var allEntities = (await GetsAsync<TEntity>(url)).ToList();
            var registeredEntity = allEntities.FirstOrDefault(x => x.Equals(entity));
            if (registeredEntity == null)
            {
                return ResponseStatus.ClientError;
            }
            allEntities.Remove(registeredEntity);
            allEntities.Add(entity);
            await Task.Run(() => _serializer.Serialize<IEnumerable<TEntity>, IEnumerable<TEntity>>(Endpoint.Combine(url).Value, allEntities));
            return ResponseStatus.Success;
        }

		public async Task<ResponseStatus> DeletesAsync(string url)
		{
			var path = Endpoint.Combine(url);
			if (!File.Exists(path.Value)) { return ResponseStatus.ClientError; }
            await Task.Run(() => File.Delete(path.Value));
            return ResponseStatus.Success;
		}

		public async Task<ResponseStatus> DeleteAsync<TEntity>(string url, TEntity entity)
        {
            var allEntities = (await GetsAsync<TEntity>(url)).ToList();
            var registeredEntity = allEntities.FirstOrDefault(x => x.Equals(entity));
            if (registeredEntity != null)
            {
                allEntities.Remove(registeredEntity);
            }
            else
            {
                return ResponseStatus.ClientError;
            }
            await Task.Run(() => _serializer.Serialize<IEnumerable<TEntity>, IEnumerable<TEntity>>(Endpoint.Combine(url).Value, allEntities));
            return ResponseStatus.Success;
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