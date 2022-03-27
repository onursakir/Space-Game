using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOnOffManager : MonoBehaviour
{
    [SerializeField] Button soundOn;
    [SerializeField] Button soundOff;

    public void SoundOn()
    {
        AudioListener.volume = 0;
        soundOff.gameObject.SetActive(true);    
        soundOn.gameObject.SetActive(false); 
    }
    public void SoundOff()
    {
        AudioListener.volume = 1;
        soundOn.gameObject.SetActive(true);  
        soundOff.gameObject.SetActive(false);      
    }
}
