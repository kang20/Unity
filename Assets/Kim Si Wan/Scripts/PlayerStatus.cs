using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public Slider HpBarSlider;
    public Text Debuff;
    private string debuffMsg = "";
    public int maxHp = 100;

    public int currentHp;
    public ItemMaker[] belongings;
    public int currentBelongingIndex = 0;

    public bool usedFood = false;
    public bool usedWater = false;
    public bool usedClothes = false;
    public bool usedFirstAid = false;
    public bool usedMask = false;
    public bool usedRadio = false;
    public bool usedBattery = false;
    public bool usedTape = false;
    public bool usedTowel = false;
    public bool usedFlashLight = false;

    public int countTape = 0;
    void Start()
    {
        currentHp = maxHp;
        belongings = new ItemMaker[20];
    }

    public void setBelongings(ItemMaker itemMaker) {
        for (int i = 0; i < 20; i++) {
            if (belongings[i] == null)
            {
                belongings[i] = itemMaker;
                break;
            }
        }
    }
    public void deleteBelongings(ItemMaker itemMaker) {
        for (int i = 0; i < 20; i++)
        {
            if (belongings[i] != null) { 
                if (belongings[i].itemName == itemMaker.itemName) {
                belongings[i] = null;
                break;
                }
            }
        }
    }

    public void gameover() {
        StopAllCoroutines();
        GameManager.instance.isGameover = true;
    }

    void checkHp()
    {
        if (HpBarSlider != null)
            HpBarSlider.value = currentHp / maxHp;
    }
    public void damage() //* damage
    {
        currentHp -= 5;
        checkHp(); //* 체력 갱신
        if (currentHp <= 0)
        {
            // 게임 오버
            gameover();
        }
    }
}