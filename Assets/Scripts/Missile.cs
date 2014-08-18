using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	World world;
	ModifyTerrain mod;
	GameObject cameraGO;

	public GameObject explosion;
	//public GameObject target;

	// Declare/initialize variables
	public float minFallSpeed = 15f;
	public float maxFallSpeed = 20f;
	public float minScale = 1f;
	public float maxScale = 1f;
	public float levelSize = 150f;
	
	private float fallSpeed = 10f;
	private float missileScale = 0.1f;
	private float dirX;
	private float dirZ;
	private float rotX;
	private float rotY;
	private float rotZ;
	
	private float range;


	//Vector3 targetPos;

	void Start(){
		
		//world = gameObject.GetComponent ("World") as World;
		mod = GameObject.FindGameObjectWithTag ("World").GetComponent ("ModifyTerrain") as ModifyTerrain;
		//cameraGO = GameObject.FindGameObjectWithTag ("MainCamera");

		// Set variables per instance of object
		fallSpeed = Random.Range (minFallSpeed, maxFallSpeed);
		//Debug.Log (fallSpeed);
		missileScale = Random.Range (minScale, maxScale);
		dirX = Random.Range (-0, 0);
		dirZ = Random.Range (-0, 0);
		rotX = Random.Range (-0f, 0f);
		rotY = Random.Range (-15f, 15f);
		rotZ = Random.Range (-0f, 0f);

		// Apply scale transformation
		transform.localScale = new Vector3 (missileScale, missileScale, missileScale);

		/*
		// Creates target telegraph
		Ray ray = new Ray(transform.position, new Vector3(0f,-100f,0f));
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) {
			if (hit.distance < range) {
				targetPos = hit.point;
				targetPos += (hit.normal * -0.5f);
				Instantiate (target, targetPos, transform.rotation);

				Debug.Log ("Target's raycast hit: " + targetPos.x + ", " + targetPos.y + ", " + targetPos.z);
			}
			Debug.DrawLine(ray.origin,ray.origin+( ray.direction*hit.distance),Color.yellow,2);
		}

		Instantiate (target, targetPos, transform.rotation);
		*/

		range = 1f;
	}

	// Update is called once per frame
	void Update () {

		// Detects for ground collision
		Ray ray = new Ray(transform.position, new Vector3(0f,-(range),0f));
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) {
			if(hit.distance<range){
				Debug.Log("Ground detected");
				// Instance explosion sphere and destroy terrain
				explosion.transform.localScale = new Vector3(transform.lossyScale.x*2f, transform.lossyScale.y*2f, transform.lossyScale.z*2f);
				Instantiate(explosion, transform.position, transform.rotation);

				mod.ReplaceBlockExplodeDown(3, hit, 0);

				//GameObject.Destroy (target);
				GameObject.Destroy (gameObject);
			}
			Debug.DrawLine(ray.origin,ray.origin+( ray.direction*hit.distance),Color.red,2);
		}

		// Sends meteor with downwards velocity
		transform.rigidbody.velocity = new Vector3 (dirX, -fallSpeed, dirZ);

		// Applies rotation to meteor
		transform.Rotate (rotX * Time.deltaTime, rotY * Time.deltaTime, rotZ * Time.deltaTime);
	}

	void OnCollisionEnter(Collision c){
		// Spawn explosions on collisions, and destroy this object when it runs out of bounces
		if (c.gameObject.tag == "World" || c.gameObject.tag == "Player1" || c.gameObject.tag == "Player2"){
			//Debug.Log ("Collision detected");
			explosion.transform.localScale = new Vector3 (transform.lossyScale.x * 4f, transform.lossyScale.y * 4f, transform.lossyScale.z * 4f);
			Instantiate (explosion, transform.position, transform.rotation);
			//target.gameObject.Destroy (target);
			GameObject.Destroy (gameObject);
		}

	}
}
