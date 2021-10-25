using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
	//script de transição
	[SerializeField] SceneTransition ST;
	//mixer de audio
	[SerializeField] AudioMixer audioM;
	
	//objeto com as configurações
	[SerializeField] GameObject OptionsObj;
	
	//dropdown com as opções de resolução
	[SerializeField] Dropdown resDropdown;
	//array com as resoluções
	Resolution[] resolutions;
	
    void Start()
    {
		//coloca as resoluções no array
        resolutions = Screen.resolutions;
		//limpa as opções do dropdown
		resDropdown.ClearOptions();
		
		//resolução escolhida
		int currRes = 0;
		
		//lista de strings de resolução
		List<string> resOptions = new List<string>();
		//cria as opções da lista
		for(int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + "x" + resolutions[i].height;
			resOptions.Add(option);
			
			//se a resolução i for igual a resolução da tela, currRes = i
			if(resolutions[i].width == Screen.currentResolution.width &&
			   resolutions[i].height == Screen.currentResolution.height)
			{
				currRes = i;
			}
		}
		
		//bota as opções da lista no dropdown
		resDropdown.AddOptions(resOptions);
		//faz currRes ser a opção inicial do dropdown
		resDropdown.value = currRes;
		//da refresh no valor do dropdown
		resDropdown.RefreshShownValue();
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
			
			Debug.Log("Volume: " + Mathf.Log10(volume) * 20);
		}
	
		//define a qualidade
		public void SetQuality(int quality)
		{
			//muda a qualidade pro valor selecionado
			//0 very low, 1 low, 2 medium, 3 high, 4 very high, 5 ultra
			QualitySettings.SetQualityLevel(quality);
			
			Debug.Log("Quality: " + quality);
		}
		
		//deixa o jogo em fullscreen/windowed
		public void SetFullscren(bool fscreen)
		{
			Screen.fullScreen = fscreen;
			
			Debug.Log("Fullscreen: " + fscreen);
		}
		
		//define a resolução do jogo
		public void SetResolution(int resIndex)
		{
			//resolução escolhida
			Resolution res = resolutions[resIndex];
			//setta a resolução
			Screen.SetResolution(res.width, res.height, Screen.fullScreen);
			
			Debug.Log("Resolution: " + res.width + "x" + res.height);
		}
	
	#endregion
	
	public void Exit()
	{
		//sai do jogo
		Application.Quit();
	}
}
