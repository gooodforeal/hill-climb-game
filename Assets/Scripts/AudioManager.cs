using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    void Start()
    {

        if (!PlayerPrefs.HasKey("GameMusic"))
        {
            PlayerPrefs.SetFloat("GameMusic", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("GameMusic", volumeSlider.value);
    }
    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("GameMusic");
        AudioListener.volume = volumeSlider.value;
    }
}