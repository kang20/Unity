using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool invectoryActivated = false;  // inventory active? -> true(camera don't move)

    [SerializeField]
    private GameObject go_InventoryBase; // Inventory_Base image
    [SerializeField]
    private GameObject go_SlotsParent;  // Grid Setting

    private Slot[] slots;  // Slot array

    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();
    }

    void Update()
    {
        TryOpenInventory();
    }

    private void TryOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            invectoryActivated = !invectoryActivated;

            if (invectoryActivated)
                OpenInventory();
            else
                CloseInventory();

        }
    }

    private void OpenInventory()
    {
        go_InventoryBase.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void CloseInventory()
    {
        go_InventoryBase.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void AcquireItem(ItemMaker _itemMaker, int _count = 1)
    {
        if (ItemMaker.ItemType.Equipment != _itemMaker.itemType)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].itemMaker != null)
                {
                    if (slots[i].itemMaker.itemName == _itemMaker.itemName)
                    {
                        slots[i].SetSlotCount(_count);
                        return;
                    }
                }
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].itemMaker == null)
            {
                slots[i].AddItem(_itemMaker, _count);
                return;
            }
        }
    }
}