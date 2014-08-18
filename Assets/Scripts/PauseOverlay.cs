using UnityEngine;
using System.Collections;

public class PauseOverlay : MonoBehaviour {

	Pauser pauser;

	Material materialToLoad;

	// Use this for initialization
	void Start () {
		pauser = GameObject.FindGameObjectWithTag ("Pauser").GetComponent ("Pauser") as Pauser;
	}
	
	// Update is called once per frame
	void Update () {

		// Turns alpha to 1 if game is paused, or reverts to 0 after unpause
		if (pauser.paused) {
			gameObject.renderer.material = materialToLoad;
		} else {
			gameObject.renderer.material = null;
		}
	}
}
