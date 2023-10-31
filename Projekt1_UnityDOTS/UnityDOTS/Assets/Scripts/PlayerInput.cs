using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] Transform spaceshipT;
    [SerializeField] LineRenderer spaceshipLR;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && spaceshipT.position.y <= 0.75f)
        {
            spaceshipT.position += new Vector3(0, 0.005f, 0);
        }

        if (Input.GetKey(KeyCode.S) && spaceshipT.position.y >= -0.35f)
        {
            spaceshipT.position -= new Vector3(0, 0.005f, 0);
        }

        if (Input.GetKey(KeyCode.A) && spaceshipT.position.x <= 1.0f)
        {
            spaceshipT.position += new Vector3(0.005f, 0, 0);
        }

        if (Input.GetKey(KeyCode.D) && spaceshipT.position.x >= -1.0f)
        {
            spaceshipT.position -= new Vector3(0.005f, 0, 0);
        }

        spaceshipLR.SetPosition(0, spaceshipT.position);
        spaceshipLR.SetPosition(1, spaceshipT.position + new Vector3(0, 0, 0.2f));
    }
}
