using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Collections;
using Unity.Transforms;

public class MoveLineRenderer : MonoBehaviour
{
    Entity spaceshipEntity;
    float rocketLength;
    int rocketTimer;

    void Start()
    {
        rocketLength = 0.2f;
        EntityQuery playerTagQuery = World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(typeof(Spaceship));
        NativeArray<Entity> entityNativeArray = playerTagQuery.ToEntityArray(Unity.Collections.Allocator.Temp);
        if (entityNativeArray.Length > 0) {
            spaceshipEntity = entityNativeArray[0];
        } else {
            spaceshipEntity = Entity.Null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rocketTimer++;
        if (rocketTimer > 30) {
            rocketLength = Random.Range(0.1f, 0.25f);
            rocketTimer = 0;
        }

        if (spaceshipEntity != Entity.Null) {
            Vector3 followPosition = World.DefaultGameObjectInjectionWorld.EntityManager.GetComponentData<LocalTransform>(spaceshipEntity).Position;
            this.GetComponent<LineRenderer>().SetPosition(0, followPosition);
            this.GetComponent<LineRenderer>().SetPosition(1, followPosition + new Vector3(0, 0, rocketLength));
        }
    }
}
