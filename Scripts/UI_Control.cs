using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Control : MonoBehaviour
{
    public void OnClickStartGame()   // ����ȭ�鿡�� Game Start�� Ŭ��������
    {
        Debug.Log("���� ����");
        SceneManager.LoadScene("Home");
    }

    public void OnClickHeal()
    {
        Data_Control.data.Player_Health = Data_Control.data.Max_Player_Health;
    }
}
