using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class ItemMaker : ScriptableObject
{
    public enum ItemType  // Item Type
    { 
        Equipment,
        Used,
        ETC,
    }

    public string itemName;
    public ItemType itemType;
    public Sprite itemImage;
    public GameObject itemPrefab;
    public bool usePermit = false;
    public string itemDescription;
}