using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFps : MonoBehaviour
{
    public int avgFrameRate;
    public GameObject FPSBox;
    public Text textFps;

    void Start()
    {
        if(PlayerPrefs.GetInt("ShowFPS")==1){
            FPSBox.SetActive(true);
        }
        
    }

    void Update()
    {
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
        textFps.text = "FPS: " + avgFrameRate.ToString();
    }
}
