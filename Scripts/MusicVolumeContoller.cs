using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolumeContoller : MonoBehaviour
{
    public AudioSource audio;
    public float value;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        value = PlayerPrefs.GetFloat("MusicValue");
        audio.volume = value;
    }
}
