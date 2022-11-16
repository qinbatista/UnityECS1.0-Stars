using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SpawnerAuthoring : MonoBehaviour
{
    public GameObject _ballPrefab;
    public GameObject _spawnPoint;
    public static bool isStartSpawning = false;
    public void StartSpawning() { Debug.Log("isStartSpawning=true");isStartSpawning = true; }
}
public class SpawnerBaker : Baker<SpawnerAuthoring>
{
    public override void Bake(SpawnerAuthoring authoring)
    {
        AddComponent(new SpawnerComponent
        {
            _ballEntity = GetEntity(authoring._ballPrefab),
            _random = new Unity.Mathematics.Random((uint)Random.Range(int.MinValue, int.MaxValue)),
            _position = authoring._spawnPoint.transform.position,
        });
    }
}