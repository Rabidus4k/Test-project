using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneHandleButton : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnTransferData);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnTransferData);
    }

    private void OnTransferData()
    {
        SceneDataHandler.Instance.SpriteToPreview = _image.sprite;
    }
}
