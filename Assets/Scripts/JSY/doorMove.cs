using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorMove : MonoBehaviour
{
    bool isopen;
    // Start is called before the first frame update
    void Start()
    {
        isopen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("´©¸§");
        Vector3 rotAxis;
        rotAxis = transform.position;
        rotAxis.x += 1.2f;
        if(!isopen)
        {
            transform.Rotate(new Vector3(0, 90, 0));
            isopen = true;
        }
        else
        {
            transform.Rotate(new Vector3(0, -90, 0));
            isopen = false;
        }
    }
}
