using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseLanguage : MonoBehaviour
{
    [SerializeField] SaveGame SG;
	
	//texto das opções do menu
	//[SerializeField] Text txtResume, txtRestart, txtTitle;
	//objetos das imagens das opções do menu
	[SerializeField] GameObject RsuEN, RsuPT, RstEN, RstPT, MMEN, MMPT;
	
	void Start()
	{
		LoadText();
	}
	
	public void LoadText()
	{
		switch (SG.language)
		{
			case "portugues":
			Pt();
			break;
			
			default://english
			En();
			break;
		}
	}
	
	#region englishText
	
	void En()
	{
		/*txtResume.text = "Resume";
		txtRestart.text = "Restart";
		txtTitle.text = "Main Menu";*/
		RsuEN.SetActive(true);
		RstEN.SetActive(true);
		MMEN.SetActive(true);
		RsuPT.SetActive(false);
		RstPT.SetActive(false);
		MMEN.SetActive(false);
	}
	
	#endregion
	
	#region portuguesText
	
	void Pt()
	{
		/*txtResume.text = "Continuar";
		txtRestart.text = "Recomeçar";
		txtTitle.text = "Menu Inicial";*/
		RsuPT.SetActive(true);
		RstPT.SetActive(true);
		MMPT.SetActive(true);
		RsuEN.SetActive(false);
		RstEN.SetActive(false);
		MMEN.SetActive(false);
	}
	
	#endregion
}
