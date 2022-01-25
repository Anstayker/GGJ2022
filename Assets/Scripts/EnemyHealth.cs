using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyHealth : MonoBehaviour {
    
    public int health = 5;
    //private int _maxHealth = 10;

    [SerializeField] private GameObject[] possibleDeadDrops;
    [SerializeField] private float[] deadDropPercentage;
    [SerializeField] private GameObject[] possibleHitDrops;
    [SerializeField] private float[] hitDropPercentage;
    [SerializeField] private bool canDropOnHit = false;
    
    private float _trembleIntensity = 1.0f;
    private LevelColorChange _level;
    private SpriteController _spriteController;

    private void Start() {
        _level = FindObjectOfType<LevelColorChange>();
        _spriteController = transform.Find("Sprites").GetComponent<SpriteController>();
    }

    public void ReduceHealth(int damageTaken) {
        health -= damageTaken;
        TakeDamage();
        if (health == 0) {
            KillEnemy();
        }
    }

    private void TakeDamage() {
        StartCoroutine(Tremble());
        if (canDropOnHit) {
            RandomDropGenerator(possibleHitDrops, hitDropPercentage);   
        }
    }

    private void KillEnemy() {
        RandomDropGenerator(possibleDeadDrops, deadDropPercentage);
        _level.levelObjects.Remove(_spriteController);
        Destroy(this.gameObject);
    }

    private void RandomDropGenerator(GameObject[] itemPool, float[] percentageList) {
        for (int i = 0; i < percentageList.Length; i++) {
            float randomNumber = Random.Range(0.0f, 100.0f);
            if (randomNumber <= percentageList[i]) {
                GenerateItem(itemPool, i);
            }            
        }
    }

    private void GenerateItem(GameObject[] itemPool, int itemIndex) {
        Vector3 itemSpawnPoint = RandomCircle(transform.position, 10.0f);
        GameObject newItem = Instantiate(itemPool[itemIndex], itemSpawnPoint, Quaternion.identity);
        newItem.transform.parent = _level.transform;
        SpriteController newItemSprite = newItem.transform.Find("Sprites").GetComponent<SpriteController>();
        if (!_level.isColor) {
            _spriteController.colorSprite.enabled = false;
            _spriteController.monoSprite.enabled = true;
        }
        _level.levelObjects.Add(newItemSprite);
    }

    IEnumerator Tremble() {
        for ( int i = 0; i < 10; i++) {
            gameObject.transform.localPosition += new Vector3(_trembleIntensity, 0, 0);
            yield return new WaitForSeconds(0.01f);
            gameObject.transform.localPosition -= new Vector3(_trembleIntensity, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }

    Vector3 RandomCircle ( Vector3 center ,   float radius  ){
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
    
}
