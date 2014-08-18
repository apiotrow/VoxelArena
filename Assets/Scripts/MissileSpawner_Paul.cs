using UnityEngine;
using System.Collections;
//utilized in shoot now, no longer needed.
public class MissileSpawner_Paul : MonoBehaviour {
	public GameObject missile;
	public GameObject cmissile;
	GameObject p1;
	GameObject p2;
	float distp1;
	float distp2;
	Vector3 dropspot;
	Vector3 firstDrop;
	Pauser pause;
	int offset;
	bool canFire;

	// Use this for initialization
	void Start () {
		canFire = true;
		dropspot = transform.position;
		firstDrop = dropspot;
		p1 = GameObject.FindGameObjectWithTag ("Player1");
		p2 = GameObject.FindGameObjectWithTag ("Player2");
		pause = GameObject.FindGameObjectWithTag ("Pauser").GetComponent ("Pauser") as Pauser;
	}
	
	// Update is called once per frame
	void Update () {
		/*if(!pause.paused){
		//Distance checks so that it can't go out of bounds
		distp1 = Vector2.Distance (new Vector2 (dropspot.x, dropspot.y), new Vector2 (p1.transform.position.x, p2.transform.position.z));
		distp2 = Vector2.Distance (new Vector2 (dropspot.x, dropspot.y), new Vector2 (p1.transform.position.x, p2.transform.position.z));
		//Press X
		if (Input.GetButton ("BigBootyBitches") && canFire) {
			//Regular missile
			//range checker to make sure it isn't spawning out of bounds.
			if(distp1 < 60 && distp2 < 60 && dropspot.x > 0 && dropspot.z > 0 && dropspot.x < 144 && dropspot.z < 144){
					for(offset = 1; offset < 4; offset++){
						Instantiate(missile, dropspot + new Vector3(offset,0,0), missile.transform.rotation);
						Instantiate(missile, dropspot + new Vector3(-1*offset,0,0), missile.transform.rotation);
					}
					canFire = false;
					StartCoroutine(shootWait ());
			//Constructor missile
			//Instantiate(cmissile, dropspot, missile.transform.rotation);
			//Move it to the Right
			//dropspot += new Vector3(1,0,0);
			//Move it to the Left
			//dropspot += new Vector3(-1,0,0);
			//Move it to the Up
			//dropspot += new Vector3(0,0,1);
			//Move it to the Down
			//dropspot += new Vector3(0,0,-1);
			//RandomMissileSpawn ();
			}else{
				dropspot = firstDrop;
			}
		}
		}*/
	}

	void RandomMissileSpawn(){
		//Vary the location by up to 10 up/down and left/right
		//dropspot += new Vector3 (Random.Range (-10, 10), 0, Random.Range (-10, 10));
		//Vary the location by up to 5 up/down and left/right
		dropspot += new Vector3 (Random.Range (-5, 5), 0, Random.Range (-5, 5));
	}
	IEnumerator shootWait(){
		yield return new WaitForSeconds(1f);
		canFire = true;
	}
}
