using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseLanguage : MonoBehaviour
{
    [SerializeField] SaveGame SG;
	
	//texto das opções do menu
	[SerializeField] Text txtResume, txtRestart, txtTitle;
	
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
		txtResume.text = "Resume";
		txtRestart.text = "Restart";
		txtTitle.text = "Main Menu";
	}
	
	#endregion
	
	#region portuguesText
	
	void Pt()
	{
		txtResume.text = "Continuar";
		txtRestart.text = "Recomeçar";
		txtTitle.text = "Menu Inicial";
	}
	
	#endregion
}
