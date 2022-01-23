using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponCollision : MonoBehaviour {

    private CapsuleCollider2D _collider;

    private void Start() {
        _collider = GetComponent<CapsuleCollider2D>();
    }

    public void TurnOnCollider() {
        _collider.enabled = true;
    }

    public void TurnOffCollider() {
        _collider.enabled = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<EnemyHealth>()) {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            enemyHealth.ReduceHealth(1);
        }
    }
}
