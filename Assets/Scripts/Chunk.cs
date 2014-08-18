using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chunk : MonoBehaviour {
	
	private List<Vector3> newVertices = new List<Vector3>();
	private List<int> newTriangles = new List<int>();
	private List<Vector2> newUV = new List<Vector2>();
	
	private float tUnit = 0.25f;
	private Vector2 tStone = new Vector2 (0, 2);
	private Vector2 tGrass = new Vector2 (1, 0);
	private Vector2 tHeart = new Vector2 (3, 1);
	private Vector2 tBedrock = new Vector2 (3, 3);
	
	private Mesh mesh;
	private MeshCollider col;
	
	private int faceCount;
	public GameObject worldGO;
	private World world;
	public int chunkSize=16;
	public int chunkX;
	public int chunkY;
	public int chunkZ;
	//private Vector2 tGrassTop = new Vector2 (2, 1);
	public bool update;

//	public bool makingHeart;
//	public Vector3[] heartLocations = new Vector3[100];
//	public int heartIter = 0;

	// Use this for initialization
	void Start () {
		mesh = GetComponent<MeshFilter> ().mesh;
		col = GetComponent<MeshCollider> ();
		world=worldGO.GetComponent("World") as World;
		GenerateMesh ();
		/*CubeTop(0,0,0,0);
		CubeNorth(0,0,0,0);
		CubeEast(0,0,0,0);
		CubeSouth(0,0,0,0);
		CubeWest(0,0,0,0);//Single box tester
		CubeBot(0,0,0,0);
		UpdateMesh ();*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	byte Block(int x, int y, int z){
		return world.Block(x+chunkX,y+chunkY,z+chunkZ);
	}

	void CubeTop (int x, int y, int z, byte block) {
		
		newVertices.Add(new Vector3 (x,  y,  z + 1));
		newVertices.Add(new Vector3 (x + 1, y,  z + 1));
		newVertices.Add(new Vector3 (x + 1, y,  z ));
		newVertices.Add(new Vector3 (x,  y,  z ));
		
		Vector2 texturePos=new Vector2(0,0);
		
		if(Block(x,y,z)==1){
			texturePos=tStone;
		} else if(Block(x,y,z)==2){
			texturePos=tGrass;
		} else if(Block (x,y,z)==3){
			texturePos=tHeart;
		}
		if (y == chunkY || y == chunkY+1) {
			texturePos = tBedrock;
		}

//		if(makingHeart == true)
//			texturePos=tHeart;

		Cube (texturePos);
	}
	void CubeNorth (int x, int y, int z, byte block) {
		//CubeNorth
		newVertices.Add(new Vector3 (x + 1, y-1, z + 1));
		newVertices.Add(new Vector3 (x + 1, y, z + 1));
		newVertices.Add(new Vector3 (x, y, z + 1));
		newVertices.Add(new Vector3 (x, y-1, z + 1));

		Vector2 texturePos=new Vector2(0,0);;
		
		if(Block(x,y,z)==1){
			texturePos=tStone;
		} else if(Block(x,y,z)==2){
			texturePos=tGrass;
		} else if(Block (x,y,z)==3){
			texturePos=tHeart;
		}
		if (y == chunkY || y == chunkY+1) {
			texturePos = tBedrock;
		}
//		if(makingHeart == true)
//			texturePos=tHeart;

		Cube (texturePos);
	}
	void CubeEast (int x, int y, int z, byte block) {
		//CubeEast
		newVertices.Add(new Vector3 (x + 1, y - 1, z));
		newVertices.Add(new Vector3 (x + 1, y, z));
		newVertices.Add(new Vector3 (x + 1, y, z + 1));
		newVertices.Add(new Vector3 (x + 1, y - 1, z + 1));

		Vector2 texturePos=new Vector2(0,0);;
		
		if(Block(x,y,z)==1){
			texturePos=tStone;
		} else if(Block(x,y,z)==2){
			texturePos=tGrass;
		} else if(Block (x,y,z)==3){
			texturePos=tHeart;
		}
		if (y == chunkY || y == chunkY+1) {
			texturePos = tBedrock;
		}
//		if(makingHeart == true)
//			texturePos=tHeart;

		Cube (texturePos);
	}
	void CubeSouth (int x, int y, int z, byte block) {
		//CubeSouth
		newVertices.Add(new Vector3 (x, y - 1, z));
		newVertices.Add(new Vector3 (x, y, z));
		newVertices.Add(new Vector3 (x + 1, y, z));
		newVertices.Add(new Vector3 (x + 1, y - 1, z));
		
		Vector2 texturePos=new Vector2(0,0);;
		
		if(Block(x,y,z)==1){
			texturePos=tStone;
		} else if(Block(x,y,z)==2){
			texturePos=tGrass;
		} else if(Block (x,y,z)==3){
			texturePos=tHeart;
		}
		if (y == chunkY || y == chunkY+1) {
			texturePos = tBedrock;
		}
//		if(makingHeart == true)
//			texturePos=tHeart;

		Cube (texturePos);
	}
	void CubeWest (int x, int y, int z, byte block) {
		//CubeWest
		newVertices.Add(new Vector3 (x, y- 1, z + 1));
		newVertices.Add(new Vector3 (x, y, z + 1));
		newVertices.Add(new Vector3 (x, y, z));
		newVertices.Add(new Vector3 (x, y - 1, z));
		
		Vector2 texturePos=new Vector2(0,0);;
		
		if(Block(x,y,z)==1){
			texturePos=tStone;
		} else if(Block(x,y,z)==2){
			texturePos=tGrass;
		} else if(Block (x,y,z)==3){
			texturePos=tHeart;
		}
		if (y == chunkY || y == chunkY+1) {
			texturePos = tBedrock;
		}
//		if(makingHeart == true)
//			texturePos=tHeart;

		Cube (texturePos);
	}
	void CubeBot (int x, int y, int z, byte block) {
		//CubeBot
		newVertices.Add(new Vector3 (x,  y-1,  z ));
		newVertices.Add(new Vector3 (x + 1, y-1,  z ));
		newVertices.Add(new Vector3 (x + 1, y-1,  z + 1));
		newVertices.Add(new Vector3 (x,  y-1,  z + 1));
		
		Vector2 texturePos=new Vector2(0,0);;
		
		if(Block(x,y,z)==1){
			texturePos=tStone;
		} else if(Block(x,y,z)==2){
			texturePos=tGrass;
		} else if(Block (x,y,z)==3){
			texturePos=tHeart;
		}
		if (y == chunkY || y == chunkY+1) {
			texturePos = tBedrock;
		}
//		if(makingHeart == true)
//			texturePos=tHeart;

		Cube (texturePos);
	}

	void Cube (Vector2 texturePos) {
		
		newTriangles.Add(faceCount * 4  ); //1
		newTriangles.Add(faceCount * 4 + 1 ); //2
		newTriangles.Add(faceCount * 4 + 2 ); //3
		newTriangles.Add(faceCount * 4  ); //1
		newTriangles.Add(faceCount * 4 + 2 ); //3
		newTriangles.Add(faceCount * 4 + 3 ); //4
		
		newUV.Add(new Vector2 (tUnit * texturePos.x + tUnit, tUnit * texturePos.y));
		newUV.Add(new Vector2 (tUnit * texturePos.x + tUnit, tUnit * texturePos.y + tUnit));
		newUV.Add(new Vector2 (tUnit * texturePos.x, tUnit * texturePos.y + tUnit));
		newUV.Add(new Vector2 (tUnit * texturePos.x, tUnit * texturePos.y));
		
		faceCount++; // Add this line
	}
	
	void UpdateMesh ()
	{
		mesh.Clear ();
		mesh.vertices = newVertices.ToArray();
		mesh.uv = newUV.ToArray();
		mesh.triangles = newTriangles.ToArray();
		mesh.Optimize ();
		mesh.RecalculateNormals ();
		
		col.sharedMesh=null;
		col.sharedMesh=mesh;
		
		newVertices.Clear();
		newUV.Clear();
		newTriangles.Clear();

		faceCount = 0;
	}
	
	void LateUpdate () {
		if(update){
			GenerateMesh();
			update=false;
		}
	}

	public void GenerateMesh(){
		
		for (int x=0; x<chunkSize; x++){
			for (int y=0; y<chunkSize; y++){
				for (int z=0; z<chunkSize; z++){
					//This code will run for every block in the chunk


//					if(Random.Range(0f, 1f) < 0.01f){
//						makingHeart = true;
//						heartLocations[heartIter] = new Vector3(x,y,z);
//						heartIter++;
//						if(x == chunkSize - 1){
//							heartIter = 0;
//						}
//					}
//					else{
//						makingHeart = false;
//					}


					if(Block(x,y,z)!=0){
						//If the block is solid
						
						if(Block(x,y+1,z)==0){
							//Block above is air
							CubeTop(x,y,z,Block(x,y,z));
						}
						
						if(Block(x,y-1,z)==0){
							//Block below is air
							CubeBot(x,y,z,Block(x,y,z));
							
						}
						
						if(Block(x+1,y,z)==0){
							//Block east is air
							CubeEast(x,y,z,Block(x,y,z));
							
						}
						
						if(Block(x-1,y,z)==0){
							//Block west is air
							CubeWest(x,y,z,Block(x,y,z));
							
						}
						
						if(Block(x,y,z+1)==0){
							//Block north is air
							CubeNorth(x,y,z,Block(x,y,z));
							
						}
						
						if(Block(x,y,z-1)==0){
							//Block south is air
							CubeSouth(x,y,z,Block(x,y,z));
							
						}
						
					}
					
				}
			}
		}
		
		UpdateMesh ();
	}
}
