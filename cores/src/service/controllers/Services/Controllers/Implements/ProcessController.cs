using System;

namespace Mov.Core.Controllers.Services.Controllers.Implements
{
    public class ProcessController
    {
        static System.Diagnostics.Process serviceProcess;

        /// <summary>
        /// サービス起動
        /// </summary>
        /// <returns></returns>
        private bool Start()
        {
            serviceProcess = new System.Diagnostics.Process();
            serviceProcess.StartInfo.FileName = @"C:\Program Files\IIS Express\iisexpress.exe";
            serviceProcess.StartInfo.CreateNoWindow = false;   //コンソールウインドウ非表示
            serviceProcess.StartInfo.UseShellExecute = true;   //シェル使用
            serviceProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;    //ウインドウサイズ
            //serviceProcess.SynchronizingObject = this;
            serviceProcess.Exited += new EventHandler(serviceProcess_Exited);    //イベントハンドラ追加
            serviceProcess.EnableRaisingEvents = true;  //終了時にExitedイベント生成

            //起動する
            serviceProcess.Start();
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
