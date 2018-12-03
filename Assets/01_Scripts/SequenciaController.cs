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
    ERRO,
    TUTORIAL
}


public class SequenciaController : MonoBehaviour {

    private SequenciaSonoraData sequenciaData = new SequenciaSonoraData();

	[SerializeField]
	private AllSequenciaSonoraData gameData;

	[SerializeField]
	private DataController dataController;

    public GameState gameState;

	Animator anim;

    public Text roundTxt, tutorialTxt;
    
    public Color[] color;
	public Animator[] buttons, btnTutorial;
	public Transform[] birds;
	
    public GameObject startButton, sino;

    public List<int> colors; //sequencia de cores 
    public int idResp, qtdCores, rodada, pontuacao;
    public int qtdTutorial, rodadaTutorial;

    private AudioSource fonteAudio;
    public AudioClip[] sons;

    private int notaFinal;
    private float media;
    float tempo;
    private int idTema;
    public GameObject[] FeedbackEffect;

    [SerializeField]
	public Color standard;

	[Header("Celeiro")]
	public Animator[] barnAnims;
	public GameObject ExitBoard;

    [Header("DificultControl")]
	[Space(10)]
	[SerializeField]
	GameDificultScripting[] gamedificultScripiting;
	[Space(10)]
	[SerializeField]
	GameObject DificultGameObject;

	[SerializeField]
	Button[] gameButtons;
    public int gamelevel;

    [SerializeField]
    GameObject TutorialPrefab;
    [SerializeField]
    public GameObject tutButton;
    public bool isgame = false;



	// Use this for initialization
	void Start () 
    {
       /*  dataController = GameObject.Find("DataController").GetComponent<DataController>();
		gameData.sequenciaSonoraDatas = dataController.GetSequenciData();
		gameData.notaFacil = dataController.GetSequenciaFacil();
		gameData.notaMedio = dataController.GetSequenciaMedio();
		gameData.notaDificil = dataController.GetSequenciaDificil();*/
		sequenciaData = new SequenciaSonoraData();
		idTema = PlayerPrefs.GetInt ("idTema");
        
        OpenLevel();
		StarsPointsControl();
        fonteAudio = GetComponent<AudioSource>();
        gameState = GameState.NOVA;
        NovaRodada();
        pontuacao = 0;
        anim = GetComponent<Animator> ();

	}

    public void OpenTutorial() 
	{
		
		ExitBoard.SetActive(false);
		tutButton.SetActive(false);
		TutorialPrefab.SetActive(true);
		Time.timeScale = 0;
		SoundManager.instance.Play("Player", SoundManager.instance.clipList.TutorialSequencia);
		isgame = true;
			
	}

    private void Update() 
    {
        Cronometro();
        
			
    }

    public void GameDificultControl(int GameDificultValue)
	{	

		gamelevel = GameDificultValue;
		for (int i = 0; i < gamedificultScripiting.Length; i++)
		{
			if(gamedificultScripiting[i].gameValue == GameDificultValue)
			{
				gamedificultScripiting[i].gamePrefabDificult.SetActive(true);
            }
       
            ExitBoard.SetActive(false);
			DificultGameObject.SetActive(false);
		}
         if (gamelevel == 0)
		{
			SoundManager.instance.Play("Player", SoundManager.instance.clipList.TutorialSequencia);
            tutButton.SetActive(false);
            TutorialPrefab.SetActive(true);
			/* sequenciaData.level = "F";
		} else if (gamelevel == 1){
			sequenciaData.level = "M";
		} else if (gamelevel == 2){
			sequenciaData.level = "D";*/
		}
        else if (gamelevel == 1 || gamelevel == 2)
        {
           
            tutButton.SetActive(true);
        }
        

	}
	public void OpenLevel()
	{
        string dif = PlayerPrefs.GetString("dificuldade" + idTema);
		
		if (dif == "F" ||  dif == "")
		{
			gameButtons[1].interactable = false;
			gameButtons[2].interactable = false;
		}
		else if (dif == "M") 
		{
			gameButtons[2].interactable = false;
		}
		/* bool hasF = false;
		bool hasM = false;
		for (int i = 0; i < gameData.sequenciaSonoraDatas.Count; i++)
		{
			if(gameData.sequenciaSonoraDatas[i].level == "F") {
				hasF = true;
			}
			if(gameData.sequenciaSonoraDatas[i].level == "M"){
				hasM = true;
			}
		}
		
		if (!hasF)
		{
			gameButtons[1].interactable = false;
			gameButtons[2].interactable = false;
		}
		
		if (!hasM) 
		{
			gameButtons[2].interactable = false;
        }*/
	}

