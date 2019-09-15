using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxSlider : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector2.left * 1 * Time.deltaTime);
       
    }
}
