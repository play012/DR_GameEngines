using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Unity.Entities;
using Unity.Collections;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Mathematics;

public class SpaceshipManager : MonoBehaviour
{
    [SerializeField] LineRenderer spaceshipLR;
    [SerializeField] GameObject explosionGO;
    [SerializeField] VideoPlayer explosionVP;

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

    void Update()
    {
        rocketTimer++;
        if (rocketTimer > 30) {
            rocketLength = UnityEngine.Random.Range(0.1f, 0.25f);
            rocketTimer = 0;
        }

        if (spaceshipEntity != Entity.Null) {
            Vector3 followPosition = eM.GetComponentData<LocalTransform>(spaceshipEntity).Position;
            Quaternion followRotation = eM.GetComponentData<LocalTransform>(spaceshipEntity).Rotation;

            if (!eM.GetComponentData<Spaceship>(spaceshipEntity).exploding) {
                spaceshipLR.SetPosition(0, followPosition);
                spaceshipLR.SetPosition(1, followPosition + new Vector3(0, 0, rocketLength));
                explosionGO.transform.position = followPosition;
            } else {
                explosionGO.SetActive(true);
                spaceshipLR.enabled = false;
                eM.SetComponentData<LocalTransform>(spaceshipEntity, LocalTransform.FromPositionRotationScale(followPosition, followRotation, 0.001f));
                explosionVP.loopPointReached += EndReached;
                explosionVP.Play();
            }
        }
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        explosionGO.SetActive(false);
        spaceshipLR.enabled = true;
        eM.SetComponentData<LocalTransform>(spaceshipEntity, LocalTransform.FromPositionRotationScale(new float3(0, 0, 0), quaternion.Euler(-90, 0, 0), 1f));
        eM.SetComponentData<Spaceship>(spaceshipEntity, new Spaceship {speedVal = 0.02f, exploding = false} );
    }
}
