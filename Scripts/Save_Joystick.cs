using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save_Joystick : MonoBehaviour
{
    public Player_Script _player;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (_player.Player_Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
