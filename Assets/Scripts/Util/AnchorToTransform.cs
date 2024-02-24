using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorToTransform : MonoBehaviour
{
    [SerializeField] private Transform anchor;
    [SerializeField] private Vector3 offset;
    private void LateUpdate()
    {
        transform.position = anchor.position + offset;
    }
}
