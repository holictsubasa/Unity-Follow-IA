using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

using UnityEngine.UI;
using System;

public class RayShooter : MonoBehaviour {

	private Camera camara;
	// Use this for initialization
	void Start () {
		camara = GetComponent<Camera> ();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		//
		if(Input.GetMouseButtonDown(0) && 
			!EventSystem.current.IsPointerOverGameObject()){
			//
			Vector3 punto = new Vector3 (camara.pixelWidth / 2, camara.pixelHeight / 2, 0);
			Ray ray = camara.ScreenPointToRay (punto);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = 
					hitObject.GetComponent<ReactiveTarget>();
				if (target != null) {
					target.reacciona ();
				} else {
					StartCoroutine (SphereIndicator (hit.point));
				}
			}
		}
	}
		
	private IEnumerator SphereIndicator(Vector3 pos){
		GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		sphere.transform.position = pos;
		yield return new WaitForSeconds (1.5f);
		Destroy (sphere);
	}

	void OnGUI(){
		int size = 12;
		float posX= camara.pixelWidth/2 - size/4;
		float posy = camara.pixelHeight/2 - size/2;
		GUI.Label (new Rect(posX,posy,size,size),"*");
	}

}
