using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Control : MonoBehaviour
{
    public void OnClickStartGame()   // ����ȭ�鿡�� Game Start�� Ŭ��������
    {
        Debug.Log("���� ����");
        SceneManager.LoadScene("Tutorial");
    }

    public void OnClickNewGame()      // GameOverȭ�鼭���� Restart�� Ŭ��������
    {
        Debug.Log("�����");
        SceneManager.LoadScene("Main");
    }
}