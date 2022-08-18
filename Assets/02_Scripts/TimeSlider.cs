using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour
{
    public bool onTimer;
    public Slider slider;
    private float currentTime;
    public float time;
    void Update()
    {
        if (onTimer)
        {
            currentTime += Time.deltaTime;
            slider.value = Mathf.Lerp(slider.minValue, slider.maxValue, currentTime / time);
            if(slider.value >= slider.maxValue)
            {
                slider.value = 0;
                currentTime = 0;
                onTimer = false;
            }
        }
    }
}
