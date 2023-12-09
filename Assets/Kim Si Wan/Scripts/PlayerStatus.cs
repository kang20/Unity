using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public Slider HpBarSlider;
    public float maxHp = 100f;

    public float currentHp;
    public string[] belongings;
    private int belongingsIndex = 0;

    private bool isHungry;
    private bool isThirsty;
    private bool isCold;
    private bool isAsh;
    private bool isLightOut;
    private bool isSick;
    void Start()
    {
        currentHp = maxHp;
        belongings = new string[20];
    }

    void CheckHp()
    {
        if (HpBarSlider != null)
            HpBarSlider.value = currentHp / maxHp;
    }
    public void Damage(bool badStatus) //* damage
    {
        while (badStatus)
        if (currentHp <= 0) //* if hp < 0 -> pass
            return;
        currentHp -= 5;
        CheckHp(); //* 체력 갱신
        if (currentHp <= 0)
        {
            //* gameover
        }
    }

    public void setBelongings(string itemName) {
        belongings[belongingsIndex] = itemName;
    }
}
