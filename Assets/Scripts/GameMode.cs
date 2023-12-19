using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public Dictionary<string, GameObject> OnlinePlayerInfo = new Dictionary<string, GameObject>(); //온라인 플레이어들의 정보를 저장하는 딕셔너리

    [SerializeField]
    public GameObject LocalPlayer;
    public LocalPlayerManager LocalPMgr;

    [SerializeField]
    private GameObject OnlinePlayer;

    private void Start()
    {
        GetComponent<AudioSource>().volume = LocalPlayerManager.instance.MainSound;
        Camera.main.GetComponent<AudioSource>().volume = LocalPlayerManager.instance.EffectSound;

        LocalPMgr = GameObject.Find("PlayerManager").GetComponent<LocalPlayerManager>();
        if (LocalPMgr.Nickname != "")
        {//로비 씬으로 되돌아올때 플레이어 닉네임 출력 설정 (첫 접속일땐 호출 x)
            Debug.LogError("플레이어 복귀");
            LocalPMgr.LocalPlayerModel = GameObject.Find("LPO");
            LocalPMgr.PrintLocalPlayerName();
            GetComponent<FromReact>().initfromUnity();
        }
    }

    public void AddPlayerInfo(initDTO Key)
    {
        if (OnlinePlayerInfo.ContainsKey(Key.nickname))
        { //이미 존재하는 플레이어의 init이 왔을 시
            Debug.LogError("initfromReact: 이미 존재하는 플레이어" + Key.nickname);   
        }
        else
        {//플레이 도중 새 플레이어 접속 시 플레이어 생성
            GameObject OP = Instantiate(OnlinePlayer);
            OP.GetComponent<OnlinePlayerManager>().Nickname = Key.nickname;
            OP.GetComponent<OnlinePlayerManager>().Score = Key.score;
            OP.GetComponent<OnlinePlayerManager>().isLogin = Key.islogin;
            OP.GetComponent<OnlinePlayerManager>().PrintOnlinePlayerName();
            OP.transform.position = new Vector3(-120, 0, -120);
            OnlinePlayerInfo.Add(Key.nickname, OP);
            //내 정보 전달
            GetComponent<FromReact>().playerfromUnity();
        }
    }

    public void UpdatePlayerInfo(PlayerDTO Key)
    {
        if (OnlinePlayerInfo.ContainsKey(Key.nickname))
        {//플레이어 정보 업데이트
            OnlinePlayerInfo[Key.nickname].transform.position = new Vector3(Key.pos_x, Key.pos_y, Key.pos_z);
            OnlinePlayerInfo[Key.nickname].transform.rotation = Quaternion.Euler(Key.rot_x, Key.rot_y, Key.rot_z);
            OnlinePlayerInfo[Key.nickname].GetComponent<PlayerAnimation>().UpdateStat(Key.is_walk, Key.is_run, Key.is_jump);
        }
        else
        {//처음 접속 시 로비에 있던 플레이어 생성
            GameObject OP = Instantiate(OnlinePlayer);
            OP.GetComponent<OnlinePlayerManager>().Nickname = Key.nickname;
            OP.GetComponent<OnlinePlayerManager>().Score = Key.score;
            OP.GetComponent<OnlinePlayerManager>().PrintOnlinePlayerName();
            OP.transform.position = new Vector3(Key.pos_x, Key.pos_y, Key.pos_z);
            OP.transform.rotation = Quaternion.Euler(Key.rot_x, Key.rot_y, Key.rot_z);
            OP.GetComponent<PlayerAnimation>().UpdateStat(Key.is_walk, Key.is_run, Key.is_jump);
            OnlinePlayerInfo.Add(Key.nickname, OP);
        }
    }

    public void DeletePlayerInfo(initDTO Key)
    {
        Destroy(OnlinePlayerInfo[Key.nickname]);
        OnlinePlayerInfo.Remove(Key.nickname);
    }

    public void ConstructLocalPlayer(LocalDTO Key)
    { //첫 입장 (로컬 플레이어 정보 획득)
        Debug.Log("게임 접속 성공");
        LocalPMgr.Nickname = Key.nickname;
        LocalPMgr.Score = Key.score;
        LocalPMgr.isLogin = true;
        LocalPMgr.PrintLocalPlayerName();
    }

    public void SetMainSound()
    {

    }
}
