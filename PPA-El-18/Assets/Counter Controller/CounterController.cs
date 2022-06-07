using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterController : MonoBehaviour
{
    public static CounterController Instance;
    [SerializeField] private TextMeshProUGUI counter;
    private int _amount = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void AddPoint()
    {
        _amount++;
        counter.text = _amount.ToString();
    }
}
