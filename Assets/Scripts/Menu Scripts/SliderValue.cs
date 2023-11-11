using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderValue : MonoBehaviour
{
    public Slider sliderUI;
    private TMP_Text textSliderValue;

    void Start (){
    textSliderValue = GetComponent<TMP_Text>();
    ShowSliderValue();
    }

    public void ShowSliderValue () {
    string sliderMessage = "" + sliderUI.value;
    textSliderValue.text = sliderMessage;
    }
}
