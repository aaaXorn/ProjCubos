using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
	[SerializeField] RawImage FadeImg;//objeto de imagem
	
	[SerializeField] bool fadeIn;//se o fade começou, se da fade in ou fade out
	
	[SerializeField] string nextScene;//próxima cena
	
	[SerializeField] float timer, color;//timer da transição
	
	public static string lastScene;
	
    void Awake()
    {
		//inicia o fade in
        Fade(true, null);
    }
	
	//fIn = true se a tela começa preta, = false se começa transparente
	public void Fade(bool fIn, string nScene)
	{
		//habilita o FadeImg
		if(FadeImg) FadeImg.enabled = true;
		//variáveis do fade
		fadeIn = fIn;
		nextScene = nScene;
		timer = 0;
		//inicia a courotine
		StartCoroutine("CauseFade");
	}
	
	//causa o fade
	IEnumerator CauseFade()
	{
		//enquanto o timer estiver rodando
		while(timer < 1)
		{
			//timer
			timer += Time.unscaledDeltaTime;//dividido pro fade não acontecer instantaneamente
			//if(fadeIn) color = (1-timer); else color = timer;
			color = fadeIn ? (1 - timer) : timer;
			//setta a transparência, causando o efeito de fade
			if(FadeImg) FadeImg.color = new Color(0, 0, 0, color);
			yield return null;
		}
		//quando o timer acaba
		if(timer >= 1)
		{
			//no fade out, inicia a próxima cena
			if(!fadeIn)
			{
				lastScene = SceneManager.GetActiveScene().name;
				
				SceneManager.LoadScene(nextScene);
			}
			else
				//desabilita o FadeImg
				if(FadeImg) FadeImg.enabled = false;
			
			//encerra a coroutine
			StopCoroutine("CauseFade");
		}
	}
}