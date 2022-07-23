using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Script : MonoBehaviour
{
    public Joystick joystick;   // ���̽�ƽ ��ũ��Ʈ
    public float MoveSpeed;     // �÷��̾� �̵��ӵ�

    private Vector3 _moveVector; // �÷��̾� �̵� ����
    private Transform _transform;

    public RandomMoveMonster monster;

    void Start()
    {
        _transform = transform;    // Transform ĳ��
        _moveVector = Vector3.zero; // �÷��̾� �̵����� �ʱ�ȭ
    }

    void Update()
    {
        if (Data_Control.data.Player_Health <= 0)
        {
            SceneManager.LoadScene("Home");
            Data_Control.data.Player_Health = Data_Control.data.Max_Player_Health;
        }
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

    void OnTriggerEnter2D(Collider2D col) // �÷��̾ ���� �Ѿ��� ������ ���� ���ݷ¸�ŭ ü�� ������
    {
        if (col.gameObject.tag == "Monster_bullet")
        {
            monster.AttakPlayer();

            Vector3 pos = Camera.main.WorldToScreenPoint(col.transform.position);
            FloatingText_Player.Instance.CreateDamageText(pos, monster.Monster_Power);
        }
    }
}
