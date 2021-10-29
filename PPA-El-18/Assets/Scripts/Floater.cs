using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Floater : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField]private float _depthBeforeSumerged = 1f;
    [SerializeField]private float _displacementAmount = 3f;
    [SerializeField]private int _floaterCount = 1;
    [SerializeField]private float _waterDrag = 0.99f;
    [SerializeField]private float _waterAngularDrag = 0.5f;

    private void Awake()
    {
        _rigidbody = GetComponentInParent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var waveHeight = WaveManager.Instance.GetWaveHeight(transform.position.x) + WaveManager.Instance.transform.position.y;
        _rigidbody.AddForceAtPosition(Physics.gravity / _floaterCount, transform.position, ForceMode.Acceleration);
        if (transform.position.y < waveHeight)
        {
            float displacementMultiplier =
                Mathf.Clamp01((waveHeight-transform.position.y) / _depthBeforeSumerged) * _displacementAmount;
            _rigidbody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y)* displacementMultiplier, 0f),transform.position, ForceMode.Acceleration);
            _rigidbody.AddForce(displacementMultiplier * -_rigidbody.velocity * _waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            _rigidbody.AddTorque(displacementMultiplier * -_rigidbody.angularVelocity * _waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);

        }
    }
}
 