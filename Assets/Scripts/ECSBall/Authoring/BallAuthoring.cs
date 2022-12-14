using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class BallAuthoring : MonoBehaviour
{
    public float3 _position;
    public float3 _acceleration;
    public float3 _direction;
}
public class BallBaker : Baker<BallAuthoring>
{
    public override void Bake(BallAuthoring authoring)
    {
        AddComponent(new BallComponent
        {
            _position = authoring._position,
            _acceleration = authoring._acceleration,
            _direction = authoring._direction,
        });
        AddComponent(new BallTagComponent
        {

        });
    }
}