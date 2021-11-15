using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.CompareTag("Parede"))
		{
			//ativa a parede
			other.gameObject.GetComponent<ParedeEsfera>().Activate();
		}
	}
}
