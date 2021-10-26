using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	//vida e vida máxima
	public float HP, maxHP;
	
	//sprite de imagem
	[SerializeField] Image FillImg;
	
    public void ChangeHP(int health)
	{
		HP += health;
		if(HP > maxHP) HP = maxHP;
		else if(HP < 0) HP = 0;
		
		FillImg.fillAmount = (HP/maxHP);
	}
	
	void Update()
	{
		FillImg.fillAmount = (HP/maxHP);
	}
}
