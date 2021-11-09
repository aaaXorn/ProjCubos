using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolidCristal : MonoBehaviour
{
	[SerializeField] Image CSolidoUI;
	[SerializeField] GameObject Gate;//leva pro próximo nível
	
    void OnTriggerEnter(Collider other)
	{
		//deixa o jogador ir pro próximo nível
		Gate.SetActive(true);
		
		//habilita o sprite e destrói o cristal
		CSolidoUI.enabled = true;
		Destroy(gameObject);
	}
}
