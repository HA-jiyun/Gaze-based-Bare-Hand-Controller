# (開発中) Gaze based Bare Hand Controller
Gaze Based Bare-Hand Controller for Better Depth Recognition in 3D Environment

3차원 환경에서 개선된 깊이 인지를 위한 시선 기반 맨손 컨트롤러


### ✳ Introduction

3次元環境におけるオブジェクトの選択方法は、大きく「グリッドベース」と「メニューベース」の2種類に分類される。

グリッドベースの方法は、奥行き認識の不足により操作性が低下する一方で、メニューベースの方法は、オブジェクトを人為的に整列し、選択手続きを追加する必要があるという課題がある。

本プロジェクトでは、グリッドベースの方法を採用し、視線を活用することで奥行き認識の不足を補い、素手で直感的に操作できるシステムを設計する。

### ✳ Environment
* Unity 2021.3.7f1
* Tobii Eye Tracker 5
* Web camera
* Google MediaPipe

### ✳ Features
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
