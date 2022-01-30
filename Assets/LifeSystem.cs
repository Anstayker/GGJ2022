using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour {

    [SerializeField] private Sprite hearthFull;
    [SerializeField] private Sprite hearthHalf;
    [SerializeField] private Sprite hearthEmpty;

    [SerializeField] private Image[] hearths;

    private void Start() {
        foreach (Image hearth in hearths) {
            hearth.sprite = hearthFull;
        }
    }

    public void UpdateHearths(int currentHp) {
        switch (currentHp) {
            case 0:
                for (int i = 0; i < hearths.Length; i++) {
                    hearths[0].sprite = hearthEmpty;
                    hearths[1].sprite = hearthEmpty;
                    hearths[2].sprite = hearthEmpty;
                }
                break;
            case 1:
                for (int i = 0; i < hearths.Length; i++) {
                    hearths[0].sprite = hearthHalf;
                    hearths[1].sprite = hearthEmpty;
                    hearths[2].sprite = hearthEmpty;
                }
                break;
            case 2:
                for (int i = 0; i < hearths.Length; i++) {
                    hearths[0].sprite = hearthFull;
                    hearths[1].sprite = hearthEmpty;
                    hearths[2].sprite = hearthEmpty;
                }
                break;
            case 3:
                for (int i = 0; i < hearths.Length; i++) {
                    hearths[0].sprite = hearthFull;
                    hearths[1].sprite = hearthHalf;
                    hearths[2].sprite = hearthEmpty;
                }
                break;
            case 4:
                for (int i = 0; i < hearths.Length; i++) {
                    hearths[0].sprite = hearthFull;
                    hearths[1].sprite = hearthFull;
                    hearths[2].sprite = hearthEmpty;
                }
                break;
            case 5:
                for (int i = 0; i < hearths.Length; i++) {
                    hearths[0].sprite = hearthFull;
                    hearths[1].sprite = hearthFull;
                    hearths[2].sprite = hearthHalf;
                }
                break;
            case 6:
                for (int i = 0; i < hearths.Length; i++) {
                    hearths[0].sprite = hearthFull;
                    hearths[1].sprite = hearthFull;
                    hearths[2].sprite = hearthFull;
                }
                break;
        }
    }
}
