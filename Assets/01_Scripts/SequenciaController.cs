﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState
{
    SEQUENCIA,
    RESPONDER,
    NOVA,
    ERRO
}


public class SequenciaController : MonoBehaviour {
    public GameState gameState;

    public Text roundTxt;
    
    public Color[] color;
	public SpriteRenderer[] buttons;
	public SpriteRenderer[] buttonsBack;

    public GameObject startButton;

    public List<int> colors; //sequencia de cores 
    public int idResp, qtdCores, rodada, pontuacao;

    private AudioSource fonteAudio;
    public AudioClip[] sons;

    private int notaFinal;
    private float media;
    private int idTema;

	public GameObject tutorial;

    [SerializeField]
	public Color standard;

	// Use this for initialization
	void Start () {
        fonteAudio = GetComponent<AudioSource>();
        gameState = GameState.NOVA;
        NovaRodada();
        pontuacao = 0;
        idTema = PlayerPrefs.GetInt ("idTema");

        Debug.Log(idTema);
	}

    public IEnumerator StartGame()
    {
        roundTxt.text = "Rodada: " + (rodada + 1).ToString();
        yield return new WaitForSeconds(0.5f);
        for (float f = 0f; f <= standard.a; f += 0.01f)
        {
            Color c = roundTxt.color;
			c.a = f;
			roundTxt.color = c;
			new WaitForSeconds(.5f);
            yield return null;
        }
        yield return new WaitForSeconds(2f);
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = roundTxt.color;
			c.a = f;
			roundTxt.color = c;
			new WaitForSeconds(.5f);
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);
        roundTxt.text = "Acerte as " + (qtdCores + rodada).ToString() + " notas dos passarinhos";
        for (float f = 0f; f <= standard.a; f += 0.01f)
        {
            Color c = roundTxt.color;
			c.a = f;
			roundTxt.color = c;
			new WaitForSeconds(.5f);
            yield return null;
        }
        yield return new WaitForSeconds(2f);
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = roundTxt.color;
			c.a = f;
			roundTxt.color = c;
			new WaitForSeconds(.5f);
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("Sequencia", qtdCores + rodada);
    }

    private void NovaRodada()
    {
       /* roundTxt.text = "Rodada: " + (rodada + 1).ToString();
        sequenceTxt.text = "Sequência: " + (qtdCores + rodada).ToString();*/
        colors.Clear();
        startButton.SetActive(true);

		foreach (SpriteRenderer img in buttons)
        {
            img.color = color[0];
        }
    }

    IEnumerator Sequencia(int qtd)
    {
        startButton.SetActive(false);

        for(int i = qtd; i > 0; i--)
        {
            yield return new WaitForSeconds(0.5f);

            int r = Random.Range(0, buttons.Length);
            buttons[r].color = color[1];
			buttonsBack [r].color = color [0];
            fonteAudio.PlayOneShot(sons[r]);

            colors.Add(r);

            yield return new WaitForSeconds(0.5f);
            buttons[r].color = color[0];
			buttonsBack [r].color = color [1];
        }
        gameState = GameState.RESPONDER;
        idResp = 0;
    }


    IEnumerator Responder(int idBtn)
    {
        buttons[idBtn].color = color[1];
		buttonsBack[idBtn].color = color[0];
        if(colors[idResp] == idBtn)
        {
            fonteAudio.PlayOneShot(sons[idBtn]);
        }
        else
        {
            gameState = GameState.ERRO;
            StartCoroutine("GameOver");
        }

        idResp++;

        if(idResp >= colors.Count)
        {
            gameState = GameState.NOVA;
            rodada++;
            if(rodada > 6) pontuacao += 10;
            else if(rodada > 3) pontuacao += 7;
            else if(rodada <= 3) pontuacao += 5;
            Debug.Log(pontuacao);
            yield return new WaitForSeconds(1f);
            NovaRodada();
        }

        yield return new WaitForSeconds(0.3f);
        buttons[idBtn].color = color[0];
		buttonsBack[idBtn].color = color[1];
    }

    IEnumerator GameOver()
    {
       
        fonteAudio.PlayOneShot(sons[4]);
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 3; i++)
        {
			for (int x = 0; i < buttons.Length; i++)
            {
				buttons[x].color = color[1];
				buttonsBack [x].color = color [0];
            }

            yield return new WaitForSeconds(0.2f);

			for (int x = 0; i < buttons.Length; i++)
			{
				buttons[x].color = color[1];
				buttonsBack [x].color = color [0];
			}
            yield return new WaitForSeconds(0.2f);
        }

        int idB = 0;
        for(int i = 0; i < 12; i++)
        {
            buttons[idB].color = color[1];
			buttonsBack [idB].color = color [0];
            yield return new WaitForSeconds(0.1f);
            buttons[idB].color = color[0];
			buttonsBack [idB].color = color [1];
            idB++; 
            if(idB > 3) { idB = 0; }
        }

        media = pontuacao * rodada;
        Debug.Log("media: "+media);
        notaFinal = Mathf.RoundToInt(media);

        if (notaFinal > PlayerPrefs.GetInt("notaFinal" + idTema.ToString())){

				PlayerPrefs.SetInt ("notaFinal" + idTema.ToString (), notaFinal);
				PlayerPrefs.SetInt ("acertos" + idTema.ToString (), (int) rodada);

			}

			PlayerPrefs.SetInt ("notaFinalTemp" + idTema.ToString (), notaFinal);
			PlayerPrefs.SetInt ("acertosTemp" + idTema.ToString (), (int) rodada);
            rodada = 0;
            Debug.Log("nota final: " + notaFinal);
            Debug.Log("nota final: " + PlayerPrefs.GetInt("notaFinalTemp"+idTema.ToString()));
            Debug.Log("acertos: " + PlayerPrefs.GetInt("acertosTemp"+idTema.ToString()));
			SceneManager.LoadScene("Score");
    }

	public void Comecar(){
		tutorial.SetActive (false);
	}
}