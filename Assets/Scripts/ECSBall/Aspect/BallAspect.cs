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
        _transformAspect.Position += _BallComponent.ValueRO._direction * deltaTime;
    }
    public void SetRandomValue(Unity.Mathematics.Random random)
    {

    }
}
