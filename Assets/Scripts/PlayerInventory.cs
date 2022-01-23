using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

    public Pickable[] inventoryItems;
    public int[] _inventoryItemQuantity;

    /*
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Pickable>()) {
            Pickable pickableItem = other.GetComponent<Pickable>();
            if (!IsInventoryFull()) {
                PickupItem(pickableItem);
            }
        }
    }
    */

    public bool IsInventoryFull() {
        for (int i = 0; i < inventoryItems.Length; i++) {
            if (inventoryItems[i] == null) {
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
                _inventoryItemQuantity[i]++;
                isItemAdded = true;
                break;
            }
        }

        if (!isItemAdded) {
            //Find empty Slot
            while (emptyIndex == -1) {
                if (inventoryItems[currentIndex] == null) {
                    emptyIndex = currentIndex;
                } else {
                    currentIndex++;
                }
            }
        
            //Add the new item
            inventoryItems[emptyIndex] = newItem;
            _inventoryItemQuantity[emptyIndex]++;   
        }

    }

}
