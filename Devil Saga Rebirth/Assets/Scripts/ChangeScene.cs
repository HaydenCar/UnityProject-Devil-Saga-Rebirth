using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;
    public string lastSceneName;

    public void OnTriggerEnter(Collider other)
    {
        //Gaets the last scene the player was in and saves the name and positon before swapping scene
        lastSceneName = SceneManager.GetActiveScene().name;
        Vector3 storePosition = transform.position;
        SceneManager.LoadScene(sceneName);
        //TurnBasedSystem TBS;
        //TBS.SetupBattle();
        Debug.Log("Changed Scene");
        Debug.Log("Last scene name is " + lastSceneName);
    }

    public void EndScreen() {

        SceneManager.LoadScene(0);

    }

    public void ReturnToLast() {

        SceneManager.LoadScene(lastSceneName);
        //transform.position = storePosition;

    }
}
