using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public enum battleState { START, PLAYERTURN, ENEMYTURN, WIN, LOSE }


public class TurnBasedSystem : MonoBehaviour
{
    public battleState state;
    public GameObject Player;
    public GameObject Enemy;

    CharacterStats PlayerCharacter;
    CharacterStats EnemyCharacter;
    ChangeScene endGame;


    public void StartBattle(){
        // Start the battle
        state = battleState.START;
        SetupBattle();
    }

    public void SetupBattle() {
        GameObject PlayerStats =  Instantiate(Player);
        PlayerCharacter = PlayerStats.GetComponent<CharacterStats>();

        GameObject EnemyStats =  Instantiate(Enemy);
        EnemyCharacter =  EnemyStats.GetComponent<CharacterStats>();
        EnemyStats.transform.position = new Vector3(0.9172727f, 0.5f, 1.95f);

        if (EnemyStats != null)
        {
            Debug.Log("Enemy instantiated successfully");
        }
        else
        {
            Debug.LogError("Enemy instantiation failed");
        }

        state = battleState.PLAYERTURN;
        

    }

    private void Start()
    {
        SetupBattle();
    }

    IEnumerator PlayerPhysicalAttack() {
        //Damage button handles players physical attacks
        if (state != battleState.PLAYERTURN)
        {
            yield break;
        }
        bool isDead  = EnemyCharacter.TakeDamage(PlayerCharacter.physicalPower);

        //wait
        yield return new WaitForSeconds(2.0f);

        if (isDead == true)
        {
            //Call end battle function
            EndBattle();
        }
        else {
            //continue
            state = battleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    public void OnAttackButton() {

        Debug.Log("Works ");
        Debug.Log("Enemy HP: " + EnemyCharacter.currentHP);
        if (state == battleState.PLAYERTURN)
        {
            StartCoroutine(PlayerPhysicalAttack());
        }
        else
        {
            Debug.Log("It's not the player's turn!");
        }

    }

    IEnumerator EnemyTurn() {
        Debug.Log("Enemy Turn");
        Debug.Log("Player HP: " + PlayerCharacter.currentHP);
        //Handles Enemy turn
        bool isDead = PlayerCharacter.TakeDamage(EnemyCharacter.physicalPower);

        //wait
        yield return new WaitForSeconds(5.0f);

        if (isDead == true)
        {
            state = battleState.LOSE;
            //end battle
            EndBattle();
        }
        else
        {
            //continue
            state = battleState.PLAYERTURN;
        }
    }

    public void EndBattle() {//Ends the battle if win or lose
        if (state == battleState.WIN) { // end and return
            endGame.EndScreen();
        }
        else {
            endGame.EndScreen();
        }
    }

}