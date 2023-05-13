using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Mov.Accessors.Serializer.Implements
{
    /// <summary>
    /// CSVシリアライザー
    /// </summary>
    public class CsvSerializer : ISerializer
    {
        #region フィールド

        private readonly IFileContext _context;

        #endregion フィールド

        #region コンストラクター

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CsvSerializer(IFileContext context)
        {
            _context = context;
        }

        #endregion コンストラクター

        #region メソッド

        /// <summary>
        /// データをシリアライズしてファイルに書き込み
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public TResponse Post<TRequest, TResponse>(string url, TRequest list)
        {
            var isExist = File.Exists(_context.FileUnit.Path);

            var configuration = new CsvConfiguration(CultureInfo.CurrentCulture);
            configuration.HasHeaderRecord = true;

            using (var sw = new StreamWriter(Path.Combine(_context.FileUnit.Path, url), true, _context.Encoding))
            {
                using (var csv = new CsvWriter(sw, configuration))
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
        public T Get<T>(string url)
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };

            using (var sr = new StreamReader(Path.Combine(_context.FileUnit.Path, url), _context.Encoding))
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