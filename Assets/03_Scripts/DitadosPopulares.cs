using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DitadosPopulares : MonoBehaviour {



	public SpriteRenderer pergunta; 
	public Text           respostaA;
	public Text           respostaB;
	public Text           respostaC;

	public Sprite[]  perguntas;
	public string[]  alternativaA;
	public string[]  alternativaB;
	public string[]  alternativaC;
	public string[]  corretas;

	private int      idPergunta;




	void Start () 
	{
		idPergunta = 0;
		pergunta.sprite = perguntas   [idPergunta];
		respostaA.text = alternativaA [idPergunta];
		respostaB.text = alternativaB [idPergunta];
		respostaC.text = alternativaC [idPergunta];
	}

	public void resposta (string alternativa)
	{
		if (alternativa == "A")
		{
			if (alternativaA[idPergunta] == corretas [idPergunta]){}
		}
		 else if (alternativa == "B")
		{
			if(alternativaB[idPergunta] == corretas [idPergunta]){}
		}
		else if (alternativa == "C")
		{
			if(alternativaC[idPergunta] == corretas [idPergunta]){}
		}
		Next ();
	}

	public void Next()
	{
		idPergunta ++;

		pergunta.sprite = perguntas [idPergunta];
		respostaA.text = alternativaA [idPergunta];
		respostaB.text = alternativaB [idPergunta];
		respostaC.text = alternativaC [idPergunta];
	}
}
