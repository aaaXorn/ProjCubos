using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuracoActivate : MonoBehaviour
{
	[SerializeField] BuracoWall BW;//script da parede
	
	[SerializeField] GameObject Piramide;//child object de piramide
	
	bool start;//se o movimento começou
	
	[SerializeField] float speed;//velocidade do movimento
	
	public Pickup_Teste P_T;//script de pickup
	
	void Start()
	{
		P_T = GameObject.FindWithTag("Player").GetComponent<Pickup_Teste>();
	}
	
    public void Activate()
	{
		if(!start)
		{
			//ativa o child object de piramide
			Piramide.SetActive(true);
			//começa a corrotina
			StartCoroutine("MovePiramide");
			
			start = true;
		}
	}
	
	IEnumerator MovePiramide()
	{
		var distance = Vector3.Distance(transform.position, Piramide.transform.position);
		
		//enquanto a piramide não alcançar o alvo
		while(distance > speed)
		{
			//move a piramide
			Piramide.transform.position = Vector3.MoveTowards(Piramide.transform.position, 
															  transform.position,
															  speed);
			
			distance = Vector3.Distance(transform.position, Piramide.transform.position);
			
			yield return null;
		}
		
		//quando a piramide chega no alvo
		if(distance <= speed)
		{
			Piramide.transform.position = transform.position;
			
			if(BW)
				BW.Activate();
			
			StopCoroutine("MovePiramide");
		}
	}
}
