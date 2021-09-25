using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
//
{
    public static WaveManager Instance;
    [SerializeField] private float _amplitude = 1f;
    [SerializeField] private float _lenght = 2f;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _offset = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        _offset += Time.deltaTime * _speed;
    }

    public float GetWaveHeight(float x)
    {
        return _amplitude * Mathf.Sin(x / _lenght + _offset);
    }

    
}