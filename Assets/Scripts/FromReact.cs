using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;



public class FromReact : MonoBehaviour
{
    [DllImport("__Internal")] 
    private static extern void info(string playerstr); // 플레이어의 상태 정보를 클라이언트(리액트로 보내는 함수)
    [DllImport("__Internal")] 
    private static extern void newplay(string initstr);// 플레이어의 플레이어가 생성했다는 메세지를 클라이언트(리액트)로 보내는 함수

    [DllImport("__Internal")]
    private static extern void BuildComplete(); // 플레이어의 상태 정보를 클라이언트(리액트로 보내는 함수)

    public initDTO _initDto;
    private string initstr;

    public PlayerDTO _playerDto;
    private string playerstr;

    public LocalDTO _localDto;

    public GameMode LobbyMode;

    private void Start()
    {
        if(LobbyMode.LocalPMgr.Nickname == "")
        {
            BuildCompleteFromUnity();
        }
    }


    private void Update()
    {
        //플레이어 정보 변경 시 호출
        if (LobbyMode.LocalPlayer.GetComponentInChildren<PlayerAnimation>().transform.hasChanged)
        {
            Debug.Log("로컬 플레이어 정보 바뀜");
            playerfromUnity();
            LobbyMode.LocalPlayer.GetComponentInChildren<PlayerAnimation>().transform.hasChanged = false;
        }
    }

    // Unity -> React
    public void initfromUnity()
    {//로비 씬 입장 or 퇴장 시 사용
        initstr = JsonUtility.ToJson(new initDTO(LobbyMode.LocalPMgr.Nickname, LobbyMode.LocalPMgr.Score, LobbyMode.LocalPMgr.isLogin));
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        newplay(initstr);
#else
        Debug.Log("유니티(실행 위치) -> 리액트 : " + initstr);
#endif
        Debug.Log("유니티(실행 위치) -> 리액트 : " + initstr);
    }

    // Unity -> React
    // player 정보를 리액트로 보내는 유니티 내부 함수
    public void playerfromUnity()
    {//로컬 플레이어 정보 변경 시 호출
        playerstr = JsonUtility.ToJson(LobbyMode.LocalPMgr.LocalPlayerDTO);
        Debug.Log(playerstr);

#if UNITY_WEBGL == true && UNITY_EDITOR == false
        info(playerstr);
#else
        Debug.Log("유니티(실행 위치) -> 리액트 : " + playerstr);
#endif
        Debug.Log("유니티(실행 위치) -> 리액트: " + playerstr);
    }

    // Unity -> React
    public void BuildCompleteFromUnity()
    {//빌드 성공 후 호출
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        BuildComplete();
#else
        Debug.Log("유니티(실행 위치) -> 리액트 : " + initstr);
#endif
        Debug.Log("유니티(실행 위치) -> 리액트 : " + initstr);
    }

    // React -> Unity
    public void initfromReact(string reactInit)
    {
        _initDto = JsonUtility.FromJson<initDTO>(reactInit);
        if (_initDto.islogin)
        {
            LobbyMode.AddPlayerInfo(_initDto);
        }
        else
        {
            LobbyMode.DeletePlayerInfo(_initDto);
        }
        Debug.Log("리액트 -> 유니티(실행 위치) init : " + reactInit);
    }

    // React -> Unity
    public void playerfromReact(string reactPlayer)
    {
        _playerDto = JsonUtility.FromJson<PlayerDTO>(reactPlayer);

        LobbyMode.UpdatePlayerInfo(_playerDto);
        
        Debug.Log("리액트 -> 유니티 player(실행위치) : " + reactPlayer);
    }

    //React -> Unity 추가 (플레이어 로그인 정보 획득)
    public void StatfromReact(string reactStat)
    {
        _localDto = JsonUtility.FromJson<LocalDTO>(reactStat);

        LobbyMode.ConstructLocalPlayer(_localDto);
        initfromUnity();
    }
}
