using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Control : MonoBehaviour
{
    public static Data_Control data;
    public int Money = 0;           // �÷��̾� ��
    public int Player_Power = 10;        // �÷��̾� ���ݷ�
    public int Player_Health = 10;        // �÷��̾� ���� ü��
    public int Max_Player_Health = 10;   // �÷��̾� ��ü ü��
    public float FireCoolTime = 0.5f;     // �÷��̾� ���ݼӵ�
    public int Health_NeedMoney = 100;
    public int Power_NeedMoney = 100;
    public bool Gun_Up = false;

    void Awake()  // ������Ʈ�� ���� �ϳ��� �ֵ��� ����
    {
        DontDestroyOnLoad(gameObject);  
        if (data == null)
            data = this;
        else if (data != this)
            Destroy(gameObject);
    }
}
