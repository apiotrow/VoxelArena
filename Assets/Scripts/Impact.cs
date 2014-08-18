using UnityEngine;
using System.Collections;

public class Impact : MonoBehaviour
{
	World world;
	ModifyTerrain mt;
	GameObject player;
	GameObject camera;
	public bool punched;
	public GameObject end;
	public GameObject start;
	public RobotAnim robot;
	public bool gOut;
	public bool hasHit;
	Pauser pause;
	int dire1;
	int dire2;
	static string fistPunching; //holds which fist is next up to do the punching
	int test = 0; //just for debug purposes
	PlayerController p1;
	PlayerController p2;
	private GUIStyle buttonStyle = new GUIStyle ();
	int boxWidth = 120;
	int boxHeight = 30;



	void Start ()
	{
		world = GameObject.FindGameObjectWithTag ("World").GetComponent ("World") as World;
		mt = GameObject.FindGameObjectWithTag ("World").GetComponent ("ModifyTerrain") as ModifyTerrain;
		//robot = GameObject.FindGameObjectWithTag ("roBot").GetComponent ("RobotAnim") as RobotAnim;
		//robot = GameObject.FindGameObjectWithTag ("roBot");

		if (gameObject.tag == "Fist1.1") {
			player = GameObject.FindGameObjectWithTag ("Player1");
			camera = GameObject.FindGameObjectWithTag ("Player1Camera");
		}
		if (gameObject.tag == "Fist1.2") {
			player = GameObject.FindGameObjectWithTag ("Player1");
			camera = GameObject.FindGameObjectWithTag ("Player1Camera");
		}
		if (gameObject.tag == "Fist2") {
			player = GameObject.FindGameObjectWithTag ("Player2");
			camera = GameObject.FindGameObjectWithTag ("Player2Camera");
		}
		
		p1 = GameObject.FindGameObjectWithTag ("P1Hit").GetComponent ("PlayerController") as PlayerController;
		p2 = GameObject.FindGameObjectWithTag ("P2Hit").GetComponent ("PlayerController") as PlayerController;
		
		fistPunching = "Fist1.1";
	}


