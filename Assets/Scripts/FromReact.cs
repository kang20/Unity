using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;



public class FromReact : MonoBehaviour
{
    [DllImport("__Internal")] 
    private static extern void info(string playerstr);
    [DllImport("__Internal")] 
    private static extern void newplay(string initstr);

    public initDTO _initDto;
    private string initstr ;

    public PlayerDTO _playerDto;
    private string playerstr;
    void Start()
    {
        _initDto = new initDTO("admin", 100, true);
        _playerDto = new PlayerDTO("admin", 200, 5f, 5f, 5f, 10f, 10f, 10f, true, true, false);
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


    // Unity -> React
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

    // Unity -> React    
    public void playerfromUnity()
    {
        playerstr = JsonUtility.ToJson(_playerDto);
        Debug.Log(_playerDto);

#if UNITY_WEBGL == true && UNITY_EDITOR == false
        newplay(playerstr);
#else
        Debug.Log("Error Unity player json : " + playerstr);
#endif
        Debug.Log("Unity init player json : " + playerstr);
    }

    
    // React -> Unity
    public void initfromReact(string reactInit)
    {
        _initDto = JsonUtility.FromJson<initDTO>(reactInit);
        Debug.Log("리액트 -> 유니티 init : " + reactInit);
    }    

    // React -> Unity
    public void playerfromReact(string reactPlayer)
    {
        _playerDto = JsonUtility.FromJson<PlayerDTO>(reactPlayer);
        Debug.Log("리액트 -> 유니티 player : " + reactPlayer);
    }
}
