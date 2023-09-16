using System;

namespace Mov.Core.Functions.Controllers
{
    public class ProcessController
    {
        private System.Diagnostics.Process _process;

        /// <summary>
        /// サービス起動
        /// </summary>
        /// <returns></returns>
        private bool Start()
        {
            _process = new System.Diagnostics.Process();
            _process.StartInfo.FileName = @"C:\Program Files\IIS Express\iisexpress.exe";
            _process.StartInfo.CreateNoWindow = false;   //コンソールウインドウ非表示
            _process.StartInfo.UseShellExecute = true;   //シェル使用
            _process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;    //ウインドウサイズ
            //serviceProcess.SynchronizingObject = this;
            _process.Exited += new EventHandler(serviceProcess_Exited);    //イベントハンドラ追加
            _process.EnableRaisingEvents = true;  //終了時にExitedイベント生成

            //起動する
            _process.Start();
            return true;
        }

        //----- イベントハンドラ -------------
        private void serviceProcess_Exited(object sender, EventArgs e)
        {
            //プロセスが終了したときに実行される
            //MessageBox.Show("終了しました。");
        }
    }
}
