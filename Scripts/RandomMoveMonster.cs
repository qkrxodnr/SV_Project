using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

public class RandomMoveMonster : MonoBehaviour
{
    public float MovingSpeed, AttackSpeed = 20; // MovingSpeed는 랜덤으로 나중에 정해짐
    private float w, h; // MoveRandom 함수의 방향설정을 위한 변수
    public GameObject Bullet; // 프리팹 설정
    public Transform target;
    private int Count, AttackCount; // 발사 횟수 설정을 위한 변수
    public GameObject player;
    public Player_Script _player;
    public int Monster_Health; // 몬스터 체력
    public int Monster_Power;  // 몬스터 공격력
    public int Monster_Money;  // 몬스터가 주는 돈

    void Start()
    {
        transform.position = new Vector3(8, 4, 0); // 시작 위치 설정
        AttackCount = 3; // 한번 공격할 때 몇 번 쏠지 설정
        MoveRandom(); // 어디로 움직일지 정해주는 함수, 한번만 호출하고 함수안에서 알아서 재귀함
        Attack(); // 한번만 호출하고 함수안에서 알아서 재귀함
    }
    void Update()
    {
        if (Monster_Health <= 0)              // 몬스터 체력 0보다 낮을시 삭제
        {
            Destroy(this.gameObject);
            Data_Control.data.Money += Monster_Money;
        }
            
        Moving(); // 이동함수
    }

    void Moving()
    {
        transform.Translate(new Vector3(w, h, 0) * MovingSpeed * Time.deltaTime); // 이동 코드
        // 카메라 밖 못 나가게 설정
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) { pos.x = 0f; w *= -1; } // 벽으로 움직이면 튕김
        if (pos.x > 1f) { pos.x = 1f; w *= -1; } // 벽으로 움직이면 튕김
        if (pos.y < 0f) { pos.y = 0f; h *= -1; } // 벽으로 움직이면 튕김
        if (pos.y > 1f) { pos.y = 1f; h *= -1; } // 벽으로 움직이면 튕김
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
    void MoveRandom() // w와 h의 값을 수시로 바꾸어 랜덤으로 움직일 방향 설정
    {
        w = Random.Range(-2, 3);
        if (w > 0) w = 1;
        else if (w < 0) w = -1;
        else w = 0;
        h = Random.Range(-2, 3);
        if (h > 0) h = 1;
        else if (h < 0) h = -1;
        else h = 0;
        MovingSpeed = Random.Range(2, 6); // 움직이는 속도 랜덤 설정
        float delay = Random.Range(0.3f, 3.0f); // 얼마 동안 설정한 방향대로 움직일지 설정
        Invoke("MoveRandom", delay); // delay 시간 만큼 지난 후에 MoveRandom 함수 호출
    }
    void Attack() // 공격함수
    {
        Invoke("Fire", 3); // 3초 후 발사함수 호출
    }

    void Fire() // 발사함수
    {
        MonsterBullet _monsterbullet = Bullet.GetComponent<MonsterBullet>(); // 프리팹 컴포넌트 불러움
        _monsterbullet.shooter = transform.position; // 프리팹 컴포넌트에 내 위치 넘겨줌
        _monsterbullet.target = target.position;     // 프리팹 컴포넌트에 타겟 위치 넘겨줌
        _monsterbullet.speed = AttackSpeed;          // 프리팹 컴포넌트에 공격 속도 넘겨줌
        Instantiate(Bullet, transform.position, Quaternion.identity); // 프리팹 클론(총알) 생성
        Count++; // 한 번 발사 할 때마다 1씩 더해주고 AttackCount 만큼 발사하면 재귀멈춤
        if (Count == AttackCount)
        {
            CancelInvoke("Fire"); // 재귀멈춤
            Count = 0; // 다음 발사를 위한 초기화
            Attack(); // 발사가 끝나면 다시 Attack 함수를 호출하여 3초 후 다시 Fire 함수 호출됨
        }
        else Invoke("Fire", 0.3f); // 0.3초마다 재귀하여 발사함
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.tag == "Player_bullet")   // 몬스터가 player 총알을 맞으면 플레이어 공격력만큼 체력 낮아짐.
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