	// Update is called once per frame
	void Update ()
	{
		if (!punched) {
			/*Direction1 will be split with
			 * 1 = North
			 * 2 = East
		 	 * 3 = South
		 	 * 4 = West
		 	 * Direction2 will be split with 
		 	 * 0 = base height
		 	 * 1 = up
			 * 2 = down
			 * This combo allows if Direct2 != 0, Direct1's outcome is used while if direct2  is 1 or 2 they override the impact direction
			 * */
			if (camera.transform.eulerAngles.x >= 270 && camera.transform.eulerAngles.x <= 315) {
				dire2 = 1;
			} else if (camera.transform.eulerAngles.x >= 45 && camera.transform.eulerAngles.x <= 90) {
				dire2 = 2;
			} else {
				dire2 = 0;
			}
			if (player.transform.eulerAngles.y <= 135 && player.transform.eulerAngles.y > 45) {
				dire1 = 2;
			} else if (player.transform.eulerAngles.y <= 225 && player.transform.eulerAngles.y > 135) {
				dire1 = 3;
			} else if (player.transform.eulerAngles.y <= 315 && player.transform.eulerAngles.y > 225) {
				dire1 = 4;
			} else {
				dire1 = 1;
			}

			if ((Input.GetButton ("Punch") && (gameObject.tag == "Fist1.1" || gameObject.tag == "Fist1.2"))
				|| (Input.GetButton ("Punch_alt") && (gameObject.tag == "Fist2.1" || gameObject.tag == "Fist2.2"))) {



				punched = true;
				gOut = true;
				hasHit = false;
				//StartCoroutine (punchTime ());

				//randomly assigns either fist1 or fist2 of player 1 to be the fist that punches
				if (Random.Range (0f, 1f) < 0.5f) {
					if (gameObject.tag == "Fist1.1" || gameObject.tag == "Fist1.2") {
						fistPunching = "Fist1.1";
					}
					if (gameObject.tag == "Fist2.1" || gameObject.tag == "Fist2.2") {
						fistPunching = "Fist2.1";
					}
				} else {
					if (gameObject.tag == "Fist1.1" || gameObject.tag == "Fist1.2") {
						fistPunching = "Fist1.2";
					}
					if (gameObject.tag == "Fist2.1" || gameObject.tag == "Fist2.2") {
						fistPunching = "Fist2.2";
					}
				}
			}
			
		} else {
			//if the fist running this script is the fist we want to be punching right now
			if (gameObject.tag == fistPunching) {
				if (gOut) {
					Ray ray;
					
					Ray[] rayArray = {
						new Ray (transform.position - Vector3.down, Vector3.up),
						new Ray (transform.position - Vector3.up, Vector3.down),
						new Ray (transform.position - Vector3.right, Vector3.left),
						new Ray (transform.position - Vector3.left, Vector3.right),
						new Ray (transform.position - Vector3.back, Vector3.forward),
						new Ray (transform.position - Vector3.forward, Vector3.back),
						new Ray (transform.position, Vector3.up),
						new Ray (transform.position, Vector3.down),
						new Ray (transform.position, Vector3.left),
						new Ray (transform.position, Vector3.right),
						new Ray (transform.position, Vector3.forward),
						new Ray (transform.position, Vector3.back)};
					RaycastHit hit;
					
					
					//					Debug.DrawRay(transform.position, Vector3.right, Color.green, 5f);
					//					Debug.DrawRay(transform.position, Vector3.left, Color.green, 5f);
					//					Debug.DrawRay(transform.position, Vector3.up, Color.green, 5f);
					//					Debug.DrawRay(transform.position, Vector3.down, Color.green, 5f);
					//					Debug.DrawRay(transform.position, Vector3.forward, Color.green, 5f);
					//					Debug.DrawRay(transform.position, Vector3.back, Color.green, 5f);
					//Debug.DrawRay(transform.position, end.transform.position, Color.green, 5f);
					
					//move fist towards the target location
					transform.position = Vector3.MoveTowards (transform.position, end.transform.position, .5f);
					
					//if the fist hit the target location
					if (transform.position == end.transform.position) {
						gOut = false;
					}

					//GameObject camm = GameObject.FindGameObjectWithTag ("Player1Camera");


					//Debug.DrawRay(camm.transform.position, camm.transform.forward, Color.green, 5f);
//					Debug.DrawRay(camera.transform.position, camera.transform.forward, Color.green, 5f);
//
//					Vector3 u = camera.transform.forward;
//					u.x += 1;
//					Debug.DrawRay(camera.transform.position, u, Color.green, 5f);

					ray = new Ray(camera.transform.position, camera.transform.forward);
					if (Physics.Raycast (ray, out hit)) {
						if (hit.distance < 0.3f) {
							//gOut = false;
							//ReplaceBlockAt(hit,block);
							if (hit.collider.tag == "Terrain" && !hasHit) {
								//mt.ReplaceBlockExplodeDirection (dire1, dire2, 1, hit, 0);
								gOut = false;
							}
							if (hit.collider.tag == "P1Hit" && gameObject.tag == "Fist2" && !hasHit) {
								p1.applyHit ();
								hasHit = true;
								gOut = false;
							} else if ((hit.collider.tag == "P2Hit" || hit.collider.tag == "Player2") && 
							           (gameObject.tag == "Fist1.1" || gameObject.tag == "Fist1.2") 
							           && !hasHit) {
								p2.applyHit ();
								hasHit = true;
								gOut = false;
							}
						}
					}
					
					
//					if (Physics.SphereCast (transform.position, 3f, end.transform.position, out hit, 1f)) {
//						if (hit.distance < .85f) {
//							//gOut = false;
//							//ReplaceBlockAt(hit,block);
//							if (hit.collider.tag == "Terrain" && !hasHit) {
//								mt.ReplaceBlockExplodeDirection (dire1, dire2, 1, hit, 0);
//								//gOut = false;
//							}
//							if (hit.collider.tag == "P1Hit" && gameObject.tag == "Fist2" && !hasHit) {
//								p1.applyHit ();
//								hasHit = true;
//								//gOut = false;
//							} else if ((hit.collider.tag == "P2Hit" || hit.collider.tag == "Player2") && 
//							           (gameObject.tag == "Fist1.1" || gameObject.tag == "Fist1.2") 
//							           && !hasHit) {
//								p2.applyHit ();
//								hasHit = true;
//								//gOut = false;
//							}
//						}
//					}

					//Debug.DrawRay (transform.position, transform.worldToLocalMatrix.MultiplyVector(Vector3.forward), Color.green, 5f);
					
//					for (int y = 0; y < rayArray.Length; y++) {
//						ray = rayArray [y];
//						//Debug.DrawRay (ray.origin, ray.direction, Color.green, 5f);
//						if (Physics.Raycast (ray, out hit)) {
//							if (hit.distance < .85f) {
//								//gOut = false;
//								//ReplaceBlockAt(hit,block);
//								if (hit.collider.tag == "Terrain" && !hasHit) {
//									mt.ReplaceBlockExplodeDirection (dire1, dire2, 1, hit, 0);
//									gOut = false;
//								}
//								if (hit.collider.tag == "P1Hit" && gameObject.tag == "Fist2" && !hasHit) {
//									p1.applyHit ();
//									hasHit = true;
//									gOut = false;
//								} else if ((hit.collider.tag == "P2Hit" || hit.collider.tag == "Player2") && 
//									(gameObject.tag == "Fist1.1" || gameObject.tag == "Fist1.2") 
//									&& !hasHit) {
//									p2.applyHit ();
//									hasHit = true;
//									gOut = false;
//								}
//							}
//						}
//					}
				
				} else {
					hasHit = true;

					//move fist towards the start location
					transform.position = Vector3.MoveTowards (transform.position, start.transform.position, .3f);

					//if fist hit the start location
					if (transform.position == start.transform.position) {
						punched = false;
					}
				}
			}
		}
	
	}
	
	/*void OnTriggerEnter(Collider other){
		if (other.tag == "FistTar") {
			gOut = false;
		}
		if (other.tag == "FistStart") {
			punched = false;
		}
	}*/
	
//	IEnumerator punchTime ()
//	{
//		yield return new WaitForSeconds (.25f);
//		//transform.Translate (preset*Time.deltaTime);
//		gOut = false;
//		StartCoroutine (punchReturn ());
//	}
//	
//	IEnumerator punchReturn ()
//	{
//		yield return new WaitForSeconds (.25f);
//		//transform.Translate (preset*Time.deltaTime);
//		punched = false;
//		
//		//gOut = false;
//	}
	
}
