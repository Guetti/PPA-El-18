using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour
{
    public Transform rodFinal;
    private void FixedUpdate()
    {
        transform.position = new Vector3(rodFinal.position.x, rodFinal.position.y - 4f, rodFinal.position.z);
    }
}
