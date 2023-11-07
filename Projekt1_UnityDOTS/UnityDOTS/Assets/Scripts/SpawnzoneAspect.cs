using Unity.Entities;
using Unity.Transforms;

public readonly partial struct SpawnzoneAspect : IAspect
{
    public readonly Entity entity;
    private readonly RefRO<Spawnzone> spawnzoneRef;
    public Entity enemyPrefab => spawnzoneRef.ValueRO.enemyEntity;
}
