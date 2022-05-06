;位置決め
G0 X16.0 Y16.0 Z125.0

;撮影待機
#1009 = 1.0
msg "executing camera"
while [#1009 > 0.0]
    G4 P1
endwhile
msg "finished camera"

;ワーク原点へ移動
G0 X0.0 Y0.0 Z125.0

M2