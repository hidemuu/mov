using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Mov.Accessors
{
    /// <summary>
    /// CSVシリアライザー
    /// </summary>
    public class CsvSerializer : ISerializer
    {
        #region フィールド

        private readonly string basePath;
        private string path;
        private Encoding encoding;

        #endregion フィールド

        #region コンストラクター

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CsvSerializer(string basePath, string relativePath, string encoding)
        {
            this.basePath = basePath;
            this.path = Path.Combine(basePath, relativePath);
            if (string.IsNullOrEmpty(Path.GetExtension(path))) this.path += DbConstants.PATH_EXTENSION_CSV;
            this.encoding = Encoding.GetEncoding(encoding);
        }

        #endregion コンストラクター

        #region メソッド

        /// <summary>
        /// データをシリアライズしてファイルに書き込み
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public void Write<T>(T list)
        {
            var isExist = File.Exists(path);

            var configuration = new CsvConfiguration(CultureInfo.CurrentCulture);
            configuration.HasHeaderRecord = true;

            using (var sw = new StreamWriter(path, true, encoding))
            {
                using (var csv = new CsvWriter(sw, configuration))
                {
                    //csv.Context.RegisterClassMap<M>();
                    // 区切り文字をタブとかに変えることも可能
                    //config.Delimiter = "\t";
                    //csv.WriteRecords(list);
                    csv.WriteRecord(list);
                }
            }
        }

        /// <summary>
        /// データをファイルから読み出して指定クラスにデシリアライズ
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Read<T>()
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };

            using (var sr = new StreamReader(path, encoding))
            {
                using (var csv = new CsvReader(sr, configuration))
                {
                    //var records = new List<T>();

                    //csv.Context.RegisterClassMap<M>();
                    //records = csv.GetRecords<T>();

                    //読み込み開始準備を行います
                    csv.Read();
                    //ヘッダを読み込みます
                    csv.ReadHeader();
                    //行毎に読み込みと処理を行います
                    //while (csv.Read())
                    //{
                    //    var record = csv.GetRecord<T>();
                    //    records.Add(record);
                    //}

                    return csv.GetRecord<T>();
                }
            }
        }

        #endregion メソッド
    }
}