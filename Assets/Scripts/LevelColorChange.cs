using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelColorChange : MonoBehaviour {
    
    private Camera _mainCamera;
    private Color _mainCameraDefaultColor;
    
    public List<SpriteController> levelObjects = new List<SpriteController>();
    public bool isColor = true;
    
    private void Awake() {
        SpriteController[] allChildren = this.transform.GetComponentsInChildren<SpriteController>(true);
        for (int i = 0; i < allChildren.Length; i++) {
            levelObjects.Add(allChildren[i]);
        }
    }

    private void Start() {
        _mainCamera = FindObjectOfType<Camera>();
        _mainCameraDefaultColor = _mainCamera.backgroundColor;
    }

    public void ChangeColor(int colorOption) {
        switch (colorOption) {
            // Color world
            case 0:
                _mainCamera.backgroundColor = _mainCameraDefaultColor;
                foreach (SpriteController spriteController in levelObjects) {
                    spriteController.colorSprite.enabled = true;
                    spriteController.monoSprite.enabled = false;
                    isColor = true;
                }
                break;
            
            // Monochromatic World
            case 1:
                _mainCamera.backgroundColor = Color.black;
                foreach (SpriteController spriteController in levelObjects) {
                    spriteController.colorSprite.enabled = false;
                    spriteController.monoSprite.enabled = true;
                    isColor = false;
                }
                break;
        }
    }
}
