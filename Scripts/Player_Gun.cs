using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player_Gun : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Image joyOut;       // �Ѿ� ���� ���̽�ƽ �ٱ��κ� �̹���
    private Image joyIn;        // �Ѿ� ���� ���̽�ƽ ���ʺκ�  �̹���
    private Vector3 inputVector; // �Ѿ� �̵� ���Ͱ�
    public GameObject bulletObj; // �Ѿ� ������
    public Transform Muzzle_Transform; // �ѱ� ��ġ
    private bool isFire;         // �ѽ�� ��Ÿ�� ������
    private float FireCoolTime = 0.5f; // �� ��Ÿ��
    private float FireLeftTime;         // �� ��Ÿ�� �����ð�
    public float BulletSpeed;       // �Ѿ� �ӵ�
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
            FireLeftTime -= Time.deltaTime; // �� ��Ÿ�� ��� ������Ʈ
            if (FireLeftTime <= 0)          // ���� �� ��Ÿ�� �����ð��� 0 ���϶�� �� �� �غ� �Ϸ�
            {
                isFire = false;
            }
            Fire();             // ��� Fire()�Լ� ����
        }
    }

    //���̽�ƽ�� ������ ���� �� ������ �Լ�
    public virtual void OnDrag(PointerEventData ped) 
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
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    // ��ġ�� ���������� �߻��ϴ� �Լ� (��ġ �ʱ�ȭ)
    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector3.zero;
        joyIn.rectTransform.anchoredPosition = Vector3.zero;
    }

    // �Ѿ� �߻��ϴ� �Լ�
    void Fire()
    {
        if (isFire is false) // �� �߻����� �ƴҶ�
        {
            isFire = true;   // �� �߻������� ������Ʈ
            if (FireLeftTime <= 0) // ���� �� �� �غ� �Ǹ�
            {
                Vector3 myPos = new Vector3(Muzzle_Transform.position.x, Muzzle_Transform.position.y, 0); // �ѱ� ��ġ
                if (inputVector.x != 0 | inputVector.y != 0) // ���̽�ƽ�� ������ ���� ������ �߻�
                {
                    Debug.Log("�߻�");
                    GameObject bullet = Instantiate(bulletObj, myPos, Quaternion.identity); // ������ �ν��Ͻ�ȭ
                    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();    // ������� �������� Rigidbody ��������
                    float h = inputVector.x;                    // �Ѿ� ���ư� ���� �����ֱ�
                    float v = inputVector.y;
                    Vector3 moveDir = new Vector3(h, v, 0).normalized; // ����ȭ
                    rigid.AddForce(moveDir * BulletSpeed, ForceMode2D.Impulse);  // ���ư���
                    FireLeftTime = FireCoolTime;                // ��Ÿ�� �缳��

                }
            }
        }
    }
}