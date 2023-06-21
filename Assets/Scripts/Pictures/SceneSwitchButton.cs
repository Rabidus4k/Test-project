using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SceneSwitchButton : MonoBehaviour
{
    [SerializeField]
    private SceneName _sceneToLoad;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnSwitchScene);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnSwitchScene);
    }

    public void OnSwitchScene()
    {
        SceneLoader.Instance.LoadScene(_sceneToLoad);
    }
}
