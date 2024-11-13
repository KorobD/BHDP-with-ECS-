using Unity.Entities;
using Unity.Mathematics;

public struct Movement : IComponentData {

    public float3 moveDir;
    public float moveSpeed;

}
