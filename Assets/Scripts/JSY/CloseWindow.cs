using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindow : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject ClosedWindow;
    [SerializeField]
    GameObject Playermodel;

    [SerializeField]
    private AudioClip WindowClip;
    private void OnMouseDown()
    {
        float distance = Vector3.Distance(Playermodel.transform.position, transform.position);
        if (distance < 5)
        {
            Camera.main.GetComponent<AudioSource>().clip = WindowClip;
            Camera.main.GetComponent<AudioSource>().Play();
            JSGameMode.instance.Point += 10;
            gameObject.SetActive(false);
            ClosedWindow.SetActive(true);
        }
    }
}

