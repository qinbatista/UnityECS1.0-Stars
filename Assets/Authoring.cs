using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Authoring : MonoBehaviour
{
    public static bool isStartSpawning = false;
    public bool useECS = false;
    public Material _material;
    public GameObject _ballPrefab;
    float colorRedAngle = 0.0f;
    float colorGAngle = 0.0f;
    float colorBAngle = 0.0f;
    int quantity = 0;
    GameObject ball;
    public int total = 30000;
    public static Authoring Instance { get; private set; } // static singleton
    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
        isStartSpawning = false;
    }
    public void StartSpawning() { Debug.Log("isStartSpawning=true"); isStartSpawning = true; }
    void Update()
    {
        colorRedAngle += 0.7f * Time.deltaTime;
        colorGAngle += 0.9f * Time.deltaTime; ;
        colorBAngle += 1f * Time.deltaTime; ;
        _material.SetColor("_EmissionColor", new Color(Mathf.Sin(colorRedAngle) + 0.6f, Mathf.Sin(colorGAngle) + 0.8f, Mathf.Sin(colorBAngle) + 1f) * 8);

        if (Authoring.isStartSpawning && !useECS)
        {
            if (quantity < total)
            {
                for (int i = 0; i < total; i++)
                {
                    ball = Instantiate(_ballPrefab, this.transform.position, Quaternion.identity);
                    ball.transform.position = new Vector3(Random.Range(90.69f - 3f, 90.69f + 3f), Random.Range(5.322f - 1f, 5.322f + 1f), Random.Range(84.64999f - 10f, 84.64999f + 10f));
                    quantity++;
                }
            }
        }
    }
}
