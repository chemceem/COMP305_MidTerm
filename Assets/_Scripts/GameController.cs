using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public int tankCount = 3;
	public GameObject enemyTank;
	public PlayerController player;
	public Text LivesText;
	public Text ScoreText;
	public Text GameoverText;
	public Text HighScoreText;
	public Button RestartButton;

	//PUBLIC INSTANCE VARIABLES
	private int _scoreValue;	
	private int _lifeValues;

	//PUBLIC ACCESS METHODS
	public int ScoreValue{
		get { 
			return _scoreValue;
		}
		set { 
			this._scoreValue = value;
			this.ScoreText.text = "Score : " + this._scoreValue;
		}
	}

	public int LivesValue {
		get { 
			return _lifeValues;
		}
		set{
			this._lifeValues = value;
			if (this._lifeValues <= 0) {
				this._endGame ();
			} else {
				this.LivesText.text = "Lives : " + this._lifeValues;
			}
		}
	}

	// Use this for initialization
	void Start () {
		this._initialize ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void _initialize(){
		this.ScoreValue = 0;
		this.LivesValue = 5;
		this.GameoverText.enabled = false;
		this.HighScoreText.enabled = false;
		this._GenerateTanks ();	
		this.RestartButton.gameObject.SetActive(false);
	}

	// generate Clouds
	private void _GenerateTanks() {
		for (int count=0; count < this.tankCount; count++) {
			Instantiate(enemyTank.gameObject);
		}
	}

	//PRIVATE METHODS
	private void _endGame(){
		this.LivesText.enabled = false;
		this.ScoreText.enabled = false;
		this.HighScoreText.text = "Final Score : " + this._scoreValue;
		this.RestartButton.gameObject.SetActive(true);
		this.GameoverText.enabled = true;
		this.HighScoreText.enabled = true;
		this.LivesText.text = "Lives : 0";
		this.player.gameObject.SetActive (false);
		//this.enemyTank.gameObject.SetActive (false);
		Destroy (this.enemyTank.gameObject);

	}

	//PUBLIC METHODS
	public void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
