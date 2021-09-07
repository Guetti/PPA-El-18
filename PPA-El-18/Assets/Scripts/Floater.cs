using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Floater : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float depthBeforeSumerged = 1f;
    private float displacementAmount = 3f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (transform.position.y < 0f)
        {
            float displacementMultiplier =
                Mathf.Clamp01(-transform.position.y / depthBeforeSumerged) * displacementAmount;
            _rigidbody.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y)* displacementMultiplier, 0f), ForceMode.Acceleration);
        }
    }
}
