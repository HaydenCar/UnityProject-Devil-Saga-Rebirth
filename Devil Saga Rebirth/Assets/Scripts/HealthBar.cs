using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider hpSlider;

    private void Start()
    {
        hpSlider = GetComponent<Slider>();
    }

    public void SetMaxHP(int maxHP)
    {
        hpSlider.maxValue = maxHP;
        hpSlider.value = maxHP;
    }
    public void SetHP(int currentHP)
    {
        hpSlider.value = currentHP;
    }
}
