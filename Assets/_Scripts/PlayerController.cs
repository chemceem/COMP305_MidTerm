using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES +++++++++++++++++++++++++++++++++++++++
	public float speed = 10f;
	public Boundary boundary;

	// get a reference to the camera to make mouse input work
	public Camera camera; 
	
	// PRIVATE INSTANCE VARIABLES
	private Transform _transform;
	private Vector2 _currentPosition;
	private float _playerInput;
	//private Vector2 _newPosition = new Vector2(0.0f, 0.0f);
	
	// Use this for initialization
	void Start () {
		this._transform = gameObject.GetComponent<Transform> ();
		this._transform.position = new Vector2 (0,-180);
	}

	// Update is called once per frame
	void Update () {
		this._CheckInput ();

	}

	private void _CheckInput() {		
		this._currentPosition = this._transform.position;

		//check keyboard movement
		this._playerInput = Input.GetAxis ("Horizontal");
		if (this._playerInput > 0) {
			this._currentPosition += new Vector2 (this.speed, 0);
		}
		if (this._playerInput < 0) {			
			this._currentPosition -= new Vector2 (this.speed, 0);
		}

		//check mouse movement
		Vector2 mousePosition = Input.mousePosition;
		this._currentPosition.x = this.camera.ScreenToWorldPoint (mousePosition).x;

		this.transform.position = this._currentPosition;
		this._BoundaryCheck ();
	}

	private void _BoundaryCheck() {
		if (this._currentPosition.x < this.boundary.xMin) {
			this._currentPosition.x = this.boundary.xMin;
		}

		if (this._currentPosition.x > this.boundary.xMax) {
			this._currentPosition.x = this.boundary.xMax;
		}
	}
}
