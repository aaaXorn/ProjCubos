using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlePlayer : MonoBehaviour
{
	[Header("Velocidade")]
	[SerializeField] float walkSpd;//velocidade andando
	[SerializeField] float runSpd;//velocidade correndo
	[SerializeField] float currSpd;//velocidade atual
	
	[Header("Pulo")]
	[SerializeField] float jumpForce;//força do pulo
	[SerializeField] ForceMode jumpFM;//modo da força do pulo
	[SerializeField] int currentJumps;//pulos feitos
	[SerializeField] int maxJumps;//número de pulos máximo
	
	[Header("Inputs")]
	[SerializeField] bool jumping;//input de pulo
	[SerializeField] bool sprintInput;//input de correr
	[SerializeField] float xInput, zInput;//input de movimento
	
	[Header("Outros")]
	//direção que a camera está apontando
	[SerializeField] Transform CamParent;
	[SerializeField] string groundLayerMask;//layer do chão
	[SerializeField] float raycastDist;
	
	Rigidbody rigid;
	RaycastHit rayHit;
	
	Vector3 groundLocation;//localização do chão
	int groundLM;//layer do chão
	[SerializeField] float distFromGround;//distância entre o player e o chão
	[SerializeField] float distToJump;//distância máxima até o chão pro player poder pular
	
	bool grounded;//se o player está no chão
	bool jumpStart;//se o player começou a pular
	
	[SerializeField] PlayerHealth PH;
	
	//setta variáveis
    void Start()
    {
		rigid = GetComponent<Rigidbody>();
		groundLM = LayerMask.GetMask(groundLayerMask);
		
		jumpStart = true;
    }

	//pega inputs e checa se o player está no chão
    void Update()
    {
		//inputs de movimento
		xInput = Input.GetAxis("Horizontal");//movimento horizontal
		zInput = Input.GetAxis("Vertical");//movimento vertical
		jumping = Input.GetButton("Jump");//pulo
		sprintInput = Input.GetButton("Sprint");//se o jogador está correndo
		
		//if(sprintInput) currSpd = runSpd; else currSpd = walkSpd;
		currSpd = sprintInput ? runSpd : walkSpd;
		
		//checa se o jogador está próximo do chão e sua distância do chão
		if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down),
						  out rayHit, raycastDist, groundLM))
		{
			groundLocation = rayHit.point;
			distFromGround = transform.position.y - groundLocation.y;
		}
		//debug: desenha o Raycast na tela
		Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * raycastDist, Color.blue);
    }
	
	//movimentação
	void FixedUpdate()
	{
		if(!PH.dead)//se o jogador não está morto
		{
			//rotaciona o player de acordo com a camera
			transform.rotation = Quaternion.Euler(transform.rotation.x, 
												  CamParent.rotation.eulerAngles.y - 90, 
												  transform.rotation.z);
			
			//move o player
			rigid.MovePosition(transform.position + Time.deltaTime * currSpd
							   * transform.TransformDirection(xInput, 0, zInput));
			
			//se o player está no chão
			grounded = (distFromGround <= distToJump);//true se distFromGround <= distToJump
			
			//se o player pode pular
			if(jumping && jumpStart && (grounded || (maxJumps > currentJumps)))
			{
				//inicia o pulo
				StartCoroutine(ApplyJump());
			}
			//se o player está no chão
			if(grounded)
			{
				currentJumps = 0;//reseta os pulos feitos
			}
		}
	}
	
	//aplica a força do pulo
	void Jump(float jumpF, ForceMode fMode)
	{
		rigid.AddForce(jumpF * rigid.mass * Time.deltaTime * Vector3.up, fMode);
	}
	
	//pulo
	IEnumerator ApplyJump()
	{
		//força do pulo
		Jump(jumpForce, jumpFM);
		
		//pro if do pulo funcionar
		grounded = false;
		jumpStart = false;
		
		//espera até o jogador soltar o botão de pulo
		yield return new WaitUntil(() => !jumping);
		
		currentJumps++;//adiciona um pulo feito
		jumpStart = true;//pro if do pulo funcionar
	}
}
