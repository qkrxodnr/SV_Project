using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    public float speed; // ���Ϳ��� ��������

    public Vector3 target, shooter; // ���Ϳ��� ��������

    private float w, h;

    void Start()
    {
        w = target.x - shooter.x; // Ÿ�� ��ġ ������ ���� ����(�¿�)
        h = target.y - shooter.y; // Ÿ�� ��ġ ������ ���� ����(����)
    }

    void Update()
    {
        transform.Translate(new Vector3(w, h, 0).normalized * speed * Time.deltaTime);
    }

    // �Ѿ��� �浹�� �߻��ϴ� �Լ�
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall") // ���̶� �浹
            Destroy(this.gameObject);

        if (col.gameObject.tag == "Player") // �÷��̾�� �浹
            Destroy(this.gameObject);
    }
}