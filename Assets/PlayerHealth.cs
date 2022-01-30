using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth = 6;
    private int _currentHealth;
    public float inmunityTime = 0.5f;
    
    private bool _canTakeDamage = true;
    [SerializeField] private LifeSystem lifeSystem;
    
    private void Awake() {
        _currentHealth = maxHealth;
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (other.transform.CompareTag("Enemy") && _canTakeDamage) {
            TakeDamage();
        }
    }

    public void TakeDamage() {
        _canTakeDamage = false;
        StartCoroutine(InmunityFrame());
        _currentHealth--;
        lifeSystem.UpdateHearths(_currentHealth);
    }

    IEnumerator InmunityFrame() {
        yield return new WaitForSeconds(inmunityTime);
        _canTakeDamage = true;
    }
}
