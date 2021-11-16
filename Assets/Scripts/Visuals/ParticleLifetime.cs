using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLifetime : MonoBehaviour
{
	float timer;
	
    void Update()
    {
        timer += Time.deltaTime;
		if(timer >= 1.2f)
			Destroy(gameObject);
    }
}
