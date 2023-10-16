using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    int timer;
    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer > 30) {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            GetComponent<TMP_Text>().text = "Entities: 0\nFPS: " + fps.ToString();
            timer = 0;
        }
    }
}
