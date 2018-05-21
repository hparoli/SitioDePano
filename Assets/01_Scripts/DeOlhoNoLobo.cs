using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeOlhoNoLobo : MonoBehaviour {

	[SerializeField]
	private GameObject[] spawns, arbustos;

	[SerializeField]
	private GameObject lobo;

	[SerializeField]
	private float delay, time, moveSpeed;

	[SerializeField]
	private Text cronometro;

	public int ovelhas;
	// Use this for initialization
	void Start () {
		time = 45f;
		delay = 3f;
		ovelhas = 0;
		moveSpeed = 2.5f;
		StartCoroutine("SpawnLobo");
	}
	
	// Update is called once per frame
	void Update () {
		if(time > 0){
			time -= Time.deltaTime;
			cronometro.text = time.ToString("f0");
		} else {
			time = 0;
		}

		if(time <= 30){
			delay = 2.5f;
			moveSpeed = 3f;
		}
		
		if(time <= 20){
			delay = 2f;
			moveSpeed = 3.5f;
		}
		
		if(time <= 10){
			delay = 1.5f;
			moveSpeed = 4f;
		}

		
		if(ovelhas == 10)
			StartCoroutine("GameOver");
	}

	IEnumerator SpawnLobo(){
		int spawnPointIndex = Random.Range (0, spawns.Length);
		GameObject loboGO = Instantiate (lobo, spawns[spawnPointIndex].transform.position, spawns[spawnPointIndex].transform.rotation);
		StartCoroutine("Arbusto", spawnPointIndex);
		yield return new WaitForSeconds(0.1f);
		loboGO.GetComponent<LoboBehavior>().SetWaypointIndex(spawnPointIndex, moveSpeed);
		yield return new WaitForSeconds(delay);
		
		if(time > 0){
			StartCoroutine("SpawnLobo");
		} else{
			StartCoroutine("GameOver");
		}
	}

	IEnumerator Arbusto(int index){
		arbustos[index].GetComponent<Animator>().SetBool("Mexe",true);
		yield return new WaitForSeconds(2f);
		arbustos[index].GetComponent<Animator>().SetBool("Mexe",false);
	}

	IEnumerator GameOver(){
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(7);
	}

	public void SetOvelhas(){
		ovelhas++;
	}
}
