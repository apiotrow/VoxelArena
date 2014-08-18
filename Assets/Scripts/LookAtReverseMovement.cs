using UnityEngine;
using System.Collections;

public class LookAtReverseMovement : MonoBehaviour {
	public GameObject start;
	Pauser pause;
	// Use this for initialization
	void Start () {
		transform.LookAt (start.transform);
		pause = GameObject.FindGameObjectWithTag ("Pauser").GetComponent ("Pauser") as Pauser;
	}
	
	// Update is called once per frame
	void Update () {
		if(!pause.paused){
			transform.Translate (-Vector3.forward*Time.deltaTime*2);
			//if(
		}
	}
}
