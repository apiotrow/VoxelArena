using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public int hp;
	public bool gotHit;
	public bool bonusDmg;
	public bool fullHp;
	public int pow;
	Pauser pause;

	GameObject p1ballfist2;
	GameObject p1sledge2;
	GameObject p1ballfist1;
	GameObject p1sledge1;

	GameObject p2ballfist2;
	GameObject p2sledge2;
	GameObject p2ballfist1;
	GameObject p2sledge1;

	// Use this for initialization
	void Start () {
		pause = GameObject.FindGameObjectWithTag ("Pauser").GetComponent ("Pauser") as Pauser;
		hp = pause.health;
		pow = pause.fistpow;

		p1ballfist1 = GameObject.FindGameObjectWithTag ("p1ballfist1");
		p1sledge1 = GameObject.FindGameObjectWithTag ("p1sledge1");
		p1ballfist2 = GameObject.FindGameObjectWithTag ("p1ballfist2");
		p1sledge2 = GameObject.FindGameObjectWithTag ("p1sledge2");

		p2ballfist1 = GameObject.FindGameObjectWithTag ("p2ballfist1");
		p2sledge1 = GameObject.FindGameObjectWithTag ("p2sledge1");
		p2ballfist2 = GameObject.FindGameObjectWithTag ("p2ballfist2");
		p2sledge2 = GameObject.FindGameObjectWithTag ("p2sledge2");
	}
	void Update(){
		
	}

	public void takeDmg(int val){
			hp -= val;
			bonusDmg = false;
			gotHit = false;
		
	}
	public void applyHit(){
		gotHit = true;
	}
	public void applyBonus(){
		gotHit = true;
		bonusDmg = true;
	}
	public void heal(){
		if (hp < 10) {
			hp += 1;
		}
	}
	/*void OnTriggerExit(Collider other){
		//Debug.Log ("Here");
		if (gameObject.tag == "P1Hit") {
			if(other.gameObject.tag == "Fist2"){
				Debug.Log ("H");
				gotHit = true;
			}
		}
		if (gameObject.tag == "P2Hit") {
			if(other.gameObject.tag == "Fist"){
				gotHit = true;
			}
		}
	}*/
	// Update is called once per frame
	void FixedUpdate () {
		if (pow == 0 && gameObject.tag == "P1Hit") {
			p1sledge1.renderer.enabled = false;
			p1ballfist1.renderer.enabled = false;
			p1sledge2.renderer.enabled = false;
			p1ballfist2.renderer.enabled = false;
		}else if (pow == 1 && gameObject.tag == "P1Hit") {
			p1sledge1.renderer.enabled = true;
			p1ballfist1.renderer.enabled = false;
			p1sledge2.renderer.enabled = true;
			p1ballfist2.renderer.enabled = false;
		}else if (pow == 2 && gameObject.tag == "P1Hit") {
			p1sledge1.renderer.enabled = false;
			p1ballfist1.renderer.enabled = true;
			p1sledge2.renderer.enabled = false;
			p1ballfist2.renderer.enabled = true;
		}

		if (pow == 0 && gameObject.tag == "P2Hit") {
			p2sledge1.renderer.enabled = false;
			p2ballfist1.renderer.enabled = false;
			p2sledge2.renderer.enabled = false;
			p2ballfist2.renderer.enabled = false;
		}else if (pow == 1 && gameObject.tag == "P2Hit") {
			p2sledge1.renderer.enabled = true;
			p2ballfist1.renderer.enabled = false;
			p2sledge2.renderer.enabled = true;
			p2ballfist2.renderer.enabled = false;
		}else if (pow == 2 && gameObject.tag == "P2Hit") {
			p2sledge1.renderer.enabled = false;
			p2ballfist1.renderer.enabled = true;
			p2sledge2.renderer.enabled = false;
			p2ballfist2.renderer.enabled = true;
		}


		if (gotHit) {
			if(bonusDmg){
				takeDmg (2);
			}else{
				takeDmg (1);
			}
		}
		if (transform.position.y <= -1) {
			hp = 0;
			if(gameObject.tag == "P1Hit"){
				pause.winner = 2;
			}
			if(gameObject.tag == "P2Hit"){
				pause.winner = 1;
			}
		}
		if (hp <= 0) {
			if(gameObject.tag == "P1Hit"){
				pause.winner = 2;
			}
			if(gameObject.tag == "P2Hit"){
				pause.winner = 1;
			}
			Application.LoadLevel(3);
		}
	}
}