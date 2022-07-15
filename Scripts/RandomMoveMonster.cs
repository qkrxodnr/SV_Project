using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

public class RandomMoveMonster : MonoBehaviour
{
    public float MovingSpeed, AttackSpeed = 20; // MovingSpeed�� �������� ���߿� ������
    private float w, h; // MoveRandom �Լ��� ���⼳���� ���� ����
    public GameObject Bullet; // ������ ����
    public Transform target;
    private int Count, AttackCount; // �߻� Ƚ�� ������ ���� ����
    public GameObject player;
    public Player_Script _player;
    public int Monster_Health; // ���� ü��
    public int Monster_Power;  // ���� ���ݷ�
    public int Monster_Money;  // ���Ͱ� �ִ� ��

    void Start()
    {
        transform.position = new Vector3(8, 4, 0); // ���� ��ġ ����
        AttackCount = 3; // �ѹ� ������ �� �� �� ���� ����
        MoveRandom(); // ���� �������� �����ִ� �Լ�, �ѹ��� ȣ���ϰ� �Լ��ȿ��� �˾Ƽ� �����
        Attack(); // �ѹ��� ȣ���ϰ� �Լ��ȿ��� �˾Ƽ� �����
    }
    void Update()
    {
        if (Monster_Health <= 0)              // ���� ü�� 0���� ������ ����
        {
            Destroy(this.gameObject);
            Data_Control.data.Money += Monster_Money;
        }
            
        Moving(); // �̵��Լ�
    }

    void Moving()
    {
        transform.Translate(new Vector3(w, h, 0) * MovingSpeed * Time.deltaTime); // �̵� �ڵ�
        // ī�޶� �� �� ������ ����
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) { pos.x = 0f; w *= -1; } // ������ �����̸� ƨ��
        if (pos.x > 1f) { pos.x = 1f; w *= -1; } // ������ �����̸� ƨ��
        if (pos.y < 0f) { pos.y = 0f; h *= -1; } // ������ �����̸� ƨ��
        if (pos.y > 1f) { pos.y = 1f; h *= -1; } // ������ �����̸� ƨ��
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
    void MoveRandom() // w�� h�� ���� ���÷� �ٲپ� �������� ������ ���� ����
    {
        w = Random.Range(-2, 3);
        if (w > 0) w = 1;
        else if (w < 0) w = -1;
        else w = 0;
        h = Random.Range(-2, 3);
        if (h > 0) h = 1;
        else if (h < 0) h = -1;
        else h = 0;
        MovingSpeed = Random.Range(2, 6); // �����̴� �ӵ� ���� ����
        float delay = Random.Range(0.3f, 3.0f); // �� ���� ������ ������ �������� ����
        Invoke("MoveRandom", delay); // delay �ð� ��ŭ ���� �Ŀ� MoveRandom �Լ� ȣ��
    }
    void Attack() // �����Լ�
    {
        Invoke("Fire", 3); // 3�� �� �߻��Լ� ȣ��
    }

    void Fire() // �߻��Լ�
    {
        MonsterBullet _monsterbullet = Bullet.GetComponent<MonsterBullet>(); // ������ ������Ʈ �ҷ���
        _monsterbullet.shooter = transform.position; // ������ ������Ʈ�� �� ��ġ �Ѱ���
        _monsterbullet.target = target.position;     // ������ ������Ʈ�� Ÿ�� ��ġ �Ѱ���
        _monsterbullet.speed = AttackSpeed;          // ������ ������Ʈ�� ���� �ӵ� �Ѱ���
        Instantiate(Bullet, transform.position, Quaternion.identity); // ������ Ŭ��(�Ѿ�) ����
        Count++; // �� �� �߻� �� ������ 1�� �����ְ� AttackCount ��ŭ �߻��ϸ� ��͸���
        if (Count == AttackCount)
        {
            CancelInvoke("Fire"); // ��͸���
            Count = 0; // ���� �߻縦 ���� �ʱ�ȭ
            Attack(); // �߻簡 ������ �ٽ� Attack �Լ��� ȣ���Ͽ� 3�� �� �ٽ� Fire �Լ� ȣ���
        }
        else Invoke("Fire", 0.3f); // 0.3�ʸ��� ����Ͽ� �߻���
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.tag == "Player_bullet")   // ���Ͱ� player �Ѿ��� ������ �÷��̾� ���ݷ¸�ŭ ü�� ������.
        {
            Player_Script _player = player.GetComponent<Player_Script>();
            Monster_Health -= Data_Control.data.Player_Power;
        }
    }

    public void AttakPlayer()
    {
        _player.Player_Health -= Monster_Power;
    }
}
