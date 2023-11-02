using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public partial struct PlayerInputSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach(var (spaceship, transform) in SystemAPI.Query<RefRW<Spaceship>, RefRW<LocalTransform>>())
        {
            if (Input.GetKey(KeyCode.W) && transform.ValueRW.Position.y <= 0.75f) {
                transform.ValueRW = transform.ValueRO.Translate(new float3(0, spaceship.ValueRO.speedVal, 0));
            }

            if (Input.GetKey(KeyCode.S) && transform.ValueRW.Position.y >= -0.35f) {
                transform.ValueRW = transform.ValueRO.Translate(new float3(0, -spaceship.ValueRO.speedVal, 0));
            }

            if (Input.GetKey(KeyCode.A) && transform.ValueRW.Position.x <= 1.0f) {
                transform.ValueRW = transform.ValueRO.Translate(new float3(spaceship.ValueRO.speedVal, 0, 0));
            }

            if (Input.GetKey(KeyCode.D) && transform.ValueRW.Position.x >= -1.0f) {
                transform.ValueRW = transform.ValueRO.Translate(new float3(-spaceship.ValueRO.speedVal, 0, 0));
            }
        }
    }
}
