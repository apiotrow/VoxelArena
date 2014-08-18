using UnityEngine;
using System.Collections;

public class AirstrikeController : MonoBehaviour {
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
		
		startPoint = transform.TransformPoint(0, spawnHeight, 0);
	}
	
	void getForwardPosition(){
		startPoint.x += 5f;
		Debug.Log (startPoint.x + ", " + startPoint);
	}
	
	// Instantiate function to be called by Invoke()
	void Instantiate(){
		Instantiate (missile, startPoint, transform.rotation);
		getForwardPosition ();
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
