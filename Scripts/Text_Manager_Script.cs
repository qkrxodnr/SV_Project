using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // TextMeshPro를 쓰기위해 필요함
using UnityEngine.SceneManagement;

public class Text_Manager_Script : MonoBehaviour
{
    public TextMeshProUGUI status_ui;  // 캐릭터 상태를 작성하기 위한 선언
    string hp;          // 텍스트는 string으로 해야하기 때문에
    string pow;
    string mon;
    string max_hp;

    public TextMeshProUGUI StageName;  // Stage 이름을 작성하기 위한 선언

    public TextMeshProUGUI Health_Cost;  // Health 업그레이드  Cost 텍스트
    public TextMeshProUGUI Power_Cost;
    string hc; // Health_Cost
    string pc; // Power_Cost
    void Update()
    {
        max_hp = Data_Control.data.Max_Player_Health.ToString();
        hp = Data_Control.data.Player_Health.ToString();
        pow = Data_Control.data.Player_Power.ToString();
        mon = Data_Control.data.Money.ToString();
        status_ui.text = "HP: " + hp + " / " + max_hp + "   Power: " + pow + "   Money: " + mon;        // 캐릭터 상태 업데이트

        Scene scene = SceneManager.GetActiveScene(); 
        StageName.text = scene.name;                      // Stage 이름 업데이트

        hc = Data_Control.data.Health_NeedMoney.ToString();     // Health_Cost 업데이트
        Health_Cost.text = "Cost: " + hc;

        pc = Data_Control.data.Power_NeedMoney.ToString();     // Power_Cost 업데이트
        Power_Cost.text = "Cost: " + pc;
    }
}