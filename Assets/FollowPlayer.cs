using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public GameObject player;

	public float offsetX, offsetY, offsetZ;

	public float jumpHeightVal;

	public float speedMove;

	private float currentOffset;

	private int position;

	// Use this for initialization
	void Start () {
		currentOffset = offsetY;
	}
	
	// Update is called once per frame
	void Update () {
		CheckPosition ();
		if (player.transform.position.y > jumpHeightVal) {
			position = 1;
		} else if (player.transform.position.y < jumpHeightVal) {
			position = 0;
		}
		transform.position = Vector3.Lerp (transform.position, new Vector3 (player.transform.position.x + offsetX, currentOffset, player.transform.position.z + offsetZ), speedMove*Time.deltaTime);
	}

	void CheckPosition(){
		if (position == 0)
			currentOffset = offsetY;
		else if (position == 1)
			currentOffset = offsetY + 3;
	}
}
