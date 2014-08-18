using UnityEngine;
using System.Collections;

public class Pauser : MonoBehaviour {
	public bool paused;
	public bool canShift;
	public int winner; //1 for player1, 2 for player2, 0 for no winner
	public int health;
	public int fistpow;
	public int sBullet;
	public int sRocket;
	public int sShotgun;
	public int sCRocket;
	public int sCShotgun;
	public int sAirstrike;
	public int sCAirstrike;



	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		winner = 0;
		paused = false;
		canShift = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevel == 1) {

		}
		//if(paused){
		if ((Input.GetButton ("Pause") || Input.GetButton ("Pause_alt")) && canShift) {
			canShift = false;
			if(paused){
				StartCoroutine(psWait());
				paused = false;
			}else{
				StartCoroutine(psWait());
				paused = true;
			}
		}
	}

	IEnumerator psWait(){
		yield return new WaitForSeconds(1f);
		canShift = true;
	}
}
