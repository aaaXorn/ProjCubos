using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlat : MonoBehaviour
{
	//se a queda começou
	bool start;
	
	Material mat;//material do objeto
	Rigidbody rigid;
	Vector3 StartPos;//posição inicial
	
	[SerializeField] float timer, color;//timer até começar a cair, transparência do objeto
	[SerializeField] float shakeForce;//quanto o objeto vibra
	
	[SerializeField] string FallPlatName;//nome do objeto da pasta resources
	
	void Start()
	{
		rigid = GetComponent<Rigidbody>();
		mat = GetComponent<MeshRenderer>().material;
		
		StartPos = transform.position;
	}
	
    void OnCollisionEnter(Collision other)
	{
		//prepara a plataforma para cair
		if(!start && other.gameObject.CompareTag("Player"))
		{
			start = true;
			
			StartCoroutine("FallTimer");
		}
		/*
		//faz a plataforma desaparecer
		if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			if(transform.position.y > other.transform.position.y)	
				StartCoroutine("MeshFade");
		}*/
	}
	
	//vibra a plataforma, fazendo ela cair no fim
	IEnumerator FallTimer()
	{
		//enquanto o timer estiver rodando
		while(timer < 1)
		{
			//coordenadas da vibração
			var posX = Random.Range(0, shakeForce);
			var posY = Random.Range(0, shakeForce);
			var posZ = Random.Range(0, shakeForce);
			
			//muda a posição do objeto, simulando um efeito de vibração
			transform.position = StartPos + new Vector3(posX, posY, posZ);
			
			timer += Time.deltaTime;
			yield return null;
		}
		if(timer >= 1)
		{
			timer = 0;
			
			//faz a plataforma cair
			rigid.isKinematic = false;
			
			StartCoroutine("Disappear");
			
			StopCoroutine("FallTimer");
		}
	}
	/*
	//desaparece
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
			timer = 0;
			
			//Se um Prefab da Instantiate em um Prefab igual a ele, vai ser criada uma
			//cópia da versão dele no momento que o Instantiate ocorreu.
			//Resources.Load corrige esse bug.
			
			//respawna a plataforma
			var FP = Instantiate(Resources.Load(FallPlatName), StartPos, transform.rotation) as GameObject;
			FP.transform.localScale = transform.localScale;
			
			StopCoroutine("MeshFade");
			
			Destroy(gameObject);
		}
	}*/
	
	IEnumerator Disappear()
	{
		gameObject.GetComponent<BoxCollider>().enabled = false;
		
		//bugfix pro jogador não entrar dentro da plataforma enquanto ela cai
		rigid.AddForce(new Vector3(0, -9, 0));
		
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
			timer = 0;
			
			//Se um Prefab da Instantiate em um Prefab igual a ele, vai ser criada uma
			//cópia da versão dele no momento que o Instantiate ocorreu.
			//Resources.Load corrige esse bug.
			
			//respawna a plataforma
			var FP = Instantiate(Resources.Load(FallPlatName), StartPos, transform.rotation) as GameObject;
			FP.transform.localScale = transform.localScale;
			
			StopCoroutine("Disappear");
			
			Destroy(gameObject);
		}
	}
}