using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Models.AMR.Omron
{
    //----- キーコード --------------
    /// <summary>
    /// ARCLコマンドIndex番号群
    /// </summary>
    public enum ArclCommandIndexs
    {
        NONE = -1,
        applicationfaultclear = 0,
        applicationFaultQuery = 1,
        applicationfaultset = 2,
        dock = 3,
        dotask = 4,
        executemacro = 5,
        faultsget = 6,
        go = 7,
        odometer = 8,
        odometerreset = 9,
        onelinestatus = 10,
        patrol = 11,
        patrolonce = 12,
        patrolresume = 13,
        play = 14,
        querydockstatus = 15,
        queryfaults = 16,
        querymotors = 17,
        say = 18,
        status = 19,
        stop = 20,
        undock = 21,
        getGoals = 22,
        getMacros = 23,
        getRoutes = 24,
        help = 25,
        inputList = 26,
        inputQuery = 27,
        outputList = 28,
        outputOff = 29,
        outputOn = 30,
        outputQuery = 31,
        payloadQuery = 32,
        payloadQueryLocal = 33,
        payloadRemove = 34,
        payloadSet = 35,
        payloadSlotCount = 36,
        payloadSlotCountLocal = 37,
        popupSimple = 38,
        queueCancel = 39,
        queueCancelLocal = 40,
        queueDropoff = 41,
        queueModify = 42,
        queueModifyLocal = 43,
        queueMulti = 44,
        queuePickup = 45,
        queuePickupDropoff = 46,
        queueQuery = 47,
        queueQueryLocal = 48,
        queueShow = 49,
        queueShowCompleted = 50,
        queueShowRobot = 51,
        queueShowRobotLocal = 52,
        quit = 53,
    }

    /// <summary>
    /// ARCLロボットステータスIndex番号群
    /// </summary>
    public enum ArclStatusIndexs
    {
        NONE = -1,
        INTERRUPT = 0,
        JOBID = 1,
        ESTOP_ON = 10,
        ESTOP_OFF = 11,
        IDLE_STOP = 20,
        IDLE_PARK = 21,
        IDLE_DOCK = 22,
        PICKUP_GOING = 30,
        PICKUP_ARRIVE = 31,
        PICKUP_FAILED = 32,
        DROPOFF_GOING = 40,
        DROPOFF_ARRIVE = 41,
        DROPOFF_FAILED = 42,
    }

    public static class ArclItem
    {
        //----- 定数 ---------------------
        public static readonly string C_NOT_EXIST = "NOT_EXIST";

        //----- ディクショナリ --------------
        /// <summary>
        /// インデックスをキーとしたコマンド文字列ディクショナリ
        /// </summary>
        public static readonly IDictionary<ArclCommandIndexs, string> CmndDic = new Dictionary<ArclCommandIndexs, string>
        {
            {ArclCommandIndexs.applicationfaultclear,"applicationfaultclear" },
            {ArclCommandIndexs.applicationFaultQuery,"applicationfaultquery" },
            {ArclCommandIndexs.applicationfaultset,"applicationfaultset" },
            {ArclCommandIndexs.dock,"dock" },
            {ArclCommandIndexs.dotask,"dotask" },
            {ArclCommandIndexs.executemacro,"execute" },
            {ArclCommandIndexs.faultsget,"faultsget" },
            {ArclCommandIndexs.go,"go" },
            {ArclCommandIndexs.odometer,"odometer" },
            {ArclCommandIndexs.odometerreset,"odometerreset" },
            {ArclCommandIndexs.onelinestatus,"onelinestatus" },
            {ArclCommandIndexs.patrol,"patrol" },
            {ArclCommandIndexs.patrolonce,"patrolonce" },
            {ArclCommandIndexs.patrolresume,"patrolresume" },
            {ArclCommandIndexs.play,"play" },
            {ArclCommandIndexs.querydockstatus,"querydockstatus" },
            {ArclCommandIndexs.queryfaults,"queryfaults" },
            {ArclCommandIndexs.querymotors,"querymotors" },
            {ArclCommandIndexs.say,"say" },
            {ArclCommandIndexs.status,"status" },
            {ArclCommandIndexs.stop,"stop" },
            {ArclCommandIndexs.undock,"undock" },
            {ArclCommandIndexs.getGoals,"getgoals" },
            {ArclCommandIndexs.getMacros,"getmacros" },
            {ArclCommandIndexs.getRoutes,"getroutes" },
            {ArclCommandIndexs.help,"help" },
            {ArclCommandIndexs.inputList,"inputlist" },
            {ArclCommandIndexs.inputQuery,"inputquery" },
            {ArclCommandIndexs.outputList,"outputlist" },
            {ArclCommandIndexs.outputOff,"outputoff" },
            {ArclCommandIndexs.outputOn,"outputon" },
            {ArclCommandIndexs.outputQuery,"outputQuery" },
            {ArclCommandIndexs.payloadQuery,"pq" },
            {ArclCommandIndexs.payloadQueryLocal,"pql" },
            {ArclCommandIndexs.payloadRemove,"pr" },
            {ArclCommandIndexs.payloadSet,"ps" },
            {ArclCommandIndexs.payloadSlotCount,"psc" },
            {ArclCommandIndexs.payloadSlotCountLocal,"pscl" },
            {ArclCommandIndexs.popupSimple,"popupsimple" },
            {ArclCommandIndexs.queueCancel,"qc" },
            {ArclCommandIndexs.queueCancelLocal,"qcl" },
            {ArclCommandIndexs.queueDropoff,"qd" },
            {ArclCommandIndexs.queueModify,"qmod" },
            {ArclCommandIndexs.queueModifyLocal,"qmodl" },
            {ArclCommandIndexs.queueMulti,"qm" },
            {ArclCommandIndexs.queuePickup,"qp" },
            {ArclCommandIndexs.queuePickupDropoff,"qpd" },
            {ArclCommandIndexs.queueQuery,"qq" },
            {ArclCommandIndexs.queueQueryLocal,"qql" },
            {ArclCommandIndexs.queueShow,"qs" },
            {ArclCommandIndexs.queueShowCompleted,"qsc" },
            {ArclCommandIndexs.queueShowRobot,"qsr" },
            {ArclCommandIndexs.queueShowRobotLocal,"qsrl" },
            {ArclCommandIndexs.quit,"quit" },
        };
        /// <summary>
        /// インデックスをキーとしたコマンドレスポンス文字列ディクショナリ
        /// 複数必要な場合は「/」区切り
        /// </summary>
        public static readonly IDictionary<ArclCommandIndexs, string> ResDic = new Dictionary<ArclCommandIndexs, string>
        {
            {ArclCommandIndexs.applicationfaultclear,"ApplicationFaultClear_cleared" },
            {ArclCommandIndexs.applicationFaultQuery,"ApplicationFaultQuery:" },
            {ArclCommandIndexs.applicationfaultset,"Fault: " },
            {ArclCommandIndexs.dock,"DockingState: " },
            {ArclCommandIndexs.dotask,"Doing task" },
            {ArclCommandIndexs.executemacro,"Executing macro" },
            {ArclCommandIndexs.faultsget,"FaultList: " },
            {ArclCommandIndexs.go,"" },
            {ArclCommandIndexs.odometer,"Odometer: " },
            {ArclCommandIndexs.odometerreset,"Reset odometer" },
            {ArclCommandIndexs.onelinestatus,"Status:" },
            {ArclCommandIndexs.patrol,"Patrolling route" },
            {ArclCommandIndexs.patrolonce,"Patrolling route" },
            {ArclCommandIndexs.patrolresume,"Patrolling route" },
            {ArclCommandIndexs.play,"Playing" },
            {ArclCommandIndexs.querydockstatus,"DockingState: " },
            {ArclCommandIndexs.queryfaults,"EndQueryFaults" },
            {ArclCommandIndexs.querymotors,"Motors/Estop pressed/Estop relieved" },
            {ArclCommandIndexs.say,"Saying" },
            {ArclCommandIndexs.status,"ExtendedStatusForHumans:" },
            {ArclCommandIndexs.stop,"Stopped" },
            {ArclCommandIndexs.undock,"Stopped" },
            {ArclCommandIndexs.getGoals,"End of goals" },
            {ArclCommandIndexs.getMacros,"End of macros" },
            {ArclCommandIndexs.getRoutes,"End of routes" },
            {ArclCommandIndexs.help,"End of commands" },
            {ArclCommandIndexs.inputList,"End of InputList" },
            {ArclCommandIndexs.inputQuery,"Input: " },
            {ArclCommandIndexs.outputList,"End of OutputList" },
            {ArclCommandIndexs.outputOff,"Output: " },
            {ArclCommandIndexs.outputOn,"Output: " },
            {ArclCommandIndexs.outputQuery,"Output: " },
            {ArclCommandIndexs.payloadQuery,"EndPayloadQuery" },
            {ArclCommandIndexs.payloadQueryLocal,"EndPayloadQuery" },
            {ArclCommandIndexs.payloadRemove,"PayloadUpdate" },
            {ArclCommandIndexs.payloadSet,"PayloadUpdate" },
            {ArclCommandIndexs.payloadSlotCount,"EndPayloadSlotCount" },
            {ArclCommandIndexs.payloadSlotCountLocal,"EndPayloadSlotCount" },
            {ArclCommandIndexs.popupSimple,"Creating simple popup" },
            {ArclCommandIndexs.queueCancel,"QueueUpdate: " },
            {ArclCommandIndexs.queueCancelLocal,"QueueUpdate: " },
            {ArclCommandIndexs.queueDropoff,"QueueUpdate: " },
            {ArclCommandIndexs.queueModify,"QueueUpdate: " },
            {ArclCommandIndexs.queueModifyLocal,"QueueUpdate: " },
            {ArclCommandIndexs.queueMulti,"QueueUpdate: " },
            {ArclCommandIndexs.queuePickup,"queuepickup" },
            {ArclCommandIndexs.queuePickupDropoff,"QueueUpdate: " },
            {ArclCommandIndexs.queueQuery,"QueueUpdate: " },
            {ArclCommandIndexs.queueQueryLocal,"QueueUpdate: " },
            {ArclCommandIndexs.queueShow,"QueueUpdate: " },
            {ArclCommandIndexs.queueShowCompleted,"QueueUpdate: " },
            {ArclCommandIndexs.queueShowRobot,"EndQueueShowRobot" },
            {ArclCommandIndexs.queueShowRobotLocal,"QueueUpdate: " },
            {ArclCommandIndexs.quit,"" },
        };
        /// <summary>
        /// インデックスをキーとしたコマンドパラメータ有無判定ディクショナリ
        /// ・パラメータが不要な場合はnull
        /// ・パラメータが必要な場合は、パラメータ文字列のガイドコメント文字列
        /// </summary>
        public static readonly IDictionary<ArclCommandIndexs, string> ParamDic = new Dictionary<ArclCommandIndexs, string>
        {
            {ArclCommandIndexs.applicationfaultclear,"<異常名>" },
            {ArclCommandIndexs.applicationFaultQuery,null },
            {ArclCommandIndexs.applicationfaultset,"<異常名>_<簡易説明>_<詳細説明>_<0or1(1はdriving異常)>_<0or1(1はcritical異常)>" },
            {ArclCommandIndexs.dock,null },
            {ArclCommandIndexs.dotask,"<タスク名>_<arg>" },
            {ArclCommandIndexs.executemacro,"<マクロ名>" },
            {ArclCommandIndexs.faultsget,null },
            {ArclCommandIndexs.go,null },
            {ArclCommandIndexs.odometer,null },
            {ArclCommandIndexs.odometerreset,null },
            {ArclCommandIndexs.onelinestatus,null },
            {ArclCommandIndexs.patrol,"<ルート名>" },
            {ArclCommandIndexs.patrolonce,"<ルート名>_<ゴールインデックス番号>" },
            {ArclCommandIndexs.patrolresume, "<ルート名>"},
            {ArclCommandIndexs.play,"<wavファイル名(フォルダ間は「/」を使用)>" },
            {ArclCommandIndexs.querydockstatus,null },
            {ArclCommandIndexs.queryfaults,"<ロボット名(全機表示の場合「default」）>_<各行終端付加文字列>" },
            {ArclCommandIndexs.querymotors,null },
            {ArclCommandIndexs.say,"<音声名>" },
            {ArclCommandIndexs.status,null },
            {ArclCommandIndexs.stop,null },
            {ArclCommandIndexs.undock,null },
            {ArclCommandIndexs.getGoals,null },
            {ArclCommandIndexs.getMacros,null },
            {ArclCommandIndexs.getRoutes,null },
            {ArclCommandIndexs.help,null },
            {ArclCommandIndexs.inputList,null },
            {ArclCommandIndexs.inputQuery,"<入力名>" },
            {ArclCommandIndexs.outputList,null },
            {ArclCommandIndexs.outputOff,"<出力名>" },
            {ArclCommandIndexs.outputOn,"<出力名>" },
            {ArclCommandIndexs.outputQuery,"<出力名>" },
            {ArclCommandIndexs.payloadQuery,"<ロボット名>_<スロット番号>_<各行終端付加文字列>" },
            {ArclCommandIndexs.payloadQueryLocal,"<スロット番号>_<各行終端付加文字列>" },
            {ArclCommandIndexs.payloadRemove,"<スロット番号>" },
            {ArclCommandIndexs.payloadSet,"<スロット番号>_<荷物名>" },
            {ArclCommandIndexs.payloadSlotCount,"<ロボット名>_<各行終端付加文字列>" },
            {ArclCommandIndexs.payloadSlotCountLocal,null },
            {ArclCommandIndexs.popupSimple,"<タイトル>_<メッセージ>_<ボタンラベル文字>_<表示時間[sec]> (※タイトル、メッセージ、ボタンラベル文字は２重引用符で囲うこと)" },
            {ArclCommandIndexs.queueCancel,"<ジョブタイプ>_<タイプ対応値>_<各行終端付加文字列>_<取消理由文字列>" },
            {ArclCommandIndexs.queueCancelLocal,"<ジョブタイプ>_<タイプ対応値>_<各行終端付加文字列>_<取消理由文字列>" },
            {ArclCommandIndexs.queueDropoff,"<ゴール名>_<優先度>_<JobID>" },
            {ArclCommandIndexs.queueModify,"<ジョブセグメントID>_<変更タイプ>_<使用タイプに対応する値>" },
            {ArclCommandIndexs.queueModifyLocal,"<ジョブセグメントID>_<変更タイプ>_<使用タイプに対応する値>" },
            {ArclCommandIndexs.queueMulti,"<ゴール数>_<ゴール使用フィールド数>_<goal1>_<goal1args>_…_<jobID>" },
            {ArclCommandIndexs.queuePickup,"<ゴール名>_<優先度>_<JobID>" },
            {ArclCommandIndexs.queuePickupDropoff,"<ピックアップゴール名>_<ドロップオフゴール名>_<ピックアップ優先度>_<ドロップオフ優先度>_<JobID>" },
            {ArclCommandIndexs.queueQuery,"<タイプ>_<タイプ対応値>_<各行終端付加文字列>" },
            {ArclCommandIndexs.queueQueryLocal,"<タイプ>_<タイプ対応値>_<各行終端付加文字列>" },
            {ArclCommandIndexs.queueShow,"<各行終端付加文字列>" },
            {ArclCommandIndexs.queueShowCompleted,"<各行終端付加文字列>" },
            {ArclCommandIndexs.queueShowRobot,"<ロボット名（全て表示させる場合は[default]）>_<各行終端付加文字列>" },
            {ArclCommandIndexs.queueShowRobotLocal,"<各行終端付加文字列>" },
            {ArclCommandIndexs.quit,null },
        };
        /// <summary>
        /// インデックスをキーとしたコマンドパラメータ使用対象判定ディクショナリ
        /// ・ロボットでもEMでも使用できる場合は「ANY」
        /// ・ロボットのみの場合は「LD」
        /// ・EMのみの場合は「EM」
        /// </summary>
        public static readonly IDictionary<ArclCommandIndexs, string> UseDic = new Dictionary<ArclCommandIndexs, string>
        {
            {ArclCommandIndexs.applicationfaultclear,"LD" },
            {ArclCommandIndexs.applicationFaultQuery,"LD" },
            {ArclCommandIndexs.applicationfaultset,"LD" },
            {ArclCommandIndexs.dock,"LD" },
            {ArclCommandIndexs.dotask,"LD" },
            {ArclCommandIndexs.executemacro,"LD" },
            {ArclCommandIndexs.faultsget,"LD" },
            {ArclCommandIndexs.go,"LD" },
            {ArclCommandIndexs.odometer,"LD" },
            {ArclCommandIndexs.odometerreset,"LD" },
            {ArclCommandIndexs.onelinestatus,"LD" },
            {ArclCommandIndexs.patrol,"LD" },
            {ArclCommandIndexs.patrolonce,"LD" },
            {ArclCommandIndexs.patrolresume, "LD"},
            {ArclCommandIndexs.play,"LD" },
            {ArclCommandIndexs.querydockstatus,"LD" },
            {ArclCommandIndexs.queryfaults,"EM" },
            {ArclCommandIndexs.querymotors,"LD" },
            {ArclCommandIndexs.say,"LD" },
            {ArclCommandIndexs.status,"LD" },
            {ArclCommandIndexs.stop,"LD" },
            {ArclCommandIndexs.undock,"LD" },
            {ArclCommandIndexs.getGoals,"ANY" },
            {ArclCommandIndexs.getMacros,"LD" },
            {ArclCommandIndexs.getRoutes,"LD" },
            {ArclCommandIndexs.help,"LD" },
            {ArclCommandIndexs.inputList,"LD" },
            {ArclCommandIndexs.inputQuery,"LD" },
            {ArclCommandIndexs.outputList,"LD" },
            {ArclCommandIndexs.outputOff,"LD" },
            {ArclCommandIndexs.outputOn,"LD" },
            {ArclCommandIndexs.outputQuery,"LD" },
            {ArclCommandIndexs.payloadQuery,"EM" },
            {ArclCommandIndexs.payloadQueryLocal,"LD" },
            {ArclCommandIndexs.payloadRemove,"LD" },
            {ArclCommandIndexs.payloadSet,"LD" },
            {ArclCommandIndexs.payloadSlotCount,"EM" },
            {ArclCommandIndexs.payloadSlotCountLocal,"LD" },
            {ArclCommandIndexs.popupSimple,"ANY" },
            {ArclCommandIndexs.queueCancel,"EM" },
            {ArclCommandIndexs.queueCancelLocal,"LD" },
            {ArclCommandIndexs.queueDropoff,"LD" },
            {ArclCommandIndexs.queueModify,"EM" },
            {ArclCommandIndexs.queueModifyLocal,"LD" },
            {ArclCommandIndexs.queueMulti,"EM" },
            {ArclCommandIndexs.queuePickup,"EM" },
            {ArclCommandIndexs.queuePickupDropoff,"EM" },
            {ArclCommandIndexs.queueQuery,"EM" },
            {ArclCommandIndexs.queueQueryLocal,"LD" },
            {ArclCommandIndexs.queueShow,"EM" },
            {ArclCommandIndexs.queueShowCompleted,"EM" },
            {ArclCommandIndexs.queueShowRobot,"EM" },
            {ArclCommandIndexs.queueShowRobotLocal,"LD" },
            {ArclCommandIndexs.quit,"ANY" },
        };
        /// <summary>
        /// インデックスをキーとしたコマンドガイド文字列ディクショナリ
        /// </summary>
        public static readonly IDictionary<ArclCommandIndexs, string> GuideDic = new Dictionary<ArclCommandIndexs, string>
        {
            {ArclCommandIndexs.applicationfaultclear,"名称指定した異常をクリア" },
            {ArclCommandIndexs.applicationFaultQuery,"" },
            {ArclCommandIndexs.applicationfaultset,"アプリケーション異常を設定" },
            {ArclCommandIndexs.dock,"dockへ移動" },
            {ArclCommandIndexs.dotask,"１つのタスクを実行する" },
            {ArclCommandIndexs.executemacro,"指定したマクロを実行する" },
            {ArclCommandIndexs.faultsget,"現在トリガされている全ての異常のリストを取得" },
            {ArclCommandIndexs.go,"ロボットの動作を再開する" },
            {ArclCommandIndexs.odometer,"ロボット走行オドメータ値を表示" },
            {ArclCommandIndexs.odometerreset,"ロボット走行オドメータ値をリセット" },
            {ArclCommandIndexs.onelinestatus,"ロボットの状態、バッテリ電圧、位置データを１行で取得" },
            {ArclCommandIndexs.patrol,"指定ルートを連続パトロール" },
            {ArclCommandIndexs.patrolonce,"指定ルートを１回パトロール" },
            {ArclCommandIndexs.patrolresume,"現在ルートのパトロールを再開" },
            {ArclCommandIndexs.play,"wavファイルを再生" },
            {ArclCommandIndexs.querydockstatus,"ドッキング／充電ステータスを取得" },
            {ArclCommandIndexs.queryfaults,"異常のリストを表示" },
            {ArclCommandIndexs.querymotors,"ロボットモータの状態を表示" },
            {ArclCommandIndexs.say,"ロボットのオーディオ出力から文字列の音声を出力" },
            {ArclCommandIndexs.status,"ロボットの動作状態を取得" },
            {ArclCommandIndexs.stop,"ロボット動作を停止" },
            {ArclCommandIndexs.undock,"ロボットをドッキングステーションから分離" },
            {ArclCommandIndexs.getGoals,"現在のマップに含まれるゴール名のリストを取得" },
            {ArclCommandIndexs.getMacros,"現在のマップに含まれるマクロ名のリストを取得" },
            {ArclCommandIndexs.getRoutes,"現在のマップ上のルートリストを表示" },
            {ArclCommandIndexs.help,"使用可能なARCLコマンドとその簡易説明リストを表示" },
            {ArclCommandIndexs.inputList,"デジタル入力名をリスト表示" },
            {ArclCommandIndexs.inputQuery,"指定した入力の状態（値）をクエリ" },
            {ArclCommandIndexs.outputList,"デジタル出力名をリスト表示" },
            {ArclCommandIndexs.outputOff,"指定したデジタル出力をオフにする" },
            {ArclCommandIndexs.outputOn,"指定したデジタル出力をオンにする" },
            {ArclCommandIndexs.outputQuery,"指定した出力の状態（値）をクエリ" },
            {ArclCommandIndexs.payloadQuery,"指定ロボットの指定スロットの荷物の有無を取得" },
            {ArclCommandIndexs.payloadQueryLocal,"指定スロットの荷物の有無を取得" },
            {ArclCommandIndexs.payloadRemove,"ロボットの指定ペイロードスロットを空（Empty）にする" },
            {ArclCommandIndexs.payloadSet,"ロボットのペイロードスロット（スロット番号、貨物名）を定義" },
            {ArclCommandIndexs.payloadSlotCount,"特定もしくは全ロボットのスロット数を表示" },
            {ArclCommandIndexs.payloadSlotCountLocal,"スロット数を表示" },
            {ArclCommandIndexs.popupSimple,"MobilePlannerソフトウェアにポップアップメッセージを表示" },
            {ArclCommandIndexs.queueCancel,"ロボットのキューに入れられたリクエストをタイプ別または値別に取り消す" },
            {ArclCommandIndexs.queueCancelLocal,"ロボットのキューに入れられたリクエストをタイプ別または値別に取り消す" },
            {ArclCommandIndexs.queueDropoff,"ロボットをドロップオフゴールのキューに入れる" },
            {ArclCommandIndexs.queueModify,"対応するジョブタイプのジョブセグメントのゴールと優先度を変更" },
            {ArclCommandIndexs.queueModifyLocal,"対応するジョブタイプのジョブセグメントのゴールと優先度を変更" },
            {ArclCommandIndexs.queueMulti,"複数ゴールのピックアップ/ドロップオフを実施" },
            {ArclCommandIndexs.queuePickup,"ピックアップ利用可能ないずれかのロボットを呼び出す" },
            {ArclCommandIndexs.queuePickupDropoff,"利用可能なロボットにピックアップとドロップオフを指示する" },
            {ArclCommandIndexs.queueQuery,"タイプ別または値別にキューのジョブステータスを表示" },
            {ArclCommandIndexs.queueQueryLocal,"タイプ別または値別にキューのジョブステータスを表示" },
            {ArclCommandIndexs.queueShow,"キュー内の最新11件のジョブステータスを表示（古い昇順）" },
            {ArclCommandIndexs.queueShowCompleted,"キュー内のCompletedジョブステータスを表示（古い昇順）" },
            {ArclCommandIndexs.queueShowRobot,"EMに接続されている全てのロボット（または特定）のステータスを表示" },
            {ArclCommandIndexs.queueShowRobotLocal,"ロボットのステータスを表示" },
            {ArclCommandIndexs.quit,"ARCLクライアントサーバ接続を終了する" },
        };

        /// <summary>
        /// インデックスをキーとしたステータスキー文字列ディクショナリ
        /// </summary>
        public static readonly IDictionary<ArclStatusIndexs, string> StatusKeyDic = new Dictionary<ArclStatusIndexs, string>
        {
            {ArclStatusIndexs.INTERRUPT,"Interrupted: " },
            {ArclStatusIndexs.JOBID,"JOB" },
            {ArclStatusIndexs.ESTOP_ON,"EStop pressed" },
            {ArclStatusIndexs.ESTOP_OFF,"EStop relieved" },
            {ArclStatusIndexs.IDLE_STOP,"Stop" },
            {ArclStatusIndexs.IDLE_PARK,"Park" },
            {ArclStatusIndexs.IDLE_DOCK,"Dock" },
            {ArclStatusIndexs.PICKUP_GOING, "Going to p" },
            {ArclStatusIndexs.PICKUP_ARRIVE,"Arrived at p" },
            {ArclStatusIndexs.PICKUP_FAILED,"Failed None Goal \"p" },
            {ArclStatusIndexs.DROPOFF_GOING,"Going to d" },
            {ArclStatusIndexs.DROPOFF_ARRIVE,"Arrived at d" },
            {ArclStatusIndexs.DROPOFF_FAILED,"Failed None Goal \"d" },
        };

        //----- メソッド -------------------
        /// <summary>
        /// ARCLコマンド文字列から、対応するインデックス番号を取得
        /// 存在しない場合「NONE」のインデックス番号を返す
        /// </summary>
        /// <param name="arclCommand">ARCLコマンド文字列</param>
        /// <returns>インデックス番号</returns>
        public static ArclCommandIndexs GetCmndIndex(string arclCommand)
        {
            ArclCommandIndexs index = ArclCommandIndexs.NONE;
            foreach (var item in ArclItem.CmndDic)
            {
                if (item.Value == arclCommand) { index = item.Key; break; }
            }
            return index;
        }

        /// <summary>
        /// ARCLコマンド文字列から、対応するレスポンスキー文字列を取得
        /// </summary>
        /// <param name="arclCommand">ARCLコマンド文字列</param>
        /// <returns></returns>
        public static string GetCmndResponceKey(string arclCommand)
        {
            var index = GetCmndIndex(arclCommand);
            if (index == ArclCommandIndexs.NONE) { return ""; }

            var result = GetCmndDicValue(ArclItem.ResDic, index);
            if (result == C_NOT_EXIST) { return ""; }
            return result;
        }
        /// <summary>
        /// ARCLコマンド文字列から、パラメータ入力有無を判定する
        /// Valueが「null」のコマンドはパラメータが存在しない
        /// </summary>
        /// <param name="arclCommand">ARCLコマンド文字列</param>
        /// <param name="guide">パラメータ有の場合の設定ガイド</param>
        /// <returns>true：パラメータ有</returns>
        public static bool GetCmndParameter(string arclCommand, out string guide)
        {
            guide = "";
            var index = GetCmndIndex(arclCommand);
            if (index == ArclCommandIndexs.NONE) { return false; }

            var result = GetCmndDicValue(ArclItem.ParamDic, index);
            //キーが存在しない場合
            if (result == C_NOT_EXIST) { return false; }
            //キーが存在するが、Valueがnullの場合
            if (result == null) { return false; }
            //キーが存在し、Valueがnull以外の場合
            guide = result;
            return true;
        }
        /// <summary>
        /// ARCLコマンド文字列から、使用対象と適合するか判定する
        /// </summary>
        /// <param name="arclCommand">ARCLコマンド文字列</param>
        /// <param name="target">現在の通信対象（「LD」もしくは「EM」）</param>
        /// <returns>true：適合</returns>
        public static bool GetCmndUse(string arclCommand, string target)
        {
            var index = GetCmndIndex(arclCommand);
            if (index == ArclCommandIndexs.NONE) { return false; }

            var result = GetCmndDicValue(ArclItem.UseDic, index);
            //キーが存在しない場合
            if (result == C_NOT_EXIST) { return false; }
            //Valueが「ANY」の場合、全対象コマンド
            if (result == "ANY") { return true; }
            //Valueとtargetが一致する場合
            if (result == target) { return true; }
            //Valueとtargetが一致しない場合
            return false;
        }
        /// <summary>
        /// ARCLコマンド文字列から、コマンドガイドを取得する
        /// </summary>
        /// <param name="arclCommand">ARCLコマンド文字列</param>
        /// <returns>コマンドガイド</returns>
        public static string GetCmndGuide(string arclCommand)
        {
            var index = GetCmndIndex(arclCommand);
            if (index == ArclCommandIndexs.NONE) { return ""; }

            var result = GetCmndDicValue(ArclItem.GuideDic, index);
            if (result == C_NOT_EXIST) { return ""; }
            return result;
        }
        /// <summary>
        /// 対象機器で使用可能コマンドの登録情報を出力
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string GetCmndAllInfo(string target)
        {
            var result = "コマンド名,    ガイド,    パラメータ" + Environment.NewLine;
            foreach (var item in ArclItem.CmndDic)
            {
                GetCmndParameter(item.Value, out string prGuide);
                if (GetCmndUse(item.Value, target))
                {
                    result += item.Value + ",   " + GetCmndGuide(item.Value) + ",   " + prGuide + Environment.NewLine;
                }

            }
            return result;
        }

        /// <summary>
        /// 対象ディクショナリのキーインデックスに対応するValueを取得する
        /// キーが存在しない場合、C_NOT_EXISTを返す
        /// </summary>
        /// <param name="dic">検索対象ディクショナリ</param>
        /// <param name="index">検索キーインデックス番号</param>
        /// <returns></returns>
        private static string GetCmndDicValue(IDictionary<ArclCommandIndexs, string> dic, ArclCommandIndexs index)
        {
            if (!dic.ContainsKey(index))
            {
                return C_NOT_EXIST;
            }
            else
            {
                return dic[index];
            }
        }

        /// <summary>
        /// ステータスキー文字列から、対応するインデックス番号を取得
        /// 存在しない場合「NONE」のインデックス番号を返す
        /// </summary>
        /// <param name="statusKey">ステータスキー文字列</param>
        /// <returns>インデックス番号</returns>
        public static ArclStatusIndexs GetStatusIndex(string statusKey)
        {
            ArclStatusIndexs index = ArclStatusIndexs.NONE;
            foreach (var item in StatusKeyDic)
            {
                if (item.Value == statusKey) { index = item.Key; break; }
            }
            return index;
        }
        /// <summary>
        /// ステータスキー文字列から、対応するインデックス番号を取得
        /// 存在しない場合「NONE」のインデックス番号を返す
        /// </summary>
        /// <param name="statusKey">ステータスキー文字列</param>
        /// <returns>インデックス番号</returns>
        public static string GetStatusKey(ArclStatusIndexs index)
        {
            string result = null;
            foreach (var item in StatusKeyDic)
            {
                if (item.Key == index) { result = item.Value; break; }
            }
            return result;
        }

    }
}
