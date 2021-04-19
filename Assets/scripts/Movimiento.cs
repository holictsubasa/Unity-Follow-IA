using UnityEngine;
using System.Collections;

public class Movimiento : MonoBehaviour {
	private float velocidad = 1.0f;
	private float velocidadbase = 1.0f;

	private CharacterController control;
	// Use this for initialization
	void Start () {
		control = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		float deltax = Input.GetAxis ("Horizontal");
		float deltaz = Input.GetAxis ("Vertical");
		float gravedad = -9.8f;

		Vector3 movimiento = new Vector3 (deltax*velocidad,gravedad,deltaz*velocidad);

		movimiento = transform.TransformDirection (movimiento);

		control.Move (movimiento);
		//transform.Translate (deltax,0,deltaz);
	}
	public void cambiaVelocidad(float cambio){
		velocidad = velocidadbase * cambio;
	}
}
