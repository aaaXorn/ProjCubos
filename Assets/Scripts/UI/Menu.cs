using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
	//script de transição
	[SerializeField] SceneTransition ST;
	//mixer de audio
	[SerializeField] AudioMixer audioM;
	
	//objeto com as configurações
	[SerializeField] GameObject OptionsObj;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NewGame()
	{
		ST.Fade(false, "MainMenu");
		//primeiro nível
	}
	
	public void SelectStage()
	{
		//abre a seleção de stages
			//transição
			//nível escolhido
	}
	
	#region options
	
	public void Options()
	{
		//abre/fecha as configurações
		OptionsObj.SetActive(!OptionsObj.activeSelf);
	}
		
		//configura o master volume de acordo com um slider
		public void VolumeSlider(float volume)
		{
			//setta a variável de volume do AudioMixer
			audioM.SetFloat("Volume", Mathf.Log10(volume) * 20);
		}
	
	#endregion
	
	public void Exit()
	{
		//sai do jogo
		Application.Quit();
	}
}
