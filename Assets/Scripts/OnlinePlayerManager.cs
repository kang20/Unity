using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnlinePlayerManager : MonoBehaviour
{
    public string Nickname;
    public int Score;
    public bool isLogin;

    public void PrintOnlinePlayerName()
    {
        GetComponentInChildren<TextMeshPro>().text = Score.ToString() + "  " + Nickname;
    }
}
