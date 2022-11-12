using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public struct BallComponent : IComponentData
{
    public float3 _position;
    public float3 _acceleration;
    public float3 _direction;
}
