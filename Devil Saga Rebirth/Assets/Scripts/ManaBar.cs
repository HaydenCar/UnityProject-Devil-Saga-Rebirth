using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider mpSlider;

    public void SetMaxMP(CharacterStats character)
    {
        mpSlider.maxValue = character.currentMP;
        mpSlider.value = character.currentMP;
    }
    public void SetMP(int mp)
    {
        mpSlider.value = mp;
    }
}
