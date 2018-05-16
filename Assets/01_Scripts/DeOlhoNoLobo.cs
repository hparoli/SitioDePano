using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeOlhoNoLobo : MonoBehaviour {

	[SerializeField]
	private GameObject[] spawns;

	[SerializeField]
	private GameObject lobo;

	[SerializeField]
	private float delay, time;

	public int ovelhas;
	// Use this for initialization
	void Start () {
		time = 0f;
		delay = 3f;
		ovelhas = 0;
		StartCoroutine("SpawnLobo");
	}
	
	// Update is called once per frame
	void Update () {
		if(time < 45)
			time += Time.deltaTime;

		if(time >= 20)
			delay = 2.5f;
		
		if(time >= 30)
			delay = 2f;
		
		if(time >= 40)
			delay = 1.5f;
		
		if(ovelhas == 10)
			StartCoroutine("GameOver");
	}

	IEnumerator SpawnLobo(){
		int spawnPointIndex = Random.Range (0, spawns.Length);
		Instantiate (lobo, spawns[spawnPointIndex].transform.position, spawns[spawnPointIndex].transform.rotation);
		yield return new WaitForSeconds(delay);
		if(time < 45)
			StartCoroutine("SpawnLobo");
		else
			StartCoroutine("GameOver");
	}

	IEnumerator GameOver(){
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(7);
	}

	public void SetOvelhas(){
		ovelhas++;
	}
}
