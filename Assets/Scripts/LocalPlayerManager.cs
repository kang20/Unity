using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocalPlayerManager : MonoBehaviour
{
    public static LocalPlayerManager instance = null;
    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public string Nickname;
    public int Score;
    public bool isLogin;
    public GameObject LocalPlayerModel;
    public PlayerDTO LocalPlayerDTO;

    public float MainSound;
    public float EffectSound;
    public float MouseSensitivity;
    public int PlayerPerson; //카메라 인칭

    void Start()
    {
        LocalPlayerModel = GameObject.Find("LPO");
        MainSound = 0.5f;
        EffectSound = 0.5f;
        MouseSensitivity = 0.5f;
        PlayerPerson = 3;
    }

    private void Update()
    {
        if (LocalPlayerModel != null)
        {
            LocalPlayerDTO.setNickname(Nickname);
            LocalPlayerDTO.setScore(Score);
            LocalPlayerDTO.setPosX(LocalPlayerModel.transform.position.x);
            LocalPlayerDTO.setPosY(LocalPlayerModel.transform.position.y);
            LocalPlayerDTO.setPosZ(LocalPlayerModel.transform.position.z);
            LocalPlayerDTO.setRotX(LocalPlayerModel.transform.eulerAngles.x);
            LocalPlayerDTO.setRotY(LocalPlayerModel.transform.eulerAngles.y);
            LocalPlayerDTO.setRotZ(LocalPlayerModel.transform.eulerAngles.z);
            LocalPlayerDTO.setWalk(LocalPlayerModel.GetComponent<PlayerAnimation>()._iswalk);
            LocalPlayerDTO.setRun(LocalPlayerModel.GetComponent<PlayerAnimation>()._isrun);
            LocalPlayerDTO.setJump(LocalPlayerModel.GetComponent<PlayerAnimation>()._isjump);
        }
        //else
        //{//이거 굳이 안해도 될거같은데..,.,.
        //    LocalPlayerModel = GameObject.Find("LPO");
        //}
    }

    public void PrintLocalPlayerName()
    {
        LocalPlayerModel.GetComponentInChildren<TextMeshPro>().text = Score.ToString() + "  " + Nickname;
    }
}
