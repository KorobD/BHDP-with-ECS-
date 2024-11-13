using UnityEngine;
using Unity.Entities;

public class DirectoryAuthoring : MonoBehaviour {

    public GameObject bulletPrefab0;
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    public GameObject bulletPrefab3;
    public GameObject bulletPrefab4;
    public GameObject bulletPrefab5;
    public GameObject bulletPrefab6;

    private class Baker : Baker<DirectoryAuthoring> {
        public override void Bake(DirectoryAuthoring authoring) {

            Entity entity = GetEntity(TransformUsageFlags.None);

            AddComponent(entity, new Directory {

                bulletPrefab0 = GetEntity(authoring.bulletPrefab0, TransformUsageFlags.Dynamic),
                bulletPrefab1 = GetEntity(authoring.bulletPrefab1, TransformUsageFlags.Dynamic),
                bulletPrefab2 = GetEntity(authoring.bulletPrefab2, TransformUsageFlags.Dynamic),
                bulletPrefab3 = GetEntity(authoring.bulletPrefab3, TransformUsageFlags.Dynamic),
                bulletPrefab4 = GetEntity(authoring.bulletPrefab4, TransformUsageFlags.Dynamic),
                bulletPrefab5 = GetEntity(authoring.bulletPrefab5, TransformUsageFlags.Dynamic),
                bulletPrefab6 = GetEntity(authoring.bulletPrefab6, TransformUsageFlags.Dynamic)

            });

        }
    }

}
