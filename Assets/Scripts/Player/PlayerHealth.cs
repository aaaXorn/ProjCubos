using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public bool dead = false;
	[SerializeField] SceneTransition ST;//usado quando o jogador morre
	
	//vida e vida máxima
	public float HP, maxHP;
	
	//sprite de imagem
	[SerializeField] Image FillImg;
	
	//muda o HP do player
    public void ChangeHP(float health)
	{
		//soma o HP com health, aumentando ou diminuindo o valor
		if(!dead) HP -= health;
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
	}
}
