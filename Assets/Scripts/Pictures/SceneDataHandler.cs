using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDataHandler : MonoBehaviour
{
    public Sprite SpriteToPreview; 
    public static SceneDataHandler Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
