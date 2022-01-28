using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseHand : MonoBehaviour {

    [SerializeField] private Pickable currentItem;
    
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

    public void EquipItemInHand(Pickable newItem) {
        if (currentItem != null) {
            Destroy(currentItem.gameObject);
        }
        currentItem = Instantiate(newItem, _playerSprite.transform);
        currentItem.GetComponent<Pickable>().enabled = false;
        //Destroy(currentItem.GetComponent<Pickable>());
        _isNewItem = true;
    }

    public void ProcessUseHand(bool isUsingItem) {
        if (_isNewItem) {
            Weapon weapon = currentItem.GetComponent<Weapon>();
            _weaponAnimatorColor = weapon.ColorSpriteAnimator;
            _weaponAnimatorMono = weapon.MonoSpriteAnimator;
            _isNewItem = false;
        }
        
        _playerAnimatorColor.SetBool(UseHand, isUsingItem);
        
        if (currentItem) {
            _weaponAnimatorColor.SetBool(IsActive, isUsingItem);
        }
        
    }
}
