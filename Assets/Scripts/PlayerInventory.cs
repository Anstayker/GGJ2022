using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

    public Pickable[] inventoryItems;
    public int[] inventoryItemQuantity;

    [SerializeField] private GameObject inventoryPanel;
    
    [HideInInspector] public bool isInventoryOpen = false;
    private Animator _inventoryUiAnimator;
    private InventoryGrid _inventoryGrid;
    private static readonly int IsInventoryOpen = Animator.StringToHash("isInventoryOpen");

    private void Start() {
        _inventoryGrid = FindObjectOfType<InventoryGrid>();
        _inventoryUiAnimator = inventoryPanel.GetComponent<Animator>();
    }

    public void UseInventory() {
        RefreshInventory();
        _inventoryGrid.UpdateInventory();
        if (!isInventoryOpen) {
            isInventoryOpen = true;
        } else {
            isInventoryOpen = false;
        }
        _inventoryUiAnimator.SetBool(IsInventoryOpen, isInventoryOpen);
        
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

    public void RefreshInventory() {
        for (int i = 0; i < inventoryItemQuantity.Length; i++) {
            if (inventoryItemQuantity[i] == 0) {
                inventoryItems[i] = null;
            }
        }
    }

}
