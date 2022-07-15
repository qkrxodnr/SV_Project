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
}
