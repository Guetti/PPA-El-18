using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour
{
    public Transform rodFinal;
    public bool isCatching;
    public GameObject fishGrabbed;

    private void FixedUpdate()
    {
        transform.position = new Vector3(rodFinal.position.x, rodFinal.position.y - 4f, rodFinal.position.z);
        if (isCatching)
        {
            if (transform.position.y > 2f)
            {
                Release();
            }
        }
    }

    public void Catch(GameObject fish)
    {
        isCatching = true;
        fishGrabbed = fish;
        var script = fish.GetComponent<Fish>();
        script.floater.gameObject.SetActive(false);
        script.rb.useGravity = false;
        script.rb.isKinematic = true;
        fish.transform.SetParent(transform);
        fish.transform.localPosition = Vector3.zero;
        fish.transform.localRotation = new Quaternion(180f, 0f, 0f, 0f);
        //StartCoroutine(PullUp());
    }

    private IEnumerator PullUp()
    {
        isCatching = true;
        var time = 0f;
        while (time < 1f)
        {
            transform.localPosition = new Vector3(rodFinal.position.x, rodFinal.position.y - 4f + time * 4f,
                rodFinal.position.z);
            time += Time.deltaTime;
        }

        isCatching = false;
        yield return null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isCatching) return;
        if (other.CompareTag("Mouth"))
        {
            Debug.Log(other.transform.parent.parent.name);
            
            Catch(other.transform.parent.parent.gameObject);
            
        }
    }

    public void Release()
    {
        isCatching = false;
        Destroy(fishGrabbed);
    }
}
