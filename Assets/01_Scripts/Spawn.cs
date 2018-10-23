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
	[Space(10)]
	[SerializeField]
	GameDificultScripting[] gamedificultScripiting;
	[Space(10)]
	[SerializeField]
	GameObject DificultGameObject;

	[SerializeField]
	Button[] gameButtons;
	
	int gamelevel;

	void Start () 
	{
		spawnAnterior = 99;
		idTema = PlayerPrefs.GetInt ("idTema");
		Time.timeScale = 0;
		infoTutorial.text = txtTutorial [indexTutorial];
		boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (false);boardsTutorial [2].SetActive (false);
		imagesTutorial [0].SetActive (true);imagesTutorial [1].SetActive (false);
		OpenLevel();
		//PlayerPrefs.SetInt ("piqueFacil" + idTema.ToString (), 0);
		//PlayerPrefs.SetInt ("piqueMedio" + idTema.ToString (), 0);
		//PlayerPrefs.SetInt ("piqueDificil" + idTema.ToString (), 0);
	}
	void Update()
	{
		Cronometro ();
		StarsPointsControl();
	}

	public void GameDificultControl(int GameDificultValue)
	{	

		gamelevel = GameDificultValue;
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
	public void OpenLevel()
	{
		string dif = PlayerPrefs.GetString("dificuldade" + idTema);
		
		if (dif == "F" ||  dif == "")
		{
			gameButtons[1].interactable = false;
			gameButtons[2].interactable = false;
		}
		else if (dif == "M") 
		{
			gameButtons[2].interactable = false;
		}
	}

	public void StarsPointsControl()
	{
		
		for (int i = 0; i < gamedificultScripiting.Length; i++)
		{
			if(i == 0)
			{
				notaFinal = PlayerPrefs.GetInt ("piqueFacil" + idTema.ToString ());
			}
			else if(i == 1)
			{
				notaFinal = PlayerPrefs.GetInt ("piqueMedio" + idTema.ToString ());
			}

			else if (i == 2)
			{
				notaFinal = PlayerPrefs.GetInt ("piqueDificil" + idTema.ToString ());
			}
			
			for (int j = 0; j < gamedificultScripiting[i].stars.Length; j++)
			{
			 if ((notaFinal == 0 || notaFinal == null) || ( notaFinal == 5 && j > 0 ) || ( notaFinal == 7 && j > 1 ) || ( notaFinal == 10 && j > 2 )) 
				{
					break;
				}
				gamedificultScripiting[i].stars[j].SetActive(true);
			}
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
		notaFinal = 0;
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
		
		if (gamelevel == 0)
		{
			if (notaFinal > PlayerPrefs.GetInt("piqueFacil" + idTema.ToString()))
			{
				PlayerPrefs.SetInt ("piqueFacil" + idTema.ToString (), notaFinal);
			}
			if(PlayerPrefs.GetString("dificuldade" + idTema) == "F" || PlayerPrefs.GetString("dificuldade" + idTema) == "")
			{
				PlayerPrefs.SetString("dificuldade" + idTema, "M");
			}
			
		}
		else if (gamelevel == 1)
		{
			if (notaFinal > PlayerPrefs.GetInt("piqueMedio" + idTema.ToString()))
			{
				PlayerPrefs.SetInt ("piqueMedio" + idTema.ToString (), notaFinal);
			}

			if(PlayerPrefs.GetString("dificuldade" + idTema) == "M")
			{
				PlayerPrefs.SetString("dificuldade" + idTema, "D");
			}
			
		}
		else if (gamelevel == 2)
		{
			if (notaFinal > PlayerPrefs.GetInt("piqueDificil" + idTema.ToString()))
			{
				PlayerPrefs.SetInt ("piqueDificil" + idTema.ToString (), notaFinal);
			}
			
		}
	
		//Score.infoValue = string.Format ("Parabéns, você me achou em {0} segundos e tirou {1}!", tempo.ToString ("0.0"), notaFinal);
		SceneManager.LoadScene ("Score");
	}
}
