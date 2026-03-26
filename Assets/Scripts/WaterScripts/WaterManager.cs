using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class WaterManager : MonoBehaviour
{
    public static WaterManager Instance;
    public float waveSpeed = 0.5f;     
    public float waveFrequency = 1f;
    public float waveAmplitude = 0.0001f;
    public float baseWaterLevel = 0f;
    public float GetWaterHeight(Vector3 position)
    {
        float wave = Mathf.Sin(Time.time * waveSpeed * waveFrequency) * waveAmplitude;
        return baseWaterLevel + wave;
    }

    void Awake()
    {
        Instance = this;
    }
}

