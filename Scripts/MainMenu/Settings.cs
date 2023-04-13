using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject settings;
    public Toggle FPSBox;

    void Start()
    {
        if(PlayerPrefs.GetInt("ShowFPS")==1){
            FPSBox.isOn = true;
        }
        else{
            FPSBox.isOn = false;
        }
    }

    void Update()
    {
        if(FPSBox.isOn){
            PlayerPrefs.SetInt("ShowFPS", 1);
        }
        else{
            PlayerPrefs.SetInt("ShowFPS", 0);
        }
    }

    public void CloseSettings(){
        settings.SetActive(false);
    }
    public void OpenSettings(){
        settings.SetActive(true);
    }
}
