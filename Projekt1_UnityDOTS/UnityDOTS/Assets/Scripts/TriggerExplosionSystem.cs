using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Burst;
using Unity.Physics;
using Unity.Physics.Systems;

[UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
[UpdateAfter(typeof(PhysicsSystemGroup))]
[BurstCompile]
public partial struct TriggerExplosionSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        SimulationSingleton simSingleton = SystemAPI.GetSingleton<SimulationSingleton>();

        state.Dependency = new TriggerExplosionJob()
        {
            playerLookup = SystemAPI.GetComponentLookup<Spaceship>()
        }
        .Schedule(simSingleton, state.Dependency);

        state.Dependency.Complete();
    }

    [BurstCompile]
    public struct TriggerExplosionJob : ITriggerEventsJob
    {
        public ComponentLookup<Spaceship> playerLookup;

        [BurstCompile]
        public void Execute(TriggerEvent triggerEvent)
        {
            Entity player = Entity.Null;

            if (playerLookup.HasComponent(triggerEvent.EntityA)) player = triggerEvent.EntityA;
            if (playerLookup.HasComponent(triggerEvent.EntityB)) player = triggerEvent.EntityB;
            if (Entity.Null.Equals(player)) return;

            Spaceship spaceshipData = new Spaceship{speedVal = 0.02f, exploding = true};
            playerLookup[player] = spaceshipData;
        }
    }
}
