using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    // �Ѿ��� �浹�� �߻��ϴ� �Լ�
    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.tag == "Wall") // ���̶� �浹
            Destroy(this.gameObject);

        if (col.gameObject.tag == "Monster") // ���Ͷ� �浹
            Destroy(this.gameObject);
    }
}