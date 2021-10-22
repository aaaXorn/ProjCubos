using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//não utilizado
public class CamDummy : MonoBehaviour
{
	[SerializeField]
	Transform FollowRotY;

    // Update is called once per frame
    void Update()
    {
		//transform.position = FollowRotY.position;
		//rotaciona o Y para ser igual ao do CamParent
        transform.rotation = Quaternion.Euler(transform.rotation.x, FollowRotY.rotation.eulerAngles.y, transform.rotation.z);
    }
}
