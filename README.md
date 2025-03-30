# Gaze based Bare Hand Controller
Gaze Based Bare-Hand Controller for Better Depth Recognition in 3D Environment

3D環境における深度認識を向上させる視線ベースの素手コントローラ

### ✳ Introduction

3次元環境におけるオブジェクトの選択方法は、大きく「グリッドベース」と「メニューベース」の2種類に分類されます。グリッドベースの方法は、深度認識の不足により操作性が低下する一方で、メニューベースの方法は、オブジェクトを人為的に整列し、選択手続きを追加する必要があるという課題があります。

本プロジェクトでは、グリッドベースの方法を採用し、視線を活用することで深度認識の不足を補い、素手で直感的に操作できるシステムを提案しています。

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
* ⚠ 深さ移動範囲を調整中

![Image](https://github.com/user-attachments/assets/e81aded0-f8e7-42fb-ab42-27753ae80163)

### ✳ こだわり
Unity上のワールド座標とスクリーン座標の違いを理解し、3次元カーソルが「見えるままに」動くようにしました。特に、ユーザーが動いた3次元カーソルがオブジェクトに触れたと見られると、接触したと認識されるよう、判定処理を工夫しました。

⚠ 現在、範囲基盤の深度移動を実装済みですが、さまざまな3次元環境に適用可能な移動方式の改良を研究しています。

### ✳ Sample Scene

![Image](https://github.com/user-attachments/assets/3a96bd56-f489-4a31-92b9-50b8d13f7fd6)

### ✳ References
CVZone 3D Hand Tracking
https://www.computervision.zone/courses/3d-hand-tracking/

Flappy Bird
https://github.com/limgm/flappy-mediapipe

Poisson Disk Sampling for 3D
https://gist.github.com/hiroakioishi/382a6ecbf741c5e0d463

1 Euro Filter
https://gery.casiez.net/1euro/

