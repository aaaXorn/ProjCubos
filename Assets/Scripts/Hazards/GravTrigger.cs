using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravTrigger : MonoBehaviour
{
    [SerializeField] GravSwitch GS;
	[SerializeField] Vector3 gravityVector;
	
    void OnTriggerEnter(Collider other)
	{
		//quando o player entra
		if(other.gameObject.CompareTag("Player"))
		{
			GS.change = true;
			GS.gravDir = gravityVector;
		}
	}
}
