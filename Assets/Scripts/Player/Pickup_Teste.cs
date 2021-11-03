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
	
	[SerializeField]
	bool grabClose, grabFar;
	
	//posição do grab/spawn da mochila
    [SerializeField]
	Transform transfPos;
	//objeto agarrado/sendo carregado
	[SerializeField]
	GameObject GrabTarget, MochilaTarget;
	
	//rigidbody do player
	[SerializeField]
	Rigidbody rigid;
	
    // Start is called before the first frame update
    void Start()
    {
		//setta o groundLayer como a layer que tem o nome layerMask
        groundLayer = LayerMask.GetMask(layerMask);
		
		//setta o rigidbody
		rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		//setta o input de grab e mochila
        grabInput = Input.GetButtonDown("Interact");
		
		//debug: desenha o Raycast na tela, Vector3.right em vez de .forward porque a frente ta como X em vez de Z ops
		Debug.DrawRay(transform.position - (rayDownMod * Vector3.up), transform.TransformDirection(Vector3.right) * raycastDist, Color.red);

		//se o jogador está tentando pegar um item
        if (grabInput)
        {
			//checa o tipo de grab usado
			GrabCheck();
        }
    }
	
	void FixedUpdate()
	{
		//enquanto o objeto está sendo agarrado
		if(grabClose)
		{
			//move o objeto
			Grab();
		}
	}
	
	void Grab()
	{
		//move o objeto pra frente do player
		GrabTarget.transform.position = Vector3.MoveTowards(GrabTarget.transform.position, 
															transfPos.position,
															4.5f);
	}
	
	void Mochila()
	{
		//desativa o gameobj
		MochilaTarget.SetActive(false);
		grabFar = true;
	}
	
	void TiraMochila()
	{
		//coloca a posição na frente do player
		MochilaTarget.transform.position = transfPos.position;
		
		//ativa o gameObj
		MochilaTarget.SetActive(true);
		grabFar = false;
	}
	
	//checa qual tipo de grab fazer
	void GrabCheck()
	{
		//solta o objeto agarrado
			if(grabClose)
			{
				grabClose = false;
				
				//habilita a gravidade do objeto
				GrabTarget.GetComponent<Rigidbody>().useGravity = true;
				//deixa a velocidade do objeto igual a do player, impedindo ele de ser catapultado
				GrabTarget.GetComponent<Rigidbody>().velocity = rigid.velocity;
			}
			//pega um objeto se estiver próximo
			else
			{
				//gera um raycast, se acertar um objeto da layer layerMask continua
				if (Physics.Raycast(transform.position - (rayDownMod * Vector3.up), transform.TransformDirection(Vector3.right), out rayHit, raycastDist, groundLayer))
				{
					//checa a distância entre o jogador e o objeto atingido
					hitDist = Vector3.Distance(transform.position, rayHit.point);
					
					//se a distância for menor que 2, agarra
					if (hitDist < 2)
					{
						//setta o objeto agarrado
						GrabTarget = rayHit.collider.gameObject;
						grabClose = true;
						
						//tira a gravidade pra não bugar
						GrabTarget.GetComponent<Rigidbody>().useGravity = false;
						
						//Grab(rayHit.collider.gameObject);
						Debug.Log("perto");
					}
					//se for maior que 2
					else if(hitDist >= 2)
					{
						if(!grabFar)
						{
							//setta o objeto carregado
							MochilaTarget = rayHit.collider.gameObject;
							
							//coloca o obj na mochila
							Mochila();
						}
						//se estiver com algo na mochila, solta
						else
						{
							TiraMochila();
						}
					}
				}
				//se o raio erra
				else
				{
					//se tem algo na mochila
					if(grabFar)
					{
						//solta o objeto na mochila
						TiraMochila();
					}
				}
			}
	}
}
