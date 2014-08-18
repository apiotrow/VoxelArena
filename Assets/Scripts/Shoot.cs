using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	World world;
	ModifyTerrain mt;
	GameObject player;
	GameObject camera;
	public GameObject projectile; //stock projectile for player's bullet
	public GameObject projectileR; //stock projectile for player's rocket
	public GameObject projectileCR;
	public GameObject projectileS;
	public GameObject projectileS_alt;
	public GameObject projectileCS;
	public GameObject projectileCS_alt;
	public GameObject projectileM;
	public GameObject projectileCM;
	//public GameObject projectile2;
	public bool ableToShoot; //can shoot?
	public bool hasHit; //hit something yet?
	public int rocket; //num of rockets
	public int bullet;
	public int shotgun;
	public int crocket;
	public int cshotgun;
	public int missile;
	public int cmissile;
	PlayerController p1;
	PlayerController p2;
	private GUIStyle buttonStyle = new GUIStyle();
	int boxWidth = 120;
	int boxHeight = 30;
	Pauser pause;
	public int ammonum;
	int dire1;
	int dire2;
	int offset;
	float missileGen;
	
	void DefineStyles(){
		buttonStyle = GUI.skin.button;
		buttonStyle.normal.textColor = Color.white;
		buttonStyle.alignment = TextAnchor.MiddleCenter;
		buttonStyle.fontStyle = FontStyle.Bold;
		buttonStyle.padding.top = 4;
		buttonStyle.padding.left = 3;
		buttonStyle.fontSize = 20;
		buttonStyle.fixedWidth = boxWidth;
		buttonStyle.fixedHeight = boxHeight;
	}
	
	void OnGUI ()
	{	//buttons for testing purpose of ammo checks (will be deleted in final build)
//		DefineStyles ();
//		if(gameObject.tag == "BSpawnP1" && ammonum == 0){
//		string ammo1Text = "B: " + (Mathf.Floor (bullet)).ToString ();
//			if (GUI.Button (new Rect ((Screen.width / 4) - (boxWidth / 2), 35, boxWidth, boxHeight), ammo1Text, buttonStyle)) {
//			}
//		}
//		if(gameObject.tag == "BSpawnP1" && ammonum == 1){
//			string ammo1Text = "R: " + (Mathf.Floor (rocket)).ToString ();
//			string ammo1_altText = "C.R: " + (Mathf.Floor (crocket)).ToString ();
//			if (GUI.Button (new Rect ((Screen.width / 4) - (boxWidth / 2), 35, boxWidth, boxHeight), ammo1Text, buttonStyle)) {
//			}
//			if (GUI.Button (new Rect ((Screen.width / 4) - (boxWidth / 2), 70, boxWidth, boxHeight), ammo1_altText, buttonStyle)) {
//			}
//		}
//		if(gameObject.tag == "BSpawnP1" && ammonum == 2){
//			string ammo1Text = "S: " + (Mathf.Floor (shotgun)).ToString ();
//			string ammo1_altText = "C.S: " + (Mathf.Floor (cshotgun)).ToString ();
//			if (GUI.Button (new Rect ((Screen.width / 4) - (boxWidth / 2), 35, boxWidth, boxHeight), ammo1Text, buttonStyle)) {
//			}
//			if (GUI.Button (new Rect ((Screen.width / 4) - (boxWidth / 2), 70, boxWidth, boxHeight), ammo1_altText, buttonStyle)) {
//			}
//		}
//		if(gameObject.tag == "BSpawnP1" && ammonum == 3){
//			string ammo1Text = "A: " + (Mathf.Floor (missile)).ToString ();
//			string ammo1_altText = "C.A: " + (Mathf.Floor (cmissile)).ToString ();
//			if (GUI.Button (new Rect ((Screen.width / 4) - (boxWidth / 2), 35, boxWidth, boxHeight), ammo1Text, buttonStyle)) {
//			}
//			if (GUI.Button (new Rect ((Screen.width / 4) - (boxWidth / 2), 70, boxWidth, boxHeight), ammo1_altText, buttonStyle)) {
//			}
//		}
//		if(gameObject.tag == "BSpawnP2" && ammonum == 0){
//			string ammo2Text = "B: " + (Mathf.Floor (bullet)).ToString ();
//			if (GUI.Button (new Rect (((Screen.width / 4) * 3) - (boxWidth / 2), 35, boxWidth, boxHeight), ammo2Text, buttonStyle)) {
//			}
//		}
//		if(gameObject.tag == "BSpawnP2" && ammonum == 1){
//			string ammo2Text = "R: " + (Mathf.Floor (rocket)).ToString ();
//			string ammo2_altText = "C.R: " + (Mathf.Floor (crocket)).ToString ();
//			if (GUI.Button (new Rect (((Screen.width / 4) * 3) - (boxWidth / 2), 35, boxWidth, boxHeight), ammo2Text, buttonStyle)) {
//			}
//			if (GUI.Button (new Rect (((Screen.width / 4) * 3) - (boxWidth / 2), 70, boxWidth, boxHeight), ammo2_altText, buttonStyle)) {
//			}
//		}
//		if(gameObject.tag == "BSpawnP2" && ammonum == 2){
//			string ammo2Text = "S: " + (Mathf.Floor (shotgun)).ToString ();
//			string ammo2_altText = "C.S: " + (Mathf.Floor (cshotgun)).ToString ();
//			if (GUI.Button (new Rect (((Screen.width / 4) * 3) - (boxWidth / 2), 35, boxWidth, boxHeight), ammo2Text, buttonStyle)) {
//			}
//			if (GUI.Button (new Rect (((Screen.width / 4) * 3) - (boxWidth / 2), 70, boxWidth, boxHeight), ammo2_altText, buttonStyle)) {
//			}
//		}
//		if(gameObject.tag == "BSpawnP2" && ammonum == 3){
//			string ammo2Text = "A: " + (Mathf.Floor (missile)).ToString ();
//			string ammo2_altText = "C.A: " + (Mathf.Floor (cmissile)).ToString ();
//			if (GUI.Button (new Rect (((Screen.width / 4) * 3) - (boxWidth / 2), 35, boxWidth, boxHeight), ammo2Text, buttonStyle)) {
//			}
//			if (GUI.Button (new Rect (((Screen.width / 4) * 3) - (boxWidth / 2), 70, boxWidth, boxHeight), ammo2_altText, buttonStyle)) {
//			}
//		}
	}
	
	
	// Use this for initialization
	void Start ()
	{	//unchanged starter pack of ammo (will be changed with setting screen)
		ammonum = 0;
		//set up for needed objects and scripts
		ableToShoot = true;
		world = GameObject.FindGameObjectWithTag ("World").GetComponent ("World") as World;
		mt = GameObject.FindGameObjectWithTag ("World").GetComponent ("ModifyTerrain") as ModifyTerrain;
		if (gameObject.tag == "BSpawnP1") {
			player = GameObject.FindGameObjectWithTag ("Player1");
			camera = GameObject.FindGameObjectWithTag ("Player1Camera");
		}
		if (gameObject.tag == "BSpawnP2") {
			player = GameObject.FindGameObjectWithTag ("Player2");
			camera = GameObject.FindGameObjectWithTag ("Player2Camera");
		}
		p1 = GameObject.FindGameObjectWithTag ("P1Hit").GetComponent ("PlayerController") as PlayerController;
		p2 = GameObject.FindGameObjectWithTag ("P2Hit").GetComponent ("PlayerController") as PlayerController;
		pause = GameObject.FindGameObjectWithTag ("Pauser").GetComponent ("Pauser") as Pauser;
		bullet = pause.sBullet;
		rocket = pause.sRocket;
		shotgun = pause.sShotgun;
		crocket = pause.sCRocket;
		cshotgun = pause.sCShotgun;
		missile = pause.sAirstrike;
		cmissile = pause.sCAirstrike;
	}
	void gunSwap(){
		if(ammonum == 0){
			if(rocket > 0 || crocket > 0){
				ammonum = 1;
			}else{//no rockets
				if(shotgun > 0 || cshotgun > 0){
					ammonum = 2;
				}else{//no shotgun
					if(missile > 0 || cmissile > 0){
						ammonum = 3;
					}else{//no other ammo
						ammonum = 0;
					}
				}
			}
		}else if(ammonum == 1){
			if(shotgun > 0 || cshotgun > 0){
				ammonum = 2;
			}else{//no shotgun
				if(missile > 0 || cmissile > 0){
					ammonum = 3;
				}else{//no missiles
					if(bullet > 0){
						ammonum = 0;
					}else{//no other ammo
						ammonum = 1;
					}
				}
			}
		}else if(ammonum == 2){
			if(missile > 0 || cmissile > 0){
				ammonum = 3;
			}else{//no missiles
				if(bullet > 0){
					ammonum = 0;
				}else{//no bullets
					if(rocket > 0 || crocket > 0){
						ammonum = 1;
					}else{//no other ammo
						ammonum = 2;
					}
				}
			}
		}else if(ammonum == 3){
			if(bullet > 0){
				ammonum = 0;
			}else{//no bullets
				if(rocket > 0 || crocket > 0){
					ammonum = 1;
				}else{//no rockets
					if(shotgun > 0 || cshotgun > 0){
						ammonum = 2;
					}else{//no other ammo
						ammonum = 3;
					}
				}
			}
		}
	}
	// Update is called once per frame
	void Update ()
	{	//Weapon swap function
		if(Input.GetButton ("GunSwap")&&gameObject.tag == "BSpawnP1" &&!pause.paused && ableToShoot){
			gunSwap ();
			ableToShoot = false;
			StartCoroutine(shootTime ());

		}
		if(Input.GetButton ("GunSwap_alt")&&gameObject.tag == "BSpawnP2" &&!pause.paused && ableToShoot){
			gunSwap ();
			ableToShoot = false;
			StartCoroutine(shootTime ());
			
		}
		//Shooting functionality per weapon, per ammo type
		if ((Input.GetButton ("Shoot") || Input.GetButton ("CShoot")) && ableToShoot &&!pause.paused && bullet >= 1 && gameObject.tag == "BSpawnP1" && ammonum == 0) {
			Instantiate(projectile, transform.position, transform.rotation);
			bullet -=1;
			if(bullet == 0){
				gunSwap ();
			}
			ableToShoot = false;
			StartCoroutine(shootTime());
		}//shoot for rocket player 1
		if (Input.GetButton ("Shoot") && ableToShoot &&!pause.paused && rocket >= 1 && gameObject.tag == "BSpawnP1" && ammonum == 1) {
			Instantiate(projectileR, transform.position, transform.rotation);
			rocket -=1;
			if(rocket == 0 && crocket == 0){
				gunSwap ();
			}
			ableToShoot = false;
			StartCoroutine(shootTime());
		}//shoot for shotgun player 1
		if (Input.GetButton ("Shoot") && ableToShoot &&!pause.paused && shotgun >= 1 && gameObject.tag == "BSpawnP1" && ammonum == 2) {
			if(Random.Range (0f, 1f) < 0.5f) {
				Instantiate(projectileS, transform.position, transform.rotation);
			}else{
				Instantiate(projectileS_alt, transform.position, transform.rotation);
			}
			shotgun -=1;
			if(shotgun == 0 && cshotgun == 0){
				gunSwap ();
			}
			ableToShoot = false;
			StartCoroutine(shootTime());
		}//shoot for cshotgun player 1
		if (Input.GetButton ("CShoot") && ableToShoot &&!pause.paused && cshotgun >= 1 && gameObject.tag == "BSpawnP1" && ammonum == 2) {
			if(Random.Range (0f, 1f) < 0.5f) {
				Instantiate(projectileCS, transform.position, transform.rotation);
			}else{
				Instantiate(projectileCS_alt, transform.position, transform.rotation);
			}
			cshotgun -=1;
			if(cshotgun == 0 && shotgun == 0){
				gunSwap ();
			}
			ableToShoot = false;
			StartCoroutine(shootTime());
		}//shoot for crocket player 1
		if (Input.GetButton ("CShoot") && ableToShoot &&!pause.paused && crocket >= 1 && gameObject.tag == "BSpawnP1" && ammonum == 1) {
			Instantiate(projectileCR, transform.position, transform.rotation);
			crocket -=1;
			if(rocket == 0 && crocket == 0){
				gunSwap ();
			}
			ableToShoot = false;
			StartCoroutine(shootTime());
		}//shoot for airstrike player 1
		if (Input.GetButton ("Shoot") && ableToShoot &&!pause.paused && missile >= 1 && gameObject.tag == "BSpawnP1" && ammonum == 3) {
			missileGen = Random.Range (0f, 1f); //x's are hits in the pattern, 0's are misses
			if(missileGen < 0.45f) {
				for(offset = 1; offset < 4; offset++){//left to right: patterned: xxx0xxx 
					Instantiate(projectileM, p2.transform.position + new Vector3(offset,50,0), projectileM.transform.rotation);
					Instantiate(projectileM, p2.transform.position + new Vector3(-1*offset,50,0), projectileM.transform.rotation);
				}
			}else if(missileGen > 0.45f && missileGen < .9f){
				for(offset = 1; offset < 4; offset++){//up and down: patterned
					//x
					//x
					//x
					//0
					//x
					//x
					//x
					Instantiate(projectileM, p2.transform.position + new Vector3(0,50,offset), projectileM.transform.rotation);
					Instantiate(projectileM, p2.transform.position + new Vector3(0,50,-1*offset), projectileM.transform.rotation);
				}
			}else{//random scatter +2 additional missiles <3
				Vector3 drop1;
				Vector3 drop2;
				for(offset = 1; offset < 5; offset++){
					drop1 = new Vector3 (Random.Range (-5, 5), 0, Random.Range (-5, 5));
					drop2 = new Vector3 (Random.Range (-5, 5), 0, Random.Range (-5, 5));
					Instantiate(projectileM, p2.transform.position + drop1, projectileM.transform.rotation);
					Instantiate(projectileM, p2.transform.position + drop2, projectileM.transform.rotation);
				}
			}
			missile -=1;
			if(missile == 0 && cmissile == 0){
				gunSwap ();
			}
			ableToShoot = false;
			StartCoroutine(shootTime());
		}//Shoot for creator airstrike (same patterns as above)
		if (Input.GetButton ("CShoot") && ableToShoot &&!pause.paused && cmissile >= 1 && gameObject.tag == "BSpawnP1" && ammonum == 3) {
			missileGen = Random.Range (0f, 1f);
			if(missileGen < 0.45f) {
				for(offset = 1; offset < 4; offset++){
					Instantiate(projectileCM, p2.transform.position + new Vector3(offset,50,0), projectileCM.transform.rotation);
					Instantiate(projectileCM, p2.transform.position + new Vector3(-1*offset,50,0), projectileCM.transform.rotation);
				}
			}else if(missileGen > 0.45f && missileGen < .9f){
				for(offset = 1; offset < 4; offset++){
					Instantiate(projectileCM, p2.transform.position + new Vector3(0,50,offset), projectileCM.transform.rotation);
					Instantiate(projectileCM, p2.transform.position + new Vector3(0,50,-1*offset), projectileCM.transform.rotation);
				}
			}else{
				Vector3 drop1;
				Vector3 drop2;
				for(offset = 1; offset < 5; offset++){
					drop1 = new Vector3 (Random.Range (-5, 5), 0, Random.Range (-5, 5));
					drop2 = new Vector3 (Random.Range (-5, 5), 0, Random.Range (-5, 5));
					Instantiate(projectileCM, p2.transform.position + drop1, projectileCM.transform.rotation);
					Instantiate(projectileCM, p2.transform.position + drop2, projectileCM.transform.rotation);
				}
			}
			cmissile -=1;
			if(missile == 0 && cmissile == 0){
				gunSwap ();
			}
			ableToShoot = false;
			StartCoroutine(shootTime());
		}//shoot for player two bullet
		if ((Input.GetButton ("Shoot_alt") || Input.GetButton ("CShoot_alt")) && ableToShoot &&!pause.paused && bullet >= 1 && gameObject.tag == "BSpawnP2" && ammonum == 0) {
			Instantiate(projectile, transform.position, transform.rotation);
			bullet -=1;
			if(bullet == 0){
				gunSwap ();
			}
			ableToShoot = false;
			StartCoroutine(shootTime());
		}//shoot for player 2 rocket
		if (Input.GetButton ("Shoot_alt") && ableToShoot &&!pause.paused && rocket >= 1 && gameObject.tag == "BSpawnP2" && ammonum == 1) {
			Instantiate(projectileR, transform.position, transform.rotation);
			rocket -=1;
			if(rocket == 0 && crocket == 0){
				gunSwap ();
			}
			ableToShoot = false;
			StartCoroutine(shootTime());
		}//shoot for player two shotgun
		if (Input.GetButton ("Shoot_alt") && ableToShoot &&!pause.paused && shotgun >= 1 && gameObject.tag == "BSpawnP2" && ammonum == 2) {
			if(Random.Range (0f, 1f) < 0.5f) {
				Instantiate(projectileS, transform.position, transform.rotation);
			}else{
				Instantiate(projectileS_alt, transform.position, transform.rotation);
			}
			shotgun -=1;
			if(cshotgun == 0 && shotgun == 0){
				gunSwap ();
			}
			ableToShoot = false;
			StartCoroutine(shootTime());
		}//shoot for player two creator shotgun
		if (Input.GetButton ("CShoot_alt") && ableToShoot &&!pause.paused && cshotgun >= 1 && gameObject.tag == "BSpawnP2" && ammonum == 2) {
			if(Random.Range (0f, 1f) < 0.5f) {
				Instantiate(projectileCS, transform.position, transform.rotation);
			}else{
				Instantiate(projectileCS_alt, transform.position, transform.rotation);
			}
			cshotgun -=1;
			if(cshotgun == 0 && shotgun == 0){
				gunSwap ();
			}
			ableToShoot = false;
			StartCoroutine(shootTime());
		}//shoot for player two creator rocket
		if (Input.GetButton ("CShoot_alt") && ableToShoot &&!pause.paused && crocket >= 1 && gameObject.tag == "BSpawnP2" && ammonum == 1) {
			Instantiate(projectileCR, transform.position, transform.rotation);
			crocket -=1;
			if(rocket == 0 && crocket == 0){
				gunSwap ();
			}
			ableToShoot = false;
			StartCoroutine(shootTime());
		}//shoot for airstrike same pattern as player one
		if (Input.GetButton ("Shoot_alt") && ableToShoot &&!pause.paused && missile >= 1 && gameObject.tag == "BSpawnP2" && ammonum == 3) {
			missileGen = Random.Range (0f, 1f);
			if(missileGen < 0.45f) {
				for(offset = 1; offset < 4; offset++){
					Instantiate(projectileM, p1.transform.position + new Vector3(offset,50,0), projectileM.transform.rotation);
					Instantiate(projectileM, p1.transform.position + new Vector3(-1*offset,50,0), projectileM.transform.rotation);
				}
			}else if(missileGen > 0.45f && missileGen < .9f){
				for(offset = 1; offset < 4; offset++){
					Instantiate(projectileM, p1.transform.position + new Vector3(0,50,offset), projectileM.transform.rotation);
					Instantiate(projectileM, p1.transform.position + new Vector3(0,50,-1*offset), projectileM.transform.rotation);
				}
			}else{
				Vector3 drop1;
				Vector3 drop2;
				for(offset = 1; offset < 5; offset++){
					drop1 = new Vector3 (Random.Range (-5, 5), 0, Random.Range (-5, 5));
					drop2 = new Vector3 (Random.Range (-5, 5), 0, Random.Range (-5, 5));
					Instantiate(projectileM, p1.transform.position + drop1, projectileM.transform.rotation);
					Instantiate(projectileM, p1.transform.position + drop2, projectileM.transform.rotation);
				}
			}
			missile -=1;
			if(missile == 0 && cmissile == 0){
				gunSwap ();
			}
			ableToShoot = false;
			StartCoroutine(shootTime());
		}//shoot for player two creator airstrike same pattern as player 1
		if (Input.GetButton ("CShoot_alt") && ableToShoot &&!pause.paused && cmissile >= 1 && gameObject.tag == "BSpawnP2" && ammonum == 3) {
			missileGen = Random.Range (0f, 1f);
			if(missileGen < 0.45f) {
				for(offset = 1; offset < 4; offset++){
					Instantiate(projectileCM, p1.transform.position + new Vector3(offset,50,0), projectileCM.transform.rotation);
					Instantiate(projectileCM, p1.transform.position + new Vector3(-1*offset,50,0), projectileCM.transform.rotation);
				}
			}else if(missileGen > 0.45f && missileGen < .9f){
				for(offset = 1; offset < 4; offset++){
					Instantiate(projectileCM, p1.transform.position + new Vector3(0,50,offset), projectileCM.transform.rotation);
					Instantiate(projectileCM, p1.transform.position + new Vector3(0,50,-1*offset), projectileCM.transform.rotation);
				}
			}else{
				Vector3 drop1;
				Vector3 drop2;
				for(offset = 1; offset < 5; offset++){
					drop1 = new Vector3 (Random.Range (-5, 5), 0, Random.Range (-5, 5));
					drop2 = new Vector3 (Random.Range (-5, 5), 0, Random.Range (-5, 5));
					Instantiate(projectileCM, p1.transform.position + drop1, projectileCM.transform.rotation);
					Instantiate(projectileCM, p1.transform.position + drop2, projectileCM.transform.rotation);
				}
			}
			cmissile -=1;
			if(missile == 0 && cmissile == 0){
				gunSwap ();
			}
			ableToShoot = false;
			StartCoroutine(shootTime());
		}

	}
	

	//shoot/swap weapon cooldown (shared)
		IEnumerator shootTime ()
		{
			yield return new WaitForSeconds (.25f);
			//transform.Translate (preset*Time.deltaTime);
			ableToShoot = true;
		}

}
