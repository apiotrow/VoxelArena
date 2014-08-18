using UnityEngine;
using System.Collections;

public class PlayerGUI : MonoBehaviour
{
	World world;
	ModifyTerrain mt;
	GameObject player;
	GameObject camera;
	private GUIStyle buttonStyle = new GUIStyle ();
	private GUIStyle healthHeartStyle = new GUIStyle ();
	PlayerController p1;
	PlayerController p2;
	int p1hp;
	int p2hp;
	int healthBoxWidth = 120;
	int healthBoxHeight = 30;
	int powerUpHeadingWidth = 150;
	int powerUpHeadingHeight = 30;
	
	Shoot p1Shoot;
	float p1Bullet;
	float p1Rocket;
	float p1Shotgun;
	float p1CRocket;
	float p1CShotgun;
	float p1Missile;
	float p1CMissile;
	
	Shoot p2Shoot;
	float p2Bullet;
	float p2Rocket;
	float p2Shotgun;
	float p2CRocket;
	float p2CShotgun;
	float p2Missile;
	float p2CMissile;
	
	void DefineStyles ()
	{
		buttonStyle = GUI.skin.box;
		buttonStyle.normal.textColor = Color.white;
		buttonStyle.alignment = TextAnchor.MiddleCenter;
		buttonStyle.fontStyle = FontStyle.Bold;
		buttonStyle.padding.top = 4;
		buttonStyle.padding.left = 3;
		buttonStyle.fontSize = 20;
		//		buttonStyle.fixedWidth = healthBoxWidth;
		//		buttonStyle.fixedHeight = healthBoxHeight;
		
		healthHeartStyle = GUI.skin.box;
		healthHeartStyle.normal.textColor = Color.white;
		healthHeartStyle.alignment = TextAnchor.MiddleCenter;
		healthHeartStyle.fontStyle = FontStyle.Bold;
		healthHeartStyle.padding.top = 0;
		healthHeartStyle.padding.left = 0;
		healthHeartStyle.padding.right = 0;
		healthHeartStyle.padding.bottom = 0;
		//		healthHeartStyle.fixedWidth = 32;
		//		healthHeartStyle.fixedHeight = 32;
	}
	
