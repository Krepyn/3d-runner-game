using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMSlider : MonoBehaviour
{

    public GameObject gSlider;
    public GameObject volumeText;
    public int volume;

    private Slider slider;
    private float audioVolume;

    private void Start() {
        slider = gSlider.GetComponent<Slider>();

        audioVolume = PlayerPrefs.GetFloat("Volume", -1);
        if(audioVolume != -1){
            volume = (int)(1000 * audioVolume);

            volumeText.GetComponent<Text>().text = volume + "";
            slider.value = (float)volume;
        }
    }

    public void OnVolumeChanged() {
        volume = (int)slider.value;
        volumeText.GetComponent<Text>().text = volume + "";

        if(volume != 0)
            audioVolume = volume / 1000f;
        else
            audioVolume = 0f;

        if(GameObject.FindGameObjectsWithTag("bgm").Length > 0)
            GameObject.FindGameObjectWithTag("bgm").GetComponent<AudioSource>().volume = audioVolume;

        PlayerPrefs.SetFloat("Volume", audioVolume);
        PlayerPrefs.Save();
    }


}
