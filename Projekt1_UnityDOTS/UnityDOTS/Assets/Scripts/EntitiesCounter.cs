using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using TMPro;

public class EntitiesCounter : MonoBehaviour
{
    EntityManager eM;
    EntityQuery eQ;
    int timer;
    TMP_Text entitiesText;

    void Start()
    {
        entitiesText = GetComponent<TMP_Text>();
        eM = World.DefaultGameObjectInjectionWorld.EntityManager;
        eQ = eM.CreateEntityQuery(ComponentType.ReadOnly<Enemy>());
    }

    void Update()
    {
        timer++;
        if (timer > 30) {
            int numEntities = eQ.CalculateEntityCount();
            entitiesText.text = "Entities: " + numEntities.ToString() + "\n\n";
            timer = 0;
        }
    }
}
