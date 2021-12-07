using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLanguage : MonoBehaviour
{
	[SerializeField] SaveGame SG;
	
	//texto das 4 opções principais
	//[SerializeField] Text txt_NG, txt_LG, txt_Opt, txt_Exit;
	//objeto com sprite de texto das 4 opções principais
	[SerializeField] GameObject NGEN, NGPT, SSEN, SSPT, OPEN, OPPT, EXEN, EXPT, CREN, CRPT;
	
	//texto das opções de nível
	//[SerializeField] Text txt_L1, txt_L2;
	//objeto com sprite de texto das opções de nível
	[SerializeField] GameObject L1EN, L1PT, L2EN, L2PT, L3EN, L3PT, L4EN, L4PT, L5EN, L5PT;
	
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
		/*txt_NG.text = "New Game";
		txt_LG.text = "Load Level";
		txt_Opt.text = "Options";
		txt_Exit.text = "Exit";*/
		NGEN.SetActive(true);
		SSEN.SetActive(true);
		OPEN.SetActive(true);
		EXEN.SetActive(true);
		CREN.SetActive(true);
		NGPT.SetActive(false);
		SSPT.SetActive(false);
		OPPT.SetActive(false);
		EXPT.SetActive(false);
		CRPT.SetActive(false);
	}
	
	void LevelsEn()
	{
		/*txt_L1.text = "Level 1";
		txt_L2.text = "Level 2";*/
		L1EN.SetActive(true);
		L2EN.SetActive(true);
		L3EN.SetActive(true);
		L4EN.SetActive(true);
		L5EN.SetActive(true);
		L1PT.SetActive(false);
		L2PT.SetActive(false);
		L3PT.SetActive(false);
		L4PT.SetActive(false);
		L5PT.SetActive(false);
	}
	
	#endregion
	
	#region portuguesText
	
	void MainPt()
	{
		/*txt_NG.text = "Novo Jogo";
		txt_LG.text = "Seleção de Níveis";
		txt_Opt.text = "Configurações";
		txt_Exit.text = "Sair";*/
		NGPT.SetActive(true);
		SSPT.SetActive(true);
		OPPT.SetActive(true);
		EXPT.SetActive(true);
		CRPT.SetActive(true);
		NGEN.SetActive(false);
		SSEN.SetActive(false);
		OPEN.SetActive(false);
		EXEN.SetActive(false);
		CREN.SetActive(false);
	}
	
	void LevelsPt()
	{
		/*txt_L1.text = "Nível 1";
		txt_L2.text = "Nível 2";*/
		L1EN.SetActive(false);
		L2EN.SetActive(false);
		L3EN.SetActive(false);
		L4EN.SetActive(false);
		L5EN.SetActive(false);
		L1PT.SetActive(true);
		L2PT.SetActive(true);
		L3PT.SetActive(true);
		L4PT.SetActive(true);
		L5PT.SetActive(true);
	}
	
	#endregion
}
