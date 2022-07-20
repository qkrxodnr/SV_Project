using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // TextMeshPro를 쓰기위해 필요함
using UnityEngine.SceneManagement;

public class Cost_Text : MonoBehaviour
{
    public TextMeshProUGUI Health_Cost;  // Health 업그레이드  Cost 텍스트
    public TextMeshProUGUI Power_Cost;
    string hc; // Health_Cost
    string pc; // Power_Cost
    void Update()
    {
        hc = Data_Control.data.Health_NeedMoney.ToString();     // Health_Cost 업데이트
        Health_Cost.text = "Cost: " + hc;

        pc = Data_Control.data.Power_NeedMoney.ToString();     // Power_Cost 업데이트
        Power_Cost.text = "Cost: " + pc;
    }
    
}
