using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.CompareTag("Player"))
		{
			PlayerHealth.checkpoint = true;
			
			Destroy(gameObject);
		}
    }
}
