using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Control : MonoBehaviour
{
    public static Data_Control data;
    public int Money = 0;           // 플레이어 돈
    public int Player_Power;        // 플레이어 공격력

    void Awake()  // 오브젝트가 씬에 하나만 있도록 구현
    {
        DontDestroyOnLoad(gameObject);  
        if (data == null)
            data = this;
        else if (data != this)
            Destroy(gameObject);
    }
}
