using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    public Joystick joystick;   // ���̽�ƽ ��ũ��Ʈ
    public float MoveSpeed;     // �÷��̾� �̵��ӵ�

    private Vector3 _moveVector; // �÷��̾� �̵� ����
    private Transform _transform;

    bool isdash;

    public int Player_Health;
    public int Player_Power;

    void Start()
    {
        _transform = transform;    // Transform ĳ��
        _moveVector = Vector3.zero; // �÷��̾� �̵����� �ʱ�ȭ
    }

    void Update()
    {
        if (Player_Health <= 0)              // �÷��̾� ü�� 0���� ������ ����
            Destroy(this.gameObject);
        HandleInput(); // ��ġ�е� �Է¹ޱ�
    }

    void FixedUpdate()
    {
        Move();    // �÷��̾� �̵�
    }

    public void HandleInput()
    {
        _moveVector = PoolInput();
    }

    public Vector3 PoolInput()
    {
        float h = joystick.GetHorizontalValue();
        float v = joystick.GetVerticalValue();
        Vector3 moveDir = new Vector3(h, v, 0).normalized;

        return moveDir;
    }

    public void Move()
    {
        _transform.Translate(_moveVector * MoveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col) // ���Ͱ� player �Ѿ��� ������ ü�� 1 ������.
    {
        if (col.gameObject.tag == "Monster_bullet")
            Player_Health -= 1;
    }

}
