using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AninhaPastoreira : MonoBehaviour {

	public Transform animal, spawn;

	[SerializeField]
	private int countSpawn, idTema, countDestroy;
	
	
	public int pontuacao;

	void Start () {
		pontuacao = 0;
		countSpawn = 20;
		countDestroy = 20;
		StartCoroutine("AnimalSpawn");
		idTema = PlayerPrefs.GetInt ("idTema");
	}
	
	void Update(){
		if(countDestroy == 0){
			StartCoroutine("FimJogo");
		}
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

	public IEnumerator FimJogo(){
		yield return new WaitForSeconds(3f);
		if (pontuacao > PlayerPrefs.GetInt("notaFinal" + idTema.ToString())){
			PlayerPrefs.SetInt ("notaFinal" + idTema.ToString (), pontuacao);
			    
		}
		PlayerPrefs.SetInt ("notaFinalTemp" + idTema.ToString (), pontuacao);
		SceneManager.LoadScene("Score");
	}
}
