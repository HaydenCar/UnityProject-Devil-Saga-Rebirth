using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCam : MonoBehaviour
{
    public Transform player, cameraTrans;
	
	void Update(){
		cameraTrans.LookAt(player);
	}
}