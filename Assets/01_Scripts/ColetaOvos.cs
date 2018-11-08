using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColetaOvos : MonoBehaviour {

	private int pegouOvos, erros;

	[Header("Game Check Dificult")]
	public GameObject[] galinhas;
	public GameObject[] eggsCollected;
	public static bool work;
	public AudioClip[] sons;
	private AudioSource fonteAudio;


	public GameObject manager;
	private int idTema;
	private int notaFinal;

	[Header("Dificult Control")]
    [Space(10)]
	[SerializeField]
	GameDificultScripting[] gamedificultScripiting;
	[Space(10)]
	[SerializeField]
	GameObject DificultGameObject;

	[SerializeField]
	Button[] gameButtons;
	
	[HideInInspector]
	public int gamelevel;

    [SerializeField]
    GameObject ExitBoard;


	// Use this for initialization
	void Start () 
	{
		work = false;
		idTema = PlayerPrefs.GetInt ("idTema");
		fonteAudio = GetComponent<AudioSource> ();
		pegouOvos = 0;
		erros     = 0;
		manager = GameObject.FindWithTag("Manager");

		for (int i = 0; i < eggsCollected.Length; i++) 
		{
			eggsCollected[i].SetActive (false);
		}

		 OpenLevel();
		 StarsPointsControl();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Game1();
		Score();
	}

	public void Game1()
	{
		if(work)
		{
			RaycastHit galinhaClick = new RaycastHit();
			bool hit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out galinhaClick);
			if (Input.GetMouseButtonDown (0)) {
				if (hit) {
					for(int i = 0; i < galinhas.Length; i++){
						if (galinhaClick.transform.gameObject.name == galinhas[i].name){
							if(galinhas[i].GetComponent<ApareceOvo>().temOvo){
								pegouOvos++;
								eggFeedback ();
								galinhas[i].GetComponent<ApareceOvo>().Desaparece();
								//feedback positivo
								Debug.Log("ACERTOU");
								fonteAudio.PlayOneShot(sons[0]);
							} else {
								erros++;
								galinhas[i].GetComponent<Animator>().SetTrigger("Erro");
								//feedback negativo
								Debug.Log("ERROU");
								fonteAudio.PlayOneShot(sons[1]);
							}
						}
					}
				}
			}
		}
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
				DificultGameObject.SetActive(false);
		}
        if (gamelevel == 0)
        {
            ExitBoard.SetActive(false);
            SoundManager.instance.Play("Player", SoundManager.instance.clipList.TutorialOvo);

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
	}

	public void StarsPointsControl()
	{
		
		for (int i = 0; i < gamedificultScripiting.Length; i++)
		{
			if(i == 0)
			{
				notaFinal = PlayerPrefs.GetInt ("piqueFacil" + idTema.ToString ());
			}
			else if(i == 1)
			{
				notaFinal = PlayerPrefs.GetInt ("piqueMedio" + idTema.ToString ());
			}

			else if (i == 2)
			{
				notaFinal = PlayerPrefs.GetInt ("piqueDificil" + idTema.ToString ());
			}
			
			for (int j = 0; j < gamedificultScripiting[i].stars.Length; j++)
			{
			 if ((notaFinal == 0 || notaFinal == null) || ( notaFinal == 5 && j > 0 ) || ( notaFinal == 7 && j > 1 ) || ( notaFinal == 10 && j > 2 ) ||( notaFinal == 20 && j > 3 )) 
				{
					break;
				}
				gamedificultScripiting[i].stars[j].SetActive(true);
			}
		}
	}

	public void eggFeedback()
	{
			if (pegouOvos >= 1) {
				eggsCollected [0].SetActive (true);
			}
			if (pegouOvos >= 2){
				eggsCollected [1].SetActive (true);	
			}
			if (pegouOvos >= 3){
				eggsCollected [2].SetActive (true);

		}
	}
	public void Score()
	{
		if(pegouOvos == 3)
		{

			if (erros == 0) 
			{
				notaFinal = 20;
			}
			else if (erros <= 3f)
			{
				notaFinal = 10;
			}
			else if (erros <= 7f)
			{
				notaFinal = 7;
			}

			else if (erros <= 10f) 
			{
				notaFinal = 5;
			}
				PlayerPrefs.SetInt ("notaFinalTemp" + idTema.ToString (), notaFinal);
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
//				Score.infoValue = string.Format ("Você errou {0} vezes!", erros);
				manager.GetComponent<ComportamentoGalinha>().EndGame();
		}
	}
}

