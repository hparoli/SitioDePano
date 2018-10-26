using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AninhaPastoreira : MonoBehaviour {

	public Transform animal, spawn;
	float tempo;
	[SerializeField]
	private int countSpawn, idTema, countDestroy;
	public int notaFinal;

	[Header("Celeiro")]
	public Animator[] barnAnims;
	public GameObject ExitBoard;

	[Header("Feedback")]
	public GameObject[] AninhaFeedback;

	[Header("Tutorial")]
	[SerializeField]
	string [] txtTutorial;
	[SerializeField]
	Text infoTutorial;
	int indexTutorial = 0;
	[SerializeField]
	GameObject tutorial;
	[SerializeField]
	GameObject[] boardsTutorial;
	[SerializeField]
	GameObject[] imagesTutorial;

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
		
		OpenLevel();
		StarsPointsControl();
		notaFinal = 0;
		countSpawn = 20;
		countDestroy = 20;
		idTema = PlayerPrefs.GetInt ("idTema");
		Time.timeScale = 0;
		infoTutorial.text = txtTutorial [indexTutorial];
		tutorial.SetActive (true);
		boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (false);boardsTutorial [2].SetActive (false);
		imagesTutorial [0].SetActive (true);imagesTutorial [1].SetActive (false);imagesTutorial [2].SetActive (false);imagesTutorial [3].SetActive (false);imagesTutorial [4].SetActive (false);

		for (int i = 0; i < AninhaFeedback.Length; i++) {
			AninhaFeedback [i].SetActive (false);
		}
	}
	
	void Update()
	{
		if(countDestroy == 0)
		{
			StartCoroutine("FimJogo");
		}
		 Cronometro();
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

	public void ChangeTextTutorialForward(){
		indexTutorial++;
		infoTutorial.text = txtTutorial [indexTutorial];

		if (indexTutorial == 0) {
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (false);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (true);
			imagesTutorial [1].SetActive (false);
			imagesTutorial [2].SetActive (false);
			imagesTutorial [3].SetActive (false);
			imagesTutorial [4].SetActive (false);

		
		}
		if (indexTutorial == 1) {
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (true);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (true);
			imagesTutorial [2].SetActive (false);
			imagesTutorial [3].SetActive (false);
			imagesTutorial [4].SetActive (false);

		}
		if (indexTutorial == 2) {
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (true);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (false);
			imagesTutorial [2].SetActive (true);
			imagesTutorial [3].SetActive (false);
			imagesTutorial [4].SetActive (false);
			

		}
		if (indexTutorial == 3) {
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (true);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (false);
			imagesTutorial [2].SetActive (false);
			imagesTutorial [3].SetActive (true);
			imagesTutorial [4].SetActive (false);

		}
		if (indexTutorial == 4) {
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (true);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (false);
			imagesTutorial [2].SetActive (false);
			imagesTutorial [3].SetActive (false);
			imagesTutorial [4].SetActive (true);

		}
		if (indexTutorial == 5) {
			boardsTutorial [0].SetActive (false);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (true);
			imagesTutorial [0].SetActive (true);
			imagesTutorial [1].SetActive (false);
			imagesTutorial [2].SetActive (false);
			imagesTutorial [3].SetActive (false);
			imagesTutorial [4].SetActive (false);
		}

	}
	public void ChangeTextTutorialBack(){
		indexTutorial--;
		infoTutorial.text = txtTutorial [indexTutorial];

		if (indexTutorial == 0) {
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (false);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (true);
			imagesTutorial [1].SetActive (false);
			imagesTutorial [2].SetActive (false);
			imagesTutorial [3].SetActive (false);
			imagesTutorial [4].SetActive (false);


		}
		if (indexTutorial == 1) {
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (true);
			imagesTutorial [2].SetActive (false);
			imagesTutorial [3].SetActive (false);
			imagesTutorial [4].SetActive (false);

		}
		if (indexTutorial == 2) {
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (false);
			imagesTutorial [2].SetActive (true);
			imagesTutorial [3].SetActive (false);
			imagesTutorial [4].SetActive (false);


		}
		if (indexTutorial == 3) {
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (false);
			imagesTutorial [2].SetActive (false);
			imagesTutorial [3].SetActive (true);
			imagesTutorial [4].SetActive (false);

		}
		if (indexTutorial == 4) {
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (false);
			imagesTutorial [2].SetActive (false);
			imagesTutorial [3].SetActive (false);
			imagesTutorial [4].SetActive (true);

		}
		if (indexTutorial == 5) {
			boardsTutorial [0].SetActive (false);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (true);
			imagesTutorial [0].SetActive (true);
			imagesTutorial [1].SetActive (false);
			imagesTutorial [2].SetActive (false);
			imagesTutorial [3].SetActive (false);
			imagesTutorial [4].SetActive (false);
		}


	}

	public void StartGame()
	{
		tutorial.SetActive (false);
		Time.timeScale = 1;
		StartCoroutine("AnimalSpawn");
	}

	public IEnumerator AnimalSpawn(){
		Instantiate(animal, spawn.position, spawn.rotation);
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
		AnaliticsControl.pastoreiraTime = tempo;
		yield return new WaitForSeconds(1f);
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
		SceneManager.LoadScene("Score");
	}
}
