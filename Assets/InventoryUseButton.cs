using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUseButton : MonoBehaviour {

    public TextMeshProUGUI buttonText;
    private InventoryGrid _inventoryGrid;
    
    private void Start() {
        _inventoryGrid = FindObjectOfType<InventoryGrid>();
    }

    public void OnClick() {
        _inventoryGrid.EquipItem();
    }
}
