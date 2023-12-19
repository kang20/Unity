using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager11 : MonoBehaviour
{
    public GameObject player;
    public GameObject panel;

    public GameObject[] canvas;

    public Slider hp;
    public Text hpText;

    public void init() {
        panel.SetActive(true);
        canvas[0].SetActive(true);
    }
    public void nextBtn(){
        if (player.GetComponent<PlayerStatus>().currentBelongingIndex == 15){
            canvas[player.GetComponent<PlayerStatus>().currentBelongingIndex].SetActive(false);
            GameManager.instance.end();
        }
        else{
            canvas[player.GetComponent<PlayerStatus>().currentBelongingIndex].SetActive(false);
            canvas[++player.GetComponent<PlayerStatus>().currentBelongingIndex].SetActive(true);
        }
        Debug.Log(GameManager.instance.finalScore);
    }
    public void skipBtn(){
        canvas[player.GetComponent<PlayerStatus>().currentBelongingIndex].SetActive(false);
        canvas[++player.GetComponent<PlayerStatus>().currentBelongingIndex].SetActive(true);
        GameManager.instance.finalScore -= 100;
        hp.value -= 100;
        hpText.text = "Á¡¼ö : " + hp.value;

        Debug.Log(GameManager.instance.finalScore);
    }
    
}
