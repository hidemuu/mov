window.initializeBabylon = () => {
    // キャンバス要素を取得
    const canvas = document.getElementById("renderCanvas");
    
    // Babylon.jsエンジンを作成
    const engine = new BABYLON.Engine(canvas, true);

    // シーンを作成
    const scene = new BABYLON.Scene(engine);

    // カメラを作成
    const camera = new BABYLON.ArcRotateCamera("camera", Math.PI / 2, Math.PI / 2.5, 10, BABYLON.Vector3.Zero(), scene);
    camera.attachControl(canvas, true);

    // ライトを追加
    const light = new BABYLON.HemisphericLight("light", new BABYLON.Vector3(1, 1, 0), scene);

    // サンプルオブジェクト（球体）を追加
    const sphere = BABYLON.MeshBuilder.CreateSphere("sphere", { diameter: 2 }, scene);
    // const box = BABYLON.MeshBuilder.CreateBox("box", { size: 2 }, scene);

    // 背景色を変更
    scene.clearColor = new BABYLON.Color4(0.2, 0.4, 0.6, 1.0);

    // レンダリングループを開始
    engine.runRenderLoop(() => {
        scene.render();
    });

    // ウィンドウサイズ変更時にリサイズ
    window.addEventListener("resize", () => {
        engine.resize();
    });
};