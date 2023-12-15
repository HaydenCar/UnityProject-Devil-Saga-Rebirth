using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //Declaring the stats for both enemy and player
    public string characterName; //Use for UI
    public int maxHP; 
    public int currentHP; 
    public int physicalPower; 
    public int magicalPower; 
    public int currentMP;
    public int defense; 
    public int characterlevel;

    public HealthBar healthBar;

    private void Start()
    {
    }
    public bool TakeDamage(int damage){
        //Handling damage and death
        currentHP -= damage;

        if (currentHP <= 0){
            Debug.Log("Battle Over"); //Testing purposes
            return true;
        } else {
            return false;
        }
    }

    public bool TakeGuardDamage(int damage){
        //Handling damage and death
        currentHP -= (damage / 2);

        if (currentHP <= 0){
            Debug.Log("Battle Over"); //Testing purposes
            return true;
        } else {
            return false;
        }
    }

}

