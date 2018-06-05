using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ComportamentoGalinha : MonoBehaviour {

	private float min,max,delayGalinha;
	public Animator[] animator;

	[SerializeField]
	ApareceOvo ApareceOvo;

	[Header("Celeiro")]
	public Animator[] barnAnims;
	public GameObject ExitBoard;

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

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		min = 1.5f;
		max = 3.5f;
		delayGalinha = 2.5f;
		ApareceOvo = FindObjectOfType <ApareceOvo> ();
		tutorial.SetActive (true);
		infoTutorial.text = txtTutorial [indexTutorial];
		boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (false);boardsTutorial [2].SetActive (false);
		imagesTutorial [0].SetActive (true);imagesTutorial [1].SetActive (false);
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
	
	IEnumerator Comportamento(){
		int galinha = Random.Range(0, animator.Length);
		float tempo = Random.Range(min, max);
		Debug.Log(galinha);
		Debug.Log(tempo);
		yield return new WaitForSeconds(tempo);
		animator[galinha].SetBool("Levantando",true);
		yield return new WaitForSeconds(delayGalinha);
		animator[galinha].SetBool("Sentando",true);
		animator[galinha].SetBool("Levantando",false);
		yield return new WaitForSeconds(0.5f);
		animator[galinha].SetBool("Sentando",false);
		StartCoroutine("Comportamento");
	}



	public void EndGame(){
		for(int i = 0; i < animator.Length; i++){
			animator[i].SetBool("Levantando",false);
			animator[i].SetBool("Sentando",false);
			animator[i].enabled = false;
			BarnAnin ();
			StartCoroutine("GameOver");
		}
	}


	public void StartGame()
	{
		tutorial.SetActive (false);
		Time.timeScale = 1;
		StartCoroutine("Comportamento");

	}

	public void BarnAnin(){
		for (int i = 0; i < barnAnims.Length; i++) {
			barnAnims [i].SetBool ("Active", true);
		}
		ExitBoard.SetActive (false);
	}


	IEnumerator GameOver(){
		
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene("Score");
	}

}
