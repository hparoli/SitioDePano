using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AninhaPastoreira : MonoBehaviour {

	public Transform animal, spawn;

	[SerializeField]
	private int countSpawn, idTema, countDestroy;
	public int pontuacao;

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

	void Start () {
		pontuacao = 0;
		countSpawn = 20;
		countDestroy = 3;

		idTema = PlayerPrefs.GetInt ("idTema");
		infoTutorial.text = txtTutorial [indexTutorial];
		tutorial.SetActive (true);
		boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (false);boardsTutorial [2].SetActive (false);
		imagesTutorial [0].SetActive (true);imagesTutorial [1].SetActive (false);imagesTutorial [2].SetActive (false);imagesTutorial [3].SetActive (false);imagesTutorial [4].SetActive (false);

		for (int i = 0; i < AninhaFeedback.Length; i++) {
			AninhaFeedback [i].SetActive (false);
		}


	}
	
	void Update(){
		if(countDestroy == 0){
			StartCoroutine("FimJogo");
		}
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

	public void StartGame(){
		tutorial.SetActive (false);
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
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene("Score");
	}
}
