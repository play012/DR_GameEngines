using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class SpawnzoneAuthoring : MonoBehaviour
{
    public int spawnRadius;
    public GameObject enemyPrefab;
    public uint randomSeed;
}

public class SpawnzoneBaker : Baker<SpawnzoneAuthoring>
{
    public override void Bake(SpawnzoneAuthoring spawnAuth) {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(new Spawnzone {
            spawnRadius = spawnAuth.spawnRadius,
            enemyPrefab = GetEntity(spawnAuth.enemyPrefab)
        });

        AddComponent(new SpawnzoneRandom {
            randValue = Unity.Mathematics.Random.CreateFromIndex(spawnAuth.randomSeed)
        });
    }
}

public struct Spawnzone : IComponentData
{
    public int spawnRadius;
    public Entity enemyPrefab;
}

public struct SpawnzoneRandom : IComponentData
{
    public Unity.Mathematics.Random randValue;
}