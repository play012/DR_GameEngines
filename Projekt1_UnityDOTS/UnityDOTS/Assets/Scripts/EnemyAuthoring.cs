using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class EnemyAuthoring : MonoBehaviour
{
    public float3 goalPosition;
}

public class EnemyBaker : Baker<EnemyAuthoring>
{
    public override void Bake(EnemyAuthoring enemyAuth){
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(new Enemy {
            goalPosition = enemyAuth.goalPosition
        });
    }
}

public struct Enemy : IComponentData
{
    public float3 goalPosition;
}
