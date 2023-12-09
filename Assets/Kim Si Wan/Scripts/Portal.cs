using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Non player Tag -> return
        if (!other.CompareTag("Player"))
            return;

        // Now active scene name
        Scene nowScene = SceneManager.GetActiveScene();

        switch (nowScene.name)
        {
            case "Indoor":
                SceneManager.LoadScene("Outdoor");
                break;
            case "Outdoor":
                SceneManager.LoadScene("Indoor");
                break;

        }
    }

}
