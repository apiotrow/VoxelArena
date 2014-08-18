using UnityEngine;
using System.Collections;

public class RobotAnim : MonoBehaviour
{
	Animation currentAnim;
	public string anim;
	World world;
	ModifyTerrain mt;
	GameObject player;
	GameObject camera;
	public bool punched;
	public GameObject fist;
	public RobotAnim robot;
	public bool gOut;
	public bool hasHit;
	Pauser pause;
	int dire1;
	int dire2;
	PlayerController p1;
	PlayerController p2;
	float powerupGen;
	Shoot ammo;
	bool inAnim;
	//bool canPunch;

	bool p1CanPunch;
	bool p2CanPunch;

	public AudioClip punchSound;
	//public AudioSource aud;

	//public GameObject punchsoundobject;


	// Use this for initialization
	void Start ()
	{
		currentAnim = GetComponent<Animation> ();
		anim = "loop_run_funny";
		p1CanPunch = true;
		p2CanPunch = true;

		//punchsoundobject = GameObject.FindGameObjectWithTag ("punchsound");
		//aud = GetComponent ("AudioSource") as AudioSource;
		//punchSound = aud.audio;

		//canPunch = true;

		world = GameObject.FindGameObjectWithTag ("World").GetComponent ("World") as World;
		mt = GameObject.FindGameObjectWithTag ("World").GetComponent ("ModifyTerrain") as ModifyTerrain;

		p1 = GameObject.FindGameObjectWithTag ("P1Hit").GetComponent ("PlayerController") as PlayerController;
		p2 = GameObject.FindGameObjectWithTag ("P2Hit").GetComponent ("PlayerController") as PlayerController;
		if (gameObject.tag == "Bot1") {
			player = GameObject.FindGameObjectWithTag ("Player1");
			camera = GameObject.FindGameObjectWithTag ("Player1Camera");
			ammo = GameObject.FindGameObjectWithTag ("BSpawnP1").GetComponent ("Shoot") as Shoot;

		}
		if (gameObject.tag == "Bot2") {
			player = GameObject.FindGameObjectWithTag ("Player2");
			camera = GameObject.FindGameObjectWithTag ("Player2Camera");
			ammo = GameObject.FindGameObjectWithTag ("BSpawnP2").GetComponent ("Shoot") as Shoot;
		}


		//charMotor = GameObject.FindGameObjectWithTag ("Player1").GetComponent ("CharacterMotor");
	}
	
	// Update is called once per frame
	void Update ()
	{

		//StartCoroutine (PlayPunch ());

		//if another animation isn't going, do idle animation
		if (!inAnim)
			anim = "loop_idle";
		
		//if bot1 is jumping
		if (gameObject.tag == "Bot1" && Input.GetButton ("Jump")) {
			StartCoroutine (WaitForAnimation (animation, "jump"));

			//if bot1 is running
		} else if (gameObject.tag == "Bot1" && (Input.GetButton ("Vertical") || Input.GetButton ("Horizontal"))) {
			
			//only do running animation if another one isn't going
			if (!inAnim) {
				anim = "loop_run_funny";
				animation ["loop_run_funny"].speed = 7.0f;
			}
			
			//if bot2 is jumping
		} else if (gameObject.tag == "Bot2" && Input.GetButton ("Jump_alt")) {
			;
			StartCoroutine (WaitForAnimation (animation, "jump"));
			
			//if bot2 is running
		} else if (gameObject.tag == "Bot2" && (Input.GetButton ("Vertical_alt") || Input.GetButton ("Horizontal_alt"))) {
			
			//only do running animation if another one isn't going
			if (!inAnim) {
				anim = "loop_run_funny";
				animation ["loop_run_funny"].speed = 7.0f;
			}
		}

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
		}

