using Mov.Core.Accessors;
using Mov.Core.Accessors.Services.Serializer;
using Mov.Core.Accessors.Services.Serializer.Implements;
using Mov.Core.Models.DbObjects;
using Mov.Core.Templates.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Repositories.Repositories.Entities
{
    /// <summary>
    /// 任意のエンティティのファイルデータのリポジトリ
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TBody"></typeparam>
    public class FileEntityRepository<TEntity, TBody>
        : IEntityRepository<TEntity>, IEntityRepositoryAsync<TEntity>, IFileRepository<TBody>
        where TEntity : IEntityObject
        where TBody : IEntityCollection<TEntity>
    {
        #region フィールド

        protected readonly ISerializer serializer;

        protected TBody body = default;

        #endregion フィールド

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="encode"></param>
        public FileEntityRepository(IAccessService service)
        {
            var type = service.FileValue.FileType;
            if (type.IsNan()) { 
                Debug.Assert(false, "拡張子が含まれていません");
            }
            else if (type.IsJson())
            {
                serializer = new JsonSerializer(service);
            }
            else if (type.IsXml())
            {
                serializer = new XmlSerializer(service);
            }
            else if (type.IsCsv())
            {
                serializer = new CsvSerializer(service);
            }
            else
            {
                Debug.Assert(false, "拡張子が不正です");
            }
        }

        #endregion コンストラクター

        #region メソッド

        #region IFileRepository

        /// <inheritdoc />
        public TBody Read()
        {
            body = serializer.Get<TBody>("");
            return body;
        }

        /// <inheritdoc />
        public void Write() => serializer.Post<TBody, TBody>("", body);

        #endregion IFileRepository

        #region IEntityRepository

        /// <inheritdoc />
        public IEnumerable<TEntity> Get()
        {
            if (body == null) Read();
            if (body == null) return new List<TEntity>();
            return body.Items;
        }

        public virtual TEntity Get(string param)
        {
            throw new NotImplementedException();
        }

        public virtual void Post(TEntity item)
        {
            throw new NotImplementedException();
        }

        #endregion IEntityRepository

        #region IEntityRepositoryAsync

        /// <inheritdoc />
        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await Task.Run(() => serializer.Get<IEnumerable<TEntity>>(""));
        }

        /// <inheritdoc />
        public async Task<TEntity> GetAsync(string param)
        {
            return await Task.Run(() => serializer.Get<TEntity>(param));
        }

        /// <inheritdoc />
        public async Task PostAsync(TEntity item)
        {
            await Task.Run(() => serializer.Post<TEntity, TEntity>("", item));
        }

        /// <inheritdoc />
        public async Task PostAsync(IEnumerable<TEntity> items)
        {
            await Task.Run(() => serializer.Post<IEnumerable<TEntity>, IEnumerable<TEntity>>("", items));

        }

        /// <inheritdoc />
        public Task DeleteAsync(string date)
        {
            throw new NotImplementedException();
        }

        #endregion IEntityRepositoryAsync

        /// <inheritdoc />
        public override string ToString()
        {
            var items = Get();
            if (items == null) return string.Empty;
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(">> ").AppendLine(typeof(TEntity).Name);
            GetHeaderStrings(items.ToList(), stringBuilder, out int[] headerLengths);
            GetContentStrings(items.ToList(), headerLengths, stringBuilder);
            return stringBuilder.ToString();
        }

        #endregion メソッド

        #region 内部メソッド

        /// <summary>
        /// ヘッダーの文字列取得
        /// </summary>
        private void GetHeaderStrings(List<TEntity> items, StringBuilder stringBuilder, out int[] headerLengths)
        {
            //ヘッダー情報取得
            var firstItem = items.FirstOrDefault();
            if (firstItem == null)
            {
                headerLengths = null;
                return;
            }
            var headerStrings = firstItem.GetHeaderStrings();
            headerLengths = new int[headerStrings.Length];
            for (var i = 0; i < headerStrings.Length; i++)
            {
                headerLengths[i] = headerStrings[i].Length;
            }
            //各項目の最大文字列サイズ取得
            foreach (var item in items)
            {
                var contentStrings = item.GetContentStrings();
                for (var i = 0; i < contentStrings.Length; i++)
                {
                    if (headerLengths[i] < contentStrings[i].Length)
                    {
                        headerLengths[i] = contentStrings[i].Length;
                    }
                }
            }
            headerLengths = headerLengths.Select(x => x + 2).ToArray();
            //ヘッダーを生成
            var headerLine = "";
            for (int i = 0; i < headerLengths.Length; i++)
            {
                //ヘッダー文字を最大長さに調整
                for (int j = 0; j < headerLengths[i]; j++)
                {
                    headerLine += RepositoryConstants.HEADER_LINE;
                }
                stringBuilder.Append(headerStrings[i].PadRight(headerLengths[i]));
            }
            stringBuilder.AppendLine();
            stringBuilder.Append(headerLine);
            stringBuilder.AppendLine();
        }

        /// <summary>
        /// コンテンツの文字列取得
        /// </summary>
        /// <param name="items"></param>
        /// <param name="stringBuilder"></param>
        private void GetContentStrings(List<TEntity> items, int[] headerLengths, StringBuilder stringBuilder)
        {
            foreach (var item in items)
            {
                var contentStrings = item.GetContentStrings();
                for (int i = 0; i < contentStrings.Length; i++)
                {
                    stringBuilder.Append(contentStrings[i].PadRight(headerLengths[i]));
                }
                stringBuilder.AppendLine();
            }
        }

        #endregion 内部メソッド

    }
}
