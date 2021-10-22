using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public bool paused = false;
	
	[SerializeField]
	float unpausedTimeScale = 1;//passagem do tempo fora do pause
	
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;//tira o cursor
		
		Time.timeScale = unpausedTimeScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	//pausa/despausa o jogo
	void PauseInput()
	{
		paused = !paused;
		Cursor.visible = !Cursor.visible;
		//pausemenu obj
		
		if(paused)
		{
			//para o tempo
			Time.timeScale = 0;
		}
		else
		{
			//volta o tempo ao normal
			Time.timeScale = unpausedTimeScale;
		}
	}
}
