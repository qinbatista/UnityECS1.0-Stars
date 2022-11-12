
using Unity.Entities;
using Unity.Mathematics;

public partial class SpawnerSystem : SystemBase
{
    protected override void OnUpdate()
    {
        // EntityQuery playerEntityQuery = GetEntityQuery(typeof(BallTagComponent));
        // SpawnerComponent spawnerComponent = SystemAPI.GetSingleton<SpawnerComponent>();
        // EntityCommandBuffer entityCommandBuffer = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(World.Unmanaged);
        // if (playerEntityQuery.CalculateEntityCount() < 2000)
        // {
        //     Entity spawnedEntity = entityCommandBuffer.Instantiate(spawnerComponent._ballEntity);
        //     entityCommandBuffer.SetComponent(spawnedEntity,
        //     new BallComponent
        //     {
        //         _position = new float3(10, 10, 10),
        //         _acceleration = new float3(1, 2, 3),
        //         _direction = new float3(1, 2, 3),
        //         _random = new Unity.Mathematics.Random(1),
        //     });
        // }
    }
}