	public void StarsPointsControl()
	{
		
		for (int i = 0; i < gamedificultScripiting.Length; i++)
		{
			if(i == 0)
			{
            	notaFinal = PlayerPrefs.GetInt ("piqueFacil" + idTema.ToString ());//gameData.notaFacil;
			}
			else if(i == 1)
			{
				notaFinal = PlayerPrefs.GetInt ("piqueMedio" + idTema.ToString ());//gameData.notaMedio;
			}

			else if (i == 2)
			{
				notaFinal = PlayerPrefs.GetInt ("piqueDificil" + idTema.ToString ());//gameData.notaDificil;
			}
			
			for (int j = 0; j < gamedificultScripiting[i].stars.Length; j++)
			{
                if ((notaFinal == 0 || notaFinal == null) || ( notaFinal == 5 && j > 0 ) || ( notaFinal == 7 && j > 1 ) || ( notaFinal == 10 && j > 2 ) || ( notaFinal == 20 && j > 3 ) ) 				{
					break;
				}
				gamedificultScripiting[i].stars[j].SetActive(true);
			}
		}
	}

    void Cronometro()
	{
	    tempo += 1 * Time.deltaTime;
		
	}

	public IEnumerator StartGame()
    {
        startButton.GetComponent<Animator>().SetTrigger("toca");
        sino.GetComponent<Animator>().SetTrigger("toca");
		fonteAudio.PlayOneShot(sons[5]);
		roundTxt.text = "Rodada: " + (rodada + 1).ToString();
        yield return new WaitForSeconds(0.2f);
        for (float f = 0f; f <= standard.a; f += 0.02f)
        {
            Color c = roundTxt.color;
			c.a = f;
			roundTxt.color = c;
			new WaitForSeconds(.1f);
            yield return null;
        }
        yield return new WaitForSeconds(.3f);
        for (float f = 1f; f >= 0; f -= 0.02f)
        {
            Color c = roundTxt.color;
			c.a = f;
			roundTxt.color = c;
			new WaitForSeconds(.1f);
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        roundTxt.text = (qtdCores + rodada) + " notas";
        for (float f = 0f; f <= standard.a; f += 0.02f)
        {
            Color c = roundTxt.color;
			c.a = f;
			roundTxt.color = c;
			new WaitForSeconds(.1f);
            yield return null;
        }
        yield return new WaitForSeconds(.7f);
        for (float f = 1f; f >= 0; f -= 0.02f)
        {
            Color c = roundTxt.color;
			c.a = f;
			roundTxt.color = c;
			new WaitForSeconds(.2f);
            yield return null;
        }
        yield return new WaitForSeconds(0.3f);
        StartCoroutine("Sequencia", qtdCores + rodada);
    }


    public IEnumerator StartGameTutorial()
    {
		
        tutorialTxt.text = "Começando o Tutorial";
        yield return new WaitForSeconds(0.5f);
        for (float f = 0f; f <= standard.a; f += 0.01f)
        {
            Color c = tutorialTxt.color;
			c.a = f;
			tutorialTxt.color = c;
			new WaitForSeconds(.5f);
            yield return null;
        }
        yield return new WaitForSeconds(2f);
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = tutorialTxt.color;
			c.a = f;
			tutorialTxt.color = c;
			new WaitForSeconds(.5f);
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);
        tutorialTxt.text = "Aperte a sequência na ordem certa...";
        for (float f = 0f; f <= standard.a; f += 0.01f)
        {
            Color c = tutorialTxt.color;
			c.a = f;
			tutorialTxt.color = c;
			new WaitForSeconds(.5f);
            yield return null;
        }
        yield return new WaitForSeconds(2f);
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = tutorialTxt.color;
			c.a = f;
			tutorialTxt.color = c;
			new WaitForSeconds(.5f);
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("SequenciaTutorial", qtdTutorial);
    }

