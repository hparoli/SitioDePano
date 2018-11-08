using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManagerMed : MonoBehaviour {

	//TrilhaSonora
	public AudioSource audio;

	public GameObject gameOver;

	public GameObject stopClick;

	public AudioClip shuffleCards;
	public AudioClip CardMatch;
	public AudioClip WrongMatch;
	private AudioSource source;

	public string[] cardAnim;
	public Sprite cardFace;
	public Sprite cardBack;
	public GameObject[] cards;
	public Text matchText;

	private bool _init = false;

	private bool comeca = false;
	private int _matches = 9;

	private int idTema;
	private int notaFinal;
	private float tempo;

	[Header("Celeiro")]
	public Animator[] barnAnims;
	public GameObject ExitBoard;

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
	
	int gamelevel;


	void Start ()
	{
		audio.Pause ();
		gamelevel = 0;
		idTema = PlayerPrefs.GetInt ("idTema");
		OpenLevel();
		StarsPointsControl();
		ExitBoard.SetActive(false);
		

	}

	void Update () 
	{

		if(comeca){
		if (stopClick.activeSelf) {
			StartCoroutine (CardCooldown ());

		}

		if (!_init)
			InitializeCards ();

		if (Input.GetMouseButtonUp (0)) {
			checkCards ();
		}

		Cronometro ();
		}
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
				if (gamelevel == 0)
			{
				SoundManager.instance.Play("Player", SoundManager.instance.clipList.TutorialMemoria);
			}
			
			DificultGameObject.SetActive(false);
			source = GetComponent<AudioSource> ();
			
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
			 if ((notaFinal == 0 || notaFinal == null) || ( notaFinal == 5 && j > 0 ) || ( notaFinal == 7 && j > 1 ) || ( notaFinal == 10 && j > 2 ) || ( notaFinal == 20 && j > 3 ) ) 
				{
					break;
				}
				gamedificultScripiting[i].stars[j].SetActive(true);
			}
		}
	}



	public void StartGame()
	{
		SoundManager.instance.Stop("Player", SoundManager.instance.clipList.TutorialMemoria);
		audio.Play ();
		ExitBoard.SetActive(true);
		tutorial.SetActive(false);
		comeca = true;
	}



	void InitializeCards(){

		//source.PlayOneShot (shuffleCards, 1);

		for (int id = 0; id < 2; id++) {
			for (int i = 1; i < 10; i++) {

				bool test = false;
				int choice = 0;
				while (!test) {
					choice = Random.Range (0, cards.Length);
					test = !(cards [choice].GetComponent<CardMed> ().initialized);
				}
				cards [choice].GetComponent<CardMed> ().cardValue = i;
				cards [choice].GetComponent<CardMed> ().initialized = true;

			}	
		}

		foreach (GameObject c in cards)
			c.GetComponent<CardMed> ().SetupGraphics ();

		if (!_init)
			_init = true;

	}

	public Sprite getCardBack() {
		return cardBack;
	}

	public Sprite getCardFace(){
		return cardFace;
	}

	public string getCardAnim(int i){
		return cardAnim[i - 1];
	}


	void checkCards(){
		source.PlayOneShot (shuffleCards, 1);
		List<int> c = new List<int> ();

		for (int i = 0; i < cards.Length; i++) {
			if (cards [i].GetComponent<CardMed> ().state == 1)
				c.Add (i);
		}

		if (c.Count == 2){
			cardComparisson (c);
			stopClick.SetActive (true);

		}
	}

	void cardComparisson(List<int> c) {
		CardMed.DO_NOT = true;

		int x = 0;

		if (cards [c [0]].GetComponent<CardMed> ().cardValue == cards [c [1]].GetComponent<CardMed> ().cardValue) {
			x = 2;
			source.PlayOneShot (CardMatch, 1);
			_matches--;
			matchText.text = "Pares Restantes : " + _matches;

			if (_matches == 0) {
				
				if (tempo <= 35f) {
					notaFinal = 20;
				} else if (tempo <= 45f) {
					notaFinal = 10;
				} else if (tempo <= 75f) {
					notaFinal = 7;
				} else if (tempo <= 105f) {
					notaFinal = 5;
				}

				PlayerPrefs.SetInt ("notaFinalTemp" + idTema.ToString (), notaFinal);
				Score.infoValue = string.Format ("Parabéns, levou {0} segundos e tirou nota {1}!", tempo.ToString ("0.0"), notaFinal);
				BarnAnin (); 
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
				StartCoroutine ("StartGameOver");

			}
		} else {
			source.PlayOneShot (WrongMatch, 1);
		}

		for (int i = 0; i < c.Count; i++) {
			cards [c [i]].GetComponent<CardMed> ().state = x;
			cards [c [i]].GetComponent<CardMed> ().falseCheck ();
		}
	}

	public void BarnAnin(){
		for (int i = 0; i < barnAnims.Length; i++) {
			barnAnims [i].SetBool ("Active", true);
		}
		ExitBoard.SetActive (false);
	}

	public IEnumerator StartGameOver()
	{

		AnaliticsControl.memoriaTime = tempo;
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene ("Score");
	}

	void Cronometro()
	{
		tempo += 1 * Time.deltaTime;
	}


	IEnumerator CardCooldown (){

		yield return new WaitForSeconds (1);
		stopClick.SetActive (false);
	}
}
