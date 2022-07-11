using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player_Gun : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Image joyOut;       // 총알 방향 조이스틱 바깥부분 이미지
    private Image joyIn;        // 총알 방향 조이스틱 안쪽부분  이미지
    private Vector3 inputVector; // 총알 이동 벡터값
    public GameObject bulletObj; // 총알 프리팹
    public Transform Muzzle_Transform; // 총구 위치
    private bool isFire;         // 총쏘고 쿨타임 중인지
    private float FireCoolTime = 0.5f; // 총 쿨타임
    private float FireLeftTime;         // 총 쿨타임 남은시간
    public float BulletSpeed;       // 총알 속도
    public GameObject player;
    public Player_Script _player;

    void Start()
    {
        joyOut = GetComponent<Image>();
        joyIn = transform.GetChild(0).GetComponent<Image>();
    }

    void Update()
    {
        if (_player.Player_Health <= 0)
            return;
    }

    void FixedUpdate()
    {
        if (_player.Player_Health > 0)
        {
            FireLeftTime -= Time.deltaTime; // 총 쿨타임 계속 업데이트
            if (FireLeftTime <= 0)          // 만약 총 쿨타임 남은시간이 0 이하라면 총 쏠 준비 완료
            {
                isFire = false;
            }
            Fire();             // 계속 Fire()함수 실행
        }
    }

    //조이스틱을 누르고 있을 때 실행할 함수
    public virtual void OnDrag(PointerEventData ped) 
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joyOut.rectTransform, ped.position, ped.pressEventCamera, out pos)) // 조이스틱 바깥부분에 터치 발생시 실행
        {
            pos.x = (pos.x / joyOut.rectTransform.sizeDelta.x);  // 터치된 로컬좌표값을 pos에 할당
            pos.y = (pos.y / joyOut.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 2, pos.y * 2, 0); // 받은 pos를 단위벡터로 변환
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            // 변환한 단위벡터를 이용해 조이스틱 안쪽부분 이동
            joyIn.rectTransform.anchoredPosition = new Vector3(inputVector.x * (joyOut.rectTransform.sizeDelta.x / 3)
                                                                , inputVector.y * (joyOut.rectTransform.sizeDelta.y / 3));
        }
    }

    // 터치 하고 있을때 발생하는 함수
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    // 터치를 중지했을때 발생하는 함수 (위치 초기화)
    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector3.zero;
        joyIn.rectTransform.anchoredPosition = Vector3.zero;
    }

    // 총알 발사하는 함수
    void Fire()
    {
        if (isFire is false) // 총 발사중이 아닐때
        {
            isFire = true;   // 총 발사중으로 업데이트
            if (FireLeftTime <= 0) // 만약 총 쏠 준비가 되면
            {
                Vector3 myPos = new Vector3(Muzzle_Transform.position.x, Muzzle_Transform.position.y, 0); // 총구 위치
                if (inputVector.x != 0 | inputVector.y != 0) // 조이스틱이 가만히 있지 않을때 발사
                {
                    Debug.Log("발사");
                    GameObject bullet = Instantiate(bulletObj, myPos, Quaternion.identity); // 프리팹 인스턴스화
                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();    // 만들어진 프리팹의 Rigidbody 가져오기
                    float h = inputVector.x;                    // 총알 날아갈 방향 정해주기
                    float v = inputVector.y;
                    Vector3 moveDir = new Vector3(h, v, 0).normalized; // 정규화
                    rigid.AddForce(moveDir * BulletSpeed, ForceMode2D.Impulse);  // 날아가기
                    FireLeftTime = FireCoolTime;                // 쿨타임 재설정

                }
            }
        }
    }
}