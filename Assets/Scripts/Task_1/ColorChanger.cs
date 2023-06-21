using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void ChangeColorToRandom()
    {
        var newColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        LeanTween.color(gameObject, newColor, 0.2f);            
    }
}
