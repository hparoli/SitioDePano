using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class responder : MonoBehaviour {

	private int idTema;

	public SpriteRenderer  pergunta;
	public Text            respA;
	public Text            respB;
	public Text            respC;
	public Text infoResposta;

	public Sprite[] perguntas;
	public string[] alternativaA;
	public string[] alternativaB;
	public string[] alternativaC;
	public string[] corretas;

	private int idPergunta;

	private float acertos;
	private float questões;
	private float media;
	private int notaFinal;




	void Start () {

		idTema = PlayerPrefs.GetInt ("idTema");
		idPergunta = 0;
		questões = perguntas.Length;

		pergunta.sprite = perguntas [idPergunta];
		respA.text = alternativaA [idPergunta];
		respB.text = alternativaB [idPergunta];
		respC.text = alternativaC [idPergunta];

		infoResposta.text = "Respondendo " + (idPergunta + 1).ToString() + " de " + questões.ToString() + " perguntas ";
		
	}

	public void resposta(string alternativa)
	{
		if (alternativa == "A") 
		{
			if (alternativaA [idPergunta] == corretas [idPergunta]) 
			{
				acertos += 1;
			}
		}

		else if (alternativa == "B") 
		{
			if (alternativaB [idPergunta] == corretas [idPergunta]) 
			{
				acertos += 1;
			}
		}

		else if (alternativa == "C") 
		{
			if (alternativaC [idPergunta] == corretas [idPergunta]) 
			{
				acertos += 1;
			}
		}

		proximaPergunta ();
	}

	void proximaPergunta()
	{
		idPergunta += 1;

		if (idPergunta <= (questões - 1))
		{

			pergunta.sprite = perguntas [idPergunta];
			respA.text = alternativaA [idPergunta];
			respB.text = alternativaB [idPergunta];
			respC.text = alternativaC [idPergunta];

			infoResposta.text = "Respondendo " + (idPergunta + 1).ToString() + " de " + questões.ToString() + " perguntas ";
		}

		else 
		{
			media = 10 * (acertos / questões);
			notaFinal = Mathf.RoundToInt (media);

			if (notaFinal > PlayerPrefs.GetInt("notaFinal" + idTema.ToString())){

				PlayerPrefs.SetInt ("notaFinal" + idTema.ToString (), notaFinal);
				PlayerPrefs.SetInt ("acertos" + idTema.ToString (), (int) acertos);

			}

			PlayerPrefs.SetInt ("notaFinalTemp" + idTema.ToString (), notaFinal);
			PlayerPrefs.SetInt ("acertosTemp" + idTema.ToString (), (int) acertos);

			SceneManager.LoadScene("Score");
		}

	}

}
