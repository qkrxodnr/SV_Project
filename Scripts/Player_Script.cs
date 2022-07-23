using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Script : MonoBehaviour
{
    public Joystick joystick;   // 조이스틱 스크립트
    public float MoveSpeed;     // 플레이어 이동속도

    private Vector3 _moveVector; // 플레이어 이동 벡터
    private Transform _transform;

    public RandomMoveMonster monster;

    void Start()
    {
        _transform = transform;    // Transform 캐싱
        _moveVector = Vector3.zero; // 플레이어 이동벡터 초기화
    }

    void Update()
    {
        if (Data_Control.data.Player_Health <= 0)
        {
            SceneManager.LoadScene("Home");
            Data_Control.data.Player_Health = Data_Control.data.Max_Player_Health;
        }
        HandleInput(); // 터치패드 입력받기
    }

    void FixedUpdate()
    {
        Move();    // 플레이어 이동
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

    void OnTriggerEnter2D(Collider2D col) // 플레이어가 몬스터 총알을 맞으면 몬스터 공격력만큼 체력 낮아짐
    {
        if (col.gameObject.tag == "Monster_bullet")
        {
            monster.AttakPlayer();

            Vector3 pos = Camera.main.WorldToScreenPoint(col.transform.position);
            FloatingText_Player.Instance.CreateDamageText(pos, monster.Monster_Power);
        }
    }
}
