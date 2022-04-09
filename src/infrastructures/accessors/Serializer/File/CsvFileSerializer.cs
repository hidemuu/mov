using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Mov.Accessors
{
    public class CsvFileSerializer
    {
        private const string EXTENSION = ".csv";
        private string path;
        private Encoding encoding;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <param name="encoding">エンコード</param>
        public CsvFileSerializer(string path, string encoding)
        {
            this.path = path;
            if (string.IsNullOrEmpty(Path.GetExtension(path))) this.path += EXTENSION;
            this.encoding = Encoding.GetEncoding(encoding);
        }

        /// <summary>
        /// データをシリアライズしてファイルに書き込み
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public void Write<T>(IEnumerable<T> list)
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
                    csv.WriteRecords(list);
                }
            }

        }

        /// <summary>
        /// データをファイルから読み出して指定クラスにデシリアライズ
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> Read<T>()
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
                    var records = new List<T>();

                    //csv.Context.RegisterClassMap<M>();
                    //records = csv.GetRecords<T>();

                    //読み込み開始準備を行います
                    csv.Read();
                    //ヘッダを読み込みます
                    csv.ReadHeader();
                    //行毎に読み込みと処理を行います
                    while (csv.Read())
                    {
                        var record = csv.GetRecord<T>();
                        records.Add(record);
                    }

                    return records;
                }
            }

        }
    }
}
