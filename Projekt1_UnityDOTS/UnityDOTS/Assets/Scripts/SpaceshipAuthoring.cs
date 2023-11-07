using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class SpaceshipAuthoring : MonoBehaviour
{
    public float speedVal;
    public bool exploding;
}

public class SpaceshipBaker : Baker<SpaceshipAuthoring>
{
    public override void Bake(SpaceshipAuthoring authoring) {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(new Spaceship {
            speedVal = authoring.speedVal,
            exploding = authoring.exploding
        });
    }
}

public struct Spaceship : IComponentData
{
    public float speedVal;
    public bool exploding;
}