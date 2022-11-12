using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public readonly partial struct BallAspect : IAspect
{
    public readonly TransformAspect _transformAspect;
    readonly RefRW<BallComponent> _BallComponent;
    readonly RefRW<BallTagComponent> _TagComponent;
    public void FlyingAround(float deltaTime)
    {
        // Debug.Log("_transformAspect.Position="+_transformAspect.Position);
        if (_transformAspect.Position.x == 0 && _transformAspect.Position.y == 0 && _transformAspect.Position.z == 0)
        {
            _transformAspect.Position = new float3(_BallComponent.ValueRO._position.x, _BallComponent.ValueRO._position.y, _BallComponent.ValueRO._position.z);
        }
        else
        {
            _transformAspect.Position += _BallComponent.ValueRO._direction * deltaTime;
        }

    }
    public void SetRandomValue(Unity.Mathematics.Random random)
    {

    }
}
