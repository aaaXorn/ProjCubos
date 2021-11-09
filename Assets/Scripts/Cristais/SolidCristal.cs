using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolidCristal : MonoBehaviour
{
	[SerializeField] Image CSolidoUI;
	[SerializeField] GameObject Gate;//leva pro próximo nível
	
	[SerializeField] GameObject Particles;//partículas criadas quando o cristal é destruído
	
    void OnTriggerEnter(Collider other)
	{
		//deixa o jogador ir pro próximo nível
		Gate.SetActive(true);
		
		//habilita o sprite, cria partículas e destrói o cristal
		CSolidoUI.enabled = true;
		Instantiate(Particles, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
