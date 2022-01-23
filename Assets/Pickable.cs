using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour {

    [SerializeField] private Pickable pickablePrefab;

    [SerializeField] private float pickupVelocity = 1.0f;
    
    private CircleCollider2D _collider2D;
    
    private Transform _playerPosition;
    private PlayerInventory _playerInventory;
    private bool _isPickingUp = false;
    
    private void Start() {
        _collider2D = gameObject.AddComponent(typeof(CircleCollider2D)) as CircleCollider2D;
        _collider2D.isTrigger = true;
        _collider2D.radius = 20.0f;
    }

    private void Update() {
        if (_isPickingUp) {
            transform.position = Vector2.MoveTowards(gameObject.transform.position, 
                _playerPosition.position, 
                pickupVelocity * Time.deltaTime);
            if (Mathf.Approximately(transform.position.magnitude, _playerPosition.transform.position.magnitude)) {
                PickUp(_playerInventory);
                _isPickingUp = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<PlayerInventory>()) {
            _playerInventory = other.GetComponent<PlayerInventory>();
            _isPickingUp = true;
            _playerPosition = other.transform;
            _collider2D.radius = 35.0f;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.GetComponent<PlayerInventory>()) {
            _isPickingUp = false;
            _collider2D.radius = 20.0f;
        }
    }

    private void PickUp(PlayerInventory player) {
        //Esto deberia destruir el item y añadir al inventario
        if (!_playerInventory.IsInventoryFull() && _isPickingUp) {
            _playerInventory.PickupItem(pickablePrefab);
            Destroy(this.gameObject);
        }
    }

    
    
}
