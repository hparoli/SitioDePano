using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Spawn : MonoBehaviour {


	//B: Random Spawn Point toda vez que rodar o jogo

	int idTema;
	public GameObject dollObj; // prefab da boneca
	public GameObject Tutorial;
	public Transform[] spawnPoints; // Array c/ Spawn Points
	public string [] txtTutorial;
	public Text infoTutorial;

	public int dollCount;
	public int notaFinal;
	public float tempo;
	public bool StartTutorial = true;

	int indexTutorial = 0;





	void Start () 
	{
		idTema = PlayerPrefs.GetInt ("idTema");
		if (StartTutorial) {
			TakeTutorial ();
		}
	}

	void Update()
	{
		
		Cronometro ();

	}

	public void TakeTutorial(){
		
		StartCoroutine ("tutorialTextChanges");
		Instantiate (dollObj, spawnPoints [2].position, spawnPoints [2].rotation);
	}

	public IEnumerator tutorialTextChanges(){


		infoTutorial.text = txtTutorial [indexTutorial];
		if (indexTutorial < 2){
			indexTutorial++;
		}
		yield return new WaitForSeconds (2);
		infoTutorial.text = txtTutorial [indexTutorial];
		if (indexTutorial < 2){
			indexTutorial++;

		}
		yield return new WaitForSeconds (2);
}

	public void StartGame(){
			StartTutorial = false;
			Tutorial.SetActive (false);
			CreatDoll ();
		}

	public void CreatDoll() 
	{
		
			if (dollCount < 3) {
				dollCount++;
				int spawnPointIndex = Random.Range (0, spawnPoints.Length);
				Instantiate (dollObj, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			}
			else {
				ToScore ();
			}

		} 
	
	void Cronometro()
	{
		tempo += 1 * Time.deltaTime;

	}

	void ToScore()
	{

		if (tempo <= 2f) 
		{
			notaFinal = 20;
		}
		else if (tempo <= 3f)
		{
			notaFinal = 10;
		}
		else if (tempo <= 7f)
		{
			notaFinal = 7;
		}

		else if (tempo <= 10f) 
		{
			notaFinal = 5;
		}


		PlayerPrefs.SetInt ("notaFinalTemp" + idTema.ToString (), notaFinal);
		Score.infoValue = string.Format ("Parabéns, você me achou em {0} segundos e tirou {1}!", tempo.ToString ("0.0"), notaFinal);
		SceneManager.LoadScene ("Score");
	}
}
