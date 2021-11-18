using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEnd : MonoBehaviour
{
    [SerializeField] SceneTransition ST;
	[SerializeField] SaveGame SG;
	[SerializeField] string nextScene;//próximo nível
	[SerializeField] int currLvl;
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			if(SG.levelsUnlocked < currLvl)
				SG.levelsUnlocked = currLvl;//desbloqueia o lvl atual
			
			SG.Save();//salva o jogo
			ST.Fade(false, nextScene);//muda o nível
		}
	}
}
