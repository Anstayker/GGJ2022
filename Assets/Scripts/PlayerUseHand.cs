using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseHand : MonoBehaviour {

    [SerializeField] private Weapon currentItem;
    
    private static readonly int UseHand = Animator.StringToHash("useHand");
    private static readonly int IsActive = Animator.StringToHash("isActive");
    
    private SpriteController _playerSprite;
    private Animator _playerAnimatorColor;
    private Animator _playerAnimatorMono;
    private Animator _weaponAnimatorColor;
    private Animator _weaponAnimatorMono;
    private bool _isNewItem = false;
    
    private void Start() {
        _playerSprite = GetComponentInChildren<SpriteController>();
        _playerAnimatorColor = _playerSprite.colorSprite.GetComponent<Animator>();
        _playerAnimatorMono = _playerSprite.monoSprite.GetComponent<Animator>();
        
        //TODO Esto se deberia hacer al equipar en el inventario
        if (currentItem) {
            currentItem = Instantiate(currentItem, _playerSprite.transform);
            Destroy(currentItem.GetComponent<Pickable>());
            _isNewItem = true;
        }

    }

    public void ProcessUseHand(bool isUsingItem) {
        if (_isNewItem) {
            _weaponAnimatorColor = currentItem.ColorSpriteAnimator;
            _weaponAnimatorMono = currentItem.MonoSpriteAnimator;
            _isNewItem = false;
        }
        
        _playerAnimatorColor.SetBool(UseHand, isUsingItem);
        
        if (currentItem) {
            _weaponAnimatorColor.SetBool(IsActive, isUsingItem);
        }
        
    }
}
