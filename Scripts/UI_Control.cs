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

    public void OnClickHeal()       // Home ȭ�鿡�� Heal ��ư Ŭ���� ü��ȸ��
    {
        Data_Control.data.Player_Health = Data_Control.data.Max_Player_Health;
    }

    public void OnClickDungeon_1()    // Dungeon 1 ���ý�
    {
        SceneManager.LoadScene("1 - 1");
    }
    public void OnClickDungeon_2()    // Dungeon 2 ���ý�
    {
        SceneManager.LoadScene("2 - 1");
    }
    public void OnClickDungeon_3()    // Dungeon 3 ���ý�
    {
        SceneManager.LoadScene("3 - 1");
    }
    public void OnClickDungeon_4()    // Dungeon 4 ���ý�
    {
        SceneManager.LoadScene("4 - 1");
    }
    public void OnClickDungeon_5()    // Dungeon 5 ���ý�
    {
        SceneManager.LoadScene("5 - 1");
    }
    public void OnClickBoss()    // Boss ���ý�
    {
        SceneManager.LoadScene("Boss");
    }
}
