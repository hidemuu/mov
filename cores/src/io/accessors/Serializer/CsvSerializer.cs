using CsvHelper;
using CsvHelper.Configuration;
using Mov.Core.Models.Texts;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Mov.Core.Accessors.Serializer
{
    /// <summary>
    /// CSVシリアライザー
    /// </summary>
    public class CsvSerializer : IFileSerializer
    {
        #region property

        public EncodingValue Encoding { get; }

        #endregion property

        #region constructor

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CsvSerializer(EncodingValue encoding)
        {
            Encoding = encoding;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// データをシリアライズしてファイルに書き込み
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public TResponse Serialize<TRequest, TResponse>(string url, TRequest list)
        {
            var configuration = new CsvConfiguration(CultureInfo.CurrentCulture);
            configuration.HasHeaderRecord = true;

            using (var streamWriter = new StreamWriter(url, true, Encoding.Value))
            {
                using (var csv = new CsvWriter(streamWriter, configuration))
                {
                    //csv.Context.RegisterClassMap<M>();
                    // 区切り文字をタブとかに変えることも可能
                    //config.Delimiter = "\t";
                    //csv.WriteRecords(list);
                    csv.WriteRecord(list);
                    return default;
                }
            }
        }

        /// <summary>
        /// データをファイルから読み出して指定クラスにデシリアライズ
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public TResponse Deserialize<TRequest, TResponse>(string url)
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };

            using (var streamReader = new StreamReader(url, Encoding.Value))
            {
                using (var csvReader = new CsvReader(streamReader, configuration))
                {
                    var records = csvReader.GetRecords<TRequest>().ToList();
                    if (records is TResponse responces)
                    {
                        return responces;
                    }
                    return default;
                }
            }
        }

        #endregion method
    }
}