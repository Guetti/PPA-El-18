using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketController : MonoBehaviour
{
    [Header("Water Options")]
    private Mesh _waterMesh;
    [SerializeField] private GameObject waterObject;
    [SerializeField] private int edges = 360;
    [SerializeField] private float initialAngle = 0f;

    private void Start()
    {
        //_waterMesh = new Mesh();
        //waterObject.GetComponent<MeshFilter>().mesh = _waterMesh;
        //GenerateMesh();
    }

    private void GenerateMesh()
    {
        Vector3[] vertices = new Vector3[edges + 2];
        int[] triangles = new int[edges * 3];
        vertices[0] = Vector3.zero;
        float actualAngle = initialAngle;
        float increment = 360f / edges;
        
        int verticeIndex = 1;
        int triangleIndex = 0;
        
        for (int i = 0; i < edges; i++)
        {
            Vector3 actualVertice = vertices[0] + GetVectorFromAngle(actualAngle) * 0.3f;
            vertices[verticeIndex] = actualVertice;
            if (i != 0)
            {
                triangles[triangleIndex] = 0;
                triangles[triangleIndex + 1] = verticeIndex - 1;
                triangles[triangleIndex + 2] = verticeIndex;

                triangleIndex += 3;
            }

            verticeIndex++;
            actualAngle -= increment;
        }

        _waterMesh.vertices = vertices;
        _waterMesh.triangles = triangles;

    }

    private Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
}
