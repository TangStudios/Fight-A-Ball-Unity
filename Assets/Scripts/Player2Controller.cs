using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;

public class Player2Controller : MonoBehaviour {
	
	public float speed;
	public float jump;
	public float tiltAngle;
	public float smooth;

	public Text winText;
	public Text restartText;

	private float moveHorizontal;
	private float moveVertical;
	private Rigidbody rb;
	private int clicks;

	void Start() {
		rb = GetComponent<Rigidbody>();
		clicks = 0;
		winText.text = "";
		restartText.text = "";
		moveHorizontal = 0;
		moveVertical = 0;
	}
	
	void Update() {
		
		if (transform.position.y < -10) {
			rb.isKinematic = true;
			rb.isKinematic = false;
			gameObject.SetActive(false);

			if (winText.text == "") {
				winText.text = "Player 1 Wins!";
				restartText.text = "Press r to restart.";
			}
		}
		
		if (transform.position.y >= 0.4 && transform.position.y <= 0.6)
			clicks = 0;
		
		if (Input.GetKeyDown ("u")) {
			clicks++;
		}
	}
	
	void FixedUpdate()
	{
		if (Input.GetKey ("i")) {
			moveVertical = 1;
		} else if (Input.GetKey ("k")) {
			moveVertical = -1;
		} else {
			moveVertical = 0;
		}

		if (Input.GetKey ("j")) {
			moveHorizontal = -1;
		} else if (Input.GetKey ("l")) {
			moveHorizontal = 1;
		} else {
			moveHorizontal = 0;
		}
		float tiltAroundY = Input.GetAxis ("Horizontal") * tiltAngle;
		
		Vector3 movement = new Vector3 (moveHorizontal, 0f, moveVertical);
		Vector3 movementJump = new Vector3 (0f, jump, 0f);
		
		Quaternion target = Quaternion.Euler (0, tiltAroundY, 0);
		
		rb.AddForce (movement * speed);
		
		transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime * smooth);
		
		if (Input.GetKeyDown ("u")) {
			if (clicks < 1) rb.AddForce (movementJump);
		}
		
		if (Input.GetKeyDown ("r")) {
			rb.isKinematic = true;
			rb.isKinematic = false;
		}
	}
}