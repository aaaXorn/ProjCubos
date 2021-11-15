using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuracoWall : MonoBehaviour
{
	[SerializeField] float speed;
	
	[SerializeField] Vector3 MoveTo;
	
	[SerializeField] int buracoSolved, buracoTotal;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
	public void Activate()
	{
		buracoSolved++;
		if(buracoSolved == buracoTotal)
			StartCoroutine("MoveWall");
	}

    IEnumerator MoveWall()
	{
		var distance = Vector3.Distance(MoveTo, transform.position);
		
		//quando a parede chega no alvo
		if(distance <= speed)
		{
			transform.position = MoveTo;
			
			StopCoroutine("MoveWall");
		}
		
		//enquanto a parede não alcançar o alvo
		while(distance > speed)
		{
			//move a parede
			transform.position = Vector3.MoveTowards(transform.position, 
													 MoveTo,
													 speed);
			
			yield return null;
		}
	}
}
