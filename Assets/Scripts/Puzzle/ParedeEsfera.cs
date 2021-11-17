using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedeEsfera : MonoBehaviour
{
	[SerializeField] GameObject ParedeDust;
	
	public void Activate()
	{
		//instantiate das partículas
		Instantiate(ParedeDust, transform.position, transform.rotation);
		
		Destroy(gameObject);
	}
}
