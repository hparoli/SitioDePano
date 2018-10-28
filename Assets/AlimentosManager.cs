using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlimentosManager : MonoBehaviour {

	private int countR, countG, level, acertos;

	private float tempo;

	private bool conta;

	[SerializeField]
	private  Alimentos[] alimentos;

	[SerializeField]
	private Text texto;

	private GameObject[] botoes;

	private string[] tipos = { "carne", "legume", "vegetal", "fruta" };

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator StartGame(){
		texto.text = "Prepare-se...";
		for (float f = 0f; f <= 1; f += 0.02f){
			Color c = texto.color;
			c.a = f;
			texto.color = c;
			new WaitForSeconds(.5f);
			yield return null;
		}

		yield return new WaitForSeconds(1f);

		for (float f = 1f; f > 0; f -= 0.02f){
			Color c = texto.color;
			c.a = f;
			texto.color = c;
			new WaitForSeconds(.5f);
			yield return null;
		}

		texto.text = "Vamos Começar!";
		yield return new WaitForSeconds(.5f);

		for (float f = 0f; f <= 1; f += 0.02f){
			Color c = texto.color;
			c.a = f;
			texto.color = c;
			new WaitForSeconds(.5f);
			yield return null;
		}

		yield return new WaitForSeconds(1f);

		for (float f = 1f; f > 0; f -= 0.02f){
			Color c = texto.color;
			c.a = f;
			texto.color = c;
			new WaitForSeconds(.5f);
			yield return null;
		}
		yield return new WaitForSeconds(.5f);
		StartCoroutine ("IniciaRodada");
		StopCoroutine ("StartGame");
	}


	IEnumerator IniciaRodada(){
		int tip = Random.Range (0, 3);
		texto.text = alimentos [tip].mensagem;
		for (float f = 0f; f <= 1; f += 0.02f){
			Color c = texto.color;
			c.a = f;
			texto.color = c;
			new WaitForSeconds(.5f);
			yield return null;
		}

		yield return new WaitForSeconds(1f);

		for (float f = 1f; f > 0; f -= 0.02f){
			Color c = texto.color;
			c.a = f;
			texto.color = c;
			new WaitForSeconds(.5f);
			yield return null;
		}
		yield return new WaitForSeconds(.5f);
	}

	void MudaAlimentos(){

	}
}
