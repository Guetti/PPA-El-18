using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public GameObject prefab;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}
