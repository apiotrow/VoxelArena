using UnityEngine;
using System.Collections;

public class ModifyTerrain : MonoBehaviour {
	public World world;
	GameObject cameraGO;
	GameObject cameraGO2;
	// Use this for initialization
	void Start () {
		
		world=gameObject.GetComponent("World") as World;
		cameraGO=GameObject.FindGameObjectWithTag("Player1Camera");
		cameraGO2=GameObject.FindGameObjectWithTag("Player2Camera");
	}
	
	// Update is called once per frame
	void Update () {
		/*if(Input.GetMouseButtonDown(0) || Input.GetButton ("Punch")){
			ReplaceBlockCenter(20,0);
		}
		if (Input.GetButton ("Punch_alt")) {
			ReplaceBlockCenter2(20,0);		
		}*/
		/*if(Input.GetMouseButtonDown(1)){
			AddBlockCursor(1);
		}*/
		LoadChunks(GameObject.FindGameObjectWithTag("Player1").transform.position, GameObject.FindGameObjectWithTag("Player2").transform.position,64,64);
		//LoadChunks(GameObject.FindGameObjectWithTag("Player2").transform.position,32,48);
	}

	public void LoadChunks(Vector3 playerPos, Vector3 player2Pos, float distToLoad, float distToUnload){
		for(int x=0;x<world.chunks.GetLength(0);x++){
			for(int z=0;z<world.chunks.GetLength(2);z++){
				
				float dist=Vector2.Distance(new Vector2(x*world.chunkSize,
				                                        z*world.chunkSize),new Vector2(playerPos.x,playerPos.z));
				float dist2=Vector2.Distance(new Vector2(x*world.chunkSize,
				                                        z*world.chunkSize),new Vector2(player2Pos.x,player2Pos.z));
				if(dist<distToLoad || dist2<distToLoad){
					if(world.chunks[x,0,z]==null){
						world.GenColumn(x,z);
					}
				} else if(dist>distToUnload && dist2>distToUnload){
					if(world.chunks[x,0,z]!=null){
						
						world.UnloadColumn(x,z);
					}
				}
				
			}
		}
	}
	public void ReplaceBlockCenter(float range, byte block){
		//Replaces the block directly in front of the player
		
		Ray ray = new Ray(cameraGO.transform.position, cameraGO.transform.forward);
		RaycastHit hit;
		
		if (Physics.Raycast (ray, out hit)) {
			
			if(hit.distance<range){
				ReplaceBlockAt(hit,block);
				//ReplaceBlockExplode(1,hit, block);
			}
		}
		
	}
	public void ReplaceBlockCenter2(float range, byte block){
		//Replaces the block directly in front of the player
		
		Ray ray = new Ray(cameraGO2.transform.position, cameraGO2.transform.forward);
		RaycastHit hit;
		
		if (Physics.Raycast (ray, out hit)) {
			
			if(hit.distance<range){
				ReplaceBlockAt(hit,block);
				//ReplaceBlockExplode(1,hit, block);
			}
		}
		
	}
	
	public void AddBlockCenter(float range, byte block){
		//Adds the block specified directly in front of the player
		
		Ray ray = new Ray(cameraGO.transform.position, cameraGO.transform.forward);
		RaycastHit hit;
		
		if (Physics.Raycast (ray, out hit)) {
			
			if(hit.distance<range){
				AddBlockAt(hit,block);
			}
			Debug.DrawLine(ray.origin,ray.origin+( ray.direction*hit.distance),Color.green,2);
		}
		
	}
	
