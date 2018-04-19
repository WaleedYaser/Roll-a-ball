using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	private int score;

	public float speed = 10;
	public Text scoreText;
	public Text winText;
	public int totalPickups = 8;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		score = 0;
		SetScoreText ();
		winText.text = "";
	}

	void FixedUpdate ()
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		Vector3 f = new Vector3 (h, 0, v);

		rb.AddForce (f * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive (false);
			score += 1;
			SetScoreText ();
		}
	}

	void SetScoreText()
	{
		scoreText.text = "Score: " + score.ToString ();
		if (score >= totalPickups) {
			winText.text = "You Win!";
		}
	}
}
