using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jump;
	public float tiltAngle;
	public float smooth;
	
	public Text winText;
	public Text restartText;

	private Rigidbody rb;
	private int clicks;

	void Start() {
		rb = GetComponent<Rigidbody>();
		clicks = 0;
		winText.text = "";
		restartText.text = "";
	}

	void Update() {
		if (transform.position.y < -10) {
			rb.isKinematic = true;
			rb.isKinematic = false;
			gameObject.SetActive(false);

			if (winText.text == "") {
				winText.text = "Player 2 Wins!";
				restartText.text = "Press r to restart.";
			}
		}

		if (transform.position.y >= 0.4 && transform.position.y <= 0.6)
			clicks = 0;

		if (Input.GetKeyDown ("q")) {
			clicks++;
		}
	}
 
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float tiltAroundY = Input.GetAxis ("Horizontal") * tiltAngle;

		Vector3 movement = new Vector3 (moveHorizontal, 0f, moveVertical);
		Vector3 movementJump = new Vector3 (0f, jump, 0f);

		Quaternion target = Quaternion.Euler (0, tiltAroundY, 0);
		
		rb.AddForce (movement * speed);

		transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime * smooth);

		if (Input.GetKeyDown ("q")) {
			if (clicks < 1) rb.AddForce (movementJump);
		}

		if (Input.GetKeyDown ("r")) {
			rb.isKinematic = true;
			rb.isKinematic = false;
		}
	}
}