	void OnGUI ()
	{
		DefineStyles ();
		
		//		buttonStyle.fixedWidth = healthBoxWidth;
		//		buttonStyle.fixedHeight = healthBoxHeight;
		//		//health displays
		//		float p1HealthBox = (Screen.width / 4) - (healthBoxWidth / 2);
		//		float p2HealthBox = ((Screen.width / 4) * 3) - (healthBoxHeight / 2);
		
		//		string health1Text = "Health: " + (Mathf.Floor (p1hp)).ToString ();
		//		GUI.Box (new Rect (p1HealthBox, 0, healthBoxWidth, healthBoxHeight), health1Text, buttonStyle);
		//		
		//		string health2Text = "Health: " + (Mathf.Floor (p2hp)).ToString ();
		//		GUI.Box (new Rect (p2HealthBox, 0, healthBoxWidth, healthBoxHeight), health2Text, buttonStyle);
		
		
		
		
		
		//powerup heading
		float p1PowerupHeading = 0;
		float p2PowerupHeading = 0.5f;
		
		//string powerupText = "Powerups";
		//GUI.Box (new Rect (p1PowerupHeading, 0, powerUpHeadingWidth, powerUpHeadingHeight), powerupText, buttonStyle);
		
		
		
		
		
		
		
		
		
		/*
		 * Heart health stuff
		 * And melee stuff
		 */
		
		//for redundancy
		p1 = GameObject.FindGameObjectWithTag ("P1Hit").GetComponent ("PlayerController") as PlayerController;
		p2 = GameObject.FindGameObjectWithTag ("P2Hit").GetComponent ("PlayerController") as PlayerController;
		p1Shoot = GameObject.FindGameObjectWithTag ("BSpawnP1").GetComponent ("Shoot") as Shoot;
		p2Shoot = GameObject.FindGameObjectWithTag ("BSpawnP2").GetComponent ("Shoot") as Shoot;
		
		Texture2D heartImage = Resources.Load<Texture2D> ("heart_full_32x32_1");
		Texture2D fistImage = Resources.Load<Texture2D> ("fist");
		Texture2D sledgeImage = Resources.Load<Texture2D> ("sledgehammer");
		Texture2D maceImage = Resources.Load<Texture2D> ("mace");
		
		float heartBoxDimensions = ((Screen.width / 3.8f) / 10f);
		
		healthHeartStyle.fixedWidth = heartBoxDimensions;
		healthHeartStyle.fixedHeight = heartBoxDimensions;
		
		/*
		 * Player 1 health/melee
		 */
		
		//pistol stuff
		float heart1 = 10;
		float health1 = heart1 + heartBoxDimensions;
		
		//fist stuff
		float fist1 = heartBoxDimensions * 3;
		
		//sledge stuff
		float sledge1 = fist1 + heartBoxDimensions + 10;
		
		//mace stuff
		float mace1 = sledge1 + heartBoxDimensions + 60;
		
		
		//health
		GUI.DrawTexture ((new Rect (heart1, 0, heartBoxDimensions, heartBoxDimensions)), 
		                 heartImage, ScaleMode.ScaleToFit, true, 0f);
		string healthText = (Mathf.Floor (p1.hp)).ToString ();
		if (GUI.Button (new Rect (health1, 0, 
		                          heartBoxDimensions, heartBoxDimensions), healthText, buttonStyle)) {
		}
		
		//melee
		//		string meleeText = "Melee: Fists";
		//		if(p1.pow == 0){
		//			meleeText = "Melee: Fists";
		//		}else if(p1.pow == 1){
		//			meleeText = "Melee: Sledgefists";
		//		}else if (p1.pow == 2){
		//			meleeText = "Melee: Macefists";
		//		}
		//
		//
		//		if (GUI.Button (new Rect (heartBoxDimensions * 4, 0, 
		//		                          1000, heartBoxDimensions), meleeText, buttonStyle)) {
		//		}
		
		//		//fist
		//		GUI.DrawTexture ((new Rect (fist1, 0, heartBoxDimensions, heartBoxDimensions)), 
		//		                 fistImage, ScaleMode.ScaleToFit, true, 0f);
		//		
		//		//sledgehammer
		//		GUI.DrawTexture ((new Rect (sledge1, -20, heartBoxDimensions * 3, heartBoxDimensions * 3)), 
		//		                 sledgeImage, ScaleMode.ScaleToFit, true, 0f);
		//
		//		//mace
		//		GUI.DrawTexture ((new Rect (mace1, 0, heartBoxDimensions * 2, heartBoxDimensions)), 
		//		                 maceImage, ScaleMode.ScaleToFit, true, 0f);
		
		
		
		
		/*
		 * Player 2 health/melee
		 */
		//health hearts player 2sq
		//pistol stuff
		float heart12 = 10 + (Screen.width / 2);
		float health12 = heart12 + heartBoxDimensions;
		
		//fist stuff
		float fist12 = heartBoxDimensions * 3 + (Screen.width / 2);
		
		//sledge stuff
		float sledge12 = fist12 + heartBoxDimensions + 10;
		
		//mace stuff
		float mace12 = sledge12 + heartBoxDimensions + 60;
		
		
		//health
		GUI.DrawTexture ((new Rect (heart12, 0, heartBoxDimensions, heartBoxDimensions)), 
		                 heartImage, ScaleMode.ScaleToFit, true, 0f);
		healthText = (Mathf.Floor (p2.hp)).ToString ();
		if (GUI.Button (new Rect (health12, 0, 
		                          heartBoxDimensions, heartBoxDimensions), healthText, buttonStyle)) {
		}
		
		//		//fist
		//		GUI.DrawTexture ((new Rect (fist12, 0, heartBoxDimensions * 2, heartBoxDimensions)), 
		//		                 fistImage, ScaleMode.ScaleToFit, true, 0f);
		//		
		//		//sledgehammer
		//		GUI.DrawTexture ((new Rect (sledge12, -20, heartBoxDimensions * 3, heartBoxDimensions * 3)), 
		//		                 sledgeImage, ScaleMode.ScaleToFit, true, 0f);
		//		
		//		//mace
		//		GUI.DrawTexture ((new Rect (mace12, 0, heartBoxDimensions * 2, heartBoxDimensions)), 
		//		                 maceImage, ScaleMode.ScaleToFit, true, 0f);
		
		
		
		
		
		/*
		 * Weapon stuff
		 * 
		 */
		
		
		Texture2D bulletammo = Resources.Load<Texture2D> ("pistol");
		
		Texture2D drocket_ammo = Resources.Load<Texture2D> ("rocket");
		Texture2D crocket_ammo = Resources.Load<Texture2D> ("rocket_gray");
		
		Texture2D dshotgun_ammo = Resources.Load<Texture2D> ("shotgun");
		Texture2D cshotgun_ammo = Resources.Load<Texture2D> ("shotgun_gray");
		
		Texture2D dmissile_ammo = Resources.Load<Texture2D> ("airstrike");
		Texture2D cmissile_ammo = Resources.Load<Texture2D> ("airstrike_gray");
		
		
		
		float weaponBoxDimensions = ((Screen.width / 3.8f) / 10f);
		
		
		/*
		 * Player 1 weapons
		 */
		
		//pistol stuff
		float weap1 = 10;
		float ammo1 = weap1 + weaponBoxDimensions;
		
		//rocket stuff
		float weap2 = ammo1 + (weaponBoxDimensions * 1.5f);
		float ammo2 = weap2 + weaponBoxDimensions;
		
		//shotgun stuff
		float weap3 = ammo2 + (weaponBoxDimensions * 1.5f);
		float ammo3 = weap3 + weaponBoxDimensions;
		
		//missile stuff
		float weap4 = ammo3 + (weaponBoxDimensions * 1.5f);
		float ammo4 = weap4 + weaponBoxDimensions;
		
		//row 1 stuff
		float toprow = 45 + 77;
		float bottomrow = 77 - 10;
		
		
		//weapon highlight stuff
		Texture2D weapselect = Resources.Load<Texture2D> ("weapon_cursor_r");
		
		float selectplace = weap1 - 15;
		if (p1Shoot.ammonum == 0) {
			selectplace = weap1 - 11f;		
		}else if(p1Shoot.ammonum == 1) {
			selectplace = weap2 - 11f;	
		}else if(p1Shoot.ammonum == 2) {
			selectplace = weap3 - 11f;	
		}else if(p1Shoot.ammonum == 3) {
			selectplace = weap4 - 11f;	
		}
		GUI.DrawTexture ((new Rect (selectplace, toprow - 65, heartBoxDimensions * 2.5f, heartBoxDimensions * 2.5f)), 
		                 weapselect, ScaleMode.ScaleToFit, true, 0f);
		
		
		//bullet
		GUI.DrawTexture ((new Rect (weap1, (bottomrow + toprow) / 2, weaponBoxDimensions, weaponBoxDimensions)),
		                 bulletammo, ScaleMode.ScaleToFit, true, 0f);
		
		string ammo1Text = (Mathf.Floor (p1Shoot.bullet)).ToString ();
		if (GUI.Button (new Rect (ammo1, (bottomrow + toprow) / 2, 
		                          weaponBoxDimensions, weaponBoxDimensions), ammo1Text, buttonStyle)) {
		}
		
		
		
		//crocket
		GUI.DrawTexture ((new Rect (weap2,toprow, weaponBoxDimensions, weaponBoxDimensions)),
		                 crocket_ammo, ScaleMode.ScaleToFit, true, 0f);
		
		ammo1Text = (Mathf.Floor (p1Shoot.crocket)).ToString ();
		if (GUI.Button (new Rect (ammo2, toprow, 
		                          weaponBoxDimensions, weaponBoxDimensions), ammo1Text, buttonStyle)) {
		}
		
		//drocket
		GUI.DrawTexture ((new Rect (weap2, bottomrow, weaponBoxDimensions, weaponBoxDimensions)),
		                 drocket_ammo, ScaleMode.ScaleToFit, true, 0f);
		
		ammo1Text = (Mathf.Floor (p1Shoot.rocket)).ToString ();
		if (GUI.Button (new Rect (ammo2, bottomrow, 
		                          weaponBoxDimensions, weaponBoxDimensions), ammo1Text, buttonStyle)) {
		}
		
		
		
		//cshotgun
		GUI.DrawTexture ((new Rect (weap3,toprow, weaponBoxDimensions, weaponBoxDimensions)),
		                 cshotgun_ammo, ScaleMode.ScaleToFit, true, 0f);
		
		ammo1Text = (Mathf.Floor (p1Shoot.cshotgun)).ToString ();
		if (GUI.Button (new Rect (ammo3, toprow, 
		                          weaponBoxDimensions, weaponBoxDimensions), ammo1Text, buttonStyle)) {
		}
		
		//dshotgun
		GUI.DrawTexture ((new Rect (weap3, bottomrow, weaponBoxDimensions, weaponBoxDimensions)),
		                 dshotgun_ammo, ScaleMode.ScaleToFit, true, 0f);
		
		ammo1Text = (Mathf.Floor (p1Shoot.shotgun)).ToString ();
		if (GUI.Button (new Rect (ammo3, bottomrow, 
		                          weaponBoxDimensions, weaponBoxDimensions), ammo1Text, buttonStyle)) {
		}
		
		
		//cmissile
		GUI.DrawTexture ((new Rect (weap4,toprow, weaponBoxDimensions, weaponBoxDimensions)),
		                 cmissile_ammo, ScaleMode.ScaleToFit, true, 0f);
		
		ammo1Text = (Mathf.Floor (p1Shoot.cmissile)).ToString ();
		if (GUI.Button (new Rect (ammo4, toprow, 
		                          weaponBoxDimensions, weaponBoxDimensions), ammo1Text, buttonStyle)) {
		}
		
		//dmissile
		GUI.DrawTexture ((new Rect (weap4, bottomrow, weaponBoxDimensions, weaponBoxDimensions)),
		                 dmissile_ammo, ScaleMode.ScaleToFit, true, 0f);
		
		ammo1Text = (Mathf.Floor (p1Shoot.missile)).ToString ();
		if (GUI.Button (new Rect (ammo4, bottomrow, 
		                          weaponBoxDimensions, weaponBoxDimensions), ammo1Text, buttonStyle)) {
		}
		
		
		
		
		
		/*
		 * Player 2 weapons
		 */
		
		//pistol stuff
		float weap12 = 10 + (Screen.width / 2);
		float ammo12 = weap12 + weaponBoxDimensions;
		
		//rocket stuff
		float weap22 = ammo12 + (weaponBoxDimensions * 1.5f);
		float ammo22 = weap22 + weaponBoxDimensions;
		
		//shotgun stuff
		float weap32 = ammo22 + (weaponBoxDimensions * 1.5f);
		float ammo32 = weap32 + weaponBoxDimensions;
		
		//missile stuff
		float weap42 = ammo32 + (weaponBoxDimensions * 1.5f);
		float ammo42 = weap42 + weaponBoxDimensions;
		
		//row 1 stuff
		toprow = 45 + 77;
		bottomrow = 77 - 10;
		
		//weapon highlight stuff
		weapselect = Resources.Load<Texture2D> ("weapon_cursor_r");
		
		selectplace = weap12 - 15;
		if (p2Shoot.ammonum == 0) {
			selectplace = weap12 - 11f;		
		}else if(p2Shoot.ammonum == 1) {
			selectplace = weap22 - 11f;	
		}else if(p2Shoot.ammonum == 2) {
			selectplace = weap32 - 11f;	
		}else if(p2Shoot.ammonum == 3) {
			selectplace = weap42 - 11f;	
		}
		GUI.DrawTexture ((new Rect (selectplace, toprow - 65, heartBoxDimensions * 2.5f, heartBoxDimensions * 2.5f)), 
		                 weapselect, ScaleMode.ScaleToFit, true, 0f);
		
		//bullet
		GUI.DrawTexture ((new Rect (weap12, (bottomrow + toprow) / 2, weaponBoxDimensions, weaponBoxDimensions)),
		                 bulletammo, ScaleMode.ScaleToFit, true, 0f);
		
		ammo1Text = (Mathf.Floor (p2Shoot.bullet)).ToString ();
		if (GUI.Button (new Rect (ammo12, (bottomrow + toprow) / 2, 
		                          weaponBoxDimensions, weaponBoxDimensions), ammo1Text, buttonStyle)) {
		}
		
		
		
		//crocket
		GUI.DrawTexture ((new Rect (weap22,toprow, weaponBoxDimensions, weaponBoxDimensions)),
		                 crocket_ammo, ScaleMode.ScaleToFit, true, 0f);
		
		ammo1Text = (Mathf.Floor (p2Shoot.crocket)).ToString ();
		if (GUI.Button (new Rect (ammo22, toprow, 
		                          weaponBoxDimensions, weaponBoxDimensions), ammo1Text, buttonStyle)) {
		}
		
		//drocket
		GUI.DrawTexture ((new Rect (weap22, bottomrow, weaponBoxDimensions, weaponBoxDimensions)),
		                 drocket_ammo, ScaleMode.ScaleToFit, true, 0f);
		
		ammo1Text = (Mathf.Floor (p2Shoot.rocket)).ToString ();
		if (GUI.Button (new Rect (ammo22, bottomrow, 
		                          weaponBoxDimensions, weaponBoxDimensions), ammo1Text, buttonStyle)) {
		}
		
		
		
		//cshotgun
		GUI.DrawTexture ((new Rect (weap32,toprow, weaponBoxDimensions, weaponBoxDimensions)),
		                 cshotgun_ammo, ScaleMode.ScaleToFit, true, 0f);
		
		ammo1Text = (Mathf.Floor (p2Shoot.cshotgun)).ToString ();
		if (GUI.Button (new Rect (ammo32, toprow, 
		                          weaponBoxDimensions, weaponBoxDimensions), ammo1Text, buttonStyle)) {
		}
		
		//dshotgun
		GUI.DrawTexture ((new Rect (weap32, bottomrow, weaponBoxDimensions, weaponBoxDimensions)),
		                 dshotgun_ammo, ScaleMode.ScaleToFit, true, 0f);
		
		ammo1Text = (Mathf.Floor (p2Shoot.shotgun)).ToString ();
		if (GUI.Button (new Rect (ammo32, bottomrow, 
		                          weaponBoxDimensions, weaponBoxDimensions), ammo1Text, buttonStyle)) {
		}
		
		
		//cmissile
		GUI.DrawTexture ((new Rect (weap42,toprow, weaponBoxDimensions, weaponBoxDimensions)),
		                 cmissile_ammo, ScaleMode.ScaleToFit, true, 0f);
		
		ammo1Text = (Mathf.Floor (p2Shoot.cmissile)).ToString ();
		if (GUI.Button (new Rect (ammo42, toprow, 
		                          weaponBoxDimensions, weaponBoxDimensions), ammo1Text, buttonStyle)) {
		}
		
		//dmissile
		GUI.DrawTexture ((new Rect (weap42, bottomrow, weaponBoxDimensions, weaponBoxDimensions)),
		                 dmissile_ammo, ScaleMode.ScaleToFit, true, 0f);
		
		ammo1Text = (Mathf.Floor (p2Shoot.missile)).ToString ();
		if (GUI.Button (new Rect (ammo42, bottomrow, 
		                          weaponBoxDimensions, weaponBoxDimensions), ammo1Text, buttonStyle)) {
		}
		
		
		
		
		
		
		
		
		
		
		
		
		//		p1Shoot = GameObject.FindGameObjectWithTag ("BSpawnP1").GetComponent ("Shoot") as Shoot;
		//
		//
		//		int weaponTopLeft = 40;
		
		//		GUIStyle cBox = new GUIStyle (GUI.skin.box);
		//		cBox.normal.background = Resources.Load<Texture2D> ("redbg");
		//		cBox.fixedWidth = 100;
		//		GUI.Box (new Rect (weaponBoxDimensions + 10, weaponTopLeft, 1, 1), "", cBox);
		
		/*
		GUI.color = Color.white;
		//bullet stuff
		if (p1Shoot.ammonum == 0) {
			int boxWidth = 120;
			int boxHeight = 30;
//			GUI.DrawTexture ((new Rect ((weaponBoxDimensions) + 10, 64, weaponBoxDimensions, weaponBoxDimensions)),
//							                 bulletammo, ScaleMode.ScaleToFit, true, 0f);
//
//			string ammo1Text = (Mathf.Floor (p1Shoot.bullet)).ToString ();
//			if (GUI.Button (new Rect ((weaponBoxDimensions) + 10 + weaponBoxDimensions, 64, 
//			                          weaponBoxDimensions, weaponBoxDimensions), ammo1Text, buttonStyle)) {
//						}

//			for (int h = 0; h < p1Shoot.bullet; h++) {
////				GUI.DrawTexture ((new Rect ((h * weaponBoxDimensions) + 10, 64, weaponBoxDimensions, weaponBoxDimensions)),
////				                 bulletammo, ScaleMode.ScaleToFit, true, 0f);
//
////				if (GUI.Button((new Rect ((h * weaponBoxDimensions) + 10, 64, weaponBoxDimensions, weaponBoxDimensions)), bulletammo)){
////
////				}
//
//				//GUI.Label((new Rect ((h * weaponBoxDimensions) + 10, 64, weaponBoxDimensions, weaponBoxDimensions)), bulletammo);
//				
//			}
			
			//rocket stuff
		} else if (p1Shoot.ammonum == 1) {

//			GUI.DrawTexture ((new Rect ((weaponBoxDimensions) + 10 + weaponBoxDimensions, 64, weaponBoxDimensions, weaponBoxDimensions)),
//			                 crocket_ammo, ScaleMode.ScaleToFit, true, 0f);
//			
//			string ammo1Text = (Mathf.Floor (p1Shoot.crocket)).ToString ();
//			if (GUI.Button (new Rect ((weaponBoxDimensions) + 10 + weaponBoxDimensions + weaponBoxDimensions, 64, 
//			                          weaponBoxDimensions, weaponBoxDimensions), ammo1Text, buttonStyle)) {
//			}
			
		int rowLength = 5;
//			//destruction rocket
//			for (int h = 0; h < p1Rocket; h++) {
//				
//				if (h < rowLength) {
//					GUI.DrawTexture ((new Rect ((h * weaponBoxDimensions) + 10, weaponTopLeft, 
//					                            weaponBoxDimensions, weaponBoxDimensions)),
//					                 drocket_ammo, ScaleMode.ScaleToFit, true, 0f);
//				} else {
//					GUI.DrawTexture ((new Rect (((h - rowLength) * weaponBoxDimensions) + 10, weaponTopLeft + 32, 
//					                            weaponBoxDimensions, weaponBoxDimensions)),
//					                 drocket_ammo, ScaleMode.ScaleToFit, true, 0f);
//				}
//				
//			}
			
			
			//construction rocket
			for (int h = 0; h < p1CRocket; h++) {
				
				if (h < rowLength) {
					GUI.DrawTexture ((new Rect ((h * weaponBoxDimensions) + (rowLength * weaponBoxDimensions) + 30, weaponTopLeft, 
					                            weaponBoxDimensions, weaponBoxDimensions)),
					                 crocket_ammo, ScaleMode.ScaleToFit, true, 0f);
				} else {
					GUI.DrawTexture ((new Rect (((h - rowLength) * weaponBoxDimensions) + (rowLength * weaponBoxDimensions) + 30, weaponTopLeft + 32, 
					                            weaponBoxDimensions, weaponBoxDimensions)),
					                 crocket_ammo, ScaleMode.ScaleToFit, true, 0f);
				}
				
			}
			
			//shotgun stuff
		} else if (p1Shoot.ammonum == 2) {
			
			int rowLength = 5;
			//destruction shotgun
			for (int h = 0; h < p1Shotgun; h++) {
				
				if (h < rowLength) {
					GUI.DrawTexture ((new Rect ((h * weaponBoxDimensions) + 10, weaponTopLeft, 
					                            weaponBoxDimensions, weaponBoxDimensions)),
					                 dshotgun_ammo, ScaleMode.ScaleToFit, true, 0f);
				} else {
					GUI.DrawTexture ((new Rect (((h - rowLength) * weaponBoxDimensions) + 10, weaponTopLeft + 32, 
					                            weaponBoxDimensions, weaponBoxDimensions)),
					                 dshotgun_ammo, ScaleMode.ScaleToFit, true, 0f);
				}
				
			}
			
			
			//construction shotgun
			for (int h = 0; h < p1CShotgun; h++) {
				
				if (h < rowLength) {
					GUI.DrawTexture ((new Rect ((h * weaponBoxDimensions) + (rowLength * weaponBoxDimensions) + 30, weaponTopLeft, 
					                            weaponBoxDimensions, weaponBoxDimensions)),
					                 cshotgun_ammo, ScaleMode.ScaleToFit, true, 0f);
				} else {
					GUI.DrawTexture ((new Rect (((h - rowLength) * weaponBoxDimensions) + (rowLength * weaponBoxDimensions) + 30, weaponTopLeft + 32, 
					                            weaponBoxDimensions, weaponBoxDimensions)),
					                 cshotgun_ammo, ScaleMode.ScaleToFit, true, 0f);
				}
				
			}
			
		} else if (p1Shoot.ammonum == 3) {
			
			int rowLength = 5;
			//destruction airstrike
			for (int h = 0; h < p1Missile; h++) {
				
				if (h < rowLength) {
					GUI.DrawTexture ((new Rect ((h * weaponBoxDimensions) + 10, weaponTopLeft, 
					                            weaponBoxDimensions, weaponBoxDimensions)),
					                 cmissile_ammo, ScaleMode.ScaleToFit, true, 0f);
				} else {
					GUI.DrawTexture ((new Rect (((h - rowLength) * weaponBoxDimensions) + 10, weaponTopLeft + 32, 
					                            weaponBoxDimensions, weaponBoxDimensions)),
					                 cmissile_ammo, ScaleMode.ScaleToFit, true, 0f);
				}
				
			}
			
			
			//construction airstrike
			for (int h = 0; h < p1CMissile; h++) {
				
				if (h < rowLength) {
					GUI.DrawTexture ((new Rect ((h * weaponBoxDimensions) + (rowLength * weaponBoxDimensions) + 30, weaponTopLeft, 
					                            weaponBoxDimensions, weaponBoxDimensions)),
					                 dmissile_ammo, ScaleMode.ScaleToFit, true, 0f);
				} else {
					GUI.DrawTexture ((new Rect (((h - rowLength) * weaponBoxDimensions) + (rowLength * weaponBoxDimensions) + 30, weaponTopLeft + 32, 
					                            weaponBoxDimensions, weaponBoxDimensions)),
					                 dmissile_ammo, ScaleMode.ScaleToFit, true, 0f);
				}
				
			}

			
		}
		*/
		
		
		
		
		
		
		
		
		/*
		 * Player 2 weapon stuff
		 */ 
		//		weaponTopLeft = 40;
		//		
		//		//		GUIStyle cBox = new GUIStyle (GUI.skin.box);
		//		//		cBox.normal.background = Resources.Load<Texture2D> ("redbg");
		//		//		cBox.fixedWidth = 100;
		//		//		GUI.Box (new Rect (weaponBoxDimensions + 10, weaponTopLeft, 1, 1), "", cBox);
		//
		//		p2Shoot = GameObject.FindGameObjectWithTag ("BSpawnP2").GetComponent ("Shoot") as Shoot;
		//		
		//		GUI.color = Color.white;
		//		//bullet stuff
		//		if (p2Shoot.ammonum == 0) {
		//			for (int h = 0; h < p2Bullet; h++) {
		//				GUI.DrawTexture ((new Rect ((h * weaponBoxDimensions) + (Screen.width / 2) + 10, 64, weaponBoxDimensions, weaponBoxDimensions)),
		//				                 bulletammo, ScaleMode.ScaleToFit, true, 0f);
		//				
		//			}
		//			
		//			//rocket stuff
		//		} else if (p2Shoot.ammonum == 1) {
		////			GUI.DrawTexture ((new Rect ((weaponBoxDimensions) + (Screen.width / 2) + 10, weaponTopLeft, 
		////			                            weaponBoxDimensions, weaponBoxDimensions)),
		////			                 drocket_ammo, ScaleMode.ScaleToFit, true, 0f);
		//
		//
		//			//Debug.Log (p2Shoot.ammonum);
		//			int rowLength = 5;
		//			//destruction rocket
		//			for (int g = 0; g < p2Rocket; g++) {
		//				
		//				if (g < rowLength) {
		//					GUI.DrawTexture ((new Rect ((g * weaponBoxDimensions) + (Screen.width / 2) + 10, weaponTopLeft, 
		//					                            weaponBoxDimensions, weaponBoxDimensions)),
		//					                 drocket_ammo, ScaleMode.ScaleToFit, true, 0f);
		//				} else {
		//					GUI.DrawTexture ((new Rect (((g - rowLength) * weaponBoxDimensions) + (Screen.width / 2) + 10, weaponTopLeft + 32, 
		//					                            weaponBoxDimensions, weaponBoxDimensions)),
		//					                 drocket_ammo, ScaleMode.ScaleToFit, true, 0f);
		//				}
		//				
		//			}
		//			
		//			
		//			//construction rocket
		//			for (int h = 0; h < p2CRocket; h++) {
		//				
		//				if (h < rowLength) {
		//					GUI.DrawTexture ((new Rect ((h * weaponBoxDimensions) + (rowLength * weaponBoxDimensions) + 30 + (Screen.width / 2), weaponTopLeft, 
		//					                            weaponBoxDimensions, weaponBoxDimensions)),
		//					                 crocket_ammo, ScaleMode.ScaleToFit, true, 0f);
		//				} else {
		//					GUI.DrawTexture ((new Rect (((h - rowLength) * weaponBoxDimensions) + (rowLength * weaponBoxDimensions) + 30 + (Screen.width / 2), weaponTopLeft + 32, 
		//					                            weaponBoxDimensions, weaponBoxDimensions)),
		//					                 crocket_ammo, ScaleMode.ScaleToFit, true, 0f);
		//				}
		//				
		//			}
		//			
		//			//shotgun stuff
		//		} else if (p2Shoot.ammonum == 2) {
		//			
		//			int rowLength = 5;
		//			//destruction shotgun
		//			for (int h = 0; h < p2Shotgun; h++) {
		//				
		//				if (h < rowLength) {
		//					GUI.DrawTexture ((new Rect ((h * weaponBoxDimensions) + 10 + (Screen.width / 2), weaponTopLeft, 
		//					                            weaponBoxDimensions, weaponBoxDimensions)),
		//					                 dshotgun_ammo, ScaleMode.ScaleToFit, true, 0f);
		//				} else {
		//					GUI.DrawTexture ((new Rect (((h - rowLength) * weaponBoxDimensions) + 10 + (Screen.width / 2), weaponTopLeft + 32, 
		//					                            weaponBoxDimensions, weaponBoxDimensions)),
		//					                 dshotgun_ammo, ScaleMode.ScaleToFit, true, 0f);
		//				}
		//				
		//			}
		//			
		//			
		//			//construction shotgun
		//			for (int h = 0; h < p2CShotgun; h++) {
		//				
		//				if (h < rowLength) {
		//					GUI.DrawTexture ((new Rect ((h * weaponBoxDimensions) + (rowLength * weaponBoxDimensions) + 30 + (Screen.width / 2), weaponTopLeft, 
		//					                            weaponBoxDimensions, weaponBoxDimensions)),
		//					                 cshotgun_ammo, ScaleMode.ScaleToFit, true, 0f);
		//				} else {
		//					GUI.DrawTexture ((new Rect (((h - rowLength) * weaponBoxDimensions) + (rowLength * weaponBoxDimensions) + 30 + (Screen.width / 2), weaponTopLeft + 32, 
		//					                            weaponBoxDimensions, weaponBoxDimensions)),
		//					                 cshotgun_ammo, ScaleMode.ScaleToFit, true, 0f);
		//				}
		//				
		//			}
		//			
		//		}else if (p2Shoot.ammonum == 3) {
		//			
		//			int rowLength = 5;
		//			//destruction airstrike
		//			for (int h = 0; h < p2Missile; h++) {
		//				
		//				if (h < rowLength) {
		//					GUI.DrawTexture ((new Rect ((h * weaponBoxDimensions) + 10 + (Screen.width / 2), weaponTopLeft, 
		//					                            weaponBoxDimensions, weaponBoxDimensions)),
		//					                 cmissile_ammo, ScaleMode.ScaleToFit, true, 0f);
		//				} else {
		//					GUI.DrawTexture ((new Rect (((h - rowLength) * weaponBoxDimensions) + 10 + (Screen.width / 2), weaponTopLeft + 32, 
		//					                            weaponBoxDimensions, weaponBoxDimensions)),
		//					                 cmissile_ammo, ScaleMode.ScaleToFit, true, 0f);
		//				}
		//				
		//			}
		//			
		//			
		//			//construction airstrike
		//			for (int h = 0; h < p2CMissile; h++) {
		//				
		//				if (h < rowLength) {
		//					GUI.DrawTexture ((new Rect ((h * weaponBoxDimensions) + (rowLength * weaponBoxDimensions) + 30 + (Screen.width / 2), weaponTopLeft, 
		//					                            weaponBoxDimensions, weaponBoxDimensions)),
		//					                 dmissile_ammo, ScaleMode.ScaleToFit, true, 0f);
		//				} else {
		//					GUI.DrawTexture ((new Rect (((h - rowLength) * weaponBoxDimensions) + (rowLength * weaponBoxDimensions) + 30 + (Screen.width / 2), weaponTopLeft + 32, 
		//					                            weaponBoxDimensions, weaponBoxDimensions)),
		//					                 dmissile_ammo, ScaleMode.ScaleToFit, true, 0f);
		//				}
		//				
		//			}
		//			
		//		}
		
		
		
	}
	
