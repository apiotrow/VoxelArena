using UnityEngine;
using System.Collections;

public class SettingController : MonoBehaviour {
	// Max/min values
	// -1 = off; max+1 = inf
	public int healthMax = 10;
	public int healthMin = 1;
	public int fistMax = 2;
	public int fistMin = 0;
	public int pistolMax = 11;
	public int pistolMin = -1;
	public int shotgunMax = 11;
	public int shotgunMin = -1;
	public int rocketMax = 6;
	public int rocketMin = -1;
	public int airstrikeMax = 2;
	public int airstrikeMin = -1;

	// Player starting values
	public int health = 5;
	public int fist = 0;
	public int pistol = 5;
	public int cShotgun = 0;
	public int dShotgun = 0;
	public int cRocket = 0;
	public int dRocket = 0;
	public int cAirstrike = 0;
	public int dAirstrike = 0;
	
	// Holds materials for mesh swaps
	public Material zero;
	public Material one;
	public Material two;
	public Material three;
	public Material four;
	public Material five;
	public Material six;
	public Material seven;
	public Material eight;
	public Material nine;
	public Material ten;
	public Material off;
	public Material inf;
	
	//Holds gameobjects to change
	public GameObject HealthDisplay;
	public GameObject FistDisplay;
	public GameObject PistolDisplay;
	public GameObject DShotgunDisplay;
	public GameObject CShotgunDisplay;
	public GameObject DRocketDisplay;
	public GameObject CRocketDisplay;
	public GameObject DAirstrikeDisplay;
	public GameObject CAirstrikeDisplay;

	// Update states
	public bool updateHealth = true;
	public bool updateFist = false;
	public bool updatePistol = false;
	public bool updateDShotgun = false;
	public bool updateCShotgun = false;
	public bool updateDRocket = false;
	public bool updateCRocket = false;
	public bool updateDAirstrike = false;
	public bool updateCAirstrike = false;
	public bool retreat = false;
	public bool gameStarter = false;

	public bool canShift = true;
	Pauser pause;

	void Start(){
		pause = GameObject.FindGameObjectWithTag ("Pauser").GetComponent ("Pauser") as Pauser;
	}

	void UpdateIncSwapper(){
		if (updateHealth) {
			updateHealth = false;
			updateFist = true;
		}else if (updateFist) {
			updateFist = false;
			updatePistol = true;
		}else if (updatePistol) {
			updatePistol = false;
			updateDShotgun = true;
		}else if (updateDShotgun) {
			updateDShotgun = false;
			updateCShotgun = true;
		}else if (updateCShotgun) {
			updateCShotgun = false;
			updateDRocket = true;
		}else if (updateDRocket) {
			updateDRocket = false;
			updateCRocket = true;
		}else if (updateCRocket) {
			updateCRocket = false;
			updateDAirstrike = true;
		}else if (updateDAirstrike) {
			updateDAirstrike = false;
			updateCAirstrike = true;
		}else if (updateCAirstrike) {
			updateCAirstrike = false;
			retreat = true;
		}else if (retreat) {
			retreat = false;
			gameStarter = true;
		}
	}

	void UpdateDecSwapper(){
		if (gameStarter) {
			gameStarter = false;
			retreat = true;
		}else if (updateFist) {
			updateFist = false;
			updateHealth = true;
		}else if (updatePistol) {
			updatePistol = false;
			updateFist = true;
		}else if (updateDShotgun) {
			updateDShotgun = false;
			updatePistol = true;
		}else if (updateCShotgun) {
			updateCShotgun = false;
			updateDShotgun = true;
		}else if (updateDRocket) {
			updateDRocket = false;
			updateCShotgun = true;
		}else if (updateCRocket) {
			updateCRocket = false;
			updateDRocket = true;
		}else if (updateDAirstrike) {
			updateDAirstrike = false;
			updateCRocket = true;
		}else if (updateCAirstrike) {
			updateCAirstrike = false;
			updateDAirstrike = true;
		}else if (retreat) {
			retreat = false;
			updateCAirstrike = true;
		}
	}

