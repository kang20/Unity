using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Vector3 MovePos;
    private void OnTriggerEnter(Collider other)
    {
        // Non player Tag -> return
        if (!other.CompareTag("Player"))
            return;
        else {
            other.transform.position = MovePos;
        }
    }
}
