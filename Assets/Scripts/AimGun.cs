using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AimGun : MonoBehaviour
{
    [SerializeField] private RaycastAim raycastAim;

    private RotationConstraint _rotationConstraint;
    private AimConstraint _aimConstraint;

    private void Start()
    {
        _rotationConstraint = GetComponent<RotationConstraint>();
        _aimConstraint = GetComponent<AimConstraint>();
    }

    private void Update()
    {
        if (raycastAim.IsColliding)
        {
            _aimConstraint.constraintActive = true;
            _rotationConstraint.constraintActive = false;
        }
        else
        {
            _aimConstraint.constraintActive = false;
            _rotationConstraint.constraintActive = true;
        }
    }
}
