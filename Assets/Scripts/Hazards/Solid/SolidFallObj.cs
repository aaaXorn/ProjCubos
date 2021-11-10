using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidFallObj : MonoBehaviour
{
	Rigidbody rigid;
	Material mat;//material do objeto
	
	//timer e cor (transparência)
	[SerializeField] float timer, color;
	//dano que o objeto da
	[SerializeField] float damage = 2;
	
	void Start()
	{
		rigid = GetComponent<Rigidbody>();
		//impede o objeto de rotacionar e ser empurrado pro X ou Z
		rigid.constraints = RigidbodyConstraints.FreezeRotation | 
							RigidbodyConstraints.FreezePositionX | 
							RigidbodyConstraints.FreezePositionZ;
							
		mat = GetComponent<MeshRenderer>().material;
	}
	
    void OnCollisionEnter(Collision other)
	{
		//se estiver caindo
		if(!rigid.isKinematic)
		{
			//se colidir com o chão
			if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
			{
				//começa a desaparecer
				StartCoroutine("MeshFade");
				//impede o player de tomar dano do objeto enquanto ele fica no chão
				rigid.isKinematic = true;
			}
			
			//se colidir com o player
			if(other.gameObject.CompareTag("Player"))
			{
				//causa damage de dano
				other.gameObject.GetComponent<PlayerHealth>().ChangeHP(damage, transform.position);
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
			mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, color);
			yield return null;
		}
		//quando o timer acaba
		if(timer >= 3)
		{
			Destroy(gameObject);
			
			StopCoroutine("MeshFade");
		}
	}
}
