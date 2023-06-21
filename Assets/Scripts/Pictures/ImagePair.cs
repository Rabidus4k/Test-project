using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagePair : MonoBehaviour
{
    [SerializeField]
    private List<Image> _images = new List<Image>();


    public void AddImage(Sprite sprite)
    {
        var imagePrefab = (Resources.Load("Image") as GameObject).GetComponent<Image>();
        var newImage = Instantiate(imagePrefab, transform);
        newImage.sprite = sprite;
        newImage.preserveAspect = true;

        _images.Add(newImage);
    }
}
