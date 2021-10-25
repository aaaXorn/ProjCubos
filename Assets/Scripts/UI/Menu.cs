using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	[SerializeField] SceneTransition ST;
	
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
	
	public void Options()
	{
		//abre as opções
	}
	
	public void Exit()
	{
		Application.Quit();
	}
}
