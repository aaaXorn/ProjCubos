using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPush : MonoBehaviour
{
	//posição máxima relativa que um objeto pode boiar
	[SerializeField]
	float floatPos;
	
	//força da água
	[SerializeField]
	Vector3 Force;
	
	//rigidbody dos objetos empurrados pela água
	[SerializeField]
	Rigidbody otherRigid;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerStay(Collider other)
	{
		
	}
	
	void WaterForce(Collider obj)
	{
		otherRigid = obj.gameObject.GetComponent<Rigidbody>();
		
		//aplicação da força da água
		if((obj.gameObject.transform.position.y - transform.position.y) < floatPos)
		{
			if(otherRigid != null)
			{
				otherRigid.AddForce(Force);
			}
		}
		else
		{
			if(otherRigid != null)
			{
				//se acima de floatPos, força Y é ignorada
				otherRigid.AddForce(Force.x, 0, Force.z);
			}
		}
	}
}
