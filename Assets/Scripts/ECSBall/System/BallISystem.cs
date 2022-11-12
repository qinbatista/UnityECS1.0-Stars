

using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;

[BurstCompile]
public partial struct BallISystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {

    }
    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
    }
    [BurstCompile]
    public void OnUpdate(ref SystemState state)//work as main thread
    {
        float deltaTime = SystemAPI.Time.DeltaTime;
        JobHandle jobHandle = new BallJob
        {
            _deltaTime = deltaTime,
        }.ScheduleParallel(state.Dependency);
        jobHandle.Complete();
    }
}
[BurstCompile]
public partial struct BallJob : IJobEntity
{
    public float _deltaTime;
    public void Execute(BallAspect _ballAspect)
    {
        _ballAspect.FlyingAround(_deltaTime);
    }
}