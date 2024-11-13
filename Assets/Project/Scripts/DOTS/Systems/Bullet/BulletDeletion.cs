using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using PN;
using Unity.Collections;

[BurstCompile]
public partial struct BulletCleanupSystem : ISystem {

    public void OnUpdate(ref SystemState state) {
        
        ScreenBound screenBounds = SystemAPI.GetSingleton<ScreenBound>();

        EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.Temp);

        
        foreach ((RefRO<LocalTransform> localTransform, Entity entity) in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<BulletTag>().WithEntityAccess()) {
            float3 position = localTransform.ValueRO.Position;

            
            if (math.abs(position.x) > screenBounds.bounds.x / 2 || math.abs(position.y) > screenBounds.bounds.y / 2) {
                ecb.DestroyEntity(entity);
            }
        }

        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
}
