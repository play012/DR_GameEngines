using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class SpaceshipAuthoring : MonoBehaviour
{
    public float value;
}

public class SpaceshipBaker : Baker<SpaceshipAuthoring>
{
    public override void Bake(SpaceshipAuthoring authoring) {
        AddComponent(new Spaceship {
            value = authoring.value
        });
    }
}