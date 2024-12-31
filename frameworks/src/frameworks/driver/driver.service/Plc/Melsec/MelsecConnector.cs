using System;

namespace Mov.Driver.Service.Plc.Melsec
{
    public class MelsecConnector
    {
        //----- フィールド --------------
        private int _actType;

        //----- キーコード --------------
        public enum ActTypes
        {
            None = 0,
            ForProgram = 1,
            ForUtl = 2,
        }

        //----- コンストラクタ ----------
        public MelsecConnector()
        {
            _actType = (int)ActTypes.None;
        }

        //----- メソッド ----------------
        /// <summary>
        /// オープン処理(ActProg)
        /// </summary>
        /// <returns></returns>
        public int OpenOnProg(int id, int protocol, string password)
        {

            int iReturnCode;                //コントロールのメソッドの戻り値

            try
            {
                //ActProgTypeが選択されている場合
                //ユニットタイプ(UNIT_QNUSB)の設定


                //プロトコルタイプ(PROTOCOL_USB)の設定


                //パスワードの設定


                //Open関数処理の実行
                iReturnCode = 0;

                //Openが成功した場合、イベントハンドラを生成する。

                if (iReturnCode == 0)
                {
                    _actType = (int)ActTypes.ForProgram;
                }

            }
            //例外処理

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                iReturnCode = -1;
            }

            //コントロールのメソッドの戻り値の表示(8桁の16進数)
            //resCode = String.Format("0x{0:x8} [HEX]", iReturnCode);
            return iReturnCode;
        }

        /// <summary>
        /// オープン処理(ActUtl)
        /// </summary>
        /// <returns></returns>
        public int OpenOnUtl(int logicalStationNo, string password)
        {

            int iReturnCode;                //コントロールのメソッドの戻り値

            try
            {

                //論理局番の設定



                //パスワードの設定


                //Open関数処理の実行

                iReturnCode = 0;
                //Openが成功した場合、LogicalStationNumberテキストボックスを無効にする。

                //Openが成功した場合、イベントハンドラを生成する。

                if (iReturnCode == 0)
                {
                    _actType = (int)ActTypes.ForUtl;
                }


            }
            //例外処理

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                iReturnCode = -1;
            }

