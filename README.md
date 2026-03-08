# Gaze based Bare Hand Controller
Gaze Based Bare-Hand Controller for Better Depth Recognition in 3D Environment

## 🌏 Multi-language Guide

<details>
  <summary>🇰🇷 한국어 (Korean)</summary>
  <br>
  
  ### ✳ Title
  3차원 환경에서 개선된 오브젝트 선택을 위한 시선 기반 맨손 컨트롤러

  ### ✳ Introduction
  
  3차원 환경에서의 오브젝트 선택 방법은, 크게 깊이(depth) 기반 방법과 격자(grid) 기반 방법으로 나뉜다. 깊이 기반 방법은 사용자의 깊이 인지(depth recognition)에 따라 조작성이 갈리는 반면, 격자 기반 방법은 오브젝트를 인위적으로 정렬해 선택 절차를 추가할 필요가 있다.

  이 프로젝트는 깊이 기반 방법을 사용하되, 시선을 활용해 깊이 인지를 보완하여 맨손으로 직관적인 조작이 가능한 시스템을 제안한다.
  
  ### ✳ Features
  * 시선을 기반으로 3차원 커서에서 범위 이동
  * 중지~소지로 깊이 조절, 핀치(Pinch) 동작으로 선택 확정
  * (MediaPipe기준) 0번 랜드마크의 상대 이동으로 위치 조작
  * 커서가 닿으면 초록색, 확정 동작을 취하면 파란색으로 머터리얼 변화
  * UDPsend.py를 별도로 실행한 후, Unity 프로젝트를 실행

![Image](https://github.com/user-attachments/assets/e81aded0-f8e7-42fb-ab42-27753ae80163)

  ### ✳ 설계 과정
  사용자가 커서를 직관적으로 조작할 수 있도록, 이동 방향이나 접촉 판정 등 다양한 요소에서 좌표계의 특성을 고려해 조정했다.
  
  > 예시) 일반적인 3차원 좌표계 특성상 오브젝트가 카메라에 가까울수록 깊이 축이 비스듬해지는 문제가 있다.
  
  > ➡ 하지만 사용자가 바라보는 것은 현실 세계의 평면 모니터이므로
  
  > ➡ 모니터의 중심과 가장자리의 깊이 차이를 거의 느끼지 못한다.
  
  > ➡ 즉, 가장자리에 있는 오브젝트의 조작이 어렵다고 느끼게 된다.

  > 🚩 카메라의 위치와 커서의 현재 위치로 벡터를 생성하고, 커서의 이동 방향을 보완한다.
  
  > ➡ 대상의 위치에 무관하게 같은 조작으로 깊이 이동이 가능하다.
</details>



<details>
  <summary>🇯🇵 日本語 (Japanese)</summary>
  <br>
  
  ### ✳ Title
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
</details>

### ✳ Environment
* Unity 2021.3.7f1
* Tobii Eye Tracker 5
* Web camera
* Google MediaPipe

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

