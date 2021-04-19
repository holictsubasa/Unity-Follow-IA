using UnityEngine;
using System.Collections;

public class Jugador : MonoBehaviour {
	private int vida;
	// Use this for initialization
	void Start () {
		vida = 5;
	}
	
	public void danio(int golpe){
		vida -= golpe;
		Debug.Log ("Vida "+vida);
	}
}
