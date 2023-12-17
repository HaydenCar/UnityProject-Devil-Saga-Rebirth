using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;


public class TurnBasedSystem : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;

    CharacterStats PlayerCharacter;
    CharacterStats EnemyCharacter;
    ChangeScene endGame;

    public HealthBar playerHP;
    public HealthBar enemyHP;
    public ManaBar playerMP;

    private bool isPlayerTurn = true;

    private int itemCount = 2;
    private int itemHeal = 20;

    public void SetupBattle() {
        //Sets up battle by instantating player and enemy
        GameObject PlayerStats =  Instantiate(Player);
        PlayerCharacter = PlayerStats.GetComponent<CharacterStats>();

        GameObject EnemyStats =  Instantiate(Enemy);
        EnemyCharacter =  EnemyStats.GetComponent<CharacterStats>();
        EnemyStats.transform.position = new Vector3(0.9172727f, 0.5f, 1.95f);
        Quaternion spawnRotation = Quaternion.Euler(0f, 220f, 0f); //for enemy spawn rotation

        
        EnemyStats.transform.rotation = spawnRotation;

        playerHP.SetMaxHP(PlayerCharacter);
        enemyHP.SetMaxHP(EnemyCharacter);

        if (EnemyStats != null)
        {
            Debug.Log("Enemy instantiated successfully");
        }
        else
        {
            Debug.LogError("Enemy instantiation failed");
        }

    }

    private void Start() {
        //Calls setup battle and gets endGame scene
        endGame = GetComponent<ChangeScene>();
        SetupBattle();
    }

    IEnumerator PlayerPhysicalAttack() {
        //Called when player uses physical attack
        if (!isPlayerTurn)
        {
            Debug.Log("Not your Turn");
        }
        else
        {
            bool isDead = EnemyCharacter.TakeDamage(PlayerCharacter.physicalPower);
            enemyHP.SetHP(EnemyCharacter.currentHP);

            isPlayerTurn = false;

            // Wait
            yield return new WaitForSeconds(2.0f);

            if (isDead == true)
            {
                EndBattle();
            }
            else
            {
                StartCoroutine(EnemyTurn());
                Debug.Log("Enemy HP: " + EnemyCharacter.currentHP);
            }
        }
    }


    IEnumerator PlayerMagicAttack() {
        //Called when player uses magic attack
        if (!isPlayerTurn)
        {
            Debug.Log("Not your Turn");
        }
        else
        {
            if(PlayerCharacter.currentMP >= 4){
                PlayerCharacter.currentMP -= 4;
                Debug.Log("Current MP: "+ PlayerCharacter.currentMP);
                bool isDead = EnemyCharacter.TakeDamage(PlayerCharacter.magicalPower);
                enemyHP.SetHP(EnemyCharacter.currentHP);
                playerMP.SetMP(PlayerCharacter.currentMP);

                isPlayerTurn = false;
                
                yield return new WaitForSeconds(2.0f);

                if (isDead == true)
                {
                   // Call end battle function if player is dead
                    EndBattle();
                }
                else
                {
                    // Continue
                    StartCoroutine(EnemyTurn());
                    Debug.Log("Enemy HP: " + EnemyCharacter.currentHP);
                }
            } else Debug.Log("No MP: " + PlayerCharacter.currentMP);
        }
    }

    IEnumerator PlayerGuard() {
        //Called when player uses Guard
        if (!isPlayerTurn)
        {
            Debug.Log("Not your Turn");
        }
        else
        {
                isPlayerTurn = false;
                yield return new WaitForSeconds(2.0f);
                StartCoroutine(EnemyTurnGuard());
                Debug.Log("Enemy HP: " + EnemyCharacter.currentHP);
        }                 
    }


    public void OnAttackButton() {
        //Used to sort combat state and call damage
        Debug.Log("Works ");
        Debug.Log("Enemy HP: " + EnemyCharacter.currentHP);

        if (!isPlayerTurn)
        {
            Debug.Log("It's not the player's turn!");
        }
        else
        {
            StartCoroutine(PlayerPhysicalAttack());
        }
    }

    public void OnMagicButton() {
        //Used to sort combat state and call damage
        Debug.Log("Works ");
        Debug.Log("Enemy HP: " + EnemyCharacter.currentHP);

        if (!isPlayerTurn)
        {
            Debug.Log("It's not the player's turn!");
        }
        else
        {
            StartCoroutine(PlayerMagicAttack());
        }
    }

    public void OnGuardButton() {
        //Used to sort combat state and call damage and add MP
        Debug.Log("Guard Works ");
        Debug.Log("Enemy HP: " + EnemyCharacter.currentHP);

        if (!isPlayerTurn)
        {
            Debug.Log("It's not the player's turn!");
        }
        else
        {
            PlayerCharacter.currentMP += 2;
            playerMP.SetMP(PlayerCharacter.currentMP);
            StartCoroutine(PlayerGuard());
        }
    }

    public void OnItemButton() {
        //Used to sort combat state and add health using item
        Debug.Log("Item Works ");

        if (!isPlayerTurn)
        {
            Debug.Log("It's not the player's turn!");
        }
        else if(itemCount > 0){
            PlayerCharacter.currentHP += itemHeal;
            playerHP.SetHP(PlayerCharacter.currentHP);
            itemCount -= 1;
        }
    }

    IEnumerator EnemyTurn() {
        //Automates the enemies turn
        Debug.Log("Enemy Turn");
        Debug.Log("Player HP: " + PlayerCharacter.currentHP);
    
        yield return new WaitForSeconds(2.0f);

        bool isDead = PlayerCharacter.TakeDamage(EnemyCharacter.physicalPower);
        playerHP.SetHP(PlayerCharacter.currentHP);

        if (isDead == true)
        {
            EndBattle();
        }
        else
        {
            isPlayerTurn = true;
        }
    }

    IEnumerator EnemyTurnGuard() {
        //Automates the enemies turn
        Debug.Log("Enemy Turn");
        Debug.Log("Player HP: " + PlayerCharacter.currentHP);
    
        yield return new WaitForSeconds(2.0f);

        bool isDead = PlayerCharacter.TakeGuardDamage(EnemyCharacter.physicalPower / 2);
        playerHP.SetHP(PlayerCharacter.currentHP);

        if (isDead == true)
        {
            EndBattle();
        }
        else
        {
            isPlayerTurn = true;
        }
    }


    public void EndBattle() {//Ends the battle if win or lose
        if (EnemyCharacter.currentHP <= 0) {
            Debug.Log("You Win");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (PlayerCharacter.currentHP <= 0) {
            Debug.Log("You Lose");
            SceneManager.LoadScene(0);
        }
    }
}