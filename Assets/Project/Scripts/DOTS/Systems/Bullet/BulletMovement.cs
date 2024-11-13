using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[BurstCompile]
partial struct BulletMovement : ISystem
{

    public void OnUpdate(ref SystemState state) {

        float deltaTime = SystemAPI.Time.DeltaTime;

        foreach ((RefRW<LocalTransform> localTransform, RefRO<Movement> movement) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<Movement>>().WithAll<BulletTag>()) {

            localTransform.ValueRW.Position += movement.ValueRO.moveDir * movement.ValueRO.moveSpeed * deltaTime;
            float angle = math.degrees(math.atan2(movement.ValueRO.moveDir.y, movement.ValueRO.moveDir.x));
            localTransform.ValueRW.Rotation = quaternion.Euler(0, 0, math.radians(angle + 90));


        }

    }

}
