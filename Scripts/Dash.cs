using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dash : MonoBehaviour, IPointerDownHandler
{
    public Player_Script player; // 플레이어 스크립트

    private bool keyTouch; // 이미지가 터치 되었는지
    private bool isDash;   // 대쉬 중인지
    private float dashTime; // 대쉬 시간

    void FixedUpdate()
    {
        if (keyTouch is true) // 이미지가 터치 되었을때 실행
        {
            isDash = true;   // 대쉬중으로 설정
        }

        if (dashTime <= 0)  // 만약 대쉬 타임이 0보다 작으면 기본 이동속도로 설정하고 대쉬타임 설정
        {
            player.MoveSpeed = 3.5f;
            if (isDash)
                dashTime = 0.7f;  
        }
        else if (0 < dashTime & dashTime <= 0.5) // 만약 대쉬타임이 0 ~ 0.5 사이라면 남은 대쉬타임 줄이고 기본 이동속도로 설정
        {
            dashTime -= Time.deltaTime;
            player.MoveSpeed = 3.5f;
        }
        else  // 대쉬타임이 0.5 이상일때 남은 대쉬타임 줄이고 대쉬속도로 설정
        {
            dashTime -= Time.deltaTime;
            player.MoveSpeed = 10.0f;
        }
        isDash = false;  // 끝난 후 대쉬중이 아니란걸 표시
        keyTouch = false;  // 이미지 터치 변수 초기화
    }

    public virtual void OnPointerDown(PointerEventData ped) // 이미지가 터치 되었다면 keyTouch가 true
    {
        keyTouch = true;
    }
}