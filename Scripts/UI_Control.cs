using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Control : MonoBehaviour
{
    public void OnClickStartGame()   // 메인화면에서 Game Start를 클릭했을때
    {
        Debug.Log("게임 시작");
        SceneManager.LoadScene("Home");
    }

    public void OnClickHeal()       // Home 화면에서 Heal 버튼 클릭시 체력회복
    {
        Data_Control.data.Player_Health = Data_Control.data.Max_Player_Health;
    }

    public void OnClickDungeon_1()    // Dungeon 1 선택시
    {
        SceneManager.LoadScene("1 - 1");
    }
    public void OnClickDungeon_2()    // Dungeon 2 선택시
    {
        SceneManager.LoadScene("2 - 1");
    }
    public void OnClickDungeon_3()    // Dungeon 3 선택시
    {
        SceneManager.LoadScene("3 - 1");
    }
    public void OnClickDungeon_4()    // Dungeon 4 선택시
    {
        SceneManager.LoadScene("4 - 1");
    }
    public void OnClickDungeon_5()    // Dungeon 5 선택시
    {
        SceneManager.LoadScene("5 - 1");
    }
    public void OnClickBoss()    // Boss 선택시
    {
        SceneManager.LoadScene("Boss");
    }
}