	public void ReplaceBlockCursor(byte block){
		//Replaces the block specified where the mouse cursor is pointing
		
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		
		if (Physics.Raycast (ray, out hit)) {
			
			ReplaceBlockAt(hit, block);
			Debug.DrawLine(ray.origin,ray.origin+( ray.direction*hit.distance),
			               Color.green,2);
			
		}
		
	}
	public void ReplaceBlockExplode(int power, RaycastHit hit, byte block) {
		//removes a block at these impact coordinates, you can raycast against the terrain and call this with the hit.point
		Vector3 position = hit.point;
		position+=(hit.normal*-0.5f);
		if(power >= 1){//One by one growth 
			/*	 z/y - axis
			 *   *
			 *  ***  Center diagram with ends being * for both front and back
			 *   *
			 */
			Vector3 position2 = position + new Vector3 (0, 1, 0);
			Vector3 position3 = position + new Vector3 (0, -1, 0);
			Vector3 position4 = position + new Vector3 (0, 0, 1);
			Vector3 position5 = position + new Vector3 (0, 0, -1);
			Vector3 position6 = position + new Vector3 (1, 0, 0);
			Vector3 position7 = position + new Vector3 (-1, 0, 0);
			SetBlockAt(position2, block);
			SetBlockAt(position3, block);
			SetBlockAt(position4, block);
			SetBlockAt(position5, block);
			SetBlockAt(position6, block);
			SetBlockAt(position7, block);
		}
		if (power >= 2) {//2 by 2 growth expansion
			/*			z/y - axis
			 *			*
			 * 		   *x*
			 * 		  *xxx* Center diagram X's are in power 1, 
			 * 		   *x*
			 * 			*
			 */
			Vector3 position8 = position + new Vector3 (0, 2, 0);
			Vector3 position9 = position + new Vector3 (0, 1, 1);
			Vector3 position10 = position + new Vector3 (0, 1, -1);
			Vector3 position11 = position + new Vector3 (1, 1, 0);
			Vector3 position12 = position + new Vector3 (-1, 1, 0);
			Vector3 position13 = position + new Vector3 (-1, 0, -1);
			Vector3 position14 = position + new Vector3 (-1, 0, 1);
			Vector3 position15 = position + new Vector3 (1, 0, -1);
			Vector3 position16 = position + new Vector3 (1, 0, 1);
			Vector3 position17 = position + new Vector3 (0, -1, -1);
			Vector3 position18 = position + new Vector3 (0, -1, 1);
			Vector3 position19 = position + new Vector3 (-1, -1, 0);
			Vector3 position20 = position + new Vector3 (1, -1, 0);
			Vector3 position21 = position + new Vector3 (0, 0, 2);
			Vector3 position22 = position + new Vector3 (2, 0, 0);
			Vector3 position23 = position + new Vector3 (-2, 0, 0);
			Vector3 position24 = position + new Vector3 (0, 0, -2);
			Vector3 position25 = position + new Vector3 (0, -2, 0);
			SetBlockAt(position8, block);
			SetBlockAt(position9, block);
			SetBlockAt(position10, block);
			SetBlockAt(position11, block);
			SetBlockAt(position12, block);
			SetBlockAt(position13, block);
			SetBlockAt(position14, block);
			SetBlockAt(position15, block);
			SetBlockAt(position16, block);
			SetBlockAt(position17, block);
			SetBlockAt(position18, block);
			SetBlockAt(position19, block);
			SetBlockAt(position20, block);
			SetBlockAt(position21, block);
			SetBlockAt(position22, block);
			SetBlockAt(position23, block);
			SetBlockAt(position24, block);
			SetBlockAt(position25, block);
		}
		//print ("Replacing");
		SetBlockAt(position, block);
		
	}
	public void ReplaceBlockExplodeV(int power, Vector3 position, byte block) {
		//removes a block at these impact coordinates, you can raycast against the terrain and call this with the hit.point
		if(power >= 1){//One by one growth 
			/*	 z/y - axis
			 *   *
			 *  ***  Center diagram with ends being * for both front and back
			 *   *
			 */
			Vector3 position2 = position + new Vector3 (0, 1, 0);
			Vector3 position3 = position + new Vector3 (0, -1, 0);
			Vector3 position4 = position + new Vector3 (0, 0, 1);
			Vector3 position5 = position + new Vector3 (0, 0, -1);
			Vector3 position6 = position + new Vector3 (1, 0, 0);
			Vector3 position7 = position + new Vector3 (-1, 0, 0);
			SetBlockAt(position2, block);
			SetBlockAt(position3, block);
			SetBlockAt(position4, block);
			SetBlockAt(position5, block);
			SetBlockAt(position6, block);
			SetBlockAt(position7, block);
		}
		if (power >= 2) {//2 by 2 growth expansion
			/*			z/y - axis
			 *			*
			 * 		   *x*
			 * 		  *xxx* Center diagram X's are in power 1, 
			 * 		   *x*
			 * 			*
			 */
			Vector3 position8 = position + new Vector3 (0, 2, 0);
			Vector3 position9 = position + new Vector3 (0, 1, 1);
			Vector3 position10 = position + new Vector3 (0, 1, -1);
			Vector3 position11 = position + new Vector3 (1, 1, 0);
			Vector3 position12 = position + new Vector3 (-1, 1, 0);
			Vector3 position13 = position + new Vector3 (-1, 0, -1);
			Vector3 position14 = position + new Vector3 (-1, 0, 1);
			Vector3 position15 = position + new Vector3 (1, 0, -1);
			Vector3 position16 = position + new Vector3 (1, 0, 1);
			Vector3 position17 = position + new Vector3 (0, -1, -1);
			Vector3 position18 = position + new Vector3 (0, -1, 1);
			Vector3 position19 = position + new Vector3 (-1, -1, 0);
			Vector3 position20 = position + new Vector3 (1, -1, 0);
			Vector3 position21 = position + new Vector3 (0, 0, 2);
			Vector3 position22 = position + new Vector3 (2, 0, 0);
			Vector3 position23 = position + new Vector3 (-2, 0, 0);
			Vector3 position24 = position + new Vector3 (0, 0, -2);
			Vector3 position25 = position + new Vector3 (0, -2, 0);
			SetBlockAt(position8, block);
			SetBlockAt(position9, block);
			SetBlockAt(position10, block);
			SetBlockAt(position11, block);
			SetBlockAt(position12, block);
			SetBlockAt(position13, block);
			SetBlockAt(position14, block);
			SetBlockAt(position15, block);
			SetBlockAt(position16, block);
			SetBlockAt(position17, block);
			SetBlockAt(position18, block);
			SetBlockAt(position19, block);
			SetBlockAt(position20, block);
			SetBlockAt(position21, block);
			SetBlockAt(position22, block);
			SetBlockAt(position23, block);
			SetBlockAt(position24, block);
			SetBlockAt(position25, block);
		}
		//print ("Replacing");
		SetBlockAt(position, block);
		
	}
	public void ReplaceBlockExplodeWest(int power, RaycastHit hit, byte block){
		//Direct1 = 4
		//Debug.Log ("West");
		Vector3 position = hit.point; //base hit regardless
		position+=(hit.normal*-0.5f);
		/*			z/y - axis
		 *			*
		 * 		   ** Pattern
		 * 			*
		 * */
		if (power >= 1) {
			Vector3 position2 = position + new Vector3 (-1, 0, 0);
			Vector3 position3 = position + new Vector3 (0, 1, 0);
			Vector3 position4 = position + new Vector3 (0, -1, 0);
			Vector3 position5 = position + new Vector3 (0, 0, 1);
			Vector3 position6 = position + new Vector3 (0, 0, -1);
			SetBlockAtSavePowerup(position2, block);
			SetBlockAtSavePowerup(position3, block);
			SetBlockAtSavePowerup(position4, block);
			SetBlockAtSavePowerup(position5, block);
			SetBlockAtSavePowerup(position6, block);
		}
		/*		z/y - axis
		 *		*
		 * 	   *x
		 * 	  *xx Pattern
		 * 	   *x
		 * 		*
		 * */
		if (power >= 2) {
			Vector3 position7 = position + new Vector3 (-1, 0, -1);
			Vector3 position8 = position + new Vector3 (-1, 0, 1);
			Vector3 position9 = position + new Vector3 (-1, -1, 0);
			Vector3 position10 = position + new Vector3 (-1, 1, 0);
			Vector3 position11 = position + new Vector3 (0, 0, -2);
			Vector3 position12 = position + new Vector3 (0, 0, 2);
			Vector3 position13 = position + new Vector3 (0, -2, 0);
			Vector3 position14 = position + new Vector3 (0, 2, 0);
			Vector3 position15 = position + new Vector3 (-2, 0, 0);
			Vector3 position16 = position + new Vector3 (0, 1, -1);
			Vector3 position17 = position + new Vector3 (0, 1, 1);
			Vector3 position18 = position + new Vector3 (0, -1, -1);
			Vector3 position19 = position + new Vector3 (0, -1, 1);
			SetBlockAtSavePowerup(position7, block);
			SetBlockAtSavePowerup(position8, block);
			SetBlockAtSavePowerup(position9, block);
			SetBlockAtSavePowerup(position10, block);
			SetBlockAtSavePowerup(position11, block);
			SetBlockAtSavePowerup(position12, block);
			SetBlockAtSavePowerup(position13, block);
			SetBlockAtSavePowerup(position14, block);
			SetBlockAtSavePowerup(position15, block);
			SetBlockAtSavePowerup(position16, block);
			SetBlockAtSavePowerup(position17, block);
			SetBlockAtSavePowerup(position18, block);
			SetBlockAtSavePowerup(position19, block);
		}
		SetBlockAt(position, block);
	}
	public void ReplaceBlockExplodeEast(int power, RaycastHit hit, byte block){
		//Direct1 = 2
//		Debug.Log ("East");
		Vector3 position = hit.point; //base hit regardless
		position+=(hit.normal*-0.5f);
		/*			z/y - axis
		 *			*
		 * 		    ** Pattern
		 * 			*
		 * */
		if (power >= 1) {
			Vector3 position2 = position + new Vector3 (1, 0, 0);
			Vector3 position3 = position + new Vector3 (0, 1, 0);
			Vector3 position4 = position + new Vector3 (0, -1, 0);
			Vector3 position5 = position + new Vector3 (0, 0, 1);
			Vector3 position6 = position + new Vector3 (0, 0, -1);
			SetBlockAtSavePowerup(position2, block);
			SetBlockAtSavePowerup(position3, block);
			SetBlockAtSavePowerup(position4, block);
			SetBlockAtSavePowerup(position5, block);
			SetBlockAtSavePowerup(position6, block);
		}
		/*		z/y - axis
		 *		*
		 * 	    x*
		 * 	    xx* Pattern
		 * 	    x*
		 * 		*
		 * */
		if (power >= 2) {
			Vector3 position7 = position + new Vector3 (1, 0, -1);
			Vector3 position8 = position + new Vector3 (1, 0, 1);
			Vector3 position9 = position + new Vector3 (1, -1, 0);
			Vector3 position10 = position + new Vector3 (1, 1, 0);
			Vector3 position11 = position + new Vector3 (0, 0, -2);
			Vector3 position12 = position + new Vector3 (0, 0, 2);
			Vector3 position13 = position + new Vector3 (0, -2, 0);
			Vector3 position14 = position + new Vector3 (0, 2, 0);
			Vector3 position15 = position + new Vector3 (2, 0, 0);
			Vector3 position16 = position + new Vector3 (0, 1, -1);
			Vector3 position17 = position + new Vector3 (0, 1, 1);
			Vector3 position18 = position + new Vector3 (0, -1, -1);
			Vector3 position19 = position + new Vector3 (0, -1, 1);
			SetBlockAtSavePowerup(position7, block);
			SetBlockAtSavePowerup(position8, block);
			SetBlockAtSavePowerup(position9, block);
			SetBlockAtSavePowerup(position10, block);
			SetBlockAtSavePowerup(position11, block);
			SetBlockAtSavePowerup(position12, block);
			SetBlockAtSavePowerup(position13, block);
			SetBlockAtSavePowerup(position14, block);
			SetBlockAtSavePowerup(position15, block);
			SetBlockAtSavePowerup(position16, block);
			SetBlockAtSavePowerup(position17, block);
			SetBlockAtSavePowerup(position18, block);
			SetBlockAtSavePowerup(position19, block);
		}
		SetBlockAt(position, block);
	}
	public void ReplaceBlockExplodeNorth(int power, RaycastHit hit, byte block){
		//Direct1 = 1
		//Debug.Log ("North");
		Vector3 position = hit.point; //base hit regardless
		position+=(hit.normal*-0.5f);
		/*			z - axis
		 *	        *
		 * 		   *** Pattern
		 * */
		if (power >= 1) {
			Vector3 position2 = position + new Vector3 (1, 0, 0);
			Vector3 position3 = position + new Vector3 (-1, 0, 0);
			Vector3 position4 = position + new Vector3 (0, -1, 0);
			Vector3 position5 = position + new Vector3 (0, 1, 0);
			Vector3 position6 = position + new Vector3 (0, 0, 1);
			SetBlockAtSavePowerup(position2, block);
			SetBlockAtSavePowerup(position3, block);
			SetBlockAtSavePowerup(position4, block);
			SetBlockAtSavePowerup(position5, block);
			SetBlockAtSavePowerup(position6, block);
		}
		/*		z - axis
		 *      *
		 * 	   *x*
		 * 	  *xxx* Pattern
		 * */
		if (power >= 2) {
			Vector3 position7 = position + new Vector3 (1, 1, 0);
			Vector3 position8 = position + new Vector3 (1, -1, 0);
			Vector3 position9 = position + new Vector3 (-1, -1, 0);
			Vector3 position10 = position + new Vector3 (-1, 1, 0);
			Vector3 position11 = position + new Vector3 (2, 0, 0);
			Vector3 position12 = position + new Vector3 (-2, 0, 0);
			Vector3 position13 = position + new Vector3 (0, -2, 0);
			Vector3 position14 = position + new Vector3 (0, 2, 0);
			Vector3 position15 = position + new Vector3 (0, 0, 2);
			Vector3 position16 = position + new Vector3 (0, 1, 1);
			Vector3 position17 = position + new Vector3 (0, -1, 1);
			Vector3 position18 = position + new Vector3 (1, 0, 1);
			Vector3 position19 = position + new Vector3 (-1, 0, 1);
			SetBlockAtSavePowerup(position7, block);
			SetBlockAtSavePowerup(position8, block);
			SetBlockAtSavePowerup(position9, block);
			SetBlockAtSavePowerup(position10, block);
			SetBlockAtSavePowerup(position11, block);
			SetBlockAtSavePowerup(position12, block);
			SetBlockAtSavePowerup(position13, block);
			SetBlockAtSavePowerup(position14, block);
			SetBlockAtSavePowerup(position15, block);
			SetBlockAtSavePowerup(position16, block);
			SetBlockAtSavePowerup(position17, block);
			SetBlockAtSavePowerup(position18, block);
			SetBlockAtSavePowerup(position19, block);
		}
		SetBlockAt(position, block);
	}
	public void ReplaceBlockExplodeSouth(int power, RaycastHit hit, byte block){
		//Direct1 = 3
		//Debug.Log ("South");
		Vector3 position = hit.point; //base hit regardless
		position+=(hit.normal*-0.5f);
		/*			z - axis
		 * 		   *** Pattern
		 *          *
		 * */
		if (power >= 1) {
			Vector3 position2 = position + new Vector3 (1, 0, 0);
			Vector3 position3 = position + new Vector3 (-1, 0, 0);
			Vector3 position4 = position + new Vector3 (0, -1, 0);
			Vector3 position5 = position + new Vector3 (0, 1, 0);
			Vector3 position6 = position + new Vector3 (0, 0, -1);
			SetBlockAtSavePowerup(position2, block);
			SetBlockAtSavePowerup(position3, block);
			SetBlockAtSavePowerup(position4, block);
			SetBlockAtSavePowerup(position5, block);
			SetBlockAtSavePowerup(position6, block);
		}
		/*		z - axis
		 * 	  *xxx* Pattern
		 *     *x*
		 *      *
		 * */
		if (power >= 2) {
			Vector3 position7 = position + new Vector3 (1, 1, 0);
			Vector3 position8 = position + new Vector3 (1, -1, 0);
			Vector3 position9 = position + new Vector3 (-1, -1, 0);
			Vector3 position10 = position + new Vector3 (-1, 1, 0);
			Vector3 position11 = position + new Vector3 (2, 0, 0);
			Vector3 position12 = position + new Vector3 (-2, 0, 0);
			Vector3 position13 = position + new Vector3 (0, -2, 0);
			Vector3 position14 = position + new Vector3 (0, 2, 0);
			Vector3 position15 = position + new Vector3 (0, 0, -2);
			Vector3 position16 = position + new Vector3 (0, 1, -1);
			Vector3 position17 = position + new Vector3 (0, -1, -1);
			Vector3 position18 = position + new Vector3 (1, 0, -1);
			Vector3 position19 = position + new Vector3 (-1, 0, -1);
			SetBlockAtSavePowerup(position7, block);
			SetBlockAtSavePowerup(position8, block);
			SetBlockAtSavePowerup(position9, block);
			SetBlockAtSavePowerup(position10, block);
			SetBlockAtSavePowerup(position11, block);
			SetBlockAtSavePowerup(position12, block);
			SetBlockAtSavePowerup(position13, block);
			SetBlockAtSavePowerup(position14, block);
			SetBlockAtSavePowerup(position15, block);
			SetBlockAtSavePowerup(position16, block);
			SetBlockAtSavePowerup(position17, block);
			SetBlockAtSavePowerup(position18, block);
			SetBlockAtSavePowerup(position19, block);
		}
		SetBlockAt(position, block);
	}
	public void ReplaceBlockExplodeUp(int power, RaycastHit hit, byte block){
		//Direct2 = 1
		//Debug.Log ("Up");
		Vector3 position = hit.point; //base hit regardless
		position+=(hit.normal*-0.5f);
		/*			y - axis
		 *	        *
		 * 		   *** Pattern
		 * */
		if (power >= 1) {
			Vector3 position2 = position + new Vector3 (1, 0, 0);
			Vector3 position3 = position + new Vector3 (-1, 0, 0);
			Vector3 position4 = position + new Vector3 (0, 0, -1);
			Vector3 position5 = position + new Vector3 (0, 0, 1);
			Vector3 position6 = position + new Vector3 (0, 1, 0);
			SetBlockAtSavePowerup(position2, block);
			SetBlockAtSavePowerup(position3, block);
			SetBlockAtSavePowerup(position4, block);
			SetBlockAtSavePowerup(position5, block);
			SetBlockAtSavePowerup(position6, block);
		}
		/*		y - axis
		 *      *
		 * 	   *x*
		 * 	  *xxx* Pattern
		 * */
		if (power >= 2) {
			Vector3 position7 = position + new Vector3 (1, 0, 1);
			Vector3 position8 = position + new Vector3 (1, 0, -1);
			Vector3 position9 = position + new Vector3 (-1, 0, -1);
			Vector3 position10 = position + new Vector3 (-1, 0, 1);
			Vector3 position11 = position + new Vector3 (2, 0, 0);
			Vector3 position12 = position + new Vector3 (-2, 0, 0);
			Vector3 position13 = position + new Vector3 (0, 0, -2);
			Vector3 position14 = position + new Vector3 (0, 0, 2);
			Vector3 position15 = position + new Vector3 (0, 2, 0);
			Vector3 position16 = position + new Vector3 (0, 1, 1);
			Vector3 position17 = position + new Vector3 (0, 1, -1);
			Vector3 position18 = position + new Vector3 (1, 1, 0);
			Vector3 position19 = position + new Vector3 (-1, 1, 0);
			SetBlockAtSavePowerup(position7, block);
			SetBlockAtSavePowerup(position8, block);
			SetBlockAtSavePowerup(position9, block);
			SetBlockAtSavePowerup(position10, block);
			SetBlockAtSavePowerup(position11, block);
			SetBlockAtSavePowerup(position12, block);
			SetBlockAtSavePowerup(position13, block);
			SetBlockAtSavePowerup(position14, block);
			SetBlockAtSavePowerup(position15, block);
			SetBlockAtSavePowerup(position16, block);
			SetBlockAtSavePowerup(position17, block);
			SetBlockAtSavePowerup(position18, block);
			SetBlockAtSavePowerup(position19, block);
		}
		SetBlockAt(position, block);
	}
	public void ReplaceBlockExplodeDown(int power, RaycastHit hit, byte block){
		//Direct2 = 2
		//Debug.Log ("Down");
		Vector3 position = hit.point; //base hit regardless
		position+=(hit.normal*-0.5f);
		/*			y - axis
		 * 		   *** Pattern
		 *          *
		 * */
		if (power >= 1) {
			Vector3 position2 = position + new Vector3 (1, 0, 0);
			Vector3 position3 = position + new Vector3 (-1, 0, 0);
			Vector3 position4 = position + new Vector3 (0, 0, -1);
			Vector3 position5 = position + new Vector3 (0, 0, 1);
			Vector3 position6 = position + new Vector3 (0, -1, 0);
			SetBlockAtSavePowerup(position2, block);
			SetBlockAtSavePowerup(position3, block);
			SetBlockAtSavePowerup(position4, block);
			SetBlockAtSavePowerup(position5, block);
			SetBlockAtSavePowerup(position6, block);
		}
		/*		y - axis
		 * 	  *xxx* Pattern
		 * 	   *x*
		 *      *
		 * */
		if (power >= 2) {
			Vector3 position7 = position + new Vector3 (1, 0, 1);
			Vector3 position8 = position + new Vector3 (1, 0, -1);
			Vector3 position9 = position + new Vector3 (-1, 0, -1);
			Vector3 position10 = position + new Vector3 (-1, 0, 1);
			Vector3 position11 = position + new Vector3 (2, 0, 0);
			Vector3 position12 = position + new Vector3 (-2, 0, 0);
			Vector3 position13 = position + new Vector3 (0, 0, -2);
			Vector3 position14 = position + new Vector3 (0, 0, 2);
			Vector3 position15 = position + new Vector3 (0, -2, 0);
			Vector3 position16 = position + new Vector3 (0, -1, 1);
			Vector3 position17 = position + new Vector3 (0, -1, -1);
			Vector3 position18 = position + new Vector3 (1, -1, 0);
			Vector3 position19 = position + new Vector3 (-1, -1, 0);
			SetBlockAtSavePowerup(position7, block);
			SetBlockAtSavePowerup(position8, block);
			SetBlockAtSavePowerup(position9, block);
			SetBlockAtSavePowerup(position10, block);
			SetBlockAtSavePowerup(position11, block);
			SetBlockAtSavePowerup(position12, block);
			SetBlockAtSavePowerup(position13, block);
			SetBlockAtSavePowerup(position14, block);
			SetBlockAtSavePowerup(position15, block);
			SetBlockAtSavePowerup(position16, block);
			SetBlockAtSavePowerup(position17, block);
			SetBlockAtSavePowerup(position18, block);
			SetBlockAtSavePowerup(position19, block);
		}
		SetBlockAt(position, block);
	}
	public void ReplaceBlockExplodeDirection(int direct1, int direct2, int power, RaycastHit hit, byte block) {
		//removes a block at these impact coordinates, you can raycast against the terrain and call this with the hit.point
		/*Direction1 will be split with
		 * 1 = North
		 * 2 = East
		 * 3 = South
		 * 4 = West
		 * Direction2 will be split with 
		 * 0 = base height
		 * 1 = up
		 * 2 = down
		 * This combo allows if Direct2 != 0, Direct1's outcome is used while if direct2  is 1 or 2 they override the impact direction
		 * */
		if (direct2 == 0) {
			if(direct1 == 1){
				ReplaceBlockExplodeNorth(power, hit, block);
			}else if(direct1 == 2){
				ReplaceBlockExplodeEast(power, hit, block);
			}else if(direct1 == 3){
				ReplaceBlockExplodeSouth(power, hit, block);
			}else if(direct1 == 4){
				ReplaceBlockExplodeWest(power, hit, block);
			}
		}else if(direct2 == 1){
			ReplaceBlockExplodeUp(power, hit, block);
		}else{
			ReplaceBlockExplodeDown(power, hit, block);
		}
	}

