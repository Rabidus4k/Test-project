using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackButton : MonoBehaviour
{
    public UnityEvent OnBack;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnBack?.Invoke();
        }
    }
}
