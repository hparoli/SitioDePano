using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class AlimentosManager : MonoBehaviour {

	private int btnsCertos,contaBtn, countR, countG, level, acertos, tip, tip2;

	private float tempo;

	public float tempoInicial;

	private bool conta;

	[SerializeField]
	private  Alimentos[] alimentos;

	[SerializeField]
	private Text texto;

	[SerializeField]
	private GameObject[] botoes;

	private string[] tipos = { "carnes", "legumes", "vegetais", "frutas" };

	// Use this for initialization
	void Start () {
		contaBtn = 0;
		countG = 0;
		countR = 0;
		acertos = 0;
		level = 1;
		tempo = tempoInicial;
		StartCoroutine ("StartGame");
	}
	
	// Update is called once per frame
	void Update () {
		Cronometro ();
	}


	void Cronometro(){
		if (conta) {
			tempo -= Time.deltaTime;
			if (tempo <= 0) {
				conta = false;
				for (int i = 0; i < botoes.Length; i++) {
					botoes [i].GetComponent<Button> ().onClick.RemoveAllListeners ();
				}
				if (countR < 3) {
					countR++;
					StartCoroutine ("MudaAlimentos");
				} else {
					if (countG < 2) {
						countG++;
						countR = 0;
						StartCoroutine ("IniciaRodada");
					} else {
						
						SceneManager.LoadScene ("Score");
					}
				}
			}
		}

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

	}


	IEnumerator IniciaRodada(){
		
		if (level == 1) {
			tip = tip2 = Random.Range (0, alimentos.Length);
			texto.text = string.Format("Colete os {0}" , alimentos[tip].tipo);
		} else {
			tip = Random.Range (0, alimentos.Length);
			tip2 = Random.Range (0, alimentos.Length);
			if (level == 2) {
				if (tip == tip2) {
					texto.text = string.Format ("Colete os {0}", alimentos [tip].tipo);
				} else {
					texto.text = string.Format("Colete os {0} e os {1}", alimentos[tip].tipo, alimentos[tip2].tipo);
				}
			} 

			if (level == 3) {
				if (tip == tip2) {
					texto.text = string.Format ("Não colete os {0}", alimentos [tip].tipo);
				} else {
					texto.text = string.Format("Colete os {0} e os {1}", alimentos[tip].tipo, alimentos[tip2].tipo);
				}
			}
		}


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
		Debug.Log ("Game: " + countG);
		StartCoroutine("MudaAlimentos");
	}

	IEnumerator MudaAlimentos(){
		int rnd;
		int rnd2 = Random.Range (0, 3);

		yield return new WaitForSeconds (1f);

		for (float f = 1f; f > 0; f -= 0.05f){
			Color c = botoes [0].GetComponent<Image> ().color;
			Color c1 = botoes [1].GetComponent<Image> ().color;
			Color c2 = botoes [2].GetComponent<Image> ().color;
			Color c3 = botoes [3].GetComponent<Image> ().color;
			c.a = f;
			c1.a = f;
			c2.a = f;
			c3.a = f;
			botoes[0].GetComponent<Image>().color = c;
			botoes[1].GetComponent<Image>().color = c1;
			botoes[2].GetComponent<Image>().color = c2;
			botoes[3].GetComponent<Image>().color = c3;
			new WaitForSeconds(.5f);
			yield return null;
		}

		btnsCertos = 0;
		contaBtn = 0;

		for (int i = 0; i < botoes.Length; i++) {
			rnd = Random.Range (0, 3);
			if (rnd2 == i) {
				if (level == 1) {
					botoes [i].GetComponent<Image> ().sprite = alimentos [tip].sprite;
				} else if (level == 2) {
					if (tip == tip2) {
						botoes [i].GetComponent<Image> ().sprite = alimentos [tip].sprite;
					} else {
						if (Random.value < 0.5f) {
							botoes [i].GetComponent<Image> ().sprite = alimentos [tip].sprite;
						} else {
							botoes [i].GetComponent<Image> ().sprite = alimentos [tip2].sprite;
						}
					}
				}
				botoes [i].GetComponent<Button> ().onClick.AddListener (delegate {
					PegaItem (true);
				});
				btnsCertos++;
			} else {
				botoes [i].GetComponent<Image> ().sprite = alimentos [rnd].sprite;
				bool parametro;
				if (tip == rnd) { 
					parametro = true;
					btnsCertos++;
				} else {
					parametro = false;
				}
				botoes [i].GetComponent<Button> ().onClick.AddListener (delegate {
					PegaItem (parametro);
				});

			}

		}
		tempo = tempoInicial;
		Debug.Log ("Rodada: " + countR + ", botoes certos: " + btnsCertos + " , tempo: " + tempo);

		for (float f = 0f; f <= 1; f += 0.05f){
			Color c = botoes [0].GetComponent<Image> ().color;
			Color c1 = botoes [1].GetComponent<Image> ().color;
			Color c2 = botoes [2].GetComponent<Image> ().color;
			Color c3 = botoes [3].GetComponent<Image> ().color;
			c.a = f;
			c1.a = f;
			c2.a = f;
			c3.a = f;
			botoes[0].GetComponent<Image>().color = c;
			botoes[1].GetComponent<Image>().color = c1;
			botoes[2].GetComponent<Image>().color = c2;
			botoes[3].GetComponent<Image>().color = c3;
			new WaitForSeconds(.5f);
			yield return null;
		}


		conta = true;

	}


	public void PegaItem(bool pega){
		Debug.Log (contaBtn + ", Pega: " + pega);
		for (int i = 0; i < botoes.Length; i++) {
			if (EventSystem.current.currentSelectedGameObject.name == botoes [i].name) {
				botoes [i].GetComponent<Button> ().onClick.RemoveAllListeners ();
				StartCoroutine(ApagaBotao(i));
			}
		}


		if (pega)
			contaBtn++;

		if (btnsCertos == contaBtn) {
			acertos++;
			conta = false;
			for (int i = 0; i < botoes.Length; i++) {
				botoes [i].GetComponent<Button> ().onClick.RemoveAllListeners ();
			}
			Debug.Log ("acertou os itens");
			if (countR < 3) {
				countR++;
				StartCoroutine ("MudaAlimentos");
			} else {
				if (countG < 2) {
					countG++;
					countR = 0;
					StartCoroutine ("IniciaRodada");
				} else {
					SceneManager.LoadScene ("Score");
				}
			}
		}
		
	}

	IEnumerator ApagaBotao(int i){
		for (float f = 1f; f > 0; f -= 0.05f){
			Color c = botoes [i].GetComponent<Image> ().color;
			c.a = f;
			botoes[i].GetComponent<Image>().color = c;
			new WaitForSeconds(.5f);
			yield return null;
		}
	}
}
