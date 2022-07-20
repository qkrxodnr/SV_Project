using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // TextMeshPro를 쓰기위해 필요함

public class FloatingText : MonoBehaviour
{
    private static FloatingText _instance = null;

    public TextMeshProUGUI text;
    public static FloatingText Instance
    {
        get
        {
            if (_instance == null)
            {

                _instance = GameObject.FindObjectOfType<FloatingText>();

                if (_instance == null)
                {
                    Debug.LogError("There's no active DamageTextController Object");
                }
            }

            return _instance;
        }
    }

    public Canvas canvas;
    public GameObject dmgTxt;

    public void CreateDamageText(Vector3 hitPoint)
    {
        text.text = Data_Control.data.Player_Power.ToString();
        GameObject damageText = Instantiate(dmgTxt, hitPoint, Quaternion.identity, canvas.transform);
        
    }
}
