
using Unity.Entities;

public struct SpawnerComponent : IComponentData
{
    public Entity _ballEntity;
    public Unity.Mathematics.Random _random;
}
