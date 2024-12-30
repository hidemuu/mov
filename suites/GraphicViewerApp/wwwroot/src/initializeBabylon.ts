import * as BABYLON from "@babylonjs/core";

declare global {
    interface Window {
        initializeBabylon: () => void;
    }
}

window.initializeBabylon = () => {
    const canvas = document.getElementById("renderCanvas") as HTMLCanvasElement | null;

    if (!canvas) {
        console.error("Canvas element with ID 'renderCanvas' not found.");
        return;
    }

    const engine = new BABYLON.Engine(canvas, true);
    const scene = new BABYLON.Scene(engine);

    const camera = new BABYLON.ArcRotateCamera(
        "camera",
        Math.PI / 2,
        Math.PI / 2.5,
        10,
        BABYLON.Vector3.Zero(),
        scene
    );
    camera.attachControl(canvas, true);

    const light = new BABYLON.HemisphericLight(
        "light",
        new BABYLON.Vector3(1, 1, 0),
        scene
    );

    const sphere = BABYLON.MeshBuilder.CreateSphere(
        "sphere",
        { diameter: 2 },
        scene
    );

    scene.clearColor = new BABYLON.Color4(0.2, 0.4, 0.6, 1.0);

    engine.runRenderLoop(() => {
        scene.render();
    });

    window.addEventListener("resize", () => {
        engine.resize();
    });
};
