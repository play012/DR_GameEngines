using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Collections;
using Unity.Transforms;

public class MoveLineRenderer : MonoBehaviour
{
    EntityManager eM;
    Entity spaceshipEntity;
    float rocketLength;
    int rocketTimer;

    void Start()
    {
        rocketLength = 0.2f;
        eM = World.DefaultGameObjectInjectionWorld.EntityManager;
        spaceshipEntity = eM.CreateEntityQuery(typeof(Spaceship)).GetSingletonEntity();
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
            Vector3 followPosition = eM.GetComponentData<LocalTransform>(spaceshipEntity).Position;
            this.GetComponent<LineRenderer>().SetPosition(0, followPosition);
            this.GetComponent<LineRenderer>().SetPosition(1, followPosition + new Vector3(0, 0, rocketLength));
        }
    }
}