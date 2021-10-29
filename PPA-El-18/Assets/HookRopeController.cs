using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookRopeController : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform pivot;

    private void FixedUpdate()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, pivot.position);
    }
}
