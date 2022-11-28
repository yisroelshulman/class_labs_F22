using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Volume : MonoBehaviour
{
    public AudioMixer mixer;
    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetLevel()
    {
        float sliderValue = GameObject.FindGameObjectWithTag("VolumeSlider").GetComponent<Slider>().value;
        AudioListener.volume = (sliderValue * 100) - 80;
        SceneManager.LoadScene("MainMenu");
    }
}
