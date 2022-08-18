using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image clickImage;
    [SerializeField] TimeSlider[] sliders;
    void Start()
    {
        clickImage.gameObject.SetActive(false);
    }
    public void FillSlider(GameObject cookware, float time)
    {
        for(int i = 0; i < sliders.Length; i++)
        {
            if (sliders[i].gameObject.name == $"{cookware.name} Slider")
            {
                sliders[i].slider.maxValue = time;
                sliders[i].time = time;
                sliders[i].onTimer = true;
            }
        }
    }
    public void ShowClickImage()
    {
        StopCoroutine("ShowImage");
        StartCoroutine("ShowImage");
    }
    IEnumerator ShowImage()
    {
        clickImage.gameObject.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.LeftControl));
        clickImage.gameObject.SetActive(false);
    }
}
