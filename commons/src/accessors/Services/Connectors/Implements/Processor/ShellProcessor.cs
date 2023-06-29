using System;

namespace Mov.Core.Accessors.Services.Connectors.Implements.Processor
{
    /// <summary>
    /// シェルプロセスクラス
    /// </summary>
    public class ShellProcessor : IProcessor
    {
        #region field

        private readonly string processFileName;

        private System.Diagnostics.Process process;

        #endregion field

        #region constructor

        public ShellProcessor(string processFileName)
        {
            this.processFileName = processFileName;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// プロセス起動
        /// </summary>
        /// <param name="fileName">コマンドプロンプトの場合「System.Environment.GetEnvironmentVariable("ComSpec")」</param>
        public string Run(string args)
        {
            //Processオブジェクトの生成
            var psi = new System.Diagnostics.ProcessStartInfo();
            //プロセス起動
            psi.FileName = processFileName;    //ファイル実行
            //出力を許可する
            psi.RedirectStandardInput = false;
            psi.RedirectStandardOutput = true;      //出力の読み取りを許可
            psi.UseShellExecute = false;
            //ウィンドウ非表示の設定
            psi.CreateNoWindow = true;
            //コマンドを指定（"/c"は実行後閉じるために必要）
            psi.Arguments = args; //コマンドパラメータ

            string result;
            try
            {
                //実行
                process = System.Diagnostics.Process.Start(psi);
                //出力結果の取得
                result = process.StandardOutput.ReadToEnd();

                //出力された結果を表示
                Console.WriteLine(result);

            }
            catch
            {
                result = null;
            }
            return result;

        }

        public void Stop()
        {
            process.WaitForExit();
        }

        #endregion method

    }
}
