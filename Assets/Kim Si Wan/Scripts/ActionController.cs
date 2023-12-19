using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    private float range;            // Pickup item distance

    private bool pickupActivated = false;  // Can pickup?
    private bool doorOpenActivated = false;  // Can open?
    private bool isOpen = false;

    private RaycastHit hitInfo;     // Pickup item inform

    [SerializeField]
    private LayerMask layerMask;    // Can pickup item Layer

    [SerializeField]
    private Text actionText;        // Action decription text

    [SerializeField]
    private Inventory theInventory;  // Inventory.cs

    void Update()
    {
        CheckItem();
        TryAction();
    }

    private void TryAction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckItem();
            CanPickUp();
            OpenDoor();
        }
    }

    private void CheckItem()
    {
        Debug.DrawRay(transform.position, transform.forward * range, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, range, layerMask))
        {
            if (hitInfo.transform.tag == "Item")
            {
                ItemInfoAppear();
            }
            else if (hitInfo.transform.tag == "door")
            {
                doorOpenActivated = true;
                actionText.gameObject.SetActive(true);
                actionText.text = " ¹® ¿­±â/´Ý±â " + "<color=yellow>" + "(E)" + "</color>";
            }
        }
        else
            ItemInfoDisappear();
    }

    private void ItemInfoAppear()
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hitInfo.transform.GetComponent<Item>().itemMaker.itemName + " È¹µæ " + "<color=yellow>" + "(E)" + "</color>";
    }

    private void ItemInfoDisappear()
    {
        pickupActivated = false;
        doorOpenActivated = false;
        actionText.gameObject.SetActive(false);
    }

    private void CanPickUp()
    {
        if (pickupActivated)
        {
            if (hitInfo.transform != null)
            {
                Debug.Log(hitInfo.transform.GetComponent<Item>().itemMaker.itemName + " È¹µæ Çß½À´Ï´Ù.");  // Add inventory
                theInventory.AcquireItem(hitInfo.transform.GetComponent<Item>().itemMaker);
                Destroy(hitInfo.transform.gameObject);
                ItemInfoDisappear();
            }
        }
    }
    private void OpenDoor(){
        if (doorOpenActivated) {
            if (hitInfo.transform != null) {
                if (!isOpen){
                    hitInfo.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    isOpen = true;
                }
                else{
                    hitInfo.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    isOpen = false;
                }
            }
        }
    }
}