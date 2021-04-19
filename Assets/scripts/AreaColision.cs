using UnityEngine;
using System.Collections;

public class AreaColision : MonoBehaviour {
	[SerializeField] private FollowIA ia;

	void OnTriggerEnter (Collider other){
		Jugador jugador = other.GetComponent<Jugador> ();
		if (jugador != null) {
			ia.colisionPersonaje (true,jugador);
		}
	}


	void OnTriggerExit (Collider other){
		Jugador jugador = other.GetComponent<Jugador> ();
		if (jugador != null) {
			ia.colisionPersonaje (false,jugador);
		}
	}
}
