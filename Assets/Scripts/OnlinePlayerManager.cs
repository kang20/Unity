using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnlinePlayerManager : MonoBehaviour
{
    public string Nickname;
    public int Score;
    public bool isLogin;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<TextMeshPro>().text = Score.ToString() + "  " + Nickname;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
