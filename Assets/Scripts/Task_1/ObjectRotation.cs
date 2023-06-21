using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField]
    private Vector3 _rotationVector;

    private void Update()
    {
        transform.Rotate(_rotationVector);
    }
}
