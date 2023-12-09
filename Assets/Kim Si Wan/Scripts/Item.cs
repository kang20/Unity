using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemMaker itemMaker;

    public void useTool() {
        if (itemMaker.itemType == ItemMaker.ItemType.Equipment)
        {
            // 장착

        }
        else if (itemMaker.itemType == ItemMaker.ItemType.Used)
        {
            // 단순 상태효과 상승

        }
        else
        {
            // 외부 물체가 있는지 없는지 판단 후 외부 물체에 사용

            Debug.Log(itemMaker.itemName + " 을 사용했습니다.");
            //SetSlotCount(-1);
        }

    }
}
