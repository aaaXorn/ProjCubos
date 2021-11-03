using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntimBomb : MonoBehaviour
{
	//se a explosão pode começar/já começou
	[SerializeField]
	bool start, exploding;
	
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
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(start)
		{
			//timer
			timer += Time.deltaTime;
			
			if(timer >= bombTimer && !exploding)
			{
				Explosion();
				exploding = true;
			}
		}
    }
	
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			start = true;
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
				//damage
			}
		}
		
		Destroy(gameObject);
	}
}
