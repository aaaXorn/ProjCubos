using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] float damage;
	
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			//causa damage de dano
			other.gameObject.GetComponent<PlayerHealth>().ChangeHP(damage, transform.position);
		}
	}
}
