using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4WindTrigger : MonoBehaviour
{
	[SerializeField] GameObject Wind;
	
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.CompareTag("Player"))
		{
			Wind.SetActive(true);
			
			PlayerHealth.checkpoint = true;
			
			Destroy(gameObject);
		}
    }
}
