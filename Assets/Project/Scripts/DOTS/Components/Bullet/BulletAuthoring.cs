using UnityEngine;
using Unity.Mathematics;
using Unity.Entities;

public class BulletAuthoring : MonoBehaviour {

    public float3 moveDir;
    public float moveSpeed;


    private class Baker : Baker<BulletAuthoring> {

        public override void Bake(BulletAuthoring authoring) {
            

            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new BulletTag());
            AddComponent(entity, new Movement {
            
                moveDir = authoring.moveDir,
                moveSpeed = authoring.moveSpeed,

            });

        }

    }

}
