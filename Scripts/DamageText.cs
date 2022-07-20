using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    private float texttime = 0.65f;

    private void Update()
    {
        transform.position += Vector3.up * 0.3f;
        texttime -= Time.deltaTime;
        if (texttime <= 0) {
            Destroy(gameObject);
        }
    }
}