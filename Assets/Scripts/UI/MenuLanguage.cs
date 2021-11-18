using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLanguage : MonoBehaviour
{
	[SerializeField] SaveGame SG;
	
	//texto das 4 opções principais
	[SerializeField] Text txt_NG, txt_LG, txt_Opt, txt_Exit;
	
	//texto das opções de nível
	[SerializeField] Text txt_L1, txt_L2;
	
    public void LoadText()
	{
		print(SG.language);
		
		switch (SG.language)
		{
			case "portugues":
			MainPt();
			LevelsPt();
			break;
			
			default://english
			MainEn();
			LevelsEn();
			break;
		}
	}
	
	#region englishText
	
	void MainEn()
	{
		txt_NG.text = "New Game";
		txt_LG.text = "Load Level";
		txt_Opt.text = "Options";
		txt_Exit.text = "Exit";
	}
	
	void LevelsEn()
	{
		txt_L1.text = "Level 1";
		txt_L2.text = "Level 2";
	}
	
	#endregion
	
	#region portuguesText
	
	void MainPt()
	{
		txt_NG.text = "Novo Jogo";
		txt_LG.text = "Seleção de Níveis";
		txt_Opt.text = "Configurações";
		txt_Exit.text = "Sair";
	}
	
	void LevelsPt()
	{
		txt_L1.text = "Nível 1";
		txt_L2.text = "Nível 2";
	}
	
	#endregion
}
