;テストワーク測定プログラム

;----- common parameters -------
;速度
#1100 = 100.0
#1110 = 3750.0
#1103 = 100.0
#1113 = 3750.0
;退避位置
#1133 = 50.0
;プローブ半径
#1500 = 2.0
;退避位置
#1133 = 50.0
;ストローク
#1610 = 2.0 ;アプローチ <-> 目標
#1620 = 2.0 ;早送り <-> 目標
#1630 = 2.0 ;目標 <-> リミット
;-------------------------------

#83 = 0.0 ;Z軸 オフセット
#90 = 0.0 ;測定カウンタ
#99 = 0.0 ;測定番号

gosub escapeZ

;点計測
#1609 = 0.0 ;設定モード

;==== Z高さ測定 =========

#99 = 101.1
#1600 = 0.0
#1631 = 25.0
#1632 = 40.0
#1633 = [30.0 + #83]
gosub probePointZ
gosub probePointLog

#99 = 101.2
#1600 = 0.0
#1631 = 25.0
#1632 = 60.0
#1633 = [30.0 + #83]
;gosub probePointZ
;gosub probePointLog

#99 = 101.3
#1600 = 0.0
#1631 = 25.0
#1632 = 110.0
#1633 = [30.0 + #83]
;gosub probePointZ
;gosub probePointLog

gosub escapeZ

#99 = 102.1
#1600 = 0.0
#1631 = 10.0
#1632 = 60.0
#1633 = [20.0 + #83]
gosub probePointZ
gosub probePointLog

#99 = 102.2
#1600 = 0.0
#1631 = 10.0
#1632 = 70.0
#1633 = [20.0 + #83]
;gosub probePointZ
;gosub probePointLog

#99 = 102.3
#1600 = 0.0
#1631 = 10.0
#1632 = 80.0
#1633 = [20.0 + #83]
;gosub probePointZ
;gosub probePointLog

gosub escapeZ

#99 = 103.1
#1600 = 0.0
#1631 = 60.0
#1632 = 80.0
#1633 = [20.0 + #83]
gosub probePointZ
gosub probePointLog

#99 = 103.2
#1600 = 0.0
#1631 = 60.0
#1632 = 70.0
#1633 = [20.0 + #83]
;gosub probePointZ
;gosub probePointLog

#99 = 103.3
#1600 = 0.0
#1631 = 60.0
#1632 = 60.0
#1633 = [20.0 + #83]
;gosub probePointZ
;gosub probePointLog

gosub escapeZ

;==== XY測定 ==============

#99 = 2.1
#1600 = 0.0 ;動作角度
#1631 = 0.0 ;X軸 目標位置
#1632 = 10.0 ;Y軸 目標位置
#1633 = [25.0 + #83] ; Z軸 目標位置
gosub probePointXY
gosub probePointLog

#99 = 2.2
#1600 = 0.0
#1631 = 0.0
#1632 = 25.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

#99 = 2.3
#1600 = 0.0
#1631 = 0.0
#1632 = 40.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

gosub escapeZ

#99 = 3.1
#1600 = 315.0
#1631 = 2.0
#1632 = 48.0
#1633 = [25.0 + #83]
gosub probePointXY
gosub probePointLog

gosub escapeZ

;NoP04
#99 = 4.1
#1600 = 270.0
#1631 = 5.0
#1632 = 50.0
#1633 = [25.0 + #83]
gosub probePointXY
gosub probePointLog

#99 = 4.2
#1600 = 270.0
#1631 = 8.0
#1632 = 50.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

#99 = 4.3
#1600 = 270.0
#1631 = 11.0
#1632 = 50.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

#99 = 5.1
#1600 = 315.0
#1631 = 15.0
#1632 = 50.0
#1633 = [25.0 + #83]
gosub probePointXY
gosub probePointLog

#99 = 6.1
#1600 = 0.0
#1631 = 15.0
#1632 = 60.0
#1633 = [25.0 + #83]
gosub probePointXY
gosub probePointLog

#99 = 6.2
#1600 = 0.0
#1631 = 15.0
#1632 = 70.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

#99 = 6.3
#1600 = 0.0
#1631 = 15.0
#1632 = 80.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

#99 = 7.1
#1600 = 45.0
#1631 = 15.0
#1632 = 85.0
#1633 = [25.0 + #83]
gosub probePointXY
gosub probePointLog

#99 = 8.1
#1600 = 90.0
#1631 = 11.0
#1632 = 85.0
#1633 = [25.0 + #83]
gosub probePointXY
gosub probePointLog

#99 = 8.2
#1600 = 90.0
#1631 = 8.0
#1632 = 85.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

#99 = 8.3
#1600 = 90.0
#1631 = 5.0
#1632 = 85.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

gosub escapeZ

#99 = 9.1
#1600 = 45.0
#1631 = 2.0
#1632 = 87.0
#1633 = [25.0 + #83]
gosub probePointXY
gosub probePointLog

gosub escapeZ

#99 = 10.1
#1600 = 0.0
#1631 = 0.0
#1632 = 90.0
#1633 = [25.0 + #83]
gosub probePointXY
gosub probePointLog

#99 = 10.2
#1600 = 0.0
#1631 = 0.0
#1632 = 100.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

#99 = 10.3
#1600 = 0.0
#1631 = 0.0
#1632 = 110.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

gosub escapeZ

#99 = 11.1
#1600 = 315.0
#1631 = 2.5
#1632 = 122.5
#1633 = [25.0 + #83]
gosub probePointXY
gosub probePointLog

gosub escapeZ

