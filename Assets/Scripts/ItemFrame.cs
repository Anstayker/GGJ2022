using System;
using System.Collections;
using System.Collections.Generic;
using Pickables;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemFrame : MonoBehaviour {

    [SerializeField] private Image selectFrame;
    [SerializeField] private Image itemSprite;
    public TextMeshProUGUI itemQuantity;
    
    [HideInInspector] public PickableItem pickableItem;

    private InventoryGrid _inventoryGrid;
    
    private void Start() {
        _inventoryGrid = FindObjectOfType<InventoryGrid>();
        UpdateItemFrame();
    }

    public void SelectFrame() {
        _inventoryGrid.SelectNewItem(this);
    }

    public void HandleSelectFrame(bool isSelected) {
        selectFrame.enabled = isSelected;
    }

    public void UpdateItemFrame() {
        if (pickableItem == null) {
            itemSprite.enabled = false;
            itemQuantity.text = "";
        } else {
            itemSprite.sprite = pickableItem.inventorySprite;
            itemSprite.transform.rotation = Quaternion.Euler(0,0, pickableItem.spriteRotation);
            itemSprite.enabled = true;
        }
    }

}
