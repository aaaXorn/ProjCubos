using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPush : MonoBehaviour
{
	//posição máxima relativa que um objeto pode boiar
	[SerializeField]
	float floatPos;
	
	[Header("Force.y > 9.8 é mais forte que a gravidade padrão")]
	//força da água
	[SerializeField]
	Vector3 Force;
	
	//rigidbody dos objetos empurrados pela água
	[SerializeField]
	Rigidbody otherRigid;
	
	//enquanto um objeto está dentro da água
	void OnTriggerStay(Collider other)
	{
		WaterForce(other);
	}
	
	void WaterForce(Collider obj)
	{
		otherRigid = obj.gameObject.GetComponent<Rigidbody>();
		
		//aplicação da força da água
		//if((obj.gameObject.transform.position.y - transform.position.y) < floatPos)
		//{
			if(otherRigid != null)
			{
				otherRigid.AddForce(Force);
			}
		//}
		//else
		//{
		//	if(otherRigid != null)
		//	{
				//se acima de floatPos, força Y é diminuída
		//		otherRigid.AddForce(Force.x, Force.y/2, Force.z);
		//	}
		//}
	}
}
