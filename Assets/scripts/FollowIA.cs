using UnityEngine;
using System.Collections;

public class FollowIA : MonoBehaviour {


	[SerializeField] private GameObject balaPrefab;
	[SerializeField] private GameObject[] metas;

	private GameObject bala;
	private Jugador jugador;
	public float velocidad = 3.0f;

	private bool vivo;
	private bool jugadorEnTerritorio;
	private int objectivoActual;

	// Use this for initialization
	void Start () {
		vivo = true;
		jugadorEnTerritorio = false;
		objectivoActual = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (vivo) {
			if (jugadorEnTerritorio) {
				muevePersonaje ();
				dispara();
			} else {
				mueveObjetivo ();
			}
			transform.Translate (0,0,velocidad * Time.deltaTime);
		}
	}

	private void muevePersonaje(){
		transform.LookAt (jugador.transform.position);
	}

	private void mueveObjetivo(){
		transform.LookAt (metas[objectivoActual].transform.position);
	}

	private void dispara(){
		if (bala == null) {
			bala = Instantiate (balaPrefab) as GameObject;
			bala.transform.position = this.transform.TransformPoint
				(Vector3.forward*1.5f);
			bala.transform.rotation = this.transform.rotation;
		}
	}

	public void colisionPersonaje(bool dentro, Jugador jugador){
		this.jugador = jugador;
		jugadorEnTerritorio = dentro;
	}

	public void setVivo(bool v){
		vivo=v;
	}

	void OnTriggerEnter (Collider other){
		if (other.CompareTag ("Meta")) {
			objectivoActual++;
			if (objectivoActual >= metas.Length)
				objectivoActual = 0;
		}
	}
}
