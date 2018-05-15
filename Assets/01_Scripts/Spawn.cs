using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public static Spawn spawn;
	//B: Random Spawn Point toda vez que rodar o jogo

	public GameObject dollObj;                // prefab da boneca
	public Transform[] spawnPoints;         // Array c/ Spawn Points
	public int dollCont;





	void Start () {
	
		Invoke ("creatDolls", 0);
	}

	void Updat(){
	
		creatDolls ();
	}

	void creatDolls() {
		dollCont++;
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		Instantiate (dollObj, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
