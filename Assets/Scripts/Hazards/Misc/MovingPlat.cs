using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{
	[Header("Metade do movimento total")]
	//onde o movimento acaba para as duas direções
	[SerializeField] Vector3 GoToA;
	Vector3 GoToB;
	
	[Header("Velocidade por frame, deixe baixo")]
	//velocidade do movimento
	[SerializeField] float speed;
	//se o objeto está indo pro lado A ou lado B
	[SerializeField] bool pattern;
	
	[SerializeField] bool stop;//se é pra plataforma parar
	
    // Start is called before the first frame update
    void Start()
    {
		GoToB = transform.position - GoToA;
		
		GoToA += transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if(!stop)
		{
			if(pattern)
			{
				//move o objeto pro A
				transform.position = Vector3.MoveTowards(transform.position, 
														 GoToA,
														 speed);
				
				var distance = Vector3.Distance(GoToA, transform.position);
				
				//checa a distância
				if(distance < speed)
					//alterna o padrão
					pattern = false;
			}
			else
			{
				//move o objeto pro B
				transform.position = Vector3.MoveTowards(transform.position, 
														 GoToB,
														 speed);
				
				var distance = Vector3.Distance(GoToB, transform.position);
				
				//checa a distância
				if(distance < speed)
					//alterna o padrão
					pattern = true;
			}
		}
    }
}