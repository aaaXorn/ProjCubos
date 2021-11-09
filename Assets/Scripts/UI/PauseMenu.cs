using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] SaveGame SG;
	[SerializeField] int currentLevel;
	
	//imagens da UI
	[SerializeField] Image CSolidoUI;
	
	public bool paused = false;//se o jogo está pausado
	[SerializeField] GameObject PauseObj;//tela de menu do pause;
	
	[SerializeField] SceneTransition ST;//script de transição de cena
	[SerializeField] PlayerHealth PH;
	
	[SerializeField]
	float unpausedTimeScale = 1;//passagem do tempo fora do pause
	
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;//tira o cursor
		
		Time.timeScale = unpausedTimeScale;
		
		if(currentLevel > 1)
		{
			CSolidoUI.enabled = true;
		}
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pause") && !PH.dead)
		{
			PauseInput();
		}
    }
	
	//pausa/despausa o jogo
	void PauseInput()
	{
		paused = !paused;//define se pausa ou despausa
		PauseObj.SetActive(!PauseObj.activeSelf);//abre/fecha o menu
		
		if(paused)
		{
			//para o tempo
			Time.timeScale = 0;
			Cursor.visible = true;//faz o cursor aparecer
		}
		else
		{
			//volta o tempo ao normal
			Time.timeScale = unpausedTimeScale;
			Cursor.visible = false;//faz o cursor desaparecer
		}
	}
	
	//botões
	#region buttons
	
	//volta pro jogo, efetivamente igual a apertar "Pause" de novo
	public void Resume()
	{
		paused = false;
		PauseObj.SetActive(false);
		Cursor.visible = false;
		Time.timeScale = unpausedTimeScale;
	}
	
	public void Restart()
	{
		SG.Save();
		
		//reinicia a scene atual
		ST.Fade(false, SceneManager.GetActiveScene().name);
	}
	
	public void Title()
	{
		SG.Save();
		
		//vai pro main menu
		ST.Fade(false, "MainMenu");
	}
	
	#endregion
}
