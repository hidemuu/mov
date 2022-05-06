;円形穴の中心、直径測定プログラム

;===========parameters=============
;feed rate
;#1 = 100.000
;Z-value of retracted position
;#2 = 25.000 
;nominal X-value of hole center
;#3 = 25.000
;nominal Y-value of hole center
;#4 = 25.000
;some Z-value inside the hole
;#5 = 15.000
;probe tip radius
;#6 = 2.000
;target hole diameter
;#7 = 25.000
;spec of hole diameter
;#8 = 22.213
;rapid feed rate
#15 = 1000.000
;rapid stroke diff inside the hole
#16 = 3.0
;ring gage ok UpperLimit(Spec + Inc)
#18 = 1.0000
;ring gage ok LowerLimit(Spec - Inc)
#19 = 1.000
;=================================

;進捗初期化
N001 #1099 = 0
N002 #1098 = 0
;Z軸をアプローチ位置へ移動
#1098 = 1
N050 G0 F[#15] Z[#2]
N060 #1001=#3  
N070 #1002=#4 
N080 #1003=#5  
N090 #1004=#6  
N100 #1005=[#7/2.0 - #1004]  
N101 #1006=[[#8/2.0 - #1004] - #16]
if [#1006 < 0]
    #1006 = 0
endif
;測定中心へ位置決め
#1098 = 2
N110 G0 X#1001 Y#1002 (move above nominal hole center)  
N120 G38.2 F[#15] Z#1003 (move into hole - to be cautious, substitute G1 for G0 here) 
if [#5067 == 0]
    ;===== 測定ロジック =========
    ;0度(+Y)方向アプローチ
    #1098 = 3
    G38.2 F[#15] Y[#1002 + #1006]
    ;0度(+Y)方向測定
    if[#5067 == 0]
        #1098 = 4
        N190 G38.2 F[#1] Y[#1002 + #1005] (probe +Y side of hole)  
        N200 #1012=#5062 (save results) 
    endif
    N210 G0 X#1001 Y#1002 (back to center of hole)  
    ;120度(+X/-Y)方向測定
    if[#5067 == 0]
        #1098 = 5
        N130 G38.2 F[#1] X[#1001 + #1005] Y[#1002 - #1006]   
        N140 #1011=#5061 (save results)  
    endif
    N150 G0 X#1001 Y#1002 (back to center of hole)  
    ;-X方向アプローチ
    #1098 = 5
    G38.2 F[#15] X[#1001 - #1006]
    ;-X方向測定
    if[#5067 == 0]
        #1098 = 6
        N160 G38.2 F[#1] X[#1001 - #1005] (probe -X side of hole) 
        N161 #1018=#5061 (save results)
    endif
    ;X方向中心点算出（暫定）
    N170 #1021=[[#1011 + #5061] / 2.0] (find pretty good X-value of hole center) 
    N180 G0 X#1021 Y#1002 (back to center of hole)  
    ;+Y方向アプローチ
    #1098 = 7
    G38.2 F[#15] Y[#1002 + #1006]
    ;+Y方向測定
    if[#5067 == 0]
        #1098 = 8
        N190 G38.2 F[#1] Y[#1002 + #1005] (probe +Y side of hole)  
        N200 #1012=#5062 (save results) 
    endif
    N210 G0 X#1021 Y#1002 (back to center of hole)  
    ;-Y方向アプローチ
    #1098 = 9
    G38.2 F[#15] Y[#1002 - #1006]
    ;-Y方向測定
    if[#5067 == 0]
        #1098 = 10
        N220 G38.2 F[#1] Y[#1002 - #1005] (probe -Y side of hole) 
        N221 #1019=#5062 (save results)
    endif
    ;Y方向中心点算出
    N230 #1022=[[#1012 + #5062] / 2.0] (find very good Y-value of hole center) 
    ;Y方向直径算出
    N240 #1014=[#1012 - #5062 + [2 * #1004]] (find hole diameter in Y-direction) 
    ;中心点算出値へ位置決め
    #1098 = 11
    N250 G0 X#1021 Y#1022 (back to center of hole)  
    ;+X方向アプローチ（中心補正後）
    #1098 = 12
    G38.2 F[#15] X[#1021 + #1006]
    ;+X方向測定（中心補正後）
    if[#5067 == 0]
        #1098 = 13
        N260 G38.2 F[#1] X[#1021 + #1005] (probe +X side of hole)  
        N270 #1031=#5061 (save results)  
    endif
    ;中心位置へ戻る
    N280 G0 X#1021 Y#1022 (back to center of hole)  
    ;-X方向アプローチ（中心補正後）
    #1098 = 14
    G38.2 F[#15] X[#1021 - #1006]
    ;-X方向測定（中心補正後）
    if[#5067 == 0]
        #1098 = 15
        N290 G38.2 F[#1] X[#1021 - #1005] (probe -X side of hole)
        N291 #1038=#5061 (save results) 
    endif
    ;X方向中心点算出
    N300 #1041=[[#1031 + #5061] / 2.0] (find very good X-value of hole center)  
    ;X方向直径算出
    N310 #1024=[#1031 - #5061 + [2 * #1004]] (find hole diameter in X-direction) 
    ;X/Y直径平均値算出
    N320 #1034=[[#1014 + #1024] / 2.0] (find average hole diameter)  
    ;X/Y直径差分算出
    N330 #1035=[#1024 - #1014] (find difference in hole diameters) 
    ;X方向直径　キャリブレーション結果反映
    N340 #1050 = [#1024 + [#1150 * 2.0]]
    ;Y方向直径　キャリブレーション結果反映
    N341 #1051 = [#1014 + [#1151 * 2.0]]
    ;X/Y直径平均値　キャリブレーション結果反映
    N342 #1052 = [[#1050 + #1051] / 2.0]
    ;X/Y直径差分　キャリブレーション結果反映
    N343 #1053 = [#1050 - #1051]
    ;X方向直径　仕様差
    N350 #1060 = [#1050 - #8]
    ;Y方向直径　仕様差
    N351 #1061 = [#1051 - #8]
    ;X/Y直径平均値　仕様差
    N352 #1062 = [#1052 - #8]
    ;===== 測定ロジック終了 =======
endif

;退避処理
#1098 = 16
N340 G0 X#1021 Y#1022 (back to center of hole)  
N341 G0 Z50.0
N342 G0 X0.0 Y50.0
N349 #1099 = 1
N350 M2 (that's all, folks) 