            //コントロールのメソッドの戻り値の表示(8桁の16進数)
            //resCode = String.Format("0x{0:x8} [HEX]", iReturnCode);
            return iReturnCode;
        }

        /// <summary>
        /// クローズ処理
        /// </summary>
        /// <returns></returns>
        public int Close()
        {
            int iReturnCode;                //コントロールのメソッドの戻り値

            try
            {
                if (_actType == (int)ActTypes.ForProgram)
                {
                    iReturnCode = 0;
                }
                else if (_actType == (int)ActTypes.ForUtl)
                {
                    iReturnCode = 0;
                }
                else
                {
                    _actType = (int)ActTypes.None;
                    iReturnCode = 0;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                iReturnCode = -1;
            }
            //コントロールのメソッドの戻り値の表示(8桁の16進数)
            //resCode = String.Format("0x{0:x8} [HEX]", iReturnCode);
            return iReturnCode;
        }

        /// <summary>
        /// デバイス値の取得（２バイトデータ）
        /// </summary>
        /// <returns></returns>
        public int ReadDevice(string deviceName, int dataSize, out short[] result)
        {
            int iReturnCode;				//コントロールのメソッドの戻り値
            string szDeviceName = "";		//デバイス名文字列
            int iNumberOfData = dataSize;			//データサイズ
            short[] arrDeviceValue;		    //デバイス値格納用配列
            int iNumber;					//ループ用カウンタ
            short[] arrData;	    //結果表示データ格納用配列
            result = null;

            //デバイス名の取得

            //  テキストボックスのString 配列の各要素間を区切り記号「\n」で連結し、

            //  連結された単一の文字列を作成。

            szDeviceName = deviceName;

            //デバイス値用の領域を割り当て
            arrDeviceValue = new short[dataSize];

            //
            //ReadDeviceRandom2関数処理

            //
            try
            {
                //ラジオボタンでActProgTypeが選択されている場合

                if (_actType == (int)ActTypes.ForProgram)
                {
                    //ReadDeviceRandom関数処理の実行

                    iReturnCode = 0;
                }

                //ラジオボタンでActUtlTypeが選択されている場合

                else
                {
                    //ReadDeviceRandom関数処理の実行

                    iReturnCode = 0;
                }
            }

            //例外処理			
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                iReturnCode = -1;
            }

            //コントロールのメソッドの戻り値の表示(8桁の16進数)
            //resCode = String.Format("0x{0:x8}", iReturnCode);

            //
            //読出したデータの表示
            //
            //正常の場合

            if (iReturnCode == 0)
            {
                //結果表示データ格納用配列の領域確保

                arrData = new short[iNumberOfData];

                //結果表示用データの格納

                for (iNumber = 0; iNumber < iNumberOfData; iNumber++)
                {

                    arrData[iNumber] = arrDeviceValue[iNumber];

                }
                //結果データの表示
                result = arrData;

            }
            else
            {

            }
            return iReturnCode;
        }
        /// <summary>
        /// デバイス値の取得（２バイトデータ）
        /// </summary>
        /// <returns></returns>
        public (int returnCode, short[] result) ReadDeviceTuple(string deviceName, int dataSize)
        {
            int iReturnCode;				//コントロールのメソッドの戻り値
            string szDeviceName = "";		//デバイス名文字列
            int iNumberOfData = dataSize;			//データサイズ
            short[] arrDeviceValue;		    //デバイス値格納用配列
            int iNumber;					//ループ用カウンタ
            short[] arrData;	    //結果表示データ格納用配列
            int returnCode = -1;
            short[] result = null;

            //デバイス名の取得

            //  テキストボックスのString 配列の各要素間を区切り記号「\n」で連結し、

            //  連結された単一の文字列を作成。

            szDeviceName = deviceName;

            //デバイス値用の領域を割り当て
            arrDeviceValue = new short[dataSize];

            //
            //ReadDeviceRandom2関数処理

            //
            try
            {
                //ラジオボタンでActProgTypeが選択されている場合

                if (_actType == (int)ActTypes.ForProgram)
                {
                    //ReadDeviceRandom関数処理の実行

                    iReturnCode = 0;
                }

                //ラジオボタンでActUtlTypeが選択されている場合

                else
                {
                    //ReadDeviceRandom関数処理の実行

                    iReturnCode = 0;
                }
            }

            //例外処理			
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                iReturnCode = -1;
            }

            //コントロールのメソッドの戻り値の表示(8桁の16進数)
            //resCode = String.Format("0x{0:x8}", iReturnCode);

            //
            //読出したデータの表示
            //
            //正常の場合

            if (iReturnCode == 0)
            {
                //結果表示データ格納用配列の領域確保

                arrData = new short[iNumberOfData];

                //結果表示用データの格納

                for (iNumber = 0; iNumber < iNumberOfData; iNumber++)
                {

                    arrData[iNumber] = arrDeviceValue[iNumber];

                }
                //結果データの表示
                result = arrData;

            }
            else
            {

            }
            returnCode = iReturnCode;

            return (returnCode, result);
        }


        /// <summary>
        /// デバイスへ値を書き込み（２バイトデータ）
        /// </summary>
        /// <returns></returns>
        public int WriteDevice(string deviceName, int dataSize, short[] setValues)
        {
            int iReturnCode;				//コントロールのメソッドの戻り値
            short[] arrDeviceValue;		    //デバイス値格納用配列
            int iNumber;                    //ループ用カウンタ

            arrDeviceValue = setValues;

            //デバイス値の設定

            for (iNumber = 0; iNumber < dataSize; iNumber++)
            {
                arrDeviceValue[iNumber] = arrDeviceValue[iNumber];
            }

            //
            //WriteDeviceRandom2関数処理

            //
            try
            {
                //ラジオボタンでActProgTypeが選択されている場合

                if (_actType == (int)ActTypes.ForProgram)
                {
                    //WriteDeviceRandom関数処理の実行

                    iReturnCode = 0;
                }

                //ラジオボタンでActUtlTypeが選択されている場合

                else
                {
                    //WriteDeviceRandom関数処理の実行

                    iReturnCode = 0;
                }
            }

            //例外処理			
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                iReturnCode = -1;
            }

            //コントロールのメソッドの戻り値の表示(8桁の16進数)
            //resCode = String.Format("0x{0:x8}", iReturnCode);

            return iReturnCode;
        }

        /// <summary>
        /// デバイス群の一括取得
        /// </summary>
        /// <returns></returns>
        public int ReadDeviceBlock(string[] deviceNames, int dataSize, out short[] result)
        {
            int iReturnCode;				//コントロールのメソッドの戻り値
            string szDeviceName = "";		//デバイス名文字列
            int iNumberOfData = 0;			//データサイズ
            short[] arrDeviceValue;		    //デバイス値格納用配列
            int iNumber;					//ループ用カウンタ
            short[] arrData;	    //結果表示データ格納用配列
            result = null;

            //デバイス名の取得

            //  テキストボックスのString 配列の各要素間を区切り記号「\n」で連結し、

            //  連結された単一の文字列を作成。

            szDeviceName = string.Join("\n", deviceNames);

            //デバイス値用の領域を割り当て
            arrDeviceValue = new short[dataSize];

            //
            //ReadDeviceBlock2関数処理

            //
            try
            {
                //ラジオボタンでActProgTypeが選択されている場合

                if (_actType == (int)ActTypes.ForProgram)
                {
                    //ReadDeviceBlock2関数処理の実行

                    iReturnCode = 0;
                }

                //ラジオボタンでActUtlTypeが選択されている場合

                else
                {
                    //ReadDeviceBlock2関数処理の実行

                    iReturnCode = 0;
                }
            }

            //例外処理			
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                iReturnCode = -1;
            }

            //コントロールのメソッドの戻り値の表示(8桁の16進数)
            //resCode = String.Format("0x{0:x8}", iReturnCode);

            //
            //読出したデータの表示
            //
            //正常の場合

            if (iReturnCode == 0)
            {
                //結果表示データ格納用配列の領域確保

                arrData = new short[iNumberOfData];

                //結果表示用データの格納

                for (iNumber = 0; iNumber < iNumberOfData; iNumber++)
                {
                    arrData[iNumber] = arrDeviceValue[iNumber];
                }

                //結果データの表示
                result = arrData;
            }
            return iReturnCode;
        }

        /// <summary>
        /// デバイス群の一括取得
        /// </summary>
        /// <returns></returns>
        public (int returnCode, short[] result) ReadDeviceBlockTuple(string[] deviceNames, int dataSize)
        {
            int iReturnCode;				//コントロールのメソッドの戻り値
            string szDeviceName = "";		//デバイス名文字列
            int iNumberOfData = 0;			//データサイズ
            short[] arrDeviceValue;		    //デバイス値格納用配列
            int iNumber;					//ループ用カウンタ
            short[] arrData;	    //結果表示データ格納用配列
            int returnCode = -1;
            short[] result = null;

            //デバイス名の取得

            //  テキストボックスのString 配列の各要素間を区切り記号「\n」で連結し、

            //  連結された単一の文字列を作成。

            szDeviceName = string.Join("\n", deviceNames);

            //デバイス値用の領域を割り当て
            arrDeviceValue = new short[dataSize];

            //
            //ReadDeviceBlock2関数処理

            //
            try
            {
                //ラジオボタンでActProgTypeが選択されている場合

                if (_actType == (int)ActTypes.ForProgram)
                {
                    //ReadDeviceBlock2関数処理の実行

                    iReturnCode = 0;
                }

                //ラジオボタンでActUtlTypeが選択されている場合

                else
                {
                    //ReadDeviceBlock2関数処理の実行

                    iReturnCode = 0;
                }
            }

            //例外処理			
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                iReturnCode = -1;
            }

            //コントロールのメソッドの戻り値の表示(8桁の16進数)
            //resCode = String.Format("0x{0:x8}", iReturnCode);

            //
            //読出したデータの表示
            //
            //正常の場合

            if (iReturnCode == 0)
            {
                //結果表示データ格納用配列の領域確保

                arrData = new short[iNumberOfData];

                //結果表示用データの格納

                for (iNumber = 0; iNumber < iNumberOfData; iNumber++)
                {
                    arrData[iNumber] = arrDeviceValue[iNumber];
                }

                //結果データの表示
                result = arrData;
            }
            returnCode = iReturnCode;

            return (returnCode, result);
        }

        /// <summary>
        /// デバイス群の一括書き込み
        /// </summary>
        /// <returns></returns>
        public int WriteDeviceBlock(string[] deviceNames, int dataSize, short[] deviceDataes)
        {
            int iReturnCode;				//コントロールのメソッドの戻り値
            string szDeviceName = "";		//デバイス名文字列
            //int iNumberOfData = 0;			//データサイズ
            short[] arrDeviceValue;		        //デバイス値格納用配列
            int iNumber;					//ループ用カウンタ
            int iSizeOfIntArray;		//Int型配列のサイズ

            //デバイス名の取得

            //  テキストボックスのString 配列の各要素間を区切り記号「\n」で連結し、

            //  連結された単一の文字列を作成。

            szDeviceName = string.Join("\n", deviceNames);

            //Short型配列のサイズ取得

            iSizeOfIntArray = deviceDataes.Length;
            //デバイス値用の領域を割り当て
            arrDeviceValue = new short[dataSize];

            //Short型配列の取得

            for (iNumber = 0; iNumber < iSizeOfIntArray; iNumber++)
            {
                try
                {
                    arrDeviceValue[iNumber]
                        = Convert.ToInt16(deviceDataes[iNumber]);
                }

                //数値が入力されていなかった場合、数値が範囲外だった場合の例外処理

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    iReturnCode = -1;
                }
            }

            //
            //WriteDeviceBlock2関数処理

            //
            try
            {
                //ラジオボタンでActProgTypeが選択されている場合

                if (_actType == (int)ActTypes.ForProgram)
                {
                    //WriteDeviceBlock関数処理の実行

                    iReturnCode = 0;
                }

                //ラジオボタンでActUtlTypeが選択されている場合

                else
                {
                    //WriteDeviceBlock関数処理の実行

                    iReturnCode = 0;
                }
            }

            //例外処理			
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                iReturnCode = -1;
            }

            //コントロールのメソッドの戻り値の表示(8桁の16進数)
            //resCode = String.Format("0x{0:x8} [HEX]", iReturnCode);
            return iReturnCode;
        }
        /// <summary>
        /// 状態監視対象デバイス登録
        /// </summary>
        /// <returns></returns>
        public int EntryDeviceStatus(string[] deviceNames, int dataSize, int monitorCycle, int[] deviceData)
        {
            int iReturnCode;				//コントロールのメソッドの戻り値
            string szDeviceName = "";		//デバイス名文字列
            int iNumberOfData = dataSize;			//データサイズ
            int iMonitorCycle = monitorCycle;			//モニタ・サイクル
            int[] arrDeviceValue = deviceData;		        //デバイス値格納用配列

            //デバイス名の取得

            //  テキストボックスのString 配列の各要素間を区切り記号「\n」で連結し、

            //  連結された単一の文字列を作成。

            szDeviceName = string.Join("\n", deviceNames);


            //デバイス値の取得チェック(成功時は取得されている)
            arrDeviceValue = new int[iNumberOfData];

            //
            //EntryDeviceStatus関数処理

            //
            try
            {
                //ラジオボタンでActProgTypeが選択されている場合

                if (_actType == (int)ActTypes.ForProgram)
                {
                    //EntryDeviceStatus関数処理の実行

                    iReturnCode = 0;
                }

                //ラジオボタンでActUtlTypeが選択されている場合

                else
                {
                    //EntryDeviceStatus関数処理の実行

                    iReturnCode = 0;
                }
            }

            //例外処理			
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                iReturnCode = -1;
            }

            //コントロールのメソッドの戻り値の表示(8桁の16進数)
            //resCode = String.Format("0x{0:x8} [HEX]", iReturnCode);
            return iReturnCode;

        }
        /// <summary>
        /// 状態監視対象デバイスの開放
        /// </summary>
        /// <param name="resCode"></param>
        /// <returns></returns>
        public int FreeDeviceStatus()
        {
            int iReturnCode;    //コントロールのメソッドの戻り値


            //
            //FreeDeviceStatus関数処理

            //
            try
            {
                //ラジオボタンでActProgTypeが選択されている場合

                if (_actType == (int)ActTypes.ForProgram)
                {
                    //FreeDeviceStatus関数処理の実行

                    iReturnCode = 0;
                }

                //ラジオボタンでActUtlTypeが選択されている場合

                else
                {
                    //FreeDeviceStatus関数処理の実行

                    iReturnCode = 0;
                }
            }

            //例外処理

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                iReturnCode = -1;
            }

            //コントロールのメソッドの戻り値の表示(8桁の16進数)
            //resCode = String.Format("0x{0:x8} [HEX]", iReturnCode);
            return iReturnCode;
        }






        //----- 内部ロジック ----------------
        private bool GetShortArray(string[] lptxt_SourceOfShortArray, out short[] lplpshShortArrayValue)
        {
            int iSizeOfShortArray;		//Short型配列のサイズ
            int iNumber;				//ループ用カウンタ

            //Short型配列のサイズ取得

            iSizeOfShortArray = lptxt_SourceOfShortArray.Length;
            lplpshShortArrayValue = new short[iSizeOfShortArray];

            //Short型配列の取得

            for (iNumber = 0; iNumber < iSizeOfShortArray; iNumber++)
            {
                try
                {
                    lplpshShortArrayValue[iNumber]
                        = Convert.ToInt16(lptxt_SourceOfShortArray[iNumber]);
                }

                //数値が入力されていなかった場合、数値が範囲外だった場合の例外処理

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

            //正常終了

            return true;
        }

        private bool GetIntArray(string[] lptxt_SourceOfIntArray, out int[] lplpiIntArrayValue)
        {
            int iSizeOfIntArray;		//Int型配列のサイズ
            int iNumber;				//ループ用カウンタ

            //Int型配列のサイズ取得

            iSizeOfIntArray = lptxt_SourceOfIntArray.Length;
            lplpiIntArrayValue = new int[iSizeOfIntArray];

            //Int型配列の取得

            for (iNumber = 0; iNumber < iSizeOfIntArray; iNumber++)
            {
                try
                {
                    lplpiIntArrayValue[iNumber]
                        = Convert.ToInt32(lptxt_SourceOfIntArray[iNumber]);
                }

                //数値が入力されていなかった場合、数値が範囲外だった場合の例外処理

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

            //正常終了

            return true;
        }
        private bool GetIntValue(string lptxt_SourceOfIntValue, out int iGottenIntValue)
        {
            iGottenIntValue = 0;
            //int値を取得

            try
            {
                iGottenIntValue = Convert.ToInt32(lptxt_SourceOfIntValue);
            }

            //数値が入力されていなかった場合、数値が範囲外だった場合の例外処理

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            //正常終了

            return true;
        }

    }
}