		if (/*anim != "punch_hi_left" && anim != "punch_hi_right" &&*/((gameObject.tag == "Bot1" && Input.GetButton ("Punch")) || (gameObject.tag == "Bot2" && Input.GetButton ("Punch_alt")))) {


			if (Random.Range (0f, 1f) < 0.5f) {
				anim = "punch_hi_left";
			} else {
				anim = "punch_hi_right";
			}

			//punchSound = Resources.Load<AudioClip> ("servo13");
			//AudioSource.PlayClipAtPoint(punchSound,transform.position);
//			audio.clip = punchSound;
//			audio.Play ();
			
			//only run punch animation if another one isn't going.
			//this is so if we rapidly click the punch button, we don't
			//just repeat the first 0.1 seconds of the punch animation over
			//and over
			if (!inAnim) {
				StartCoroutine (WaitForAnimation (animation, anim));
				//punchSound = Resources.Load<AudioClip> ("servo2");
				//StartCoroutine (PlayPunch ());

				//AudioSource.PlayClipAtPoint(punchSound,transform.position);
				//audio.clip = punchSound;
				//audio.Play ();

			}

			punched = true;
			gOut = true;
			hasHit = false;
			//canPunch = false;
		} else {
			//if the fist running this script is the fist we want to be punching right now
			//canPunch = false;
			if (gOut) {
				Ray ray;
				RaycastHit hit;

				//Debug.DrawRay (transform.position, Vector3.left, Color.green, 5f);
				ray = new Ray (fist.transform.position, fist.transform.forward);
				//ray = new Ray (transform.position, Vector3.left);
				if (Physics.Raycast (ray, out hit)) {
					if (hit.distance < 1.85f) {
						if (hit.collider.tag == "Terrain" && !hasHit) {
							//Debug.Log ("2");
							//mt.ReplaceBlockCenter(20,0);
							Vector3 position = hit.point;
							position += (hit.normal * -0.5f);
							int x = Mathf.RoundToInt (position.x);
							int y = Mathf.RoundToInt (position.y);
							int z = Mathf.RoundToInt (position.z);
							if (mt.world.data [x, y, z] == 3) {
								//Debug.Log ("HealInc");
								bool powerupCheck = PowerUpGrab ();
								while (powerupCheck == false) {
									powerupCheck = PowerUpGrab ();
								}
							}
							if (gameObject.tag == "Bot1") {
								mt.ReplaceBlockExplodeDirection (dire1, dire2, p1.pow, hit, 0);
							}
							if (gameObject.tag == "Bot2") {
								mt.ReplaceBlockExplodeDirection (dire1, dire2, p2.pow, hit, 0);
							}
							//mt.ReplaceBlockExplode(0,hit,0);
							gOut = false;
							hasHit = true;
							//punched = false;
						}
						if ((hit.collider.tag == "P1Hit" || hit.collider.tag == "Player1" && !hasHit) && gameObject.tag == "Bot2" && p2CanPunch) {
							StartCoroutine (PunchCooldown (2));
							p1.applyHit ();
							hasHit = true;
							gOut = false;
							//punched = false;
						}
						if ((hit.collider.tag == "P2Hit" || hit.collider.tag == "Player2" && !hasHit) && gameObject.tag == "Bot1" && p1CanPunch) {
							StartCoroutine (PunchCooldown (1));
							p2.applyHit ();
							hasHit = true;
							gOut = false;
							//punched = false;
						}
					}
				} else {
					hasHit = true;
					punched = false;
					//canPunch = true;
				}
			}
		}