    private void NovaRodada()
    {
       /* roundTxt.text = "Rodada: " + (rodada + 1).ToString();
        sequenceTxt.text = "Sequência: " + (qtdCores + rodada).ToString();*/
        colors.Clear();
        startButton.SetActive(true);

		foreach (Animator anim in buttons)
        {
            anim.SetBool("canta", false);
        }
    }

    IEnumerator Sequencia(int qtd)
    {
        startButton.SetActive(false);

        for(int i = qtd; i > 0; i--)
        {
            yield return new WaitForSeconds(1f);

            int r = Random.Range(0, buttons.Length);
            buttons[r].SetBool("canta", true);
			Vector3 posBird = new Vector3 (birds[r].position.x, birds[r].position.y + 1, birds[r].position.z);
			Instantiate (FeedbackEffect [0],posBird, birds [r].rotation);
			Destroy (GameObject.Find ("BirdCorrect(Clone)"), 0.4f);
			fonteAudio.PlayOneShot(sons[r]);

            colors.Add(r);

            yield return new WaitForSeconds(1f);
            buttons[r].SetBool("canta", false);
			
        }

        yield return new WaitForSeconds(0.1f);
        roundTxt.text = "Agora é sua vez, acerte a sequência";
        for (float f = 0f; f <= standard.a; f += 0.02f)
        {
            Color c = roundTxt.color;
			c.a = f;
			roundTxt.color = c;
			new WaitForSeconds(.2f);
            yield return null;
        }
        gameState = GameState.RESPONDER;
        idResp = 0;
        yield return new WaitForSeconds(.2f);
        for (float f = 1f; f >= 0; f -= 0.02f)
        {
            Color c = roundTxt.color;
			c.a = f;
			roundTxt.color = c;
			new WaitForSeconds(.2f);
            yield return null;
        }
       
    }

IEnumerator SequenciaTutorial(int qtd)
    {
        
        for(int i = 0; i < qtd; i++)
        {
            yield return new WaitForSeconds(.8f);

            buttons[i].SetBool("canta", true);
            fonteAudio.PlayOneShot(sons[i]);

            colors.Add(i);

            yield return new WaitForSeconds(1f);
            buttons[i].SetBool("canta", false);
        }
        gameState = GameState.TUTORIAL;
        idResp = 0;
    }



