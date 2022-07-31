using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_HP : MonoBehaviour
{
    public Slider hpbar;

    void Update()
    {
        hpbar.value = (float)Data_Control.data.Player_Health / (float)Data_Control.data.Max_Player_Health;
    }
}
