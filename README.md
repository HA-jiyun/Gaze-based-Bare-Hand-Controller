# Gaze based Bare Hand Controller
Gaze Based Bare-Hand Controller for Better Depth Recognition in 3D Environment

3D環境における深度認識を向上させる視線ベースの素手コントローラ

### ✳ Introduction

3次元環境におけるオブジェクトの選択方法は、大きく「深度ベース」と「グリッドベース」の2種類に分類されます。深度ベースの方法は、深度認識の不足により操作性が低下する一方で、グリッドベースの方法は、オブジェクトを人為的に整列し、選択手続きを追加する必要があるという課題があります。

本プロジェクトでは、深度ベースの方法を採用し、視線を活用することで深度認識の不足を補い、素手で直感的に操作できるシステムを提案しています。

### ✳ Environment
* Unity 2021.3.7f1
* Tobii Eye Tracker 5
* Web camera
* Google MediaPipe

### ✳ Features
* 視線を基に3次元カーソルの移動範囲を限定
* 中指~小指で深さ調節、ピンチ動作で選択確定
* (MediaPipe基準)0番ランドマークの相対移動で位置操作
* カーソルが触れると緑色、ピンチ動作をすると青色でマテリアル変化
* UDPsend.py を別に実行した後、Unityプロジェクトを実行してください。

![Image](https://github.com/user-attachments/assets/e81aded0-f8e7-42fb-ab42-27753ae80163)

### ✳ こだわり
ユーザーがカーソルを直感的に操作できるよう、移動方向や接触判定など、さまざまな要素において座標系の特性を工夫して調整しました。

---

> 例) 対象がモニターの端に近づくほど、奥行きの操作軌道が斜めになる

> ➡ しかし、ユーザーが見ているのは現実世界のモニター

> ➡ 中心と端の奥行きの差をほとんど感じられない

> ➡ 操作が難しいと感じる

> 🚩 カメラの位置とカーソルの現在位置からベクトルを生成し、カーソルの移動方向を補正

> ➡ 対象の位置に関係なく、同じ操作で深さ移動


### ✳ In Progress

⚠ 現在、範囲基盤の深度移動を実装済みですが、さまざまな3次元環境に適用可能な移動方式の改良を研究しています。

### ✳ Sample Scene

![Image](https://github.com/user-attachments/assets/a34fef4a-0b21-45bb-935d-35581db12d4c)

![Image](https://github.com/user-attachments/assets/36aac3a4-63e6-49d1-9a68-2909c316f620)

### ✳ References
CVZone 3D Hand Tracking
https://www.computervision.zone/courses/3d-hand-tracking/

Flappy Bird
https://github.com/limgm/flappy-mediapipe

Poisson Disk Sampling for 3D
https://gist.github.com/hiroakioishi/382a6ecbf741c5e0d463

1 Euro Filter
https://gery.casiez.net/1euro/

