using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // TextMeshPro를 쓰기위해 필요함
using UnityEngine.SceneManagement;

public class Text_Manager_Script : MonoBehaviour
{
    public TextMeshProUGUI status_ui;  // 캐릭터 상태를 작성하기 위한 선언
    public TextMeshProUGUI StageName;  // Stage 이름을 작성하기 위한 선언
    public Player_Script _player;      // 플레이어의 공격력 체력을 가져오기 위해서

    string hp;          // 텍스트는 string으로 해야하기 때문에
    string pow;

    void Update()
    {
        hp = _player.Player_Health.ToString();
        pow = _player.Player_Power.ToString();
        status_ui.text = "HP: " + hp + "    Power: " + pow; ;         // 캐릭터 상태 업데이트

        Scene scene = SceneManager.GetActiveScene(); 
        StageName.text = "Stage: " + scene.name;                      // Stage 이름 업데이트
    }
}