	void Start ()
	{
		
		
		world = GameObject.FindGameObjectWithTag ("World").GetComponent ("World") as World;
		mt = GameObject.FindGameObjectWithTag ("World").GetComponent ("ModifyTerrain") as ModifyTerrain;
		
		//p1 = GameObject.FindGameObjectWithTag ("P1Hit").GetComponent ("PlayerController") as PlayerController;
		//p2 = GameObject.FindGameObjectWithTag ("P2Hit").GetComponent ("PlayerController") as PlayerController;
		
	}
	
	void Update ()
	{
		
		//these have to be in Update() instead of Start() for some reason
		p1 = GameObject.FindGameObjectWithTag ("P1Hit").GetComponent ("PlayerController") as PlayerController;
		p2 = GameObject.FindGameObjectWithTag ("P2Hit").GetComponent ("PlayerController") as PlayerController;
		
		p1Shoot = GameObject.FindGameObjectWithTag ("BSpawnP1").GetComponent ("Shoot") as Shoot;
		p2Shoot = GameObject.FindGameObjectWithTag ("BSpawnP2").GetComponent ("Shoot") as Shoot;
		
		p1hp = p1.hp;
		p2hp = p2.hp;
		
		p1Bullet = Mathf.Floor (p1Shoot.bullet);
		p1Rocket = Mathf.Floor (p1Shoot.rocket);
		p1Shotgun = Mathf.Floor (p1Shoot.shotgun);
		p1CRocket = Mathf.Floor (p1Shoot.crocket);
		p1CShotgun = Mathf.Floor (p1Shoot.cshotgun);
		p1Missile = Mathf.Floor (p1Shoot.missile);
		p1CMissile = Mathf.Floor (p1Shoot.cmissile);
		
		p2Bullet = Mathf.Floor (p2Shoot.bullet);
		p2Rocket = Mathf.Floor (p2Shoot.rocket);
		p2Shotgun = Mathf.Floor (p2Shoot.shotgun);
		p2CRocket = Mathf.Floor (p2Shoot.crocket);
		p2CShotgun = Mathf.Floor (p2Shoot.cshotgun);
		p2Missile = Mathf.Floor (p2Shoot.missile);
		p2CMissile = Mathf.Floor (p2Shoot.cmissile);
	}
}
