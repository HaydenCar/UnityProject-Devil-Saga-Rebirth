using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class TurnBasedSystem : MonoBehaviour
{
    public Character playerCharacter;
    public Character enemyCharacter;
    private bool playerTurn = true;

    public void StartBattle(){
        // Start the battle probably call it from random number
    }

    public void Update(){ // will loop until either player or enemy dies
        if (playerTurn == true){
            Debug.Log("Players Turn");
            // Handling player actions
            

            // Switch to the enemy's turn when player is done
            playerTurn = false;
        } else{
            Debug.Log("Enemy Turn");
            // Handle enemy attacks
            

            // Switch back to the player's turn
            playerTurn = true;
             
        }
    }
}

