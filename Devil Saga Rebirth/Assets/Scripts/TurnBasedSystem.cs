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

    public void StartBattle(){
        // Start the battle
        state = battleState.START;
    }

    public void SetupBattle() {
        GameObject PlayerStats =  Instantiate(Player);
        PlayerCharacter = PlayerStats.GetComponent<CharacterStats>();

        GameObject EnemyStats =  Instantiate(Enemy);
        EnemyCharacter =  EnemyStats.GetComponent<CharacterStats>();

        state = battleState.PLAYERTURN;
        PlayerTurn();
    }

    public void PlayerTurn() {
        

    }

    IEnumerator PlayerPhysicalAttack() {
        //Damage button handles players physical attacks
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
        if (state == battleState.PLAYERTURN) {
            StartCoroutine(PlayerPhysicalAttack());
        }

    }

    IEnumerator EnemyTurn() {
        //Handles Enemy turn
        bool isDead = PlayerCharacter.TakeDamage(EnemyCharacter.physicalPower);

        //wait
        yield return new WaitForSeconds(2.0f);

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
            PlayerTurn();
        }
    }

    public void EndBattle() {//Ends the battle if win or lose
        if (state == battleState.WIN) { // end and return
            return;
        }
        else {
            return;
        }
    }

}

