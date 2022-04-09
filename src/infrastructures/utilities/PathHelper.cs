using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities
{
    /// <summary>
    /// 絶対パス取得ロジック
    /// </summary>
    public static class PathHelper
    {
        /// <summary>
        /// 指定文字列に一致するフォルダを実行ファイル直下から検索し、絶対パスとして返す
        /// </summary>
        /// <param name="solutionName"></param>
        /// <returns></returns>
        public static string GetCurrentRootPath(string solutionName)
        {
            string currentDir = System.IO.Directory.GetCurrentDirectory();
            string[] pathArray = currentDir.Split(@"\".ToCharArray());
            string rootPath = "";
            for (int i = 0; i < pathArray.Length; i++)
            {
                if (pathArray[i].Contains(solutionName))
                {
                    rootPath = pathArray[0];
                    for (int k = 1; k <= i; k++)
                    {
                        rootPath += @"\" + pathArray[k];
                    }
                    rootPath += @"\";
                    break;
                }
            }
            return rootPath;
        }

        /// <summary>
        /// 指定した検索パターンに一致するファイルを最下層まで検索しすべて返す
        /// </summary>
        /// <param name="rootPath">
        /// 検索を開始する最上層のディレクトリへのパス
        /// ex) @"C:\Hoge\ 
        /// </param>
        /// <param name="pattern">
        /// パス内のファイル名と対応させる検索文字列
        /// ex) *Hoge*.txt
        /// </param>
        /// <returns>
        /// 検索パターンに一致したすべてのファイルパス
        /// </returns>
        public static string[] GetFilesMostDeep(string rootPath, string pattern)
        {
            System.Collections.Specialized.StringCollection stringCollection = (
                new System.Collections.Specialized.StringCollection()
            );

            // このディレクトリ内のすべてのファイルを検索する
            foreach (string filePath in System.IO.Directory.GetFiles(rootPath, pattern))
            {
                stringCollection.Add(filePath);
            }

            // このディレクトリ内のすべてのサブディレクトリを検索する (再帰)
            foreach (string stDirPath in System.IO.Directory.GetDirectories(rootPath))
            {
                string[] filePathes = GetFilesMostDeep(stDirPath, pattern);

                // 条件に合致したファイルがあった場合は、ArrayList に加える
                if (filePathes != null)
                {
                    stringCollection.AddRange(filePathes);
                }
            }

            // StringCollection を 1 次元の String 配列にして返す
            string[] returns = new string[stringCollection.Count];
            stringCollection.CopyTo(returns, 0);

            return returns;
        }
    }
}
