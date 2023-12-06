using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSPlayerMgr : MonoBehaviour
{
    [SerializeField]
    private JSGameMode JSGMode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!JSGMode.ActionObj[0].activeSelf)
        {
            Debug.Log("파티클 쳐맞음");
            JSGMode.PHealth -= 1.5f;
        }
        else
        {
            Debug.Log("파티클 쳐맞음");
            JSGMode.PHealth -= 0.05f;
        }
    }
}
