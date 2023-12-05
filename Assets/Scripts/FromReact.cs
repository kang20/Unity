using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class FromReact : MonoBehaviour
{
    [DllImport("__Internal")] 
    private static extern void info(string initstr);
    [DllImport("__Internal")] 
    private static extern void newplay(string playerstr);

    private initDTO _initDto  = new initDTO("admin", 100, true);
    private string initstr ;
    
    private PlayerDTO _playerDto  = new PlayerDTO("admin", 200, 5f, 5f, 5f, 10f, 10f, 10f, true, true, false);
    private string playerstr;
    void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            initfromUnity();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            playerfromUnity();
        }
    }

    public void initfromUnity()
    {
        initstr = JsonUtility.ToJson(_initDto);
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        info(initstr);
#else
        Debug.Log("Error Unity init json : " + initstr);
#endif
        Debug.Log("Unity init json : " + initstr);
    }
    
    public void playerfromUnity()
    {
        playerstr = JsonUtility.ToJson(_playerDto);
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        newplay(playerstr);
#else
        Debug.Log("Error Unity player json : " + playerstr);
#endif
        Debug.Log("Unity init player json : " + playerstr);
    }

    
    public void initfromReact(string reactInit)
    {
        _initDto = JsonUtility.FromJson<initDTO>(reactInit);
        Debug.Log("리액트 -> 유니티 init : " + reactInit);
    }    
    
    public void playerfromReact(string reactPlayer)
    {
        _playerDto = JsonUtility.FromJson<PlayerDTO>(reactPlayer);
        Debug.Log("리액트 -> 유니티 player : " + reactPlayer);
    }
}
