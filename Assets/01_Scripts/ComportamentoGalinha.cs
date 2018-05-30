using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ComportamentoGalinha : MonoBehaviour {

	private float min,max,delayGalinha;
	public Animator[] animator;
	public GameObject Tutorial;

	public string [] txtTutorial;
	public Text infoTutorial;
	int indexTutorial = 0;

	[SerializeField]
	ApareceOvo ApareceOvo;

	[Header("Celeiro")]
	public Animator[] barnAnims;
	public GameObject ExitBoard;

	// Use this for initialization
	void Start () {
		
		min = 1.5f;
		max = 3.5f;
		delayGalinha = 2.5f;
		ApareceOvo = FindObjectOfType <ApareceOvo> ();
		TutorialGame ();
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

	public void TutorialGame(){
		StartCoroutine ("tutorialTextChanges");
	}

	public IEnumerator tutorialTextChanges(){
		infoTutorial.text = txtTutorial [indexTutorial];
		if (indexTutorial < 3){
			indexTutorial++;
		}
		yield return new WaitForSeconds (2);
		infoTutorial.text = txtTutorial [indexTutorial];
		if (indexTutorial < 3){
			indexTutorial++;
		}
		yield return new WaitForSeconds (2);
		infoTutorial.text = txtTutorial [indexTutorial];
		if (indexTutorial < 3){
			indexTutorial++;
		}
		yield return new WaitForSeconds (2);
		infoTutorial.text = txtTutorial [indexTutorial];
		if (indexTutorial < 3){
			indexTutorial++;
		}
		yield return new WaitForSeconds (2);

}

	public void StartGame()
	{
		Tutorial.SetActive (false);
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
