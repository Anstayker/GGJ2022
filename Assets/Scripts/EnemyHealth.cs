using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    
    public int health = 5;
    //private int _maxHealth = 10;

    private float _trembleIntensity = 1.0f;
    
    public void ReduceHealth(int damageTaken) {
        health -= damageTaken;
        StartCoroutine(Tremble());
        if (health == 0) {
            Destroy(this.gameObject);
        }
    }
    
    IEnumerator Tremble() {
        for ( int i = 0; i < 10; i++) {
            gameObject.transform.localPosition += new Vector3(_trembleIntensity, 0, 0);
            yield return new WaitForSeconds(0.01f);
            gameObject.transform.localPosition -= new Vector3(_trembleIntensity, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }

}
