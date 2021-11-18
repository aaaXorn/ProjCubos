using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetanguloFix : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {	
        StartCoroutine("DelayKinematic");
    }
	
	IEnumerator DelayKinematic()
	{
		yield return new WaitForSeconds(0.1f);//espera 0.1 sec para o pickup sair de paredes
		
		//deixa ele Kinematic
		GetComponent<Rigidbody>().isKinematic = true;
		
		StopCoroutine("DelayKinematic");
	}
}
