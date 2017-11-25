using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Generate : MonoBehaviour {

	public Vector3 startingPt;
	public Transform[] premades;
	public Transform background;
	public List<Transform> currentPremades;
	Transform clone;
	int rand;


	void Start() {
		currentPremades = new List<Transform>();
		for (int z = 0; z < 5; z++) {
			rand = Random.Range (0, premades.Length);
			currentPremades.Add((Transform)Instantiate(premades[rand], new Vector3(startingPt.x, startingPt.y, startingPt.z+140*z+40), Quaternion.identity) as Transform);
			Instantiate(background, new Vector3(startingPt.x, startingPt.y, startingPt.z+140*z-10), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (currentPremades [0].position.z < -120) {
			Destroy( (currentPremades [0] as Transform).gameObject );
			currentPremades.RemoveAt (0);
			rand = Random.Range (0, premades.Length);
			Debug.Log (premades.Length);
			Debug.Log (currentPremades.Capacity-1);
			currentPremades.Add ((Transform)Instantiate (premades [rand], new Vector3 (startingPt.x, startingPt.y, currentPremades[currentPremades.Capacity-1].position.z+140), Quaternion.identity) as Transform);
			Instantiate(background, new Vector3(startingPt.x, startingPt.y, currentPremades[currentPremades.Capacity-1].position.z+140), Quaternion.identity);
		}
	}
}
