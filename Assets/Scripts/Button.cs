using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	public string levelToLoad;
	public bool exit;
	public bool leftArrow;
	public bool rightArrow;

	public bool health;
	public bool fist;
	public bool pistol;
	public bool dShotgun;
	public bool cShotgun;
	public bool dRocket;
	public bool cRocket;
	public bool dAirstrike;
	public bool cAirstrike;

	//public float minFade = 0.8f;
	//public float maxFade = 1f;

	public float minScale = 1f;
	public float maxScale = 1.15f;
	private Vector3 defaultScale;

	SettingController setController;

	// Default menu asset alpha set to minFade and size set to defaults
	public void Start(){
		//guiText.material.color.a = minFade;
		defaultScale = new Vector3 (transform.lossyScale.x, transform.lossyScale.y, transform.lossyScale.z);
		if(GameObject.FindGameObjectWithTag("SettingController") != null){
			setController = GameObject.FindGameObjectWithTag ("SettingController").GetComponent ("SettingController") as SettingController;
		}
	}

	// Checks if button is exit, and loads game if not
	private void OnMouseDown(){
		if (exit) {
			Debug.Log ("Application quit");
			Application.Quit ();
		} else if (leftArrow) {
			Debug.Log ("Left");
			// Decrement value iff value is within bounds
			if (health && setController.health > setController.healthMin && setController.health <= setController.healthMax) {
				setController.health -= 1;
				setController.updateHealth = true;
			} else if (fist && setController.fist > setController.fistMin && setController.fist <= setController.fistMax){
				setController.fist -= 1;
				setController.updateFist = true;
			}else if (pistol && setController.pistol > setController.pistolMin && setController.pistol <= setController.pistolMax){
				setController.pistol -= 1;
				setController.updatePistol = true;
			}else if (dShotgun && setController.dShotgun > setController.shotgunMin && setController.dShotgun <= setController.shotgunMax){
				setController.dShotgun -= 1;
				setController.updateDShotgun = true;
			}else if (cShotgun && setController.cShotgun > setController.shotgunMin && setController.cShotgun <= setController.shotgunMax){
				setController.cShotgun -= 1;
				setController.updateCShotgun = true;
			}else if (dRocket && setController.dRocket > setController.rocketMin && setController.dRocket <= setController.rocketMax){
				setController.dRocket -= 1;
				setController.updateDRocket = true;
			}else if (cRocket && setController.cRocket > setController.rocketMin && setController.cRocket <= setController.rocketMax){
				setController.cRocket -= 1;
				setController.updateCRocket = true;
			}else if (dAirstrike && setController.dAirstrike > setController.airstrikeMin && setController.dAirstrike <= setController.airstrikeMax){
				setController.dAirstrike -= 1;
				setController.updateDAirstrike = true;
			}else if (cAirstrike && setController.cAirstrike > setController.airstrikeMin && setController.cAirstrike <= setController.airstrikeMax){
				setController.cAirstrike -= 1;
				setController.updateCAirstrike = true;
			}
		} else if (rightArrow) {
			Debug.Log ("Right");
			// Increment valueiff value is within bounds
			if (health && setController.health >= setController.healthMin && setController.health < setController.healthMax) {
				setController.health += 1;
				setController.updateHealth = true;
			} else if (fist && setController.fist >= setController.fistMin && setController.fist < setController.fistMax){
				setController.fist += 1;
				setController.updateFist = true;
			}else if (pistol && setController.pistol >= setController.pistolMin && setController.pistol < setController.pistolMax){
				setController.pistol += 1;
				setController.updatePistol = true;
			}else if (dShotgun && setController.dShotgun >= setController.shotgunMin && setController.dShotgun < setController.shotgunMax){
				setController.dShotgun += 1;
				setController.updateDShotgun = true;
			}else if (cShotgun && setController.cShotgun >= setController.shotgunMin && setController.cShotgun < setController.shotgunMax){
				setController.cShotgun += 1;
				setController.updateCShotgun = true;
			}else if (dRocket && setController.dRocket >= setController.rocketMin && setController.dRocket < setController.rocketMax){
				setController.dRocket += 1;
				setController.updateDRocket = true;
			}else if (cRocket && setController.cRocket >= setController.rocketMin && setController.cRocket < setController.rocketMax){
				setController.cRocket += 1;
				setController.updateCRocket = true;
			}else if (dAirstrike && setController.dAirstrike >= setController.airstrikeMin && setController.dAirstrike < setController.airstrikeMax){
				setController.dAirstrike += 1;
				setController.updateDAirstrike = true;
			}else if (cAirstrike && setController.cAirstrike >= setController.airstrikeMin && setController.cAirstrike < setController.airstrikeMax){
				setController.cAirstrike += 1;
				setController.updateCAirstrike = true;
			}
		} else {
			Application.LoadLevel (levelToLoad);
			Debug.Log ("Level " + levelToLoad + " loaded");
		}

	}

	private void OnMouseOver(){
		//FadeIn();
		Grow ();
	}

	private void OnMouseExit(){
		//FadeOut ();
		Shrink ();
	}

	/*
	// Fades in over time
	public void FadeIn(){
		if(guiText.material.color.a < maxFade){
			guiText.material.color.a += Time.deltaTime;
		}
	}

	// Fades out over time
	public void FadeOut(){
		if (guiText.material.color.a > minFade) {
			guiText.material.color.a -= Time.deltaTime;
		}
	}
	*/

	public void Grow(){
		if (transform.localScale != defaultScale * maxScale) {
			transform.localScale = new Vector3 (transform.lossyScale.x * maxScale, transform.lossyScale.y * maxScale, transform.lossyScale.z * maxScale);
		}
	}

	public void Shrink(){
		if (transform.localScale != defaultScale) {
			transform.localScale = new Vector3 (defaultScale.x * minScale, defaultScale.y * minScale, defaultScale.z * minScale);
		}
	}
}
