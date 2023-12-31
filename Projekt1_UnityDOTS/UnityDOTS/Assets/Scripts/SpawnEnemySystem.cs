using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Rendering;

[BurstCompile]
public partial struct SpawnEnemySystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<Spaceship>();
        state.RequireForUpdate<Spawnzone>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        Entity spaceshipEntity = SystemAPI.GetSingletonEntity<Spaceship>();
        Entity spawnzoneEntity = SystemAPI.GetSingletonEntity<Spawnzone>();
        var spawnzoneAspect = SystemAPI.GetAspect<SpawnzoneAspect>(spawnzoneEntity);

        int fps = (int)(1f / UnityEngine.Time.unscaledDeltaTime);
        if (fps > 30) {
            Entity newEnemy = state.EntityManager.Instantiate(spawnzoneAspect.enemyPrefab);

            float3 spawnPosition = new float3(UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(-10f, -100f));
            quaternion spawnRotation = quaternion.LookRotationSafe(math.up() + SystemAPI.GetComponent<LocalTransform>(spaceshipEntity).Position, math.forward());
            state.EntityManager.SetComponentData(newEnemy, LocalTransform.FromPositionRotation(spawnPosition, spawnRotation));
            state.EntityManager.AddComponentData(newEnemy, new URPMaterialPropertyBaseColor {Value = new float4(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f))});
        }
    }
}
