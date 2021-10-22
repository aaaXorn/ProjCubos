using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrdPCam : MonoBehaviour
{
	//sensividade da camera, quanto maior for, mais ela se move por input
    [SerializeField] Vector2 cameraSensitivity = Vector2.one; 
	
    [SerializeField] float zoomSensitivity = 10.0f;//sensividade do zoom
	
    [SerializeField] float yRotClamp = 85.0f;//rotação Y máxima
 
    [SerializeField] Vector2 zoomClamp = new Vector2(0.5f, 25.0f);//zooom mínimo/máximo
 
    [SerializeField] float zoomDamp = 0.05f;//timer do damp do zoom, suaviza o zoom
 
    [SerializeField] float zoomHitMult = 0.8f;//usado para dar zoom in durante colisões
 
	//valores de rotação/zoom
    float yRot = 0.0f, xRot = 0.0f;
    [SerializeField] float targetZoom = 5.0f, zoom = 5.0f;
    float zoomVelocity = 0.0f;
 
    void Update()
    {
		//funções de rotação e zoom
        Rotate();
        Zoom();
    }
 
	//rotaciona a camera com o input do mouse
    void Rotate()
    {
		//inputs
		yRot -= Input.GetAxis("Mouse Y") * cameraSensitivity.y;
        xRot += Input.GetAxis("Mouse X") * cameraSensitivity.x;
		
		//limita a rotação entre -yRotClamp e yRotClamp
        yRot = Mathf.Clamp(yRot, -yRotClamp, yRotClamp);
		//rotaciona a camera
        transform.parent.rotation = Quaternion.Euler(yRot, xRot, 0.0f);
    }
 
	//da zoom na camera
    void Zoom()
    {
		//zoom in com scroll pra cima, zoom out com scroll pra baixo
        targetZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
		//limita o valor do targetZoom
        targetZoom = Mathf.Clamp(targetZoom, zoomClamp.x, zoomClamp.y);
		
		//checa se tem algo no caminho da camera
        Ray ray = new Ray(transform.parent.position, -transform.parent.forward);
        RaycastHit hit;
		
		//checa se tem uma parede na direção da camera
        if (Physics.Raycast(ray, out hit, targetZoom))
        {
			//da zoom na camera até o ponto de colisão
            zoom = Mathf.SmoothDamp(zoom, hit.distance * zoomHitMult, ref zoomVelocity, zoomDamp);
        }
        else
        {
			//volta a camera ao zoom anterior a colisão
            zoom = Mathf.SmoothDamp(zoom, targetZoom, ref zoomVelocity, zoomDamp);
        }
		
		//limita o valor do zoom
        zoom = Mathf.Clamp(zoom, zoomClamp.x, zoomClamp.y);
		//muda a posição da camera
        transform.localPosition = Vector3.back * zoom;
    }
}