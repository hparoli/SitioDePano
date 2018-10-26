﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeOlhoNoLobo : MonoBehaviour {

	[SerializeField]
	private GameObject[] spawns, arbustos;

	[SerializeField]
	private GameObject lobo,fumOvelha;

	[SerializeField]
	private float delay, time, moveSpeed;

	[SerializeField]
	private Text cronometro;
	public GameObject[] ovelhaCena;
	public int ovelhas;
	public bool comeca;


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

	[Space(10)]
	int notaFinal;
	int idTema;
	float tempo;

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


	// Use this for initialization
	void Start () 
	{
		OpenLevel();
		StarsPointsControl();
		Time.timeScale = 0;
		idTema = PlayerPrefs.GetInt ("idTema");
		time = 45f;
		delay = 3f;
		ovelhas = 0;
		moveSpeed = 1.5f;
		comeca = false;
		tutorial.SetActive (true);
		infoTutorial.text = txtTutorial [indexTutorial];
		boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (false);boardsTutorial [2].SetActive (false);
		imagesTutorial [0].SetActive (true);imagesTutorial [1].SetActive (false);
	
	}

	// Update is called once per frame
	void Update () 
	{
		Cronometro();
		if (comeca) 
		{
			if (time > 0) {
				time -= Time.deltaTime;
				cronometro.text = time.ToString ("f0");
			} 
			else 
			{
				time = 0;
			}

			if (time <= 30) {
				delay = 2.75f;
				moveSpeed = 2.0f;
			}

			if (time <= 20) {
				delay = 2.5f;
				moveSpeed = 2.3f;
			}

			if (time <= 10) {
				delay = 2.25f;
				moveSpeed = 2.7f;
			}

		}

		if(ovelhas == 10)
			StartCoroutine("GameOver");
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
              if ((notaFinal == 0 || notaFinal == null) || ( notaFinal == 5 && j > 0 ) || ( notaFinal == 7 && j > 1 ) || ( notaFinal == 10 && j > 2 ) || ( notaFinal == 20 && j > 3 ) ) 				{
					break;
				}
				gamedificultScripiting[i].stars[j].SetActive(true);
			}
		}
	}

	public void BarnAnin(){
		for (int i = 0; i < barnAnims.Length; i++) {
			barnAnims [i].SetBool ("Active", true);
		}
		ExitBoard.SetActive (false);
	}

	public void ChangeTextTutorialForward(){
		indexTutorial++;
		infoTutorial.text = txtTutorial [indexTutorial];

		if(indexTutorial == 0){
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (false);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (true);
			imagesTutorial [1].SetActive (false);
	
		}
		if(indexTutorial == 1){
			boardsTutorial [0].SetActive (false);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (true);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (true);

		}

	}

	public void ChangeTextTutorialBack(){
		indexTutorial--;
		infoTutorial.text = txtTutorial [indexTutorial];
		if(indexTutorial == 0){
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (false);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (true);
			imagesTutorial [1].SetActive (false);

		}

		if(indexTutorial == 1){
			boardsTutorial [0].SetActive (false);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (true);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (true);
		
		}

	}

 public void StartGame()
 	{
		comeca = true;
		tutorial.SetActive (false);
		Time.timeScale = 1;
		StartCoroutine("SpawnLobo");
	}

	void Cronometro()
	{
	    tempo += 1 * Time.deltaTime;
		Debug.Log (tempo);
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
		if (ovelhas == 0) {
			notaFinal = 20;
		} 
		else if (ovelhas == 1) {
			notaFinal = 10;
		}
		else if (ovelhas >= 3) {
			notaFinal = 7;
		}
		else if (ovelhas >= 5) {
			notaFinal = 5;
		}
		else if (ovelhas >= 10) {
			notaFinal = 0;
		}
		AnaliticsControl.lobosTime = tempo;
		PlayerPrefs.SetInt ("notaFinalTemp" + idTema.ToString (), notaFinal);
		StopCoroutine ("SpawnLobo");
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
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene("Score");
	}

	public void SetOvelhas(){
		Vector3 pos = new Vector3 (this.transform.position.x + 0.4f, this.transform.position.y + 1, this.transform.position.z);
		Instantiate (fumOvelha, pos, this.transform.rotation);
		Destroy (ovelhaCena [ovelhas]);
		ovelhas++;
		Debug.Log (ovelhas);
	}
}
