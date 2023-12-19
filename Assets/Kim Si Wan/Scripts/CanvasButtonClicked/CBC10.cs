using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CBC10 : MonoBehaviour
{
    public GameObject player;
    public Button next;
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            if (player.GetComponent<PlayerStatus>().belongings[i] != null)
                if (player.GetComponent<PlayerStatus>().belongings[i].itemName == "Radio")
                    player.GetComponent<PlayerStatus>().belongings[i].usePermit = true;
        }
    }
    void Update()
    {
        if (player.GetComponent<PlayerStatus>().usedRadio == false)
            next.GetComponent<Button>().interactable = false;
        else
            next.GetComponent<Button>().interactable = true;
    }
}
