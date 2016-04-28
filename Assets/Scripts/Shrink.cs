using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shrink : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public Text winText;
	public Text restartText;

	public GameObject cube1, cube2, cube3, cube4, cube5;

	private Random rnd = new Random();

	void Start() {
		cube1.transform.position = new Vector3(Random.value * 20f - 10f, 0.75f, Random.value * 20f - 10f);
		cube2.transform.position = new Vector3(Random.value * 20f - 10f, 0.75f, Random.value * 20f - 10f);
		cube3.transform.position = new Vector3(Random.value * 20f - 10f, 0.75f, Random.value * 20f - 10f);
		cube4.transform.position = new Vector3(Random.value * 20f - 10f, 0.75f, Random.value * 20f - 10f);
		cube5.transform.position = new Vector3(Random.value * 20f - 10f, 0.75f, Random.value * 20f - 10f);
	}

	// Update is called once per frame
	void Update () {
		if (transform.localScale.x > 0.25 && transform.localScale.z > 0.25)transform.localScale -= new Vector3 (.0005f, 0, .0005f);

		if (Input.GetKeyDown ("r")) {
			transform.localScale = new Vector3(2f, 2f, 2f);
			player1.transform.position = new Vector3(-5f, 5f, -5f);
			player2.transform.position = new Vector3(5f, 5f, 5f);
			player1.SetActive(true);
			player2.SetActive(true);

			winText.text = "";
			restartText.text = "";

			cube1.transform.position = new Vector3(Random.value * 20f - 10f, 0.75f, Random.value * 20f - 10f);
			cube2.transform.position = new Vector3(Random.value * 20f - 10f, 0.75f, Random.value * 20f - 10f);
			cube3.transform.position = new Vector3(Random.value * 20f - 10f, 0.75f, Random.value * 20f - 10f);
			cube4.transform.position = new Vector3(Random.value * 20f - 10f, 0.75f, Random.value * 20f - 10f);
			cube5.transform.position = new Vector3(Random.value * 20f - 10f, 0.75f, Random.value * 20f - 10f);
		}
	}
}
