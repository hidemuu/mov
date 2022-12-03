using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Connectors
{
    /// <summary>
    /// シェル接続ロジッククラス
    /// </summary>
    public static class ShellConnector
    {     
        /// <summary>
        /// プロセス起動
        /// </summary>
        /// <param name="fileName">コマンドプロンプトの場合「System.Environment.GetEnvironmentVariable("ComSpec")」</param>
        /// <param name="commandLine">データベース最適化の場合「fileName + " /compact"」</param>
        public static string RunProcess(string fileName, string arg)
        {
            string result = "";
            //Processオブジェクトの生成
            var psi = new System.Diagnostics.ProcessStartInfo();
            var p = new System.Diagnostics.Process();
            //プロセス起動
            psi.FileName = fileName;    //ファイル実行
            //出力を許可する
            psi.RedirectStandardInput = false;
            psi.RedirectStandardOutput = true;      //出力の読み取りを許可
            psi.UseShellExecute = false;
            //ウィンドウ非表示の設定
            psi.CreateNoWindow = true;
            //コマンドを指定（"/c"は実行後閉じるために必要）
            psi.Arguments = arg; //コマンドパラメータ

            try
            {
                //実行
                p = System.Diagnostics.Process.Start(psi);
                //出力結果の取得
                result = p.StandardOutput.ReadToEnd();

                //WaitForExitはReadToEndの後である必要がある
                //(親プロセス、子プロセスでブロック防止のため)
                p.WaitForExit();

                //出力された結果を表示
                Console.WriteLine(result);

            }
            catch
            {
                result = null;
            }
            return result;

        }
        /// <summary>
        /// VBスクリプト起動
        /// </summary>
        public static string RunVBScript(string filePath, string argLine)
        {
            string result = "";
            //argument生成
            var arg = argLine;
            if (argLine != "")
            {
                arg = filePath + " " + argLine; //コマンドパラメータ（引数付き）
            }
            else
            {
                arg = filePath; //コマンドパラメータ
            }
            result = RunProcess("WScript.exe", arg);
            //出力された結果を表示
            Console.WriteLine(result);

            return result;

        }
        /// <summary>
        /// Accessデータベース最適化処理
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="appPath"></param>
        /// <returns></returns>
        public static bool RunAccessCompact(string filePath,
                                            string appPath = @"C:\Program Files\Microsoft Office\Office15\MSACCESS.EXE")
        {
            var result = RunProcess(appPath, filePath + " /compact");
            if (result != null) { return true; }
            else { return false; }
        }



    }
}