	void IncCurrVal(){
		Debug.Log ("True");
		if (updateHealth && health >= healthMin && health <= healthMax) {
			health += 1;
		}else if (updateFist && fist >= fistMin && fist <= fistMax) {
			fist += 1;
		}else if (updateDShotgun && dShotgun >= shotgunMin && dShotgun <= shotgunMax) {
			dShotgun += 1;
		}else if (updateCShotgun && cShotgun >= shotgunMin && cShotgun <= shotgunMax) {
			cShotgun += 1;
		}else if (updateDRocket && dRocket >= rocketMin && dRocket <= rocketMax) {
			dRocket += 1;
		}else if (updateCRocket && cRocket >= rocketMin && cRocket <= rocketMax) {
			cRocket += 1;
		}else if (updateCAirstrike && cAirstrike >= airstrikeMin && cAirstrike <= airstrikeMax) {
			cAirstrike += 1;
		}else if (updateDAirstrike && dAirstrike >= airstrikeMin && dAirstrike <= airstrikeMax) {
			dAirstrike += 1;
		}
	}

	void DecCurrVal(){
		if (updateHealth && health >= healthMin && health <= healthMax) {
			health -= 1;
		}else if (updateFist && fist >= fistMin && fist <= fistMax) {
			fist -= 1;
		}else if (updateDShotgun && dShotgun >= shotgunMin && dShotgun <= shotgunMax) {
			dShotgun -= 1;
		}else if (updateCShotgun && cShotgun >= shotgunMin && cShotgun <= shotgunMax) {
			cShotgun -= 1;
		}else if (updateDRocket && dRocket >= rocketMin && dRocket <= rocketMax) {
			dRocket -= 1;
		}else if (updateCRocket && cRocket >= rocketMin && cRocket <= rocketMax) {
			cRocket -= 1;
		}else if (updateCAirstrike && cAirstrike >= airstrikeMin && cAirstrike <= airstrikeMax) {
			cAirstrike -= 1;
		}else if (updateDAirstrike && dAirstrike >= airstrikeMin && dAirstrike <= airstrikeMax) {
			dAirstrike -= 1;
		}
	}
	// Update is called once per frame
	void Update () {
		/*if(canShift){
			if(Input.GetAxis ("Vertical") > 0){
				UpdateIncSwapper();
				canShift = false;
			}
			if(Input.GetAxis ("Vertical") < 0){
				UpdateDecSwapper();
				canShift = false;
			}
			if(Input.GetButton ("Shoot")){
				IncCurrVal ();
			}
			if(Input.GetButton ("CShoot")){
				DecCurrVal ();
			}
		}*/
		// If health needs to be updated
		if (updateHealth && health >= healthMin && health <= healthMax) {
			switch (health) {
				case 0:
						HealthDisplay.renderer.material = zero;
						break;
				case 1:
						HealthDisplay.renderer.material = one;
						break;
				case 2:
						HealthDisplay.renderer.material = two;
						break;
				case 3:
						HealthDisplay.renderer.material = three;
						break;
				case 4:
						HealthDisplay.renderer.material = four;
						break;
				case 5:
						HealthDisplay.renderer.material = five;
						break;
				case 6:
						HealthDisplay.renderer.material = six;
						break;
				case 7:
						HealthDisplay.renderer.material = seven;
						break;
				case 8:
						HealthDisplay.renderer.material = eight;
						break;
				case 9:
						HealthDisplay.renderer.material = nine;
						break;
				case 10:
						HealthDisplay.renderer.material = ten;
						break;
			}
			updateHealth = false;
		}

		// If fist needs to be updated and fist is within range
		if (updateFist && fist >= fistMin && fist <= fistMax) {
			switch (fist) {
				case 0:
						FistDisplay.renderer.material = one;
						break;
				case 1:
						FistDisplay.renderer.material = two;
						break;
				case 2:
						FistDisplay.renderer.material = three;
						break;
			}
			updateFist = false;
		}

		// If pistol needs to be updated and pistol is within range
		if (updatePistol && pistol >= pistolMin && pistol <= pistolMax) {
			switch (pistol) {
				case -1:
						PistolDisplay.renderer.material = off;
						break;
				case 0:
						PistolDisplay.renderer.material = zero;
						break;
				case 1:
						PistolDisplay.renderer.material = one;
						break;
				case 2:
						PistolDisplay.renderer.material = two;
						break;
				case 3:
						PistolDisplay.renderer.material = three;
						break;
				case 4:
						PistolDisplay.renderer.material = four;
						break;
				case 5:
						PistolDisplay.renderer.material = five;
						break;
				case 6:
						PistolDisplay.renderer.material = six;
						break;
				case 7:
						PistolDisplay.renderer.material = seven;
						break;
				case 8:
						PistolDisplay.renderer.material = eight;
						break;
				case 9:
						PistolDisplay.renderer.material = nine;
						break;
				case 10:
						PistolDisplay.renderer.material = ten;
						break;
				case 11:
						PistolDisplay.renderer.material = inf;
						break;
			}
			updatePistol = false;
		}

		// If dShotgun needs to be updated and dShotgun is within range
		if (updateDShotgun && dShotgun >= shotgunMin && dShotgun <= shotgunMax) {
			switch (dShotgun) {
				case -1:
					DShotgunDisplay.renderer.material = off;
					break;
				case 0:
					DShotgunDisplay.renderer.material = zero;
					break;
				case 1:
					DShotgunDisplay.renderer.material = one;
					break;
				case 2:
					DShotgunDisplay.renderer.material = two;
					break;
				case 3:
					DShotgunDisplay.renderer.material = three;
					break;
				case 4:
					DShotgunDisplay.renderer.material = four;
					break;
				case 5:
					DShotgunDisplay.renderer.material = five;
					break;
				case 6:
					DShotgunDisplay.renderer.material = six;
					break;
				case 7:
					DShotgunDisplay.renderer.material = seven;
					break;
				case 8:
					DShotgunDisplay.renderer.material = eight;
					break;
				case 9:
					DShotgunDisplay.renderer.material = nine;
					break;
				case 10:
					DShotgunDisplay.renderer.material = ten;
					break;
				case 11:
					DShotgunDisplay.renderer.material = inf;
					break;
			}
			updateDShotgun = false;
		}

		// If cShotgun needs to be updated and cShotgun is within range
		if (updateCShotgun && cShotgun >= shotgunMin && cShotgun <= shotgunMax) {
			switch (cShotgun) {
				case -1:
					CShotgunDisplay.renderer.material = off;
					break;
				case 0:
					CShotgunDisplay.renderer.material = zero;
					break;
				case 1:
					CShotgunDisplay.renderer.material = one;
					break;
				case 2:
					CShotgunDisplay.renderer.material = two;
					break;
				case 3:
					CShotgunDisplay.renderer.material = three;
					break;
				case 4:
					CShotgunDisplay.renderer.material = four;
					break;
				case 5:
					CShotgunDisplay.renderer.material = five;
					break;
				case 6:
					CShotgunDisplay.renderer.material = six;
					break;
				case 7:
					CShotgunDisplay.renderer.material = seven;
					break;
				case 8:
					CShotgunDisplay.renderer.material = eight;
					break;
				case 9:
					CShotgunDisplay.renderer.material = nine;
					break;
				case 10:
					CShotgunDisplay.renderer.material = ten;
					break;
				case 11:
					CShotgunDisplay.renderer.material = inf;
					break;
			}
			updateCShotgun = false;
		}
		
		// If dRocket needs to be updated and dRocket is within range
		if (updateDRocket && dRocket >= rocketMin && dRocket <= rocketMax) {
			switch (dRocket) {
				case -1:
					DRocketDisplay.renderer.material = off;
					break;
				case 0:
					DRocketDisplay.renderer.material = zero;
					break;
				case 1:
					DRocketDisplay.renderer.material = one;
					break;
				case 2:
					DRocketDisplay.renderer.material = two;
					break;
				case 3:
					DRocketDisplay.renderer.material = three;
					break;
				case 4:
					DRocketDisplay.renderer.material = four;
					break;
				case 5:
					DRocketDisplay.renderer.material = five;
					break;
				case 6:
					DRocketDisplay.renderer.material = inf;
					break;
			}
			updateDRocket = false;
		}

		// If cRocket needs to be updated and cRocket is within range
		if (updateCRocket && cRocket >= rocketMin && cRocket <= rocketMax) {
			switch (cRocket) {
				case -1:
					CRocketDisplay.renderer.material = off;
					break;
				case 0:
					CRocketDisplay.renderer.material = zero;
					break;
				case 1:
					CRocketDisplay.renderer.material = one;
					break;
				case 2:
					CRocketDisplay.renderer.material = two;
					break;
				case 3:
					CRocketDisplay.renderer.material = three;
					break;
				case 4:
					CRocketDisplay.renderer.material = four;
					break;
				case 5:
					CRocketDisplay.renderer.material = five;
					break;
				case 6:
					CRocketDisplay.renderer.material = inf;
					break;
			}
			updateCRocket = false;
		}

		// If dAirstrike needs to be updated and dAirstrike is within range
		if (updateDAirstrike && dAirstrike >= airstrikeMin && dAirstrike <= airstrikeMax) {
			switch (dAirstrike) {
			case -1:
				DAirstrikeDisplay.renderer.material = off;
				break;
			case 0:
				DAirstrikeDisplay.renderer.material = zero;
				break;
			case 1:
				DAirstrikeDisplay.renderer.material = one;
				break;
			case 2:
				DAirstrikeDisplay.renderer.material = inf;
				break;
			}
			updateDAirstrike = false;
		}

		// If cAirstrike needs to be updated and cAirstrike is within range
		if (updateCAirstrike && cAirstrike >= airstrikeMin && cAirstrike <= airstrikeMax) {
			switch (cAirstrike) {
			case -1:
				CAirstrikeDisplay.renderer.material = off;
				break;
			case 0:
				CAirstrikeDisplay.renderer.material = zero;
				break;
			case 1:
				CAirstrikeDisplay.renderer.material = one;
				break;
			case 2:
				CAirstrikeDisplay.renderer.material = inf;
				break;
			}
			updateCAirstrike = false;
		}
		/*
		// If butt needs to be updated and butt is within range
		if(updateButt && butt >= buttMin && butt <= buttMax){
			switch (butt){
				case -1:
					ButtDisplay.renderer.material = off;
					break;
				case 0:
					ButtDisplay.renderer.material = zero;
					break;
				case 1:
					ButtDisplay.renderer.material = one;
					break;
				case 2:
					ButtDisplay.renderer.material = two;
					break;
				case 3:
					ButtDisplay.renderer.material = three;
					break;
				case 4:
					ButtDisplay.renderer.material = four;
					break;
				case 5:
					ButtDisplay.renderer.material = five;
				}
		}
		*/
		pause.health = health;
		pause.fistpow = fist;
		pause.sBullet = pistol;
		pause.sRocket = dRocket;
		pause.sShotgun = dShotgun;
		pause.sAirstrike = dAirstrike;
		pause.sCRocket = cRocket;
		pause.sCShotgun = cShotgun;
		pause.sCAirstrike = cAirstrike;
		
	}


	IEnumerator shiftWait(){
		yield return new WaitForSeconds(.1f);
		canShift = true;
	}
}
