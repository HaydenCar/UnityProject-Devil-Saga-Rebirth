using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;

    public void OnTriggerEnter(Collider other)
    {
        Vector3 storePosition = transform.position;
        SceneManager.LoadScene("BattleScene");
        Debug.Log("hello");
    }
}
