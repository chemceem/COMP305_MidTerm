using UnityEngine;
using System.Collections;

public class TankCollider : MonoBehaviour {

	//PUBLIC INSTANCE VARIABLES
	public GameController gameController;
	public AudioSource collisionSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("enemy")) {
			this.gameController.LivesValue--;
			//other.gameObject.SetActive (false);
			this.collisionSound.Play();
		}
	}
}