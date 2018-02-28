using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private int selectedZombiePosition = 0;
	public GameObject selectedZombie;
	public List<GameObject> zombies;
	public Vector3 selectedSize;
	public Vector3 defaultSize;

	// Use this for initialization
	void Start () {
		SelectZombie (0);
	}
	
	// Update is called once per frame
	void Update () {
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
}
