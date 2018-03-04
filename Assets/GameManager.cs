using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private int selectedZombiePosition = 0;
	public GameObject selectedZombie;
	public List<GameObject> zombies;
	public Vector3 selectedSize;
	public Vector3 defaultSize;

	private bool gameIsOver = false;

	public Text scoreText;
	private int score = 0;
	private int Score {
		get { return score; }
		set {
			score = value;
			scoreText.text = "SCORE: " + score;
		}
	}

	public Text timeLabel;
	private float timeRemaining = 10f;
	private float TimeRemaining {
		get { return timeRemaining; }
		set {
			if (timeRemaining <= 0) {
				timeRemaining = 10f;
				if (!gameIsOver) {
					gameIsOver = true;
				}
				return;
			}
			timeRemaining = value;
			timeLabel.text = "TIME: " + (int)timeRemaining;
		}
	}

	// Use this for initialization
	void Start () {
		SelectZombie (0);
		this.Score = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (this.gameIsOver) {
			if (Input.GetKeyDown ("space")) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			}
			return;
		}

		// Update the timer label
		this.TimeRemaining -= Time.deltaTime;

		if (Input.GetKeyDown ("left")) {
			GetZombieLeft ();
		}

		if (Input.GetKeyDown ("right")) {
			GetZombieRight ();
		}

		if (Input.GetKeyDown ("up")) {
			PushUp ();
		}
	}

	void GetZombieLeft() {
		if (selectedZombiePosition == 0) {
			SelectZombie (3);
		} else {
			SelectZombie (selectedZombiePosition - 1);
		}
	}

	void GetZombieRight() {
		if (selectedZombiePosition == 3) {
			SelectZombie (0);
		} else {
			SelectZombie (selectedZombiePosition + 1);
		}
	}

	void SelectZombie(int zombiePosition) {
		selectedZombiePosition = zombiePosition;
		GameObject newZombie = zombies [zombiePosition];
		selectedZombie.transform.localScale = defaultSize;
		selectedZombie = newZombie;
		newZombie.transform.localScale = selectedSize;
	}

	void PushUp() {
		Rigidbody rb = selectedZombie.GetComponent<Rigidbody> ();
		rb.AddForce (0, 0, 10, ForceMode.Impulse);
	}

	public void AddPoints(int points) {
		this.Score += points;
	}

	private bool isGameOver() {
		int zombieOffCount = 0;
		for (int i = 0; i < zombies.Count; i++) {
			GameObject zombie = zombies [i];
		}
	}
}
