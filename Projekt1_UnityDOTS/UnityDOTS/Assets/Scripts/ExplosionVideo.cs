using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Collections;
using Unity.Transforms;

public class ExplosionVideo : MonoBehaviour
{
    EntityManager eM;
    Entity spaceshipEntity;

    void Start()
    {
        eM = World.DefaultGameObjectInjectionWorld.EntityManager;
        spaceshipEntity = eM.CreateEntityQuery(typeof(Spaceship)).GetSingletonEntity();
    }

    // Update is called once per frame
    void Update()
    {
        if (spaceshipEntity != Entity.Null) {
            Vector3 followPosition = eM.GetComponentData<LocalTransform>(spaceshipEntity).Position;
            transform.position = followPosition;
        }
    }
}
