using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public GameObject end;
	public GameObject projectile;
	public bool hasHit;
	PlayerController p1;
	PlayerController p2;
	Pauser pause;
	GameObject player;
	GameObject camera;
	int dire1;
	int dire2;
	float distp1;
	float distp2;
	int ammotype;
	public GameObject explosion;
	ModifyTerrain mt;

	public AudioClip sound;


	// Use this for initialization
	void Start () {
		hasHit = false;
		transform.LookAt (end.transform);
		mt = GameObject.FindGameObjectWithTag ("World").GetComponent ("ModifyTerrain") as ModifyTerrain;
		p1 = GameObject.FindGameObjectWithTag ("P1Hit").GetComponent ("PlayerController") as PlayerController;
		p2 = GameObject.FindGameObjectWithTag ("P2Hit").GetComponent ("PlayerController") as PlayerController;
		pause = GameObject.FindGameObjectWithTag ("Pauser").GetComponent ("Pauser") as Pauser;
		if (gameObject.tag == "CMissile") {
			ammotype = 6;
		}else if (gameObject.tag == "Missile") {
			ammotype = 5;
		}else if (gameObject.tag == "CShotgun1" || gameObject.tag == "CShotgun2") {
			ammotype = 4;
			explosion = null;
		}else if (gameObject.tag == "Shotgun1" || gameObject.tag == "Shotgun2") {
			ammotype = 3;
			explosion = null;
		}else if (gameObject.tag == "CRocket1" || gameObject.tag == "CRocket2") {
			ammotype = 2;
		}else if (gameObject.tag == "Rocket1" || gameObject.tag == "Rocket2") {
			ammotype = 1;
		}else{
			explosion = null;
			ammotype = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!pause.paused){
		if(!hasHit){
				distp1 = 0;
				distp2 = 0;
			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;
		
		//Debug.DrawLine(transform.position, transform.forward, Color.green, 5f);
		
		//move fist towards the target location
			transform.position = Vector3.MoveTowards (transform.position, end.transform.position, .35f);
		
		//if the fist hit the target location
			if (transform.position == end.transform.position || transform.position.x > 148 || transform.position.z > 148 || transform.position.x < 0 || transform.position.z < 0 || transform.position.y > 300 || transform.position.y < -10) {
				hasHit = true;
			    if(ammotype == 1 || ammotype == 2){
					Instantiate(explosion, transform.position, transform.rotation);
				}
				//mt.ReplaceBlockExplodeV(2,transform.position,0);
				DestroyObject (projectile);
			}
			
			if (Physics.Raycast (ray, out hit)) {
				if (hit.distance < .85f) {
					//gOut = false;
					//ReplaceBlockAt(hit,block);
						distp1 = Vector3.Distance(hit.point, p1.transform.position);
						distp2 = Vector3.Distance(hit.point, p2.transform.position);
						if (hit.collider.tag == "Terrain") {
							hasHit = true;
							if(ammotype == 1 || ammotype == 5){
								/*distp1 = Vector3.Distance(hit.point, p1.transform.position);
								distp2 = Vector3.Distance(hit.point, p2.transform.position);*/
								if(distp1 < 2){
									p1.applyBonus();
								}if(distp2 < 2){
									p2.applyBonus();
								}
								//Debug.Log (distp1);
								Instantiate(explosion, hit.point, transform.rotation);
								mt.ReplaceBlockExplode(2,hit,0);
							}else if(ammotype == 2 || ammotype == 6){
								if(distp1 < 2){
									p1.applyBonus();
								}if(distp2 < 2){
									p2.applyBonus();
								}
								//Debug.Log (distp1);
								Instantiate(explosion, hit.point, transform.rotation);
								if(distp1 > 2 && distp2 > 2){
									mt.ReplaceBlockExplode(2,hit,1);
								}else if(distp1 < 2 && distp1 > 1 && distp2 < 2 && distp2 > 1){
									mt.ReplaceBlockExplode(1,hit,1);
								}else{
									mt.ReplaceBlockExplode (0,hit,1);
								}
							}else if(ammotype == 4){
								if(distp1 > 1.5f && distp2 > 1.5f){
									mt.AddBlockAt(hit,1);
								}
							}else if(ammotype == 3 || ammotype == 0){
								//Debug.Log ("r");
								mt.ReplaceBlockAt(hit,0);
							}
						}
						if ((hit.collider.tag == "P1Hit" || hit.collider.tag == "Player1") && 
						    (gameObject.tag == "Rocket2" || gameObject.tag == "Bullet2" || gameObject.tag == "Shotgun2")) {
							if(ammotype == 1){
								Instantiate(explosion, hit.point, transform.rotation);
								mt.ReplaceBlockExplode(2,hit,0);
								//p1.applyBonus ();
								if(distp1 < 2){
									p1.applyBonus();
								}if(distp2 < 2){
									p2.applyBonus();
								}
								hasHit = true;
							}else if(ammotype == 2){
								if(distp1 < 2){
									p1.applyBonus();
								}if(distp2 < 2){
									p2.applyBonus();
								}
								//Debug.Log (distp1);
								Instantiate(explosion, hit.point, transform.rotation);
								if(distp1 > 2 && distp2 > 2){
									mt.ReplaceBlockExplode(2,hit,1);
								}
							}else{
								p1.applyHit ();
								hasHit = true;
							}
						}if ((hit.collider.tag == "P2Hit" || hit.collider.tag == "Player1") &&
				     		(gameObject.tag == "Rocket1" || gameObject.tag == "Bullet1" || gameObject.tag == "Shotgun1")) {
							if(ammotype == 1){
								Instantiate(explosion, hit.point, transform.rotation);
								mt.ReplaceBlockExplode(2,hit,0);
								if(distp1 < 2){
									p1.applyBonus();
								}if(distp2 < 2){
									p2.applyBonus();
								}
								//p2.applyBonus ();
								hasHit = true;
							}else if(ammotype == 2){
								if(distp1 < 2){
									p1.applyBonus();
								}if(distp2 < 2){
									p2.applyBonus();
								}
								//Debug.Log (distp1);
								Instantiate(explosion, hit.point, transform.rotation);
								if(distp1 > 2 && distp2 > 2){
									mt.ReplaceBlockExplode(2,hit,1);
								}
							}else{
								p2.applyHit ();
								hasHit = true;
							}
						}
				}
			
			}
		}else{
			///*if(gameObject.tag != "Shotgun1" && gameObject.tag != "CShotgun1")
				AudioSource.PlayClipAtPoint (sound, transform.position);

			DestroyObject(projectile);
		}
		}
		//transform.position = Vector3.MoveTowards (transform.position, end.transform.position, .3f);
	}
}
