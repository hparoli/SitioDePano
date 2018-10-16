﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Spawn : MonoBehaviour {


	//B: Random Spawn Point toda vez que rodar o jogo

	int idTema;
	public GameObject dollObj; // prefab da boneca
	public Transform[] spawnPoints; // Array c/ Spawn Points

	[SerializeField]
	Transform[] spawnpointsGame2;

	private int spawnAnterior;
	public int dollCount;
	public int notaFinal;
	public float tempo;

	[Header("Tutorial")]
	public string [] txtTutorial;
	public Text infoTutorial;
	int indexTutorial = 0;
	[SerializeField]
	GameObject tutorial;
	[SerializeField]
	GameObject[] boardsTutorial;
	[SerializeField]
	GameObject[] imagesTutorial;


	[Header("Celeiro")]
	public Animator[] barnAnims;
	public GameObject ExitBoard;

	[Header("DificultControl")]
	[SerializeField]
	GameObject[] stars;
    [Space(10)]
	[SerializeField]
	GameDificultScripting[] gamedificultScripiting;
	[Space(10)]
	[SerializeField]
	GameObject DificultGameObject;
	
	

	void Start () 
	{
		spawnAnterior = 99;
		idTema = PlayerPrefs.GetInt ("idTema");
		Time.timeScale = 0;
		infoTutorial.text = txtTutorial [indexTutorial];
		boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (false);boardsTutorial [2].SetActive (false);
		imagesTutorial [0].SetActive (true);imagesTutorial [1].SetActive (false);
	}

	void Update()
	{
		Cronometro ();
		StarsPointsControl();
	}

	public void GameDificultControl(int GameDificultValue)
	{	
		for (int i = 0; i < gamedificultScripiting.Length; i++)
		{
			if(gamedificultScripiting[i].gameValue == GameDificultValue)
			{
				gamedificultScripiting[i].gamePrefabDificult.SetActive(true);

			}
			else
			{
				gamedificultScripiting[i].gamePrefabDificult.SetActive(false);	
			}

			DificultGameObject.SetActive(false);
		}
		
	}

	public void StarsPointsControl()
	{
		for (int i = 0; i < stars.Length; i++)
		{
			stars[i].SetActive(false);
		}
		
		notaFinal = PlayerPrefs.GetInt ("notaFinalTemp" + idTema.ToString ());
		Debug.Log(notaFinal);

		if (notaFinal == 10)
		{
			stars[0].SetActive(true);
			stars[1].SetActive(true);
			stars[2].SetActive(true);
		}
		if (notaFinal == 7)
		{
			stars[0].SetActive(true);
			stars[1].SetActive(true);
		}
		if (notaFinal == 5)
		{
			stars[0].SetActive(true);
		}
		
		

	}

	public void ChangeTextTutorialForward(){
		indexTutorial++;
		infoTutorial.text = txtTutorial [indexTutorial];

		if (indexTutorial == 0) {
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (false);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (true);
			imagesTutorial [1].SetActive (false);
		
		}
		if (indexTutorial == 1) {
			boardsTutorial [0].SetActive (false);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (true);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (true);

		}


	}
	public void ChangeTextTutorialBack(){
		indexTutorial--;
		infoTutorial.text = txtTutorial [indexTutorial];


		if (indexTutorial == 0) {
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (false);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (true);
			imagesTutorial [1].SetActive (false);

		}
		if (indexTutorial == 1) {
			boardsTutorial [0].SetActive (false);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (true);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (true);
		
		}


	}



	public void StartGame(int Value)
	{
			if (tutorial)
			{
				tutorial.SetActive (false);
			}
			if (Value == 1)
			{
				CreatDoll ();
			}
			if (Value == 2)
			{
				CreatDoll2();
			}
			dollCount=0;
			
			Time.timeScale = 1;
	}

	public void CreatDoll() 
	{
		
			if (dollCount < 5) 
			{
				dollCount++;
				int spawnPointIndex = Random.Range (0, spawnPoints.Length);
				if(spawnAnterior == spawnPointIndex)
				{
					spawnPointIndex++;	
				}
				GameObject aninha = Instantiate (dollObj, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation) as GameObject;	
				aninha.transform.parent = spawnPoints [spawnPointIndex].transform;	
				spawnAnterior = spawnPointIndex;
				
			}
		else 
			{
				BarnAnin ();
				StartCoroutine ("StartGameOver");
			}

	} 
		public void CreatDoll2() 
	{
		
			if (dollCount < 5) 
			{
				dollCount++;
				int spawnPointIndex = Random.Range (0, spawnpointsGame2.Length);
				if(spawnAnterior == spawnPointIndex)
				{
					spawnPointIndex++;	
				}
				GameObject aninha = Instantiate (dollObj, spawnpointsGame2 [spawnPointIndex].position, spawnpointsGame2 [spawnPointIndex].rotation) as GameObject;	
				aninha.transform.parent = spawnpointsGame2 [spawnPointIndex].transform;	
				spawnAnterior = spawnPointIndex;
				
			}
		else 
			{
				BarnAnin ();
				StartCoroutine ("StartGameOver");
			}

	} 
	
	void Cronometro()
	{
		tempo += 1 * Time.deltaTime;
		
	}

	public void BarnAnin(){

		for (int i = 0; i < barnAnims.Length; i++) 
		{
			barnAnims [i].SetBool ("Active", true);
		}
		ExitBoard.SetActive (false);
	}

	public IEnumerator StartGameOver()
	{
		yield return new WaitForSeconds (2);
		AnaliticsControl.playTime += tempo;
		ToScore ();

	}

	void ToScore()
	{

		if (tempo <= 5f) 
		{
			notaFinal = 20;
		}
		else if (tempo <= 7f)
		{
			notaFinal = 10;
		}
		else if (tempo <= 10f)
		{
			notaFinal = 7;
		}

		else if (tempo <= 15f) 
		{
			notaFinal = 5;
		}

		PlayerPrefs.SetInt ("notaFinalTemp" + idTema.ToString (), notaFinal);
		//Score.infoValue = string.Format ("Parabéns, você me achou em {0} segundos e tirou {1}!", tempo.ToString ("0.0"), notaFinal);
		SceneManager.LoadScene ("Score");
	}
}
