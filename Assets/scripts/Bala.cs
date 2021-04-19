using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {
	public float velocidad=10.0f;
	public int danio = 1;
	// Use this for initialization
	void Start () {
		///
		StartCoroutine (Destruye());
		///
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0,0,velocidad*Time.deltaTime);
	}

	void OnTriggerEnter(Collider colision){
		Jugador jugador = colision.GetComponent<Jugador> ();

		if (jugador != null) {
			jugador.danio (danio);
			Destroy (this.gameObject);
		}

			
	}
		
	private IEnumerator Destruye(){
		yield return new WaitForSeconds (5.0f);
		Destroy (this.gameObject);
	}
}
