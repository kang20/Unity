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
        CameraMovement cmm = Camera.main.GetComponent<CameraMovement>();
        cmm.isESC = true;
        cmm.CameraArm.transform.parent.GetComponent<PlayerMovement>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        go_InventoryBase.SetActive(true);
    }

    private void CloseInventory()
    {
        CameraMovement cmm = Camera.main.GetComponent<CameraMovement>();
        cmm.isESC = false;
        cmm.CameraArm.transform.parent.GetComponent<PlayerMovement>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        go_InventoryBase.SetActive(false);
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