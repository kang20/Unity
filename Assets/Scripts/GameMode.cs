using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public Dictionary<string, GameObject> OnlinePlayerInfo = new Dictionary<string, GameObject>(); //온라인 플레이어들의 정보를 저장하는 딕셔너리
    [SerializeField]
    private GameObject LocalPlayer;
    [SerializeField]
    private GameObject OnlinePlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlayerInfo(initDTO Key)
    {
        if(OnlinePlayerInfo.Count == 0)
        { //첫 입장 (로컬 플레이어 정보 획득)
            Debug.Log("게임 입장");
            LocalPlayer.GetComponent<PlayerManager>().Nickname = Key.nickname;
            LocalPlayer.GetComponent<PlayerManager>().Score = Key.score;
            LocalPlayer.GetComponent<PlayerManager>().isLogin = Key.islogin;
        }
        else if (OnlinePlayerInfo.ContainsKey(Key.nickname))
        { //존재하는 플레이어 init 왔을 시
            Debug.LogError("initfromReact: 이미 존재하는 플레이어" + Key.nickname);
        }
        else
        {//플레이 도중 새 플레이어 접속 시 플레이어 생성
            GameObject OP = Instantiate(OnlinePlayer);
            OP.GetComponent<PlayerManager>().Nickname = Key.nickname;
            OP.GetComponent<PlayerManager>().Score = Key.score;
            OP.GetComponent<PlayerManager>().isLogin = Key.islogin;
            OP.transform.position = new Vector3(-120, 0, -120);
            OnlinePlayerInfo.Add(Key.nickname, OP);
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
            OP.GetComponent<PlayerManager>().Nickname = Key.nickname;
            OP.GetComponent<PlayerManager>().Score = Key.score;
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
}
