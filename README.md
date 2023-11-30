# VRM-Behavior

## バージョン
unity: 2021.3.6f1  
uniVRM: [v0.115.0](https://github.com/vrm-c/UniVRM/releases/tag/v0.115.0)  

## 使い方
unityでプロジェクトを開いている状態から

### プロジェクトへのVRMモデルの追加   
1. VRM0→Import from VRM 0.xを選択  
![image](https://github.com/suzuki-sagau/vrm-behavior/ScreenShots/import.png)  

2. VRMモデルを選択、開くを選択  
3. 保存先を選択する画面になるので、vrm-behavior/Assets/Modelsを選択する

### 実行
1. Assets/Scenes/のsampleSceneを開く
2. Assets/Models/にある"追加したモデル.prefab"をHierarchyのSampleScene上にドラック&ドロップする  
3. Hierarchyの"Humanoid Behavior"を選択する
4. Inspector上の"Humanoid"と書いてあるところに、2で追加した先のモデルをドラック&ドロップする  
![image](https://github.com/suzuki-sagau/vrm-behavior/ScreenShots/serializedField.png)  
5. 再生ボタンをクリック、または`ctl+p`で実行する  

### csvファイルの変更
vrm-behavior/Assets/Data/config.jsonの"csvPath"を変更することで読み込むcsvファイルを変更できる

