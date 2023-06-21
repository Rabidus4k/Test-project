using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOrientation : MonoBehaviour
{
    [SerializeField]
    private ScreenOrientation _orientation;

    private void Start()
    {
        switch (_orientation)
        {
            case ScreenOrientation.Portrait:
                {
                    Screen.autorotateToLandscapeLeft
                    = Screen.autorotateToLandscapeRight
                    = false;
                    
                    Screen.autorotateToPortrait
                    = Screen.autorotateToPortraitUpsideDown
                    = true;
                }
                break;
            case ScreenOrientation.AutoRotation:
                {
                    Screen.autorotateToLandscapeLeft
                    = Screen.autorotateToLandscapeRight
                    = Screen.autorotateToPortrait
                    = Screen.autorotateToPortraitUpsideDown
                    = true;
                }
                break;
        }
    }
}
