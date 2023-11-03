using Unity.Entities;
using Unity.Transforms;

public readonly partial struct SpawnzoneAspect : IAspect
{
    public readonly Entity entity;

    private readonly RefRW<LocalTransform> transformAspect;
    private readonly RefRO<Spawnzone> spawnzoneRef;
    private readonly RefRW<SpawnzoneRandom> spawnzoneRand;

    public Entity enemyPrefab => spawnzoneRef.ValueRO.enemyPrefab;
}
