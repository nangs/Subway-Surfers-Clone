using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody rb;
	private Animator anim;
	public static int score;
	public Text scoreText;

	//placeholder positions for cube to jump to

	private int Direction;

	public float speed;
	private bool grounded;
	private bool immediateDown;
	private bool moved;

	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	public static bool dead;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		PlayerMovement.dead = false;
		score = 0;
	}
	
	// Update is called once per frame (Right before frame)
	void Update () {
		grounded = Physics.OverlapSphere (groundCheck.position, groundRadius, whatIsGround).Length >= 1;
		//rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y,10f);
		//Debug.Log(grounded);
		if (!dead) {
			scoreText.text = "Score: " + score;
			Analyze ();
			if (Input.GetKeyDown (KeyCode.A)) {
				print ("left");
				anim.CrossFade ("Left", 0.5f);
				if (Direction == 0 || Direction == 1) {
					Direction--;
				}
			} if (Input.GetKeyDown (KeyCode.D)) {
				print ("right");
				anim.CrossFade ("Right", 0.5f);
				if (Direction == 0 || Direction == -1) {
					Direction++;
				}
			}
			if (Input.GetKeyDown (KeyCode.W) && grounded) { 
				anim.CrossFade ("Jump", 0.5f);
				rb.AddForce (0, 1900f, 0);
			}
			if (Input.GetKeyDown (KeyCode.S)) {
				anim.CrossFade ("Roll", 0.5f);
				immediateDown = true;
			}
		}
		if (PlayerMovement.dead) {
			SceneManager.LoadScene ("Game Over");
		}
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Platform") {
			Vector3 hit = collision.contacts[0].normal; //perpendicular in vector terms
			float angle = Vector3.Angle(hit, Vector3.up);
			if (Mathf.Approximately (angle, 90)) {
				dead = true;
			}
		}
		if (collision.gameObject.tag == "Obstacle") {
			dead = true;
		}
		if (collision.gameObject.tag == "Coin") {
			score += 300;
			Destroy (collision.gameObject);
		}
	}

	void Analyze(){
		transform.position = Vector3.Lerp (transform.position, new Vector3 (3 * Direction, transform.position.y, transform.position.z), 3.7f*Time.deltaTime);
	}

	// For physics updates
	void FixedUpdate () {
		if (immediateDown) {
			rb.AddForce (0, -3000f, 0);
			immediateDown = false;
		}
	}

}
