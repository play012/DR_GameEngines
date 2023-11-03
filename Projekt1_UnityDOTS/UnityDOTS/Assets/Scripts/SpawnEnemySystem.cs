using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Mathematics;

[BurstCompile]
public partial struct SpawnEnemySystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<Spawnzone>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        Entity spawnzoneEntity = SystemAPI.GetSingletonEntity<Spawnzone>();
        var spawnzoneAspect = SystemAPI.GetAspect<SpawnzoneAspect>(spawnzoneEntity);

        int fps = (int)(1f / UnityEngine.Time.unscaledDeltaTime);
        if (fps > 30) {
            Entity newEnemy = state.EntityManager.Instantiate(spawnzoneAspect.enemyPrefab);
            state.EntityManager.SetComponentData(newEnemy, new LocalTransform{Position = new float3(UnityEngine.Random.Range(-100, 100), UnityEngine.Random.Range(-100, 100), UnityEngine.Random.Range(-10, -200))});
        }
    }
}
