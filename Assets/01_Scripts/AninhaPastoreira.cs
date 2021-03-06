﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AninhaPastoreira : MonoBehaviour {
	public GameObject animal;
	public Transform  spawn;
	float tempo;
	[SerializeField]
	private int countSpawn, idTema, countDestroy;
	public int notaFinal;

	//TrilhaSonora
	public AudioSource audio;

	[Header("Celeiro")]
	public Animator[] barnAnims;
	public GameObject ExitBoard;
	public GameObject tutButton;

	[Header("Feedback")]
	
	public Animator aninhaFeedBacks;
	
	[Header("Tutorial")]
	[SerializeField]
	GameObject tutorial;
	

	[Header("DificultControl")]
	[Space(10)]
	[SerializeField]
	GameDificultScripting[] gamedificultScripiting;
	[Space(10)]
	[SerializeField]
	GameObject DificultGameObject;

	[SerializeField]
	Button[] gameButtons;
	
	public int gamelevel;

	public Transform Game1;

	bool isgame = false;
	
	bool fim;

  

	void Start ()
	 {
		fim = false;
		audio.Pause ();
		notaFinal = 0;
		idTema = PlayerPrefs.GetInt ("idTema");
		
		Time.timeScale = 0;
		countDestroy = 1;
	}
	
	void Update()
	{
		OpenLevel();
		StarsPointsControl();
		if(countDestroy == 0)
		{
			if(!fim) StartCoroutine("FimJogo");
		}
		 Cronometro();
	}


	public void OpenTutorial()
	{
	ExitBoard.SetActive(false);
	tutButton.SetActive(false);
	tutorial.SetActive(true);
	Time.timeScale = 0;
	SoundManager.instance.Play("Player", SoundManager.instance.clipList.TutorialPastoreira);
	isgame = true;
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
			//else
			//{
			//	gamedificultScripiting[i].gamePrefabDificult.SetActive(false);	
			//}
            DificultGameObject.SetActive(false);
		}
        if (gamelevel == 0)
        {
            ExitBoard.SetActive(false);
			tutButton.SetActive(false);
            SoundManager.instance.Play("Player", SoundManager.instance.clipList.TutorialPastoreira);

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
			 if ((notaFinal == 0 || notaFinal == null) || ( notaFinal == 5 && j > 0 ) || ( notaFinal == 7 && j > 1 ) || ( notaFinal == 10 && j > 2 ) || ( notaFinal == 20 && j > 3 )) 
				{
					break;
				}
				gamedificultScripiting[i].stars[j].SetActive(true);
			}
		}
	}
	void Cronometro()
	{
	   tempo += 1 * Time.deltaTime;
		Debug.Log (tempo);
	}
    public void StartGame()
	{
		if(gamelevel == 0){
			countSpawn = 12;
			countDestroy = 12;
		} else if (gamelevel == 1){
			countSpawn = 20;
			countDestroy = 20;
		} else if (gamelevel == 2){
			countSpawn = 25;
			countDestroy = 25;
		}

		if (!isgame)
		{
		SoundManager.instance.Stop("Player", SoundManager.instance.clipList.TutorialPastoreira);
		audio.Play ();
        ExitBoard.SetActive(true);
		tutButton.SetActive(true);
        tutorial.SetActive (false);
		Time.timeScale = 1;
		StartCoroutine("AnimalSpawn");
		}
		else if (isgame)
		{
		SoundManager.instance.Stop("Player", SoundManager.instance.clipList.TutorialPastoreira);
		ExitBoard.SetActive(true);
		tutButton.SetActive(true);
        tutorial.SetActive (false);
		Time.timeScale = 1;	
		}
       
	}

	public IEnumerator AnimalSpawn()
	{
		Vector3 pos = new Vector3 (spawn.position.x, spawn.position.y, 0.13f);
		GameObject animalObjs =  Instantiate (animal, pos, spawn.rotation, Game1.transform) as GameObject;
		


		yield return new WaitForSeconds(6f);
		countSpawn--;
		if(countSpawn > 0){
			StartCoroutine("AnimalSpawn");
		}
	}
	public void Pontua(int ponto)
	{
		notaFinal += ponto;
	}

	public void Conta(){
		countDestroy--;
	}

	public void BarnAnin(){
		for (int i = 0; i < barnAnims.Length; i++) 
		{
			barnAnims [i].SetBool ("Active", true);
		}
		ExitBoard.SetActive (false);
	}

	public IEnumerator FimJogo(){
		fim = true;
		AnaliticsControl.pastoreiraTime = tempo;
		yield return new WaitForSeconds(1f);
        notaFinal = 10;
		if (notaFinal > PlayerPrefs.GetInt("notaFinal" + idTema.ToString()))
		{
			PlayerPrefs.SetInt ("notaFinal" + idTema.ToString (), notaFinal);
		}
		PlayerPrefs.SetInt ("notaFinalTemp" + idTema.ToString (), notaFinal);
//		Score.infoValue = string.Format ("Você marcou {0} pontos!", pontuacao);
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

		BarnAnin ();
		
		yield return new WaitForSeconds (2f);
		//SceneManager.LoadScene("Score");
		LoadingScreenManager.LoadScene(10);

	}
}
