using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Spawn : MonoBehaviour {


	//B: Random Spawn Point toda vez que rodar o jogo

	int idTema;
	public GameObject dollObj; // prefab da boneca
	public Transform[] spawnPoints; // Array c/ Spawn Points

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



	public void StartGame()
	{
			tutorial.SetActive (false);
			CreatDoll ();
			Time.timeScale = 1;
	}

	public void CreatDoll() 
	{
		
			if (dollCount < 3) {
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
	
	void Cronometro()
	{
		tempo += 1 * Time.deltaTime;
		Debug.Log (tempo);
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
		Score.infoValue = string.Format ("Parabéns, você me achou em {0} segundos e tirou {1}!", tempo.ToString ("0.0"), notaFinal);
		SceneManager.LoadScene ("Score");
	}
}
