using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

[BurstCompile]
public partial struct ResetEnemySystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float3 positionT = new float3(0, 0, -200f);
        foreach (var transform in SystemAPI.Query<RefRW<LocalTransform>>())
        {
            if (transform.ValueRW.Position.z >= 100f)
            {
                transform.ValueRW = transform.ValueRW.Translate(positionT);
            }
        }
    }
}
