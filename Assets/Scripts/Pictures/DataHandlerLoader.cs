using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataHandlerLoader : MonoBehaviour
{
    [SerializeField]
    private Image _imageToChange;

    private void Start()
    {
        _imageToChange.sprite = SceneDataHandler.Instance.SpriteToPreview;
    }
}
