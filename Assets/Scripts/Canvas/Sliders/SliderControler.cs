using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderControler : MonoBehaviour
{
    [SerializeField] protected float initValue = 100f;
    [SerializeField] protected Slider slider;

    void Start() {
        SetMaxValue(initValue);    
    }

    public void SetMaxValue(float maxValue)
    {
        slider.maxValue = maxValue;
        DisplayNewValue();
    }

    public void DecreaseValue(float value)
    {
        slider.value -= value;
        DisplayNewValue();
    }

    public void IncreaseValue(float value)
    {
        slider.value += value;
        DisplayNewValue();
    }

    void DisplayNewValue()
    {
        int v = Mathf.FloorToInt(slider.value);
        int m = Mathf.FloorToInt(slider.maxValue);
        GameObject valueDis = transform.Find("Value Displayer").gameObject;
        valueDis.GetComponent<TextMeshProUGUI>().text = $"{v}/{m}";
    }

}