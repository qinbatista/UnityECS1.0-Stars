

using System.Diagnostics;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

[BurstCompile]
public partial struct SpawnerISystem : ISystem
{
    EntityQuery playerEntityQuery;
    const int quantity = 200000;
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
            if (Authoring.isStartSpawning)
            {
                EntityCommandBuffer entityCommandBuffer = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.World.Unmanaged);
                for (int i = 0; i < quantity; i++)
                {
                    Entity spawnedEntity = entityCommandBuffer.Instantiate(spawnerComponent._ballEntity);
                    entityCommandBuffer.SetComponent(spawnedEntity,
                    new BallComponent
                    {
                        _position = spawnerComponent._position,
                        _acceleration = new float3(spawnerComponent._random.NextFloat(-90, -90), spawnerComponent._random.NextFloat(-90, 90), spawnerComponent._random.NextFloat(-90, 90)),
                        _direction = new float3(spawnerComponent._random.NextFloat(-90, 90f), spawnerComponent._random.NextFloat(-90, 90f), spawnerComponent._random.NextFloat(-90, 90f)),
                    });
                }
            }
        }
    }
}
