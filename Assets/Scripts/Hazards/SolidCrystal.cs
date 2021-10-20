using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidCrystal : MonoBehaviour
{
	[SerializeField]
	float timer, fallTimer;//tempo entre a queda dos espinhos
	
	[SerializeField]
	List<GameObject> Spikes = new List<GameObject>();//lista dos objetos de espinho
	[SerializeField]
	GameObject Drop;//próximo drop
	int nextToDrop;//espinho do array que vai cair em seguida

    // Update is called once per frame
    void Update()
    {
		if(Spikes.Count > 0)
		{
			//timer
			timer += Time.deltaTime;
			if(timer >= fallTimer)
			{
				DropSpike();
				
				timer = 0;
			}
		}
    }
	
	//faz um espinho aleatório cair
	void DropSpike()
	{
		//randomiza o próximo drop entre as opções do array
		nextToDrop = Random.Range(0, Spikes.Count);
		Drop = Spikes[nextToDrop];
		//tira o drop da lista, impedindo ele de ser selecionado novamente
		Spikes.RemoveAt(nextToDrop);
		
		//ativa a gravidade do drop
		Drop.GetComponent<Rigidbody>().isKinematic = false;
	}
}
