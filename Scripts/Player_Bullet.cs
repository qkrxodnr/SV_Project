using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col) // �Ѿ��� ���� �浹�� ����
    {
        if (col.gameObject.tag == "Wall")
            Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col) // �Ѿ��� ���� �浹�� ����
    {
        if (col.gameObject.tag == "Player")
            Destroy(this.gameObject);
    }
}