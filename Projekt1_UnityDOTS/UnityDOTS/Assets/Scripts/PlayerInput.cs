using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] Transform spaceshipT;
    [SerializeField] LineRenderer spaceshipLR;
    float speed, rocketLength;
    int rocketTimer;

    void Start()
    {
        speed = 0.005f;
        rocketLength = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        rocketTimer++;
        if (rocketTimer > 40) {
            rocketLength = Random.Range(0.1f, 0.25f);
            rocketTimer = 0;
        }

        if (Input.GetKey(KeyCode.W) && spaceshipT.position.y <= 0.75f)
        {
            spaceshipT.position += new Vector3(0, speed, 0);
        }

        if (Input.GetKey(KeyCode.S) && spaceshipT.position.y >= -0.35f)
        {
            spaceshipT.position -= new Vector3(0, speed, 0);
        }

        if (Input.GetKey(KeyCode.A) && spaceshipT.position.x <= 1.0f)
        {
            spaceshipT.position += new Vector3(speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.D) && spaceshipT.position.x >= -1.0f)
        {
            spaceshipT.position -= new Vector3(speed, 0, 0);
        }

        spaceshipLR.SetPosition(0, spaceshipT.position);
        spaceshipLR.SetPosition(1, spaceshipT.position + new Vector3(0, 0, rocketLength));
    }
}
