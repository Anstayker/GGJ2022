using System;
using System.Collections;
using System.Collections.Generic;
using Pickables;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGrid : MonoBehaviour {

    private ItemFrame _itemSelected;
    private PlayerInventory _playerInventory;
    private ItemFrame[] _itemFrames;
    private Pickable[] _inventoryItems;
    private int[] _inventoryQuantity;
    private PlayerUseHand _playerUseHand;

    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private InventoryUseButton useButton;

    [Header("Equipment Frames")]
    [SerializeField] private ItemFrame handFrame;
    [SerializeField] private ItemFrame headFrame;
    [SerializeField] private ItemFrame bodyFrame;
    [SerializeField] private ItemFrame handsFrame;
    [SerializeField] private ItemFrame shoesFrame;

    private ItemFrame handFrameInventory;
    private ItemFrame headFrameInventory;
    private ItemFrame bodyFrameInventory;
    private ItemFrame handsFrameInventory;
    private ItemFrame shoesFrameInventory;
    
    private void Start() {
        _playerInventory = FindObjectOfType<PlayerInventory>();
        _inventoryItems = _playerInventory.inventoryItems;
        _inventoryQuantity = _playerInventory.inventoryItemQuantity;
        _itemFrames = transform.GetComponentsInChildren<ItemFrame>();
        itemName.text = "";
        itemDescription.text = "";
        _playerUseHand = FindObjectOfType<PlayerUseHand>();
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
            if (itemInfo.itemType != ItemType.Material && itemInfo.itemType != ItemType.Consumable) {
                useButton.buttonText.text = "Equip";
            } else {
                useButton.buttonText.text = "Use";
            }
        }
    }

    public void UpdateInventory() {
        _inventoryItems = _playerInventory.inventoryItems;
        for (int i = 0; i < _inventoryItems.Length; i++) {
            if (_inventoryItems[i]) {
                _itemFrames[i].pickableItem = _inventoryItems[i].pickableInfo;
                _itemFrames[i].itemQuantity.text = _inventoryQuantity[i].ToString();
            }
            _itemFrames[i].UpdateItemFrame();
        }
    }

    public void EquipItem() {
        //TODO para hacerlo por tipo de item
        if (_itemSelected.pickableItem) {
            ItemType itemType = _itemSelected.pickableItem.itemType;
            switch (itemType) {
                case ItemType.HandUse:
                    if (_itemSelected.pickableItem) {
                        _playerUseHand.EquipItemInHand(_itemSelected.pickableItem.itemPrefab);
                    }
                    if (handFrameInventory) {
                        handFrameInventory.EquipItemFrame(false);
                    }
                    handFrameInventory = _itemSelected;
                    _itemSelected.EquipItemFrame(true);
                    handFrame.pickableItem = _itemSelected.pickableItem;
                    handFrame.UpdateItemFrame();
                    break;
                case ItemType.Head:
                    break;
                case ItemType.Body:
                    break;
                case ItemType.Hands:
                    break;
                case ItemType.Shoes:
                    break;
                case ItemType.Consumable:
                    //TODO Activar efecto de item:
                    break;
            }       
        }
    }

}
