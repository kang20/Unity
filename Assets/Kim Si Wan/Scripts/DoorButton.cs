using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorButton : MonoBehaviour
{
    public GameObject Btn;
    public Button use;
    public Button Cancel;
    public GameObject player;
    public GameObject Towel;

    private bool isTowel = false;

    void Update()
    {
        for (int i = 0; i < 20; i++)
        {
            if (player.GetComponent<PlayerStatus>().belongings[i] != null)
            {
                if (player.GetComponent<PlayerStatus>().belongings[i].itemName == "Towel")
                {
                    isTowel = true;
                    break;
                }
            }
        }

        if (isTowel)
            use.GetComponent<Button>().interactable = true;
        else
            use.GetComponent<Button>().interactable = false;
    }
    public void OnClickUse()
    {
        SWAudio.instance.playSound("Button");

        player.GetComponent<PlayerStatus>().usedTowel = true;
        Towel.SetActive(true);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Btn.SetActive(false);
    }
    public void OnClickCancel()
    {
        SWAudio.instance.playSound("Button");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Btn.SetActive(false);
    }
}
