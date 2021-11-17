using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravSwitch : MonoBehaviour
{
	public bool change;
	
	[Header("Grav Padrão: Y = -9.81")]
	public Vector3 gravDir;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(change)
		{
			//muda a gravidade
			Physics.gravity = gravDir;
			
			change = false;
		}
    }
}
