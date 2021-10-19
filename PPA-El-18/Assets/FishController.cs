using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    private float _rotationSpeed = 1f;

    void FixedUpdate()
    {
        //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y + _rotationSpeed,
        //    transform.rotation.z, transform.rotation.w);
        //Quaternion rotation = new Quaternion(transform.rotation.x, transform.rotation.y + _rotationSpeed,
        //transform.rotation.z, transform.rotation.w);
        Vector3 m_EulerAngleVelocity = new Vector3(0f, 100f, 0f); 
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        GetComponent<Rigidbody>().MoveRotation(deltaRotation);
    }
}