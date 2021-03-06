using UnityEngine;
using System.Collections;

public class Girar : MonoBehaviour {
	public bool giraX;
	public bool giraY;

	private float velocidadx = 5f;
	private float velocidady = 5f;

	private float minimoGiro = -45.0f;
	private float maximoGiro = 45.0f;
	private float rotaciony = 0;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (giraX) {
			float girox = Input.GetAxis ("Mouse X");
			transform.Rotate (0,girox*velocidadx,0);
		}
		if (giraY) {
			float giroy = Input.GetAxis ("Mouse Y");
			rotaciony -= giroy * velocidady;
			rotaciony = Mathf.Clamp (rotaciony,minimoGiro,maximoGiro);
			transform.localEulerAngles = new Vector3 (rotaciony,0,0);
		}


	}
}
