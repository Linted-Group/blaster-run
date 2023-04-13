using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlasterSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    public float timePlaying;
    
    void Start() {
       play();
    }       
    void Update()
    {
        if (!audioSource.isPlaying)
        {
           play();
        }
    }
    void play(){
        audioSource.PlayOneShot(RandomClip());
    }
    AudioClip RandomClip(){
        return audioClipArray[Random.Range(0, audioClipArray.Length)];
    }
}
