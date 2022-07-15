using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // TextMeshPro�� �������� �ʿ���
using UnityEngine.SceneManagement;

public class Text_Manager_Script : MonoBehaviour
{
    public TextMeshProUGUI status_ui;  // ĳ���� ���¸� �ۼ��ϱ� ���� ����
    public TextMeshProUGUI StageName;  // Stage �̸��� �ۼ��ϱ� ���� ����
    public Player_Script _player;      // �÷��̾��� ���ݷ� ü���� �������� ���ؼ�

    string hp;          // �ؽ�Ʈ�� string���� �ؾ��ϱ� ������
    string pow;
    string mon;
    
    void Update()
    {
        hp = _player.Player_Health.ToString();
        pow = Data_Control.data.Player_Power.ToString();
        mon = Data_Control.data.Money.ToString();
        status_ui.text = "HP: " + hp + "    Power: " + pow + "    Money: " + mon;        // ĳ���� ���� ������Ʈ

        Scene scene = SceneManager.GetActiveScene(); 
        StageName.text = scene.name;                      // Stage �̸� ������Ʈ
    }
}