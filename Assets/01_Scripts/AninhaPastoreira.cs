using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AninhaPastoreira : MonoBehaviour {

	public Transform animal, spawn;

	[SerializeField]
	private int countSpawn, idTema, countDestroy;

	public GameObject tutorialPanel;
	public Text infoTutorial; 
	public string[] txtTutorial;
	int indexTutorial = 0;

	public int pontuacao;

	[Header("Celeiro")]
	public Animator[] barnAnims;
	public GameObject ExitBoard;

	void Start () {
		pontuacao = 0;
		countSpawn = 3;
		countDestroy = 3;

		idTema = PlayerPrefs.GetInt ("idTema");
		tutorialPanel.SetActive (true);
		StartTutorial ();

	}
	
	void Update(){
		if(countDestroy == 0){
			StartCoroutine("FimJogo");
		}
	}

	public IEnumerator tutorialTextChanges(){
		infoTutorial.text = txtTutorial [indexTutorial];
		if (indexTutorial < 5){
			indexTutorial++;
		}
		yield return new WaitForSeconds (3);
		infoTutorial.text = txtTutorial [indexTutorial];
		if (indexTutorial < 5){
			indexTutorial++;
		}
		yield return new WaitForSeconds (3);
		infoTutorial.text = txtTutorial [indexTutorial];
		if (indexTutorial < 5){
			indexTutorial++;
		}
		yield return new WaitForSeconds (3);
		infoTutorial.text = txtTutorial [indexTutorial];
		if (indexTutorial < 5){
			indexTutorial++;
		}
		yield return new WaitForSeconds (3);
		infoTutorial.text = txtTutorial [indexTutorial];
		if (indexTutorial < 5){
			indexTutorial++;
		}
		yield return new WaitForSeconds (3);

	}

	public void StartTutorial(){
		StartCoroutine ("tutorialTextChanges");
	}

	public void StartGame(){
		tutorialPanel.SetActive (false);
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

	public void Pontua(int ponto){
		pontuacao += ponto;
	}

	public void Conta(){
		countDestroy--;
	}

	public void BarnAnin(){
		for (int i = 0; i < barnAnims.Length; i++) {
			barnAnims [i].SetBool ("Active", true);
		}
		ExitBoard.SetActive (false);
	}

	public IEnumerator FimJogo(){

		yield return new WaitForSeconds(1f);
		if (pontuacao > PlayerPrefs.GetInt("notaFinal" + idTema.ToString())){
			PlayerPrefs.SetInt ("notaFinal" + idTema.ToString (), pontuacao);
			    
		}
		PlayerPrefs.SetInt ("notaFinalTemp" + idTema.ToString (), pontuacao);
//		Score.infoValue = string.Format ("Você marcou {0} pontos!", pontuacao);
		BarnAnin ();
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene("Score");
	}
}
