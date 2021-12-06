using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiramideCollision : MonoBehaviour
{
	bool destroy;
	
    void OnCollisionStay(Collision other)
	{
		if(other.gameObject.CompareTag("Buraco"))
		{
			if(!other.gameObject.GetComponent<BuracoActivate>().P_T.grabClose && !other.gameObject.GetComponent<BuracoActivate>().start)
			{
				//ativa o buraco
				other.gameObject.GetComponent<BuracoActivate>().Activate();
				
				Destroy(gameObject);
			}
		}
	}
}
