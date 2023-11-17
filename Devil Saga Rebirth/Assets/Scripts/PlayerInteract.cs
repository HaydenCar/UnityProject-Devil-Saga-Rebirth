using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private void Update(){
        if (Input.GetKeyDown(KeyCode.E)) {
            float interactRange = 5f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position,interactRange);
            foreach (Collider collider in colliderArray) {
                if   (collider.TryGetComponent(out NPCInteractable npcinteractable)) {
                    npcinteractable.Interact();
                }

            }
        }
    }


}
