using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {
	private int danio = 1;

	public void reacciona(){
		FollowIA inteligencia2 = GetComponent<FollowIA>();
		if (inteligencia2 != null) {
			inteligencia2.setVivo (false);
		}
		StartCoroutine (Muere());
	}

	private IEnumerator Muere(){
		this.transform.Rotate (-75,0,0);
		yield return new WaitForSeconds (1.5f);
		Destroy (this.gameObject);
	}

	void OnTriggerEnter(Collider colision){
		Jugador jugador = colision.GetComponent<Jugador> ();

		if (jugador != null) {
			jugador.danio (danio);
		}

	}
}
