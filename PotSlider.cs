using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotSlider : MonoBehaviour
{
    public Slider slider;

    public void SetMaxVolume(int potVolume)
    {
        slider.maxValue = potVolume;
        slider.value = potVolume;
    }

    public void SetVolume(int potVolume)
    {
        slider.value = potVolume;
    }
}
