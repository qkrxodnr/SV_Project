using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Control : MonoBehaviour
{
    public static Data_Control data;
    public int Money = 0;           // �÷��̾� ��
    public int Player_Power;        // �÷��̾� ���ݷ�

    void Awake()  // ������Ʈ�� ���� �ϳ��� �ֵ��� ����
    {
        DontDestroyOnLoad(gameObject);  
        if (data == null)
            data = this;
        else if (data != this)
            Destroy(gameObject);
    }
}
