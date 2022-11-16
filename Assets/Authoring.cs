using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Authoring : MonoBehaviour
{
    public static bool isStartSpawning = false;
    public Material _material;
    public float colorRedAngle = 0.0f;
    public float colorGAngle = 0.0f;
    public float colorBAngle = 0.0f;
    void Awake()
    {
        isStartSpawning = false;
    }
    public void StartSpawning() { Debug.Log("isStartSpawning=true");isStartSpawning = true; }
    void Update()
    {
        colorRedAngle+=0.7f*Time.deltaTime;
        colorGAngle+=0.9f*Time.deltaTime;;
        colorBAngle+=1f*Time.deltaTime;;
        _material.SetColor("_EmissionColor", new Color(Mathf.Sin(colorRedAngle)+0.2f,Mathf.Sin(colorGAngle)+0.8f,Mathf.Sin(colorBAngle)+0.1f)*8);
    }
}
