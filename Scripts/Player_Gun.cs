using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player_Gun : MonoBehaviour, IDragHandler, IPointerUpHandler // , IPointerDownHandler
{
    private Image joyOut; // ���̽�ƽ �ٱ��κ� �̹��� �������� ����
    private Image joyIn; // ���̽�ƽ ���ʺκ�  �̹��� �������� ����
    private Vector3 inputVector; // �̵� ���Ͱ� �������� ����
    public GameObject bulletObj;
    public Transform Muzzle_Transform;
    public bool isFire;
    private float FireCoolTime = 0.5f;
    public float FireLeftTime;

    public Vector3 _moveVector; // �Ѿ� �̵� ����
    public float BulletSpeed;     // �Ѿ� �ӵ�

    void Start()
    {
        joyOut = GetComponent<Image>();
        joyIn = transform.GetChild(0).GetComponent<Image>();

        
    }

    void FixedUpdate()
    {
        HandleInput(); // ��ġ�е� �Է¹ޱ�
        FireLeftTime -= Time.deltaTime;
        if (FireLeftTime <= 0)
        {
            isFire = false;
        }
        Fire();
        
        
    }

    public virtual void OnDrag(PointerEventData ped) //���̽�ƽ�� ������ ���� �� ������ �Լ�
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joyOut.rectTransform, ped.position, ped.pressEventCamera, out pos)) // ���̽�ƽ �ٱ��κп� ��ġ �߻��� ����
        {
            pos.x = (pos.x / joyOut.rectTransform.sizeDelta.x);  // ��ġ�� ������ǥ���� pos�� �Ҵ�
            pos.y = (pos.y / joyOut.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 2, pos.y * 2, 0); // ���� pos�� �������ͷ� ��ȯ
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            // ��ȯ�� �������͸� �̿��� ���̽�ƽ ���ʺκ� �̵�
            joyIn.rectTransform.anchoredPosition = new Vector3(inputVector.x * (joyOut.rectTransform.sizeDelta.x / 3)
                                                                , inputVector.y * (joyOut.rectTransform.sizeDelta.y / 3));

        }
    }

    // ��ġ �ϰ� ������ �߻��ϴ� �Լ�
    public virtual void OnPointDown(PointerEventData ped)
    {

        OnDrag(ped);

    }

    // ��ġ�� ���������� �߻��ϴ� �Լ� (��ġ �ʱ�ȭ)
    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector3.zero;
        joyIn.rectTransform.anchoredPosition = Vector3.zero;
    }

    // Player�� �̵���Ű�� ���� ����� �����Լ�
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
                    Debug.Log("�߻�");
                    
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