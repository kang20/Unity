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
    public int PlayerPerson = 3; //Ä«¸Þ¶ó ÀÎÄª

    public string Nickname;
    public int Score;
    public bool isLogin;
    public GameObject LocalPlayerModel;
    public PlayerDTO LocalPlayerDTO;

    void Start()
    {
        LocalPlayerModel = GameObject.Find("LPO");
    }

    private void Update()
    {
        if (LocalPlayerModel != null)
        {
            LocalPlayerDTO.setPosX(LocalPlayerModel.transform.position.x);
            LocalPlayerDTO.setPosY(LocalPlayerModel.transform.position.y);
            LocalPlayerDTO.setPosZ(LocalPlayerModel.transform.position.z);
            LocalPlayerDTO.setRotX(LocalPlayerModel.transform.eulerAngles.x);
            LocalPlayerDTO.setRotY(LocalPlayerModel.transform.eulerAngles.y);
            LocalPlayerDTO.setRotZ(LocalPlayerModel.transform.eulerAngles.z);
            LocalPlayerDTO.setWalk(LocalPlayerModel.GetComponent<PlayerAnimation>()._iswalk);
            LocalPlayerDTO.setRun(LocalPlayerModel.GetComponent<PlayerAnimation>()._isrun);
            LocalPlayerDTO.setJump(LocalPlayerModel.GetComponent<PlayerAnimation>()._isjump);
            if (LocalPlayerModel.GetComponentInChildren<TextMeshPro>().text == "")
            {
                LocalPlayerModel.GetComponentInChildren<TextMeshPro>().text = Score.ToString() + "  " + Nickname;
            }
        }
        else
        {
            LocalPlayerModel = GameObject.Find("LPO");
        }
    }
}
