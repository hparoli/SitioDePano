using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManagerMed : MonoBehaviour {

	public GameObject gameOver;

	public GameObject stopClick;

	public AudioClip shuffleCards;
	private AudioSource source;

	public Sprite[] cardFace;
	public Sprite cardBack;
	public GameObject[] cards;
	public Text matchText;

	private bool _init = false;
	private int _matches = 9;


	void Update () {

		if (stopClick.activeSelf) {
			StartCoroutine (CardCooldown ());

		}

		if (!_init)
			InitializeCards ();

		if (Input.GetMouseButtonUp (0)) {
			checkCards ();
		}
	}

	void Awake () {

		source = GetComponent<AudioSource> ();

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

	public Sprite getCardFace(int i){
		return cardFace [i - 1];
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
			stopClick.SetActive (true);}
	}

	void cardComparisson(List<int> c) {
		CardMed.DO_NOT = true;

		int x = 0;

		if (cards [c [0]].GetComponent<CardMed> ().cardValue == cards [c [1]].GetComponent<CardMed> ().cardValue) {
			x = 2;
			_matches--;
			matchText.text = "Pares Restantes : " + _matches;
			if (_matches == 0) {
				gameOver.SetActive (true);

			}
		}

		for (int i = 0; i < c.Count; i++) {
			cards [c [i]].GetComponent<CardMed> ().state = x;
			cards [c [i]].GetComponent<CardMed> ().falseCheck ();
		}
	}


	IEnumerator CardCooldown (){

		yield return new WaitForSeconds (1);
		stopClick.SetActive (false);
	}
}
