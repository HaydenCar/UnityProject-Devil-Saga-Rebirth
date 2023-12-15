using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider hpSlider;

    public void SetMaxHP(CharacterStats character)
    {
        hpSlider.maxValue = character.maxHP;
        hpSlider.value = character.currentHP;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }
}
