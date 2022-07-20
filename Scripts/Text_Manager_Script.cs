using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // TextMeshPro�� �������� �ʿ���
using UnityEngine.SceneManagement;

public class Text_Manager_Script : MonoBehaviour
{
    public TextMeshProUGUI status_ui;  // ĳ���� ���¸� �ۼ��ϱ� ���� ����
    string hp;          // �ؽ�Ʈ�� string���� �ؾ��ϱ� ������
    string pow;
    string mon;
    string max_hp;

    public TextMeshProUGUI StageName;  // Stage �̸��� �ۼ��ϱ� ���� ����

    void Update()
    {
        max_hp = Data_Control.data.Max_Player_Health.ToString();
        hp = Data_Control.data.Player_Health.ToString();
        pow = Data_Control.data.Player_Power.ToString();
        mon = Data_Control.data.Money.ToString();
        status_ui.text = "HP: " + hp + " / " + max_hp + "   Power: " + pow + "   Money: " + mon;        // ĳ���� ���� ������Ʈ

        Scene scene = SceneManager.GetActiveScene(); 
        StageName.text = scene.name;                      // Stage �̸� ������Ʈ
    }
}