#99 = 12.1
#1600 = 270.0
#1631 = 20.0
#1632 = 125.0
#1633 = [25.0 + #83]
gosub probePointXY
gosub probePointLog

#99 = 12.2
#1600 = 270.0
#1631 = 40.0
#1632 = 125.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

#99 = 12.3
#1600 = 270.0
#1631 = 60.0
#1632 = 125.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

gosub escapeZ

#99 = 13.1
#1600 = 225.0
#1631 = 77.5
#1632 = 122.5
#1633 = [25.0 + #83]
gosub probePointXY
gosub probePointLog

gosub escapeZ

#99 = 14.1
#1600 = 180.0
#1631 = 80.0
#1632 = 117.0
#1633 = [25.0 + #83]
gosub probePointXY
gosub probePointLog

gosub escapeZ

#99 = 15.1
#1600 = 135.0
#1631 = 75.0
#1632 = 110.0
#1633 = [25.0 + #83]
gosub probePointXY
gosub probePointLog

#99 = 15.2
#1600 = 135.0
#1631 = 65.0
#1632 = 100.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

#99 = 15.3
#1600 = 135.0
#1631 = 55.0
#1632 = 90.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

gosub escapeZ

#99 = 16.1
#1600 = 90.0
#1631 = 48.0
#1632 = 85.0
#1633 = [25.0 + #83]
gosub probePointXY
gosub probePointLog

#99 = 16.2
#1600 = 90.0
#1631 = 45.0
#1632 = 85.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

#99 = 16.3
#1600 = 90.0
#1631 = 42.0
#1632 = 85.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

#99 = 17.1
#1600 = 135.0
#1631 = 36.5
#1632 = 83.5
#1633 = [25.0 + #83]
gosub probePointXY
gosub probePointLog

#99 = 18.1
#1600 = 180.0
#1631 = 35.0
#1632 = 80.0
#1633 = [25.0 + #83]
gosub probePointXY
gosub probePointLog

#99 = 18.2
#1600 = 180.0
#1631 = 35.0
#1632 = 70.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

#99 = 18.3
#1600 = 180.0
#1631 = 35.0
#1632 = 60.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

#99 = 19.1
#1600 = 225.0
#1631 = 36.5
#1632 = 51.5
#1633 = [25.0 + #83]
gosub probePointXY
gosub probePointLog

#99 = 20.1
#1600 = 270.0
#1631 = 40.0
#1632 = 50.0
#1633 = [25.0 + #83]
gosub probePointXY
gosub probePointLog

#99 = 20.2
#1600 = 270.0
#1631 = 50.0
#1632 = 50.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

#99 = 20.3
#1600 = 270.0
#1631 = 60.0
#1632 = 50.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

gosub escapeZ

#99 = 21.1
#1600 = 240.0
#1631 = 65.0
#1632 = 48.0
#1633 = [25.0 + #83]
gosub probePointXY
gosub probePointLog


#99 = 21.2
#1600 = 240.0
#1631 = 70.0
#1632 = 45.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

#99 = 21.3
#1600 = 240.0
#1631 = 75.0
#1632 = 42.5
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

gosub escapeZ

#99 = 22.1
#1600 = 180.0
#1631 = 80.0
#1632 = 30.0
#1633 = [25.0 + #83]
gosub probePointXY
gosub probePointLog

#99 = 22.2
#1600 = 180.0
#1631 = 80.0
#1632 = 20.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

#99 = 22.3
#1600 = 180.0
#1631 = 80.0
#1632 = 10.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

gosub escapeZ

#99 = 23.1
#1600 = 135.0
#1631 = 77.5
#1632 = 2.5
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

;gosub escapeZ

#99 = 24.1
#1600 = 90.0
#1631 = 70.0
#1632 = 0.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

#99 = 24.2
#1600 = 90.0
#1631 = 40.0
#1632 = 00.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

#99 = 24.3
#1600 = 90.0
#1631 = 10.0
#1632 = 00.0
#1633 = [25.0 + #83]
;gosub probePointXY
;gosub probePointLog

gosub escapeZ

;円計測
#1609 = 1.0

#99 = 1001.1
#1700 = 11.0
#1705 = 11.0
#1711 = 15.0
#1712 = 35.0
#1713 = [25.0 + #83]
gosub probeHoleX
gosub probeHoleLog

gosub escapeZ

#99 = 1002.1
#1700 = 11.0
#1705 = 11.0
#1711 = 15.0
#1712 = 115.0
#1713 = [25.0 + #83]
gosub probeHoleX
gosub probeHoleLog

gosub escapeZ

#99 = 1003.1
#1700 = 11.0
#1705 = 11.0
#1711 = 65.0
#1712 = 115.0
#1713 = [25.0 + #83]
gosub probeHoleX
gosub probeHoleLog

gosub escapeZ

#99 = 1004.1
#1700 = 7.0
#1705 = 7.0
#1711 = 70.0
#1712 = 67.5
#1713 = [15.0 + #83]
gosub probeHoleX
gosub probeHoleLog

gosub escapeZ

#99 = 1005.1
#1700 = 11.0
#1705 = 11.0
#1711 = 50.0
#1712 = 67.5
#1713 = [15.0 + #83]
gosub probeHoleX
gosub probeHoleLog

gosub escapeZ

#99 = 1006.1
#1700 = 6.0
#1705 = 6.0
#1711 = 65.0
#1712 = 35.0
#1713 = [25.0 + #83]
;gosub probeHoleX
;gosub probeHoleLog

gosub escapeZ

M2 