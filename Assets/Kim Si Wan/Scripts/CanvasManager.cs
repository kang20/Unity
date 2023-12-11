using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject player;
    public GameObject panel;

    public GameObject[] canvas;
    public Button[] buttons;

    public int currentIndex;

    public void init() {
        panel.SetActive(true);
        canvas[0].SetActive(true);
    }
    public void nextBtn(){
        if (currentIndex == 3) {
            if (player.GetComponent<PlayerStatus>().usedMask == false)
                this.GetComponent<Button>().interactable = true;
        }
        canvas[currentIndex].SetActive(false);
        canvas[++currentIndex].SetActive(true);
    }
    public void skipBtn(){
        canvas[currentIndex].SetActive(false);
        canvas[++currentIndex].SetActive(true);
        GameManager.instance.finalScore -= 20;
    }
    
}
