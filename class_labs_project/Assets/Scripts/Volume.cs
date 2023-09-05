using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    private AudioSource mAudio;
    private float sliderValue;
    private bool first;
    private Vector2 soundPos = new Vector2(0.0f, 0.0f);
    private GameObject slide;

    // Start is called before the first frame update
    void Start()
    {
       if (mAudio == null)
        {
            mAudio = GetComponent<AudioSource>();
        }
        first = true;
        slide = GameObject.FindGameObjectWithTag("VolumeSlider");
        slide.GetComponent<Slider>().value = AudioListener.volume;
    }
    
    public void SetVolume()
    {
        sliderValue = slide.GetComponent<Slider>().value;
        AudioListener.volume = (sliderValue);
        if (first)
        {
            first = false;
            return;
        }
        AudioSource.PlayClipAtPoint(mAudio.clip, soundPos);
    }
}
