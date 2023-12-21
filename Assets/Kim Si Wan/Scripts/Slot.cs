using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public ItemMaker itemMaker;         // Item inform object
    public int itemCount;               // Pickup item count
    public Image itemImage;             // Item image

    [SerializeField]
    private Text text_Count;            // Slot item count text
    [SerializeField]
    private GameObject go_CountImage;   // CountImage
    [SerializeField]
    private GameObject player;            // player

    [SerializeField]
    private GameObject ItemDescription;   // ItemDescription
    [SerializeField]
    private GameObject Panel;             // ItemDescription
    [SerializeField]
    private Text descriptionText;   // ItemDescription

    private bool isEnter = false;
    // Set itemImage's transparency
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    // Add item to inventory
    public void AddItem(ItemMaker _itemmaker, int _count = 1)
    {
        itemMaker = _itemmaker;
        itemCount = _count;
        itemImage.sprite = itemMaker.itemImage;

        if (itemMaker.itemType != ItemMaker.ItemType.Equipment)
        {
            go_CountImage.SetActive(true);
            text_Count.text = itemCount.ToString();
        }
        else
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }

        player.GetComponent<PlayerStatus>().setBelongings(itemMaker);

        SetColor(1);
    }

    // Set slot item count
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        Debug.Log(itemCount);
        if (itemCount <= 0)
            ClearSlot();
    }

    // Delete Slot
    private void ClearSlot()
    {
        player.GetComponent<PlayerStatus>().deleteBelongings(itemMaker);
        itemMaker = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        itemImage.gameObject.SetActive(false);
        go_CountImage.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (itemMaker != null)
        {
            isEnter = true;
            Vector3 descriptionPos = new Vector3(this.transform.position.x + 67, this.transform.position.y - 67, this.transform.position.z);
            ItemDescription.transform.position = descriptionPos;
            if(itemMaker.itemType == ItemMaker.ItemType.Used)
                descriptionText.text = "\n" + itemMaker.itemDescription + "\n\n우클릭 시 사용";
            else if (itemMaker.itemType == ItemMaker.ItemType.ETC)
                descriptionText.text = "\n" + itemMaker.itemDescription + "\n\n특정 물체 클릭 후 사용";
            Panel.SetActive(true);
        }
    }

    // Click slot event
    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (itemMaker.usePermit == false)
                return;

            if (itemMaker != null)
            {
                if (itemMaker.itemType == ItemMaker.ItemType.Used)
                {
                    // 단순 상태효과 상승
                    useTool(itemMaker.itemName);
                    Debug.Log(itemMaker.itemName + " 을 사용했습니다.");
                    SetSlotCount(-1);
                }
            }
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (isEnter == true) {
            isEnter = false;
            Panel.SetActive(false);
        }
    }

    public void useTool(string itemName) {
        PlayerStatus playerStatus = player.GetComponent<PlayerStatus>();

        if (itemName == "Food") 
            playerStatus.usedFood = true;
        else if (itemName == "WaterBottle")
            playerStatus.usedWater = true;
        else if (itemName == "Clothes")
            playerStatus.usedClothes = true;
        else if (itemName == "FirstAid")
            playerStatus.usedFirstAid = true;
        else if (itemName == "Radio")
            playerStatus.usedRadio = true;
        else if (itemName == "Battery")
            playerStatus.usedBattery = true;
        else if (itemName == "Mask")
            playerStatus.usedMask = true;
        else if (itemName == "FlashLight")
            playerStatus.usedFlashLight = true;
        else if (itemName == "Tape")
            playerStatus.usedTape = true;
        else if (itemName == "Towel")
            playerStatus.usedTowel = true;
    }
}

