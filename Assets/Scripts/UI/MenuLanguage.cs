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
		switch (SG.language)
		{
			case 0:
			
			break;
			
			case 1:
			
			break;
			
			default:
			print("erro language");
			break;
		}
	}
	
	#region englishText
	
	#endregion
	
	#region portuguesText
	
	#endregion
}
