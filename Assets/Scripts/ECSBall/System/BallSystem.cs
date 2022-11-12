

using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;

[BurstCompile]
public partial struct BallSystem : ISystem
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
        // JobHandle jobHandle = new BallJob
        // {
        //     deltaTime = SystemAPI.Time.DeltaTime
        // }.ScheduleParallel(state.Dependency);
        // jobHandle.Complete();
    }
}
[BurstCompile]
public partial struct BallJob : IJobEntity
{
    public float deltaTime;
    public void Execute(BallAspect _ballAspect)
    {
        _ballAspect.FlyingAround(deltaTime);
    }
}