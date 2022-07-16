using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject gu1;
    public GameObject gu2;

    public void OnClickHealth()  // Health 버튼 클릭시
    {
        if (Data_Control.data.Money >= Data_Control.data.Health_NeedMoney)
        {
            Data_Control.data.Money -= Data_Control.data.Health_NeedMoney;
            Data_Control.data.Health_NeedMoney += 100;
            Data_Control.data.Max_Player_Health += 10;
            Data_Control.data.Player_Health += 10;
        }
    }

    public void OnClickPower()  // Power 버튼 클릭시
    {
        if (Data_Control.data.Money >= Data_Control.data.Power_NeedMoney)
        {
            Data_Control.data.Money -= Data_Control.data.Power_NeedMoney;
            Data_Control.data.Power_NeedMoney += 100;
            Data_Control.data.Player_Power += 10;
        }
    }

    public void OnClickGun_1()    // Gun Upgrade 1 버튼 클릭시
    {
        if (Data_Control.data.Money >= 2000)
        {
            Data_Control.data.Money -= 2000;
            Data_Control.data.FireCoolTime -= 0.15f;
            gu1.SetActive(false);
        }
    }

    public void OnClickGun_2()    // Gun Upgrade 2 버튼 클릭시
    {
        if (Data_Control.data.Money >= 10000)
        {
            Data_Control.data.Money -= 10000;
            Data_Control.data.FireCoolTime -= 0.25f;
            gu2.SetActive(false);
        }
    }
}
