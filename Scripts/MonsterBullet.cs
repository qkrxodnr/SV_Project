using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    public float speed; // 몬스터에서 설정해줌

    public Vector3 target, shooter; // 몬스터에서 설정해줌

    private float w, h;

    void Start()
    {
        w = target.x - shooter.x; // 타겟 위치 쪽으로 방향 설정(좌우)
        h = target.y - shooter.y; // 타겟 위치 쪽으로 방향 설정(상하)
    }

    void Update()
    {
        transform.Translate(new Vector3(w, h, 0).normalized * speed * Time.deltaTime);
    }

    // 총알이 충돌시 발생하는 함수
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall") // 벽이랑 충돌
            Destroy(this.gameObject);

        if (col.gameObject.tag == "Player") // 플레이어랑 충돌
            Destroy(this.gameObject);
    }
}