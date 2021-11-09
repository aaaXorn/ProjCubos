using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEnd : MonoBehaviour
{
    [SerializeField] SceneTransition ST;
	[SerializeField] string nextScene;
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
			ST.Fade(false, nextScene);
	}
}
