using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dash : MonoBehaviour, IPointerDownHandler
{
    public Player_Script player; // �÷��̾� ��ũ��Ʈ

    private bool keyTouch; // �̹����� ��ġ �Ǿ�����
    private bool isDash;   // �뽬 ������
    private float dashTime; // �뽬 �ð�

    void FixedUpdate()
    {
        if (keyTouch is true) // �̹����� ��ġ �Ǿ����� ����
        {
            isDash = true;   // �뽬������ ����
        }

        if (dashTime <= 0)  // ���� �뽬 Ÿ���� 0���� ������ �⺻ �̵��ӵ��� �����ϰ� �뽬Ÿ�� ����
        {
            player.MoveSpeed = 3.5f;
            if (isDash)
                dashTime = 0.7f;  
        }
        else if (0 < dashTime & dashTime <= 0.5) // ���� �뽬Ÿ���� 0 ~ 0.5 ���̶�� ���� �뽬Ÿ�� ���̰� �⺻ �̵��ӵ��� ����
        {
            dashTime -= Time.deltaTime;
            player.MoveSpeed = 3.5f;
        }
        else  // �뽬Ÿ���� 0.5 �̻��϶� ���� �뽬Ÿ�� ���̰� �뽬�ӵ��� ����
        {
            dashTime -= Time.deltaTime;
            player.MoveSpeed = 10.0f;
        }
        isDash = false;  // ���� �� �뽬���� �ƴ϶��� ǥ��
        keyTouch = false;  // �̹��� ��ġ ���� �ʱ�ȭ
    }

    public virtual void OnPointerDown(PointerEventData ped) // �̹����� ��ġ �Ǿ��ٸ� keyTouch�� true
    {
        keyTouch = true;
    }
}