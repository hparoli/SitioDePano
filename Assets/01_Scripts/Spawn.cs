using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	//B: Random Spawn Point toda vez que rodar o jogo

	public GameObject dollObj;                // prefab da boneca
	public Transform [] spawnPoints;         // Array c/ Spawn Points



	void Start () {
	
		Invoke ("Spawner", 0);
	}

	void Spawner() {
	
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		Instantiate (dollObj, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);


	}
}
