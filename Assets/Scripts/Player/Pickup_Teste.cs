using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup_Teste : MonoBehaviour
{
	//input de grab e de troca da forma da mochila
    bool grabInput, mochilaInput;
	
	//o que o raycast atingiu
    RaycastHit rayHit;
	//alcance do raycast, onde o raycast acertou e o quão pra baixo o raycast é gerado
    [SerializeField]
    float raycastDist, hitDist, rayDownMod;

	//layer que o pickup deve afetar
    [SerializeField]
    string layerMask;//nome da layer
    int groundLayer;//id da layer
	
	[Header("Grab")]
	public bool grabClose;
	[SerializeField] bool grabFar, grabRetangulo;
	
	//posição do grab/spawn da mochila
    [SerializeField]
	Transform transfPos;
	//objeto agarrado/sendo carregado
	[SerializeField]
	GameObject GrabTarget, MochilaTarget;
	
	//rigidbody do player
	Rigidbody rigid;
	
	[Header("Formas")]
	//forma atual
	[SerializeField] int currForm;
	//imagem das formas
	[SerializeField] Image FormaImg;
	//sprites das formas
	[SerializeField] Sprite sprSquare, sprCircle, sprRectangle, sprTriangle;
	//game objects das formas
	[SerializeField] GameObject Square, Circle, Rectangle, Triangle;
	
	[Header("Outros")]
	[SerializeField] AudioSource AS_grab;
	[SerializeField] Animator anim;
	
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
		mochilaInput = Input.GetButtonDown("Mochila");
		
		//debug: desenha o Raycast na tela, Vector3.right em vez de .forward porque a frente ta como X em vez de Z ops
		Debug.DrawRay(transform.position - (rayDownMod * Vector3.up), transform.TransformDirection(Vector3.right) * raycastDist, Color.red);

		//animação
		anim.SetBool("Grab", grabClose);

		//se o jogador está tentando pegar um item
        if(grabInput)
        {
			//checa o tipo de grab usado
			GrabCheck();
        }
		
		if(mochilaInput)
		{
			ChangeMochila();
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
		/*GrabTarget.transform.position = Vector3.MoveTowards(GrabTarget.transform.position, 
															transfPos.position,
															4.5f);*/
		//distância com direção
		var distWDir = transfPos.position - GrabTarget.transform.position;
		
		//move o objeto, aplicando colisões apropriadamente
		GrabTarget.GetComponent<Rigidbody>().velocity = distWDir * 5f;
	}
	
	void Mochila()
	{
		anim.SetTrigger("Pickup");
		
		//destrói o GrabTarget
		Destroy(GrabTarget);
		
		//deixa o jogador criar um novo objeto
		grabFar = true;
	}
	
	void TiraMochila()
	{
		AS_grab.Play();
		
		//animação
		anim.SetTrigger("TiraMochila");
		
		//coloca a posição na frente do player
		GrabTarget = Instantiate(MochilaTarget, transfPos.position, transform.rotation);
		
		//impede o player de spawnar mais objetos do que tem na mochila
		grabFar = false;
		
		GrabCloseObj();
	}
	
	//checa qual tipo de grab fazer
	void GrabCheck()
	{
		//solta o objeto agarrado
		if(grabClose)
		{
			anim.SetTrigger("Release");
			
			grabClose = false;
			
			//habilita a gravidade do objeto
			GrabTarget.GetComponent<Rigidbody>().useGravity = true;
			//deixa a velocidade do objeto igual a do player, impedindo ele de ser catapultado
			GrabTarget.GetComponent<Rigidbody>().velocity = rigid.velocity;
			//retorna a massa do objeto ao normal
			GrabTarget.GetComponent<Rigidbody>().mass = 1;
			
			//se soltar um retangulo
			if(grabRetangulo)
			{
				GrabTarget.GetComponent<Rigidbody>().isKinematic = true;
				grabRetangulo = false;
			}
		}
		//pega um objeto se estiver próximo
		else
		{
			//gera um raycast, se acertar um objeto da layer layerMask continua
			if (Physics.Raycast(transform.position - (rayDownMod * Vector3.up), transform.TransformDirection(Vector3.right), out rayHit, raycastDist))
			{
				if(rayHit.transform.gameObject.CompareTag("Pickup") || rayHit.transform.gameObject.CompareTag("Retangulo"))
				{
					//checa a distância entre o jogador e o objeto atingido
					hitDist = Vector3.Distance(transform.position, rayHit.point);
					
					//setta o objeto agarrado
					GrabTarget = rayHit.collider.gameObject;
					
					//se a distância for menor que 2, agarra
					if (hitDist < 2)
					{
						anim.SetTrigger("Pickup");
						
						GrabCloseObj();
					}
					//se for maior que 2
					else if(hitDist >= 2)
					{
						if(!grabFar)
						{
							//sound effect de entrar na mochila
							AS_grab.Play();
							
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
				//bugfix pra ser possivel tirar um item da mochila se o raio bate na parede
				else
				{
					if(grabFar)
						TiraMochila();
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
	
	//muda o objeto dentro da mochila
	void ChangeMochila()
	{
		currForm++;
		if(currForm >= 4) currForm = 0;
		
		switch(currForm)
		{
			case 0:
				FormaImg.sprite = sprSquare;
				MochilaTarget = Square;
				break;
			
			case 1:
				FormaImg.sprite = sprCircle;
				MochilaTarget = Circle;
				break;
			
			case 2:
				FormaImg.sprite = sprRectangle;
				MochilaTarget = Rectangle;
				break;
				
			case 3:
				FormaImg.sprite = sprTriangle;
				MochilaTarget = Triangle;
				break;
			
			default:
				currForm = 0;
				print("Error: currForm = " + currForm);
				break;
		}
	}
	
	//agarra o objeto escolhido
	void GrabCloseObj()
	{
		//agarra o objeto
		grabClose = true;
		
		//tira a gravidade pra não bugar
		GrabTarget.GetComponent<Rigidbody>().useGravity = false;
		
		//diminui a massa do objeto para não bugar
		GrabTarget.GetComponent<Rigidbody>().mass = 0.01f;
		
		//se for um retangulo
		if(GrabTarget.CompareTag("Retangulo"))
		{
			GrabTarget.GetComponent<Rigidbody>().isKinematic = false;
			grabRetangulo = true;
		}
		
		Debug.Log("perto");
	}
}
