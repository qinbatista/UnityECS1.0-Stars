

using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

[BurstCompile]
public partial struct SpawnerISystem : ISystem
{
    EntityQuery playerEntityQuery;
    const int quantity = 800000;
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
        playerEntityQuery = state.GetEntityQuery(typeof(BallTagComponent));
        if (playerEntityQuery.CalculateEntityCount() != quantity)
        {
            SpawnerComponent spawnerComponent = SystemAPI.GetSingleton<SpawnerComponent>();
            EntityCommandBuffer entityCommandBuffer = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.World.Unmanaged);
            for (int i = 0; i < quantity; i++)
            {
                Entity spawnedEntity = entityCommandBuffer.Instantiate(spawnerComponent._ballEntity);
                entityCommandBuffer.SetComponent(spawnedEntity,
                new BallComponent
                {
                    _position = new float3(spawnerComponent._random.NextFloat(-150,150), spawnerComponent._random.NextFloat(-150,150), spawnerComponent._random.NextFloat(-150,150)),
                    _acceleration = new float3(1, 2, 3),
                    _direction = new float3(spawnerComponent._random.NextFloat(0,15f), spawnerComponent._random.NextFloat(0,15f), spawnerComponent._random.NextFloat(0,15f)),
                });
            }
        }
    }
}