	public void AddBlockCursor( byte block){
		//Adds the block specified where the mouse cursor is pointing
		
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		
		if (Physics.Raycast (ray, out hit)) {
			
			AddBlockAt(hit, block);
			Debug.DrawLine(ray.origin,ray.origin+( ray.direction*hit.distance),
			               Color.green,2);
		}
		
	}
	
	public void ReplaceBlockAt(RaycastHit hit, byte block) {
		//removes a block at these impact coordinates, you can raycast against the terrain and call this with the hit.point
		Vector3 position = hit.point;
		position+=(hit.normal*-0.5f);
		//print ("Replacing");
		SetBlockAt(position, block);
	}
	
	public void AddBlockAt(RaycastHit hit, byte block) {
		//adds the specified block at these impact coordinates, you can raycast against the terrain and call this with the hit.point
		Vector3 position = hit.point;
		position+=(hit.normal*0.5f);
		
		SetBlockAt(position,block);
		
	}

	public void SetBlockAt(Vector3 position, byte block) {
		//sets the specified block at these coordinates
		
		int x= Mathf.RoundToInt( position.x );
		int y= Mathf.RoundToInt( position.y );
		int z= Mathf.RoundToInt( position.z );
		
		SetBlockAt(x,y,z,block);
	}

	public void SetBlockAtSavePowerup(Vector3 position, byte block) {
		//sets the specified block at these coordinates
		
		int x= Mathf.RoundToInt( position.x );
		int y= Mathf.RoundToInt( position.y );
		int z= Mathf.RoundToInt( position.z );
		if (world.data [x, y, z] == 3) {
			return;
		}else{
			SetBlockAt(x,y,z,block);
		}
	}
	
