using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    SEQUENCIA,
    RESPONDER,
    NOVA,
    ERRO
}


public class GameController : MonoBehaviour {
    public GameState gameState;

    public Text roundTxt, sequenceTxt;
    
    public Color[] color;
    public Image[] buttons;
    public GameObject startButton;

    public List<int> colors; //sequencia de cores 
    public int idResp, qtdCores, rodada;

    private AudioSource fonteAudio;
    public AudioClip[] sons;

	// Use this for initialization
	void Start () {
        fonteAudio = GetComponent<AudioSource>();
        NovaRodada();
	}

    public void StartGame()
    {
        StartCoroutine("Sequencia", qtdCores + rodada);
    }

    private void NovaRodada()
    {
        roundTxt.text = "Rodada: " + (rodada + 1).ToString();
        sequenceTxt.text = "Sequência: " + (qtdCores + rodada).ToString();
        colors.Clear();
        startButton.SetActive(true);

        foreach (Image img in buttons)
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
            fonteAudio.PlayOneShot(sons[r]);

            colors.Add(r);

            yield return new WaitForSeconds(0.5f);
            buttons[r].color = color[0];
            
        }
        gameState = GameState.RESPONDER;
        idResp = 0;
    }


    IEnumerator Responder(int idBtn)
    {
        buttons[idBtn].color = color[1];
       
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
            yield return new WaitForSeconds(1f);
            NovaRodada();
        }

        yield return new WaitForSeconds(0.3f);
        buttons[idBtn].color = color[0];
    }

    IEnumerator GameOver()
    {
        rodada = 0;
        fonteAudio.PlayOneShot(sons[4]);
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 3; i++)
        {
            foreach (Image img in buttons)
            {
                img.color = color[1];
            }

            yield return new WaitForSeconds(0.2f);

            foreach (Image img in buttons)
            {
                img.color = color[0];
            }

            yield return new WaitForSeconds(0.2f);
        }

        int idB = 0;
        for(int i = 0; i < 12; i++)
        {
            buttons[idB].color = color[1];
            yield return new WaitForSeconds(0.1f);
            buttons[idB].color = color[0];
            idB++; 
            if(idB > 3) { idB = 0; }
        }

        gameState = GameState.NOVA;
        NovaRodada();
    }
}
