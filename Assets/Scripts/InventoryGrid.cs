using System;
using System.Collections;
using System.Collections.Generic;
using Pickables;
using TMPro;
using UnityEngine;

public class InventoryGrid : MonoBehaviour {

    public ItemFrame _itemSelected;
    private PlayerInventory _playerInventory;
    private ItemFrame[] _itemFrames;
    private Pickable[] _inventoryItems;
    private int[] _inventoryQuantity;

    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;
    
    private void Start() {
        _playerInventory = FindObjectOfType<PlayerInventory>();
        _inventoryItems = _playerInventory.inventoryItems;
        _inventoryQuantity = _playerInventory.inventoryItemQuantity;
        _itemFrames = transform.GetComponentsInChildren<ItemFrame>();
        itemName.text = "";
        itemDescription.text = "";
    }

    public void SelectNewItem(ItemFrame newSelection) {
        if (_itemSelected) {
            _itemSelected.HandleSelectFrame(false);
            itemName.text = "";
            itemDescription.text = "";
        }
        _itemSelected = newSelection;
        _itemSelected.HandleSelectFrame(true);
        if (_itemSelected.pickableItem) {
            PickableItem itemInfo = _itemSelected.pickableItem;
            itemName.text = itemInfo.itemName;
            itemDescription.text = itemInfo.itemDescription;
        }
    }

    public void UpdateInventory() {
        _inventoryItems = _playerInventory.inventoryItems;
        for (int i = 0; i < 1; i++) {
            if (_inventoryItems[i]) {
                _itemFrames[i].pickableItem = _inventoryItems[i].pickableInfo;
                _itemFrames[i].itemQuantity.text = _inventoryQuantity[i].ToString();
            }
            _itemFrames[i].UpdateItemFrame();
        }
    }

}
