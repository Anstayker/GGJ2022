using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

    public Pickable[] inventoryItems;
    public int[] inventoryItemQuantity;

    [SerializeField] private GameObject inventoryPanel;
    
    private bool _isInventoryOpen = false;
    private Animator _inventoryUiAnimator;
    private static readonly int IsInventoryOpen = Animator.StringToHash("isInventoryOpen");

    private void Start() {
        _inventoryUiAnimator = inventoryPanel.GetComponent<Animator>();
    }

    public void UseInventory() {
        if (!_isInventoryOpen) {
            _isInventoryOpen = true;
        } else {
            _isInventoryOpen = false;
        }
        _inventoryUiAnimator.SetBool(IsInventoryOpen, _isInventoryOpen);
        
    }

    private void OpenInventory() {
        
    }

    private void CloseInventory() {
        Debug.Log("Close inventory");
    }

    public bool IsInventoryFull() {
        for (int i = 0; i < inventoryItems.Length; i++) {
            if (!inventoryItems[i]) {
                return false;
            }
        }
        return true;
    }

    public void PickupItem(Pickable newItem) {
        
        int emptyIndex = -1;
        int currentIndex = 0;
        bool isItemAdded = false;
        
        //Find if the item exist already
        for (int i = 0; i < inventoryItems.Length; i++) {
            if (newItem.Equals(inventoryItems[i])) {
                inventoryItemQuantity[i]++;
                isItemAdded = true;
                break;
            }
        }

        if (!isItemAdded) {
            //Find empty Slot
            while (emptyIndex == -1) {
                if (!inventoryItems[currentIndex]) {
                    emptyIndex = currentIndex;
                } else {
                    currentIndex++;
                }
            }
        
            //Add the new item
            inventoryItems[emptyIndex] = newItem;
            inventoryItemQuantity[emptyIndex]++;   
        }

    }

}
