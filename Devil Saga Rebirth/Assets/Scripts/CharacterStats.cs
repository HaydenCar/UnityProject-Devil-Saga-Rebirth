using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //Declaring the stats for both enemy and player
    public string characterName; //Use for UI????
    public int maxHP; // Can change with level
    public int currentHP; // Will be same as max hp at battle start
    public int physicalPower; // Can change with level
    public int magicalPower; // Can change with level
    public int defense; // Can change with level
    public int characterlevel;
    public void TakeDamage(int damage){
        //Handling damage and death
        currentHP -= damage;

        if (currentHP <= 0){
            Debug.Log("YOU ARE DEAD"); //Testing purposes
        } else {
            return;
        }
    }

}

