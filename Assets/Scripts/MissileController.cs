using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour {
	public GameObject missile;
	public float spawnDelay = 2f;
	public float nextSpawn = 2f;
	public float spawnHeight = 50f;

	private Vector3 startPoint;
	public int maxMissiles = 5;
	public int curMissiles = 0;
	// Initialize delays
	void Start(){
		nextSpawn = Time.time + spawnDelay;
	}

	// Function to retrieve random point with respect to the controller plane
	Vector3 getRandomPosition()
	{
		Vector3 randomPoint = transform.TransformPoint (new Vector3 (Random.Range (-5.0f, 5.0f), spawnHeight, Random.Range (-5f, 5f)));
		return randomPoint;
	} 

	// Instantiate function to be called by Invoke()
	void Instantiate(){
		Instantiate (missile, getRandomPosition(), transform.rotation);
		++curMissiles;
	}

	// Update is called once per frame
	void Update () {
		if(Time.time > nextSpawn ){
			if(curMissiles < maxMissiles){
				nextSpawn = Time.time + spawnDelay + Random.Range (-1f, 1f);
				Instantiate();
				Debug.Log("Instantiated");
			}
		}
	}
}
