using UnityEngine;
using System.Collections;

public class MoveObjects : MonoBehaviour {

	public float moveSpeed;
	public float addSpeed;
	public float speedTimer;
	public float scoreTimer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!PlayerMovement.dead) {
			speedTimer += Time.deltaTime;
			scoreTimer += Time.deltaTime;
			if (scoreTimer >= 2) {
				scoreTimer = 0;
				PlayerMovement.score += 10;
			}
			if (speedTimer >= 10) {
				speedTimer = 0;
				moveSpeed += addSpeed;
				Debug.Log ("increased");
			}
			transform.Translate (0, 0, -moveSpeed * Time.deltaTime);
		}
	}
}
