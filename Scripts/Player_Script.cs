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

    bool isdash;

    public int Player_Health;
    public int Player_Power;
    public int Player_AttackSpeed;

    void Start()
    {
        _transform = transform;    // Transform 캐싱
        _moveVector = Vector3.zero; // 플레이어 이동벡터 초기화
    }

    void Update()
    {
        if (Player_Health <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
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

    void OnTriggerEnter2D(Collider2D col) // 몬스터가 player 총알을 맞으면 체력 1 낮아짐.
    {
        if (col.gameObject.tag == "Monster_bullet")
            Player_Health -= 1;
    }

}
