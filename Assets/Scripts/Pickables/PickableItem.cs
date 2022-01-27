using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pickables {
    [CreateAssetMenu(fileName = "New Item", menuName = "Item")]
    public class PickableItem : ScriptableObject {
    
        public Pickable itemPrefab;
        public Sprite inventorySprite;
        public float spriteRotation;

        public String itemName;
        [TextArea]
        public String itemDescription;

    }
}
