using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidTrigger : MonoBehaviour
{
	[SerializeField] SolidCrystal SC;
	
    void OnTriggerEnter(Collider other)
	{
		//quando o player entra
		if(other.gameObject.CompareTag("Player"))
		{
			SC.start = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		//quando o player sai
		if(other.gameObject.CompareTag("Player"))
		{
			SC.start = false;
		}
	}
}
