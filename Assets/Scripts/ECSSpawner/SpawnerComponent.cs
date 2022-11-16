
using Unity.Entities;
using Unity.Mathematics;

public struct SpawnerComponent : IComponentData
{
    public Entity _ballEntity;
    public Unity.Mathematics.Random _random;
    public float3 _position;
    public bool _startSpawning;
}
