using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidFallObj : MonoBehaviour
{
	Rigidbody rigid;
	
	[SerializeField] float timer, color;
	
	void Start()
	{
		rigid = GetComponent<Rigidbody>();
		rigid.constraints = RigidbodyConstraints.FreezeRotation;
	}
	
    void OnCollisionEnter(Collision other)
	{
		if(!rigid.isKinematic)
		{
			if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
			{
				rigid.constraints = RigidbodyConstraints.FreezePosition | 
									RigidbodyConstraints.FreezeRotation;
				
				StartCoroutine("MeshFade");
			}
			
			if(other.gameObject.CompareTag("Player"))
			{
				
			}
		}
	}
	
	IEnumerator MeshFade()
	{
		//enquanto o timer estiver rodando
		while(timer < 3)
		{
			//timer
			timer += Time.deltaTime;
			color = 1 - (timer / 3);
			//setta a transparência, causando o efeito de fade
			gameObject.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, color);
			yield return null;
		}
		//quando o timer acaba
		if(timer >= 3)
		{
			Destroy(gameObject);
		}
	}
}
