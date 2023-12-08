using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public Dictionary<string, GameObject> OnlinePlayerInfo = new Dictionary<string, GameObject>(); //온라인 플레이어들의 정보를 저장하는 딕셔너리
    [SerializeField]
    private GameObject LocalPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
