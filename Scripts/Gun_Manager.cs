using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Manager : MonoBehaviour
{
    public SpriteRenderer Gun;    // ȭ�鿡 ��Ÿ���� ��
    public Sprite UG;             // ���׷��̵�� �ٲ� ��

    private void Start()
    {
        Gun = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Data_Control.data.Gun_Up == true)
        {
            Gun.sprite = UG;    // �� �ٲٱ�
        }
    }
}
