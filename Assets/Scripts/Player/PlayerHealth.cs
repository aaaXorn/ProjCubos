using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public bool dead = false;
	[SerializeField] bool cooldown;
	[SerializeField] float timer;//timer do cooldown
	[SerializeField] SceneTransition ST;//usado quando o jogador morre
	
	[SerializeField] Rigidbody rigid;
	
	//vida e vida máxima
	public float HP, maxHP;
	
	//sprite de imagem
	[SerializeField] Image FillImg;
	//knockback
	[SerializeField] float damageKB;
	
	[SerializeField] Animator anim;
	
	[Header("Checkpoint")]
	[SerializeField] bool hasCheckpoint;
	public static bool checkpoint;
	[SerializeField] Vector3 CheckpointPos;
	
	void Awake()
	{
		if(hasCheckpoint && checkpoint)
		{
			transform.position = CheckpointPos;
			
			checkpoint = false;
		}
	}
	
	//muda o HP do player
    public void ChangeHP(float health, Vector3 ForceOrigin)
	{
		if(!cooldown)
		{
			//se o player estiver vivo
			if(!dead)
			{
				if(health > 0)
					anim.SetTrigger("Damage");
				
				//soma o HP com health, aumentando ou diminuindo o valor
				HP -= health;
				//distância com direção
				var distWDir = transform.position - ForceOrigin;
				//valor bruto da distância
				var distance = distWDir.magnitude;
				//direção
				var direction = distWDir/distance;
				//vetor de força
				var force = (new Vector3(direction.x, 0.75f, direction.z) * damageKB);
				
				rigid.AddForce(force);
			}
			//limita HP entre 0 e maxHP
			if(HP > maxHP) HP = maxHP;
			else if(HP <= 0)
			{
				HP = 0;
				
				//player morre
				dead = true;
				//reinicia a scene
				ST.Fade(false, SceneManager.GetActiveScene().name);
			}
			
			//preenche a barra de vida
			FillImg.fillAmount = (HP/maxHP);
			
			//cooldown
			cooldown = true;
			timer = 0;
			//corrotina de timer
			StartCoroutine("CooldownTimer");
		}
	}
	
	IEnumerator CooldownTimer()
	{
		//enquanto o timer estiver rodando
		while(timer < 1)
		{
			timer += Time.deltaTime;
			yield return null;
		}
		if(timer >= 1)
		{
			cooldown = false;
			StopCoroutine("CooldownTimer");
		}
	}
}