		currentAnim.CrossFade (anim);
	}

	bool PowerUpGrab ()
	{
		if (gameObject.tag == "Bot1" && p1.hp == 10 && ammo.bullet == 10 && ammo.shotgun == 10 && ammo.rocket == 5 && ammo.missile == 1 
			&& ammo.cshotgun == 10 && ammo.crocket == 5 && ammo.cmissile == 1 && p1.pow == 2) {
			return true; //condition check for all powerups are full (so the powerup loop doesn't get stuck)
		}
		if (gameObject.tag == "Bot2" && p2.hp == 10 && ammo.bullet == 10 && ammo.shotgun == 10 && ammo.rocket == 5 && ammo.missile == 1 
			&& ammo.cshotgun == 10 && ammo.crocket == 5 && ammo.cmissile == 1 && p2.pow == 2) {
			return true; //condition check for all powerups are full (so the powerup loop doesn't get stuck)
		}
		powerupGen = Random.Range (0f, 1f);//pick the percentage value
		if (powerupGen < .25f) {//heal 25 percent of the time
			if (gameObject.tag == "Bot1" && p1.hp < 10) {
				p1.heal ();
				return true;
			} else if (gameObject.tag == "Bot2" && p2.hp < 10) {
				p2.heal ();
				return true;
			} else {
				return false;
			}
		} else if (powerupGen >= .25f && powerupGen < .35f) {//10 percent chance to power up their fist
			if (gameObject.tag == "Bot1" && p1.pow < 2) {
				p1.pow++;
				return true;
			} else if (gameObject.tag == "Bot2" && p2.hp < 2) {
				p2.pow++;
				return true;
			} else {
				return false;
			}
		} else if (powerupGen >= .35f && powerupGen < .5f) {//15 percent give 6 bullet count
			if (ammo.bullet < 10) {
				ammo.bullet += 6;
				if (ammo.bullet > 10) {
					ammo.bullet = 10;
				}
				return true;
			} else {
				return false;
			}
		} else if (powerupGen >= .5f && powerupGen < .6f) {//10 percent give 4 Shotgun
			if (ammo.shotgun < 10) {
				ammo.shotgun += 4;
				if (ammo.shotgun > 10) {
					ammo.shotgun = 10;
				}
				return true;
			} else {
				return false;
			}
		} else if (powerupGen >= .6f && powerupGen < .7f) {//10 percent give 4 Creator Shotgun
			if (ammo.cshotgun < 10) {
				ammo.cshotgun += 4;
				if (ammo.cshotgun > 10) {
					ammo.cshotgun = 10;
				}
				return true;
			} else {
				return false;
			}
		} else if (powerupGen >= .7f && powerupGen < .8f) {//10 percent give 2 Rockets
			if (ammo.rocket < 5) {
				ammo.rocket += 2;
				if (ammo.rocket > 5) {
					ammo.rocket = 5;
				}
				return true;
			} else {
				return false;
			}
		} else if (powerupGen >= .8f && powerupGen < .9f) {//10 percent give 2 Creator Rockets
			if (ammo.crocket < 5) {
				ammo.crocket += 2;
				if (ammo.crocket > 5) {
					ammo.crocket = 5;
				}
				return true;
			} else {
				return false;
			}
		} else if (powerupGen >= .9f && powerupGen < .95f) {//5 percent give Airstrike Missile
			if (ammo.missile < 1) {
				ammo.missile = 1;
				return true;
			} else {
				return false;
			}
		} else if (powerupGen >= .95f && powerupGen <= 1f) {//5 percent give Creator Airstrike Missile
			if (ammo.cmissile < 1) {
				ammo.cmissile = 1;
				return true;
			} else {
				return false;
			}
		} else {
			return false;
		}
	}

	private IEnumerator WaitForAnimation (Animation animation, string a)
	{
		anim = a;
		inAnim = true;
		yield return new WaitForSeconds (currentAnim.clip.length);
		anim = "loop_idle";
		inAnim = false;
	}

	private IEnumerator PlayPunch ()
	{
		//audio.PlayOneShot(punchSound);
		//audio.clip = punchSound;
		//audio.Play ();
		//AudioSource.PlayClipAtPoint(punchSound,transform.position);
		yield return new WaitForSeconds (2f);


	}

	private IEnumerator PunchCooldown (int player)
	{
		if (player == 1) {
			p1CanPunch = false;
			yield return new WaitForSeconds (1f);
			p1CanPunch = true;
		} else if (player == 2) {
			p2CanPunch = false;
			yield return new WaitForSeconds (1f);
			p2CanPunch = true;
		}
		
	}
}
