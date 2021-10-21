using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamDummy : MonoBehaviour
{
	[SerializeField]
	Transform FollowRotY;

    // Update is called once per frame
    void Update()
    {
		//rotaciona o Y para ser igual ao do CamParent
        transform.rotation = Quaternion.Euler(transform.rotation.x, FollowRotY.rotation.y, transform.rotation.z);
    }
}
