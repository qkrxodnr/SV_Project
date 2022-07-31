using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Control : MonoBehaviour
{
    public static Data_Control data;
    public int Money = 0;           // 플레이어 돈
    public int Player_Power = 10;        // 플레이어 공격력
    public int Player_Health = 10;        // 플레이어 현재 체력
    public int Max_Player_Health = 10;   // 플레이어 전체 체력
    public float FireCoolTime = 0.5f;     // 플레이어 공격속도
    public int Health_NeedMoney = 100;
    public int Power_NeedMoney = 100;
    public bool Gun_Up = false;

    void Awake()  // 오브젝트가 씬에 하나만 있도록 구현
    {
        DontDestroyOnLoad(gameObject);  
        if (data == null)
            data = this;
        else if (data != this)
            Destroy(gameObject);
    }
}
