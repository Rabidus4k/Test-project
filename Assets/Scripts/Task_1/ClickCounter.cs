using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCounter : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI _clickText;

    private int _currentClicks = 0;

    public void Click()
    {
        _currentClicks++;
        _clickText.SetText(_currentClicks.ToString());
    }
}
