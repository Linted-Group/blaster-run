using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Sprite audioOn;
    public Sprite audioOff;
    public Button buttonAudio;
    public Slider slider;
    public AudioClip clip;
    public AudioSource audio;

    void Start(){       
       if(PlayerPrefs.GetInt("recordScore")==0){
            slider.value = 1;
       }else{
            slider.value  = PlayerPrefs.GetFloat("MusicValue");
       }
       
    }
    void Update()
    {
        if(slider.value == 0){
            buttonAudio.GetComponent<Image>().sprite = audioOff;
        }
        else{
            AudioListener.volume = slider.value;
            buttonAudio.GetComponent<Image>().sprite = audioOn;
        }
        
        audio.volume = slider.value;
        PlayerPrefs.SetFloat("MusicValue",slider.value);
    }
    public void OnOffAudio(){
        
        if(AudioListener.volume > 0){
            AudioListener.volume = 0;
            slider.value = 0;  
        }
        
        else if(AudioListener.volume == 0){
            AudioListener.volume = 1;
            slider.value = 1;
        }
        
        
    }
    public void PlaySound(){
        audio.PlayOneShot(clip);
    }
}
