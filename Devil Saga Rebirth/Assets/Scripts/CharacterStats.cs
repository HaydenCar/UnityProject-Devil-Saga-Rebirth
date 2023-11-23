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
    public int defense; 
    public int characterlevel;


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

}

