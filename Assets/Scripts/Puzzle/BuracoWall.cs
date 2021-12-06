using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuracoWall : MonoBehaviour
{
	[SerializeField] float speed;
	
	[SerializeField] Vector3 MoveTo;
	
	[SerializeField] int buracoSolved, buracoTotal;
	
	[SerializeField] string coroutine;//corrotina ativada
	
	[SerializeField] GameObject[] ChildObjs = new GameObject[0];
	
    // Start is called before the first frame update
    void Start()
    {
        MoveTo += transform.position;
    }
	
	public void Activate()
	{
		buracoSolved++;
		if(buracoSolved >= buracoTotal)
			StartCoroutine(coroutine);
	}

    IEnumerator MoveWall()
	{
		var distance = Vector3.Distance(MoveTo, transform.position);
		
		//enquanto a parede não alcançar o alvo
		while(distance > speed)
		{
			//move a parede
			transform.position = Vector3.MoveTowards(transform.position, 
													 MoveTo,
													 speed);
			
			distance = Vector3.Distance(MoveTo, transform.position);
			
			yield return null;
		}
		
		//quando a parede chega no alvo
		if(distance <= speed)
		{
			transform.position = MoveTo;
			
			StopCoroutine("MoveWall");
		}
	}
	
	IEnumerator SetActive()
	{
		for(int i = 0; i < ChildObjs.Length; i++)
		{
			ChildObjs[i].SetActive(true);
		}
		
		StopCoroutine("SetActive");
		
		yield return null;
	}
	
	IEnumerator Deactivate()
	{
		for(int i = 0; i < ChildObjs.Length; i++)
		{
			ChildObjs[i].SetActive(false);
		}
		
		StopCoroutine("SetActive");
		
		yield return null;
	}
}
