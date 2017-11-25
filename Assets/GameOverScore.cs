using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour {

	public Text gameOverScore;

	// Use this for initialization
	void Start () {
		gameOverScore.text = "Score: " + PlayerMovement.score;
	}

	// Update is called once per frame
	void Update () {

	}
}
