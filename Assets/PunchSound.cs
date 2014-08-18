using UnityEngine;
using System.Collections;

public class PunchSound : MonoBehaviour {
	public AudioClip punchSound;
	bool weplay;

	// Use this for initialization
	void Start () {
		weplay = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(weplay == true && ((Input.GetButton ("Punch"))))
			StartCoroutine (PlayPunch ());

	}

	private IEnumerator PlayPunch ()
	{
		//audio.clip = punchSound;
		//audio.Play ();
		AudioSource.PlayClipAtPoint (punchSound, transform.position);
		//audio.PlayOneShot (punchSound, 1f);
		weplay = false;
		yield return new WaitForSeconds (1f);
		weplay = true;
	}
}
