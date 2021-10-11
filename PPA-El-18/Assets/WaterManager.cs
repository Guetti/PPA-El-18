using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour
{
    private MeshFilter _meshFilter;

    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
    }

    private void Update()
    {
        Vector3[] vertices = _meshFilter.mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = WaveManager.Instance.GetWaveHeight(transform.position.x + vertices[i].x);
        }

        _meshFilter.mesh.vertices = vertices;
        _meshFilter.mesh.RecalculateNormals();
    }
}
