using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save_Gameobject : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
