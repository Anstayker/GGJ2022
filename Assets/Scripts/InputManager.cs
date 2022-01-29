using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {

    public Vector2 InputMovement { get; private set; }
    public bool isGamePaused = false;
    
    private Vector2 _rawInputMovement;
    private bool _rawUseHand;
    private PlayerUseHand _playerUseHand;

    private void Awake() {
        _playerUseHand = GetComponent<PlayerUseHand>();
    }

    public void OnMovement(InputAction.CallbackContext value) {
        if (!isGamePaused) {
            _rawInputMovement = value.ReadValue<Vector2>();
            InputMovement = new Vector2(_rawInputMovement.x, _rawInputMovement.y);   
        } else {
          InputMovement = Vector2.zero;  
        }
    }

    public void OnUseHand(InputAction.CallbackContext value) {
        if (!isGamePaused) {
            _rawUseHand = value.ReadValueAsButton();
            _playerUseHand.ProcessUseHand(_rawUseHand);   
        } else {
            _playerUseHand.ProcessUseHand(false);
        }
    }

    public void OnOpenInventory(InputAction.CallbackContext value) {
        if (value.performed) {
            GetComponent<PlayerInventory>().UseInventory();
        }
    }
}
