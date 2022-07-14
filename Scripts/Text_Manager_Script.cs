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

    void Update()
    {
        hp = _player.Player_Health.ToString();
        pow = _player.Player_Power.ToString();
        status_ui.text = "HP: " + hp + "    Power: " + pow; ;         // ĳ���� ���� ������Ʈ

        Scene scene = SceneManager.GetActiveScene(); 
        StageName.text = "Stage: " + scene.name;                      // Stage �̸� ������Ʈ
    }
}