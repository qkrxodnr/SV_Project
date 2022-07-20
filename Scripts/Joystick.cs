using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Image joyOut; // ���̽�ƽ �ٱ��κ� �̹��� �������� ����
    private Image joyIn; // ���̽�ƽ ���ʺκ�  �̹��� �������� ����
    private Vector3 inputVector; // �̵� ���Ͱ� �������� ����

    void Start()
    {
        joyOut = GetComponent<Image>();
        joyIn = transform.GetChild(0).GetComponent<Image>();
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

    // Player�� �̵���Ű�� ���� ����� �����Լ�
    public float GetHorizontalValue() { return inputVector.x; }

    public float GetVerticalValue() { return inputVector.y; }
}