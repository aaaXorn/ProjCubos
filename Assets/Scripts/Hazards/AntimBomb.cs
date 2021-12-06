using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntimBomb : MonoBehaviour
{
	//timer da explosão
	[SerializeField]
	float timer, bombTimer;
	//raio e força da explosão
	[SerializeField]
	float expRadius, expForce;
	
	//efeito especial
	[SerializeField]
	GameObject SpEffect;
	
	//array de alvos no alcance da explosão
	[SerializeField]
	Collider[] expColliders;
	//rigidbody dos alvos da explosão
	[SerializeField]
	Rigidbody otherRigid;
	
	[SerializeField] AudioSource AS_Exp;//sound effect de explosão
	
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			StartCoroutine("Timer");
		}
	}
	
	void Explosion()
	{
		if(SpEffect != null)
		{
			//efeito de explosão
			Instantiate (SpEffect, transform.position, transform.rotation);
		}
		
		//checa os colliders no alcance da explosão
		expColliders = Physics.OverlapSphere(transform.position, expRadius);
		
		foreach(Collider nearObj in expColliders)
		{
			otherRigid = nearObj.GetComponent<Rigidbody>();
			if(otherRigid != null)
			{
				//física da explosão
				otherRigid.AddExplosionForce(expForce, transform.position, expRadius);
			}
			
			if(nearObj.gameObject.CompareTag("Player"))
			{
				nearObj.gameObject.GetComponent<PlayerHealth>().ChangeHP(2, transform.position);
			}
		}
		
		Destroy(gameObject);
	}
	
	IEnumerator Timer()
	{
		AS_Exp.Play();
		
		//enquanto o timer estiver rodando
		while(timer < bombTimer)
		{
			timer += Time.deltaTime;
			yield return null;
		}
		
		Explosion();
		
		StopCoroutine("Timer");
	}
}
