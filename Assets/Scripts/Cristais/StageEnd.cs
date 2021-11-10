using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEnd : MonoBehaviour
{
    [SerializeField] SceneTransition ST;
	[SerializeField] SaveGame SG;
	[SerializeField] string nextScene;//próximo nível
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			if(SG.levelsUnlocked < 1)
				SG.levelsUnlocked = 1;//desbloqueia o segundo nível
			
			SG.Save();//salva o jogo
			ST.Fade(false, nextScene);//muda o nível
		}
	}
}
