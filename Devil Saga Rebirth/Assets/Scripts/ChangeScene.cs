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
        Debug.Log("Changed Scene");
        Debug.Log("Last scene name is " + lastSceneName);
    }
}
