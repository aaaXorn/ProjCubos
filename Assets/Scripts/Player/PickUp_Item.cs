using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Item : MonoBehaviour
{
	//public Pause pScript;

	public GameObject GrabbedItem;
	public BoxCollider boxC;

	bool grabbing;//se o jogador está segurando um item
	public bool grabInput;//igual ao Input "Interact", pra poder usar no TriggerStay
	float grabTimer, grabCD = 1;//cooldown do grab, para evitar bugs

	void Update()
	{
		grabInput = Input.GetButton("Interact");

		if (grabTimer > 0)
		{
			grabTimer -= Time.deltaTime;
		}

		if (grabbing)
		{
			if (GrabbedItem)
			{
				//gruda o GrabbedItem nesse objeto
				GrabbedItem.transform.position = transform.position;
				GrabbedItem.transform.rotation = transform.rotation;
			}

			if (grabTimer <= 0)
			{
				if (grabInput || GrabbedItem == null)
				{
					grabbing = false;
					grabTimer = grabCD;

					boxC.enabled = false;
					if (GrabbedItem)
					{
						//volta o GrabbedItem ao normal
						GrabbedItem.GetComponent<BoxCollider>().isTrigger = false;
						//para a gravidade em GrabbedItem funcionar normalmente, sem isso ele é catapultado na direção -y
						GrabbedItem.GetComponent<Rigidbody>().isKinematic = false;

						//desgruda o GrabbedItem desse objeto
						GrabbedItem = null;
					}
				}
			}
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (!grabbing && grabTimer <= 0 && other.gameObject.CompareTag("Pickup"))
		{
			if (grabInput)
			{
				grabbing = true;
				grabTimer = grabCD;

				//para impedir o pickup de entrar na parede
				boxC.enabled = true;
				//faz o objeto da colisão ser agarrado pelo jogador
				GrabbedItem = other.gameObject;
				//pro pickup não bugar o movimento do player
				GrabbedItem.GetComponent<BoxCollider>().isTrigger = true;
				//para a gravidade em GrabbedItem funcionar normalmente quando o jogador o solta
				GrabbedItem.GetComponent<Rigidbody>().isKinematic = true;
			}
		}
	}
}