using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrdPCam : MonoBehaviour
{
	//sensividade da camera, quanto maior for, mais ela se move por input
    [SerializeField]
    private Vector2 cameraSensitivity = Vector2.one; 
	
    [SerializeField]
    private float zoomSensitivity = 10.0f;//sensividade do zoom
	
    [SerializeField]
    private float yRotClamp = 85.0f;//rotação Y máxima
 
    [SerializeField]
    private Vector2 zoomClamp = new Vector2(0.5f, 25.0f);//zooom mínimo/máximo
 
    [SerializeField]
    private float zoomDamp = 0.05f;//timer do damp do zoom, suaviza o zoom
 
    [SerializeField]
    private float cameraRadius = 0.5f;//usado para dar zoom in durante colisões
 
	//valores de rotação/zoom
    private float yRot = 0.0f, xRot = 0.0f;
    private float targetZoom = 5.0f, zoom = 5.0f;
    private float zoomVelocity = 0.0f;
 
    private void Update()
    {
        Rotate();
        Zoom();
    }
 
	//rotaciona a camera com o input do mouse
    private void Rotate()
    {
		//inputs
        //if (Input.GetMouseButton(1))
        //{
            yRot -= Input.GetAxis("Mouse Y") * cameraSensitivity.y;
            xRot += Input.GetAxis("Mouse X") * cameraSensitivity.x;
        //}
		
		//limita a rotação entre -yRotClamp e yRotClamp
        yRot = Mathf.Clamp(yRot, -yRotClamp, yRotClamp);
		//rotaciona a camera
        transform.parent.rotation = Quaternion.Euler(yRot, xRot, 0.0f);
    }
 
    private void Zoom()
    {
		//zoom in/zoom out
        targetZoom += Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
        targetZoom = Mathf.Clamp(targetZoom, zoomClamp.x, zoomClamp.y);
		
		//checa se tem algo no caminho da camera
        Ray ray = new Ray(transform.parent.position, -transform.parent.forward);
        RaycastHit hit;
		
        if (Physics.Raycast(ray, out hit, targetZoom))
        {
			//da zoom na camera pra não atravessar uma parede
            zoom = Mathf.SmoothDamp(zoom, hit.distance, ref zoomVelocity, zoomDamp);
            zoom -= cameraRadius;
        }
        else
        {
            zoom = Mathf.SmoothDamp(zoom, targetZoom, ref zoomVelocity, zoomDamp);
        }
		
		//limita o valor do zoom entre zoomClamp.x e zoomClamp.y
        zoom = Mathf.Clamp(zoom, zoomClamp.x, zoomClamp.y);
		//muda a posição da camera
        transform.localPosition = Vector3.back * zoom;
    }
}