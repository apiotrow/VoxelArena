using UnityEngine;
using System.Collections;

public class ResetPrototype : MonoBehaviour {
	bool able;
	Pauser pause;
	public Material lose;
	public Material win;
	public GameObject p1Screen;
	public GameObject p2Screen;
	// Use this for initialization
	void Start () {
		StartCoroutine (ableWait ());
		pause = GameObject.FindGameObjectWithTag ("Pauser").GetComponent ("Pauser") as Pauser;
	}
	
	// Update is called once per frame
	void Update () {
		if (pause.winner == 2) {
			p1Screen.renderer.material = lose;
			p2Screen.renderer.material = win;
		}
		if (pause.winner == 1) {
			p1Screen.renderer.material = win;
			p2Screen.renderer.material = lose;
		}
		if((Input.GetButton("Punch")||Input.GetButton("Punch_alt")||Input.GetButton ("Shoot")||Input.GetButton ("Shoot_alt")||Input.GetButton ("CShoot")||Input.GetButton ("CShoot_alt")) && able){
			Application.LoadLevel(1);
		}
	}

	IEnumerator ableWait(){
		yield return new WaitForSeconds (1f);
		able = true;
	}
}
