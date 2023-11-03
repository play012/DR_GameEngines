using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    int timer;
    TMP_Text fpsText;
    
    void Start()
    {
        fpsText = GetComponent<TMP_Text>();
    }
    
    void Update()
    {
        timer++;
        if (timer > 30) {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            fpsText.text = "\nFPS: " + fps.ToString();
            timer = 0;
        }
    }
}