	public void SetBlockAt(int x, int y, int z, byte block) {
		//adds the specified block at these coordinates
		
		//print("Adding: " + x + ", " + y + ", " + z);
		//keeps player from destroying blocks on the edge of the map
		if (world.data [x + 1, y, z] == 254) {
			world.data [x + 1, y, z] = 255;
		}
		if (world.data [x - 1, y, z] == 254) {
			world.data [x - 1, y, z] = 255;
		}
		if (world.data [x, y, z + 1] == 254) {
			world.data [x, y, z + 1] = 255;
		}
		if (world.data [x, y, z - 1] == 254) {
			world.data [x, y, z - 1] = 255;
		}
		if (world.data [x, y + 1, z] == 254) {
			world.data [x, y + 1, z] = 255;
		}
		
		world.data[x,y,z]=block;
		UpdateChunkAt(x,y,z);
		
	}
	
	//To do: add a way to just flag the chunk for update then it update it in lateupdate
	public void UpdateChunkAt(int x, int y, int z){ 
		//Updates the chunk containing this block
		
		int updateX= Mathf.FloorToInt( x/world.chunkSize);
		int updateY= Mathf.FloorToInt( y/world.chunkSize);
		int updateZ= Mathf.FloorToInt( z/world.chunkSize);
		
		//print("Updating: " + updateX + ", " + updateY + ", " + updateZ);
		//world.chunks[updateX,updateY, updateZ].GenerateMesh();
		world.chunks[updateX,updateY, updateZ].update=true;
		if(x-(world.chunkSize*updateX)==0 && updateX!=0){
			world.chunks[updateX-1,updateY, updateZ].update=true;
		}
		
		if(x-(world.chunkSize*updateX)==15 && updateX!=world.chunks.GetLength(0)-1){
			world.chunks[updateX+1,updateY, updateZ].update=true;
		}
		
		if(y-(world.chunkSize*updateY)==0 && updateY!=0){
			world.chunks[updateX,updateY-1, updateZ].update=true;
		}
		
		if(y-(world.chunkSize*updateY)==15 && updateY!=world.chunks.GetLength(1)-1){
			world.chunks[updateX,updateY+1, updateZ].update=true;
		}
		
		if(z-(world.chunkSize*updateZ)==0 && updateZ!=0){
			world.chunks[updateX,updateY, updateZ-1].update=true;
		}
		
		if(z-(world.chunkSize*updateZ)==15 && updateZ!=world.chunks.GetLength(2)-1){
			world.chunks[updateX,updateY, updateZ+1].update=true;
		}
  
	}
}
