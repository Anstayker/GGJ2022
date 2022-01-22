using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {

    public Vector2 InputMovement { get; private set; }

    private Vector2 _rawInputMovement;
    private bool _rawUseHand;
    
    public void OnMovement(InputAction.CallbackContext value) {
        _rawInputMovement = value.ReadValue<Vector2>();
        InputMovement = new Vector2(_rawInputMovement.x, _rawInputMovement.y);
    }

    public void OnUseHand(InputAction.CallbackContext value) {
        _rawUseHand = value.ReadValueAsButton();
        GetComponent<PlayerUseHand>().ProcessUseHand(_rawUseHand);
    }
}
