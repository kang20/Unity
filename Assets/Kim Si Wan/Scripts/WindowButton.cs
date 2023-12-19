using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowButton : MonoBehaviour
{
    public GameObject Btn;
    public Button use;
    public Button Cancel;
    public GameObject player;

    private bool isTape = false;

    void Update()
    {
        for (int i = 0; i < 20; i++)
        {
            if (player.GetComponent<PlayerStatus>().belongings[i].itemName == "Tape")
            {
                isTape = true;
                break;
            }
        }

        if (isTape)
            use.GetComponent<Button>().interactable = true;
        else
            use.GetComponent<Button>().interactable = false;
    }
    public void OnClickUse()
    {
        ++player.GetComponent<PlayerStatus>().countTape;

        if (player.GetComponent<PlayerStatus>().countTape == 4)
            player.GetComponent<PlayerStatus>().usedTape = true;

    }
    public void OnClickCancel()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Btn.SetActive(false);
    }
}
