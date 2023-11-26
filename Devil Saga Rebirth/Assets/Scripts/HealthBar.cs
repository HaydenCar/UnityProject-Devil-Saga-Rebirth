using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider hpSlider;

    private void Start()
    {
        hpSlider = GetComponent<Slider>();
    }

    public void SetMaxHP(int currentHP)
    {
        hpSlider.maxValue = currentHP;
        hpSlider.value = currentHP;
    }
    public void SetHP(int currentHP)
    {
        hpSlider.value = currentHP;
    }
}
