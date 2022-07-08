using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    // 총알이 충돌시 발생하는 함수
    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.tag == "Wall") // 벽이랑 충돌
            Destroy(this.gameObject);

        if (col.gameObject.tag == "Monster") // 몬스터랑 충돌
            Destroy(this.gameObject);
    }
}