    IEnumerator Responder(int idBtn)
    {
        buttons[idBtn].SetBool("canta", true);

		Vector3 posBird = new Vector3 (birds[idBtn].position.x, birds[idBtn].position.y + 1, birds[idBtn].position.z);
        if(colors[idResp] == idBtn)
        {
			
			//Instantiate (FeedbackEffect [0],posBird,birds[idBtn].rotation);
			Destroy (GameObject.Find ("BirdCorrect(Clone)"), 0.5f);
            fonteAudio.PlayOneShot(sons[idBtn]);
        }
        else
        {
			//Instantiate (FeedbackEffect [1],posBird,birds[idBtn].rotation);
			Destroy (GameObject.Find ("BirdLose(Clone)"), 0.5f);
            gameState = GameState.ERRO;
            StartCoroutine("GameOver");
        }

        idResp++;

        if(idResp >= colors.Count )
        {
            
            yield return new WaitForSeconds(.3f);
            roundTxt.text = "Muito bem!";
            for (float f = 0f; f <= standard.a; f += 0.02f)
            {
                Color c = roundTxt.color;
                c.a = f;
                roundTxt.color = c;
                new WaitForSeconds(.2f);
                yield return null;
            }
            yield return new WaitForSeconds(0.2f);
            for (float f = 1f; f >= 0; f -= 0.02f)
            {
                Color c = roundTxt.color;
                c.a = f;
                roundTxt.color = c;
                new WaitForSeconds(.2f);
                yield return null;
            }
            roundTxt.text = "Aperte o sino novamente para iniciar a nova sequência";
            gameState = GameState.NOVA;
            sequenciaData.acertos++;
            rodada++;
            if(rodada > 6) pontuacao += 10;
            else if(rodada > 3) pontuacao += 7;
            else if(rodada <= 3) pontuacao += 5;
            //Debug.Log(pontuacao);
            NovaRodada();
            for (float f = 0f; f <= standard.a; f += 0.02f)
            {
                Color c = roundTxt.color;
                c.a = f;
                roundTxt.color = c;
                new WaitForSeconds(.2f);
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
            for (float f = 1f; f >= 0; f -= 0.02f)
            {
                Color c = roundTxt.color;
                c.a = f;
                roundTxt.color = c;
                new WaitForSeconds(.2f);
                yield return null;
            }
            
        
        }

        yield return new WaitForSeconds(0.2f);
        buttons[idBtn].SetBool("canta", false);
    }


	public void BarnAnin(){

		for (int i = 0; i < barnAnims.Length; i++) {
			barnAnims [i].SetBool ("Active", true);
		}
		ExitBoard.SetActive (false);
	}

    IEnumerator GameOver()
    {
       
        fonteAudio.PlayOneShot(sons[4]);
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < 3; i++)
        {
			for (int x = 0; i < buttons.Length; i++)
            {
				buttons[x].SetBool("canta", true);
            }

            yield return new WaitForSeconds(0.2f);

			for (int x = 0; i < buttons.Length; i++)
			{
				buttons[x].SetBool("canta", true);
			}
            yield return new WaitForSeconds(0.2f);
        }

        int idB = 0;
        for(int i = 0; i < 12; i++)
        {
            buttons[idB].SetBool("canta", true);
            yield return new WaitForSeconds(0.1f);
            buttons[idB].SetBool("canta", false);
            idB++; 
            if(idB > 3) { idB = 0; }
        }

		if (rodada <= 2)
		{
			notaFinal = 5;
		}
		else if (rodada >= 3 && rodada <= 4)
		{
			notaFinal = 7;
		}
		else if (rodada >= 5 && rodada <= 7)
		{
			notaFinal = 10;
		}
		else if (rodada >= 8)
		{
			notaFinal = 20;
		}
        if (gamelevel == 0)
		{
			if (notaFinal > PlayerPrefs.GetInt("piqueFacil" + idTema.ToString()))
			{
				PlayerPrefs.SetInt ("piqueFacil" + idTema.ToString (), notaFinal);
			}
			if(PlayerPrefs.GetString("dificuldade" + idTema) == "F" || PlayerPrefs.GetString("dificuldade" + idTema) == "")
			{
				PlayerPrefs.SetString("dificuldade" + idTema, "M");
			}
			
		}
		else if (gamelevel == 1)
		{
			if (notaFinal > PlayerPrefs.GetInt("piqueMedio" + idTema.ToString()))
			{
				PlayerPrefs.SetInt ("piqueMedio" + idTema.ToString (), notaFinal);
			}

			if(PlayerPrefs.GetString("dificuldade" + idTema) == "M")
			{
				PlayerPrefs.SetString("dificuldade" + idTema, "D");
			}
			
		}
		else if (gamelevel == 2)
		{
			if (notaFinal > PlayerPrefs.GetInt("piqueDificil" + idTema.ToString()))
			{
				PlayerPrefs.SetInt ("piqueDificil" + idTema.ToString (), notaFinal);
			}
			
		}
        PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString (), notaFinal);
        sequenciaData.tempoJogo = tempo;
        sequenciaData.nota = notaFinal;
        //dataController.SetSequenciaData(sequenciaData);
		BarnAnin ();
		yield return new WaitForSeconds (2);
		//Score.infoValue = string.Format ("Você acertou {0} rodadas !", rodada );
		//SceneManager.LoadScene ("Score");  
        LoadingScreenManager.LoadScene(10); 
    }


}
