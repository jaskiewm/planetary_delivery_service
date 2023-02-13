using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource AudioSource;
    public UnityEngine.UI.Text AudioPercentage;

    private float musicVolume = 0.25f;
    private float musicNumber;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f)
        {
            AudioSource.volume = 0f;
        }
        else
        {
            AudioSource.volume = musicVolume;
        }
        musicNumber = (musicVolume * 100);
        musicNumber = (int)musicNumber;
        AudioPercentage.text = musicNumber.ToString() + "%";
    }
    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }
}
