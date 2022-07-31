using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Manager : MonoBehaviour
{
    public SpriteRenderer Gun;    // 화면에 나타나는 총
    public Sprite UG;             // 업그레이드시 바꿀 총

    private void Start()
    {
        Gun = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Data_Control.data.Gun_Up == true)
        {
            Gun.sprite = UG;    // 총 바꾸기
        }
    }
}
