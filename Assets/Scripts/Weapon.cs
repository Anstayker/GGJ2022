using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public SpriteRenderer colorSprite;
    public SpriteRenderer monoSprite;

    public Animator ColorSpriteAnimator { get; private set; }
    public Animator MonoSpriteAnimator { get; private set; }

    private void Awake() {
        ColorSpriteAnimator = colorSprite.GetComponent<Animator>();
        MonoSpriteAnimator = monoSprite.GetComponent<Animator>();
    }
    
}
