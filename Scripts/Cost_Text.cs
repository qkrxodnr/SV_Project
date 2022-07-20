using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // TextMeshPro�� �������� �ʿ���
using UnityEngine.SceneManagement;

public class Cost_Text : MonoBehaviour
{
    public TextMeshProUGUI Health_Cost;  // Health ���׷��̵�  Cost �ؽ�Ʈ
    public TextMeshProUGUI Power_Cost;
    string hc; // Health_Cost
    string pc; // Power_Cost
    void Update()
    {
        hc = Data_Control.data.Health_NeedMoney.ToString();     // Health_Cost ������Ʈ
        Health_Cost.text = "Cost: " + hc;

        pc = Data_Control.data.Power_NeedMoney.ToString();     // Power_Cost ������Ʈ
        Power_Cost.text = "Cost: " + pc;
    }
    
}
