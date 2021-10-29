using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraController : MonoBehaviour
{
    [SerializeField] private GameObject rodPosition;
    private float speed = 20f;
    
    private void FixedUpdate()
    {
        FollowCamera();
    }

    private void FollowCamera()
    {
        /*
        transform.position = Vector3.Lerp(transform.position, rodPosition.transform.position, Time.deltaTime * speed);
        transform.rotation =
            Quaternion.Lerp(transform.rotation, rodPosition.transform.rotation, Time.deltaTime * speed);
        */
        transform.position = rodPosition.transform.position;
    }
}
