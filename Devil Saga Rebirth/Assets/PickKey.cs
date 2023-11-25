using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickKey : MonoBehaviour
{
    public Component doorcollider;
    public GameObject keyGone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E))
        doorcollider.GetComponent<BoxCollider> ().enabled = true;

        if (Input.GetKey(KeyCode.E))
        keyGone.SetActive (false);
    }
}
