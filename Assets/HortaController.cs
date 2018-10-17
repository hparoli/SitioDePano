﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HortaController : MonoBehaviour {

	public int level;
	
	public float saldoInicial,saldo;

	[SerializeField]
	private GameObject[] buttons;
	
	[SerializeField]
	private Text[] texts;

	[SerializeField]
	private Sprite[] imagens;

	[SerializeField]
	private Image[] legumes;

	[SerializeField]
	private Text saldoTxt,mensagem;

	private bool podeJogar,gameover;

	// Use this for initialization
	void Start () {
		level = 1;
		podeJogar = true;
		gameover = false;
		StartGame();
	}
	
	// Update is called once per frame
	void Update () {
		if(saldo < 0 || legumes[5].GetComponent<LegumesControl>().plantou){
			podeJogar = false;
			if(!gameover) StartCoroutine("GameOver");
		}
	}

	void StartGame(){
		if(level == 1 || level == 3){
			for (int i = 0; i < buttons.Length; i++)
			{
				if(i < 3) buttons[i].SetActive(true);
				else buttons[i].SetActive(false);

				buttons[i].GetComponent<Button>().onClick.RemoveAllListeners();
			}

		}
		else if(level == 2){
			for (int i = 0; i < buttons.Length; i++)
			{
				buttons[i].SetActive(true);
				buttons[i].GetComponent<Button>().onClick.RemoveAllListeners();
			}
		}
		
		if(level == 1){
			buttons[0].GetComponent<Button>().onClick.AddListener(delegate{CompraSemente("sem11",9);});
			buttons[0].GetComponentInChildren<Text>().text = "R$9,00";
			buttons[1].GetComponent<Button>().onClick.AddListener(delegate{CompraSemente("sem12",7);});
			buttons[1].GetComponentInChildren<Text>().text = "R$7,00";
			buttons[2].GetComponent<Button>().onClick.AddListener(delegate{CompraSemente("sem13",4);});
			buttons[2].GetComponentInChildren<Text>().text = "R$4,00";
			saldoInicial = saldo = 37;
			saldoTxt.text = "R$" + saldoInicial.ToString("F2");
			saldoTxt.text = saldoTxt.text.Replace(".",",");
		} else if (level == 2){
			buttons[0].GetComponent<Button>().onClick.AddListener(delegate{CompraSemente("sem21",2);});
			buttons[0].GetComponentInChildren<Text>().text = "R$2,00";
			buttons[1].GetComponent<Button>().onClick.AddListener(delegate{CompraSemente("sem22",3);});
			buttons[1].GetComponentInChildren<Text>().text = "R$3,00";
			buttons[2].GetComponent<Button>().onClick.AddListener(delegate{CompraSemente("sem23",7);});
			buttons[2].GetComponentInChildren<Text>().text = "R$7,00";
			buttons[3].GetComponent<Button>().onClick.AddListener(delegate{CompraSemente("sem24",10);});
			buttons[3].GetComponentInChildren<Text>().text = "R$10,00";
			saldoInicial = saldo = 31;
			saldoTxt.text = "R$" + saldoInicial.ToString("F2");
			saldoTxt.text = saldoTxt.text.Replace(".",",");
			saldoTxt.text = saldoTxt.text.Replace("R$-","-R$");
		} else if (level == 3){
			buttons[0].GetComponent<Button>().onClick.AddListener(delegate{CompraSemente("sem21",2.25f);});
			buttons[0].GetComponentInChildren<Text>().text = "R$2,25";
			buttons[1].GetComponent<Button>().onClick.AddListener(delegate{CompraSemente("sem22",3.25f);});
			buttons[1].GetComponentInChildren<Text>().text = "R$3,25";
			buttons[2].GetComponent<Button>().onClick.AddListener(delegate{CompraSemente("sem23",1.75f);});
			buttons[2].GetComponentInChildren<Text>().text = "R$1,75";
			saldoInicial = saldo = 14.50f;
			saldoTxt.text = "R$" + saldoInicial.ToString("F2");
			saldoTxt.text = saldoTxt.text.Replace(".",",");
			saldoTxt.text = saldoTxt.text.Replace("R$-","-R$");
		}
	}

	public void CompraSemente(string sem, float vlr){
		if(podeJogar){
		for (int i = 0; i < legumes.Length; i++)
		{
			if(!legumes[i].GetComponent<LegumesControl>().plantou){
				if(sem == "sem11" || sem == "sem21" || sem == "sem31"){
					legumes[i].sprite = imagens[0];
				} else if(sem == "sem12" || sem == "sem22" || sem == "sem32"){
					legumes[i].sprite = imagens[1];
				} else if(sem == "sem13" || sem == "sem23" || sem == "sem33"){
					legumes[i].sprite = imagens[2];
				} else if(sem == "sem24" || sem == "sem34"){
					legumes[i].sprite = imagens[3];
				} 
				legumes[i].GetComponent<LegumesControl>().plantou = true;
				saldo -= vlr;
				saldoTxt.text = "R$" + saldo.ToString("F2");
				saldoTxt.text = saldoTxt.text.Replace(".",",");
				saldoTxt.text = saldoTxt.text.Replace("R$-","-R$");
				break;
			}
		}
		}
	}

	public void Resetar(){
		for (int i = 0; i < legumes.Length; i++)
		{
			legumes[i].sprite = null;
			legumes[i].GetComponent<LegumesControl>().plantou = false;
		}
		saldo = saldoInicial;
		saldoTxt.text = "R$" + saldo.ToString("F2");
		saldoTxt.text = saldoTxt.text.Replace(".",",");
		saldoTxt.text = saldoTxt.text.Replace("R$-","-R$");
		gameover = false;
		podeJogar = true;
	}

	IEnumerator GameOver(){
		gameover = true;
		if (saldo != 0){
			//som de erro
			mensagem.text = "Que pena, você errou, tente novamente!";
			for (float f = 0f; f <= 1; f += 0.02f){
                Color c = mensagem.color;
		    	c.a = f;
		    	mensagem.color = c;
		    	new WaitForSeconds(.5f);
                yield return null;
			}
			
			yield return new WaitForSeconds(1f);

			for (float f = 1f; f > 0; f -= 0.02f){
					Color c = mensagem.color;
					c.a = f;
					mensagem.color = c;
					new WaitForSeconds(.5f);
					yield return null;
			}

			yield return new WaitForSeconds(0.5f);
			Resetar();
			StopCoroutine("GameOver");
		} else if (saldo == 0 && legumes[5].GetComponent<LegumesControl>().plantou){
			mensagem.text = "Parabéns! Você acertou!";
			for (float f = 0f; f <= 1; f += 0.02f){
                Color c = mensagem.color;
		    	c.a = f;
		    	mensagem.color = c;
		    	new WaitForSeconds(.5f);
                yield return null;
			}
			
			yield return new WaitForSeconds(1f);

			for (float f = 1f; f > 0; f -= 0.02f){
					Color c = mensagem.color;
					c.a = f;
					mensagem.color = c;
					new WaitForSeconds(.5f);
					yield return null;
			}

			if(level < 3){
				Resetar();
				level++;
				StartGame();

			} else SceneManager.LoadScene("Score");
		}
	}
}