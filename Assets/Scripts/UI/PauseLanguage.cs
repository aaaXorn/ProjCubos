using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseLanguage : MonoBehaviour
{
    [SerializeField] SaveGame SG;
	
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
