using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelColorChange : MonoBehaviour {
    
    private Camera _mainCamera;
    private Color _mainCameraDefaultColor;
    private List<SpriteController> _levelObjects = new List<SpriteController>();

    private void Awake() {
        SpriteController[] allchildren = this.transform.GetComponentsInChildren<SpriteController>(true);
        for (int i = 0; i < allchildren.Length; i++) {
            _levelObjects.Add(allchildren[i]);
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
                foreach (SpriteController spriteController in _levelObjects) {
                    spriteController.colorSprite.enabled = true;
                    spriteController.monoSprite.enabled = false;
                }
                break;
            
            // Monochromatic World
            case 1:
                _mainCamera.backgroundColor = Color.black;
                foreach (SpriteController spriteController in _levelObjects) {
                    spriteController.colorSprite.enabled = false;
                    spriteController.monoSprite.enabled = true;
                }
                break;
        }
    }
}
