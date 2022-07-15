using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Player_Script player;

    public void OnClickHealth()
    {
        if (Data_Control.data.Money >= 100)
        {
            Data_Control.data.Money -= 100;
            player.Player_Health += 10;
        }
    }

    public void OnClickPower()
    {
        if (Data_Control.data.Money >= 100)
        {
            Data_Control.data.Money -= 100;
            Data_Control.data.Player_Power += 10;
        }
    }

    public void OnClickGun()
    {
        if (Data_Control.data.Money >= 2000)
        {
            Data_Control.data.Money -= 2000;

        }
    }
}
