using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // TextMeshPro�� �������� �ʿ���

public class Status_UI : MonoBehaviour
{
    public TextMeshProUGUI status_ui;  // Text�� �ۼ��ϱ� ���� ����
    public Player_Script _player;      // �÷��̾��� ���ݷ� ü���� �������� ���ؼ�

    string hp;          // �ؽ�Ʈ�� string���� �ؾ��ϱ� ������
    string pow;

    void Update()
    {
        hp = _player.Player_Health.ToString();
        pow = _player.Player_Power.ToString();
        string output = "HP: " + hp + "    Power: " + pow;
        status_ui.text = output;
    }
}