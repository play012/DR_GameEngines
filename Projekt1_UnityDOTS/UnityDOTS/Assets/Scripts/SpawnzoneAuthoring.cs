using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class SpawnzoneAuthoring : MonoBehaviour
{
    public GameObject enemyGO;
}

public class SpawnzoneBaker : Baker<SpawnzoneAuthoring>
{
    public override void Bake(SpawnzoneAuthoring spawnAuth) {
        var transform = GetComponent<Transform>();
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new Spawnzone {
            enemyEntity = GetEntity(spawnAuth.enemyGO, TransformUsageFlags.Dynamic),
            Position = transform.position,
            Rotation = transform.rotation
        });
    }
}

public struct Spawnzone : IComponentData
{
    public Entity enemyEntity { get; set; }
    public float3 Position { get; set; }
    public quaternion Rotation { get; set; }
}