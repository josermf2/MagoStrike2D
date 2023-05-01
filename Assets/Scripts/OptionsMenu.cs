using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject pauseMenuUI;

    void Update(){
        if (gameObject.activeSelf == true){
            pauseMenuUI.SetActive(false);
        }
    }


    public void SetVolume(float volume){
        audioMixer.SetFloat("Volume", volume);
    }



}
