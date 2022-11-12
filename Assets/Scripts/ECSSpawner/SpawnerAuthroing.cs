using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SpawnerAuthoring : MonoBehaviour
{
    public GameObject _ballPrefab;
}
public class SpawnerBaker : Baker<SpawnerAuthoring>
{
    public override void Bake(SpawnerAuthoring authoring)
    {
        AddComponent(new SpawnerComponent
        {
            _ballEntity = GetEntity(authoring._ballPrefab),
        });
    }
}