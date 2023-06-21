using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSpawner : MonoBehaviour
{
    [SerializeField]
    private RectTransform _root;
    [SerializeField]
    private int _colomnCount = 2;
    [SerializeField]
    private int _maxImagesToShow = 66;
    [SerializeField]
    private Canvas _canvas;

    private int _currentColomn = 0;

    private List<ImagePair> pairs = new List<ImagePair>();
    private const string IMAGE_URL = "http://data.ikppbb.com/test-task-unity-data/pics/";

    private int _imageCount = 1;
    private const int MAX_IMAGE_HEIGHT = 512; 

    private ImagePair _lastImagePair;

    private void Start()
    {
        AddImagePair();
        InitStartImages();
    }

    private float offsetRows = 0;
    private int scrolledImages = 0;
    private int heightCount = 0;

    public void OnScroll(Vector2 vec)
    {
        offsetRows =(int)((1 - vec.y) * _root.sizeDelta.y) / MAX_IMAGE_HEIGHT;
        if (offsetRows < 0)
            return;

        if (offsetRows > scrolledImages)
        {
            scrolledImages++;
            for (int i = 0; i < _colomnCount; i++)
            {
                SpawnNewImage();
            }
        }
    }

    private void InitStartImages()
    {
        heightCount = Mathf.CeilToInt(_canvas.GetComponent<RectTransform>().sizeDelta.y / (float)MAX_IMAGE_HEIGHT) + 1;
        _root.sizeDelta = new Vector2(_root.sizeDelta.x, MAX_IMAGE_HEIGHT * Mathf.CeilToInt(_maxImagesToShow / 2.0f));

        for (int i = 0; i < heightCount * 2; i++)
        {
            SpawnNewImage();
        }
    }

    private void AddImagePair()
    {
        var pairPrefab = (Resources.Load("ImagePair") as GameObject).GetComponent<ImagePair>();
        var newPair = Instantiate(pairPrefab, _root);
        LayoutRebuilder.ForceRebuildLayoutImmediate(_root);
        _lastImagePair = newPair;
        pairs.Add(_lastImagePair);
    }

    [ContextMenu("LoadImage")]
    public void SpawnNewImage()
    {
        if (_imageCount > _maxImagesToShow)
        {
            return;
        }

        ImageLoader.Instance.LoadAndSetImageFromURL($"{IMAGE_URL}{_imageCount}.jpg",
            (Sprite s) => 
            {
                if (_currentColomn == _colomnCount)
                {
                    _currentColomn = 0;
                    AddImagePair();
                }

                _lastImagePair.AddImage(s);
                _currentColomn++;
       
            }
            );

        _imageCount++;
    }

}
