using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Teste : MonoBehaviour
{
	//input de grab
    [SerializeField]
    bool grabInput;

	//o que o raycast atingiu
    RaycastHit rayHit;
    
	//alcance do raycast, onde o raycast acertou e o quão pra baixo o raycast é gerado
    [SerializeField]
    float raycastDist, hitDist, rayDownMod;

	//layer que o pickup deve afetar
    [SerializeField]
    string layerMask;//nome da layer
    int groundLayer;//id da layer

    
    // Start is called before the first frame update
    void Start()
    {
		//setta o groundLayer como a layer que tem o nome layerMask
        groundLayer = LayerMask.GetMask(layerMask);
    }

    // Update is called once per frame
    void Update()
    {
		//setta o input de grab
        grabInput = Input.GetButton("Interact");
        Debug.Log("grab " + grabInput);

		//debug: desenha o Raycast na tela, Vector3.right em vez de .forward porque a frente ta como X em vez de Z ops
		Debug.DrawRay(transform.position - (rayDownMod * Vector3.up), transform.TransformDirection(Vector3.right) * raycastDist, Color.red);

		//se o jogador está tentando pegar um item
        if (grabInput)
        {
			//gera um raycast, se acertar um objeto da layer layerMask continua
            if (Physics.Raycast(transform.position - (rayDownMod * Vector3.up), transform.TransformDirection(Vector3.right), out rayHit, raycastDist, groundLayer))
            {
				//checa a distância entre o jogador e o objeto atingido
                hitDist = Vector3.Distance(transform.position, rayHit.point);
				
				//se a distância for menor que 2
                if (hitDist < 2)
                {
					Debug.Log("perto");
                }
				//se for maior que 2
                else
                {
					Debug.Log("longe");
                }            
            }
        }
    }
}
