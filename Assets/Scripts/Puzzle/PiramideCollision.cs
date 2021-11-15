using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiramideCollision : MonoBehaviour
{
    void OnCollisionStay(Collision other)
	{
		if(other.gameObject.CompareTag("Buraco"))
		{
			if(!other.gameObject.GetComponent<BuracoActivate>().P_T.grabClose)
			{
				//ativa o buraco
				other.gameObject.GetComponent<BuracoActivate>().Activate();
				
				//destroi o pickup
				Destroy(gameObject);
			}
		}
	}
}
