using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player_Gun : MonoBehaviour, IDragHandler, IPointerUpHandler // , IPointerDownHandler
{
    private Image joyOut; // 조이스틱 바깥부분 이미지 전역변수 선언
    private Image joyIn; // 조이스틱 안쪽부분  이미지 전역변수 선언
    private Vector3 inputVector; // 이동 벡터값 전역변수 선언
    public GameObject bulletObj;
    public Transform Muzzle_Transform;
    public bool isFire;
    private float FireCoolTime = 0.5f;
    public float FireLeftTime;

    public Vector3 _moveVector; // 총알 이동 벡터
    public float BulletSpeed;     // 총알 속도

    void Start()
    {
        joyOut = GetComponent<Image>();
        joyIn = transform.GetChild(0).GetComponent<Image>();

        
    }

    void FixedUpdate()
    {
        HandleInput(); // 터치패드 입력받기
        FireLeftTime -= Time.deltaTime;
        if (FireLeftTime <= 0)
        {
            isFire = false;
        }
        Fire();
        
        
    }

    public virtual void OnDrag(PointerEventData ped) //조이스틱을 누르고 있을 때 실행할 함수
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
    public virtual void OnPointDown(PointerEventData ped)
    {

        OnDrag(ped);

    }

    // 터치를 중지했을때 발생하는 함수 (위치 초기화)
    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector3.zero;
        joyIn.rectTransform.anchoredPosition = Vector3.zero;
    }

    // Player를 이동시키기 위해 사용할 리턴함수
    public float GetHorizontalValue() { return inputVector.x; }

    public float GetVerticalValue() { return inputVector.y; }

    

    public void HandleInput()
    {
        _moveVector = PoolInput();
    }

    public Vector3 PoolInput()
    {
        float h = GetHorizontalValue();
        float v = GetVerticalValue();
        Vector3 moveDir = new Vector3(h, v, 0).normalized;

        return moveDir;
    }

    void Fire()
    {
        if (isFire is false)
        {
            isFire = true;

            if (FireLeftTime <= 0)
            {

                Vector3 myPos = new Vector3(Muzzle_Transform.position.x, Muzzle_Transform.position.y, 0);
                if (inputVector.x == 0 & inputVector.y == 0)
                {

                }
                else
                {
                    Debug.Log("발사");
                    
                    GameObject bullet = Instantiate(bulletObj, myPos, Quaternion.identity);
                    Transform Bullet_Transform = bullet.GetComponent<Transform>();
                    Move(Bullet_Transform);
                    FireLeftTime = FireCoolTime;
                }


            }

        }
        else
        {
            return;
        }

    }

    void Move(Transform a)
    {
        a.Translate(_moveVector * BulletSpeed * Time.deltaTime);
    }
}