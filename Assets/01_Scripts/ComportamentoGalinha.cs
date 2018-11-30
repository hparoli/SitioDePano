using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ComportamentoGalinha : MonoBehaviour {
	//TrilhaSonora
	public AudioSource audio;

	public GameObject ColetaOvosControl;
	private float min,max,delayGalinha;
	public Animator[] g3;
	public Animator[] g2;
	public Animator[] g1;
	[SerializeField]
	ApareceOvo ApareceOvo;
	
	
	[Header("Celeiro")]
	public Animator[] barnAnims;
	public GameObject ExitBoard;
	

	[Header("Tutorial")]
	[SerializeField]
	GameObject[] tutorial;
	public GameObject[] tutButton;

	float tempo;
	float tempo2;
	
	int GameValue;
	bool isgame = false;

	// Use this for initialization
	void Start () 
	{	
		audio.Pause ();
		Debug.Log(GameValue);
		Time.timeScale = 0;
		min = 1.5f;
		max = 3.5f;
		delayGalinha = 2.5f;
		ApareceOvo = FindObjectOfType <ApareceOvo> ();
		
	}
    void Update() 
	{
		Cronometro();	
		GameValue = ColetaOvosControl.GetComponent<ColetaOvos>().gamelevel;
		Debug.Log(GameValue);
	}

	public void OpenTutorial()
	{
		ExitBoard.SetActive(false);
		for (int i = 0; i < tutButton.Length; i++)
		{
			tutButton[i].SetActive(false);
		}
		for (int i = 0; i < tutorial.Length; i++)
		{
			tutorial[i].SetActive(true);
		}
		Time.timeScale = 0;
		SoundManager.instance.Play("Player", SoundManager.instance.clipList.TutorialOvo);
		isgame = true;
	}

	public void StartGame()
	{
		for (int i = 0; i < tutorial.Length; i++)
		{
			tutorial[i].SetActive(false);
		}
		if (!isgame)
		{
			
			tutButton[0].SetActive(true);
			tutButton[1].SetActive(true);
			tutButton[2].SetActive(true);
			ExitBoard.SetActive(true);
       	 	SoundManager.instance.Stop("Player", SoundManager.instance.clipList.TutorialOvo);
			audio.Play ();
			Time.timeScale = 1;
			ColetaOvos.work = true;
			StartCoroutine("Comportamento");
		}
		
		else if (isgame)
		{
			tutButton[0].SetActive(true);
			tutButton[1].SetActive(true);
			tutButton[2].SetActive(true);
			ExitBoard.SetActive(true);
			SoundManager.instance.Stop("Player", SoundManager.instance.clipList.TutorialOvo);
			Time.timeScale = 1;
		}
       
	}
	
	IEnumerator Comportamento()
	{
		
		if (GameValue == 0)
		{
			int galinha = Random.Range(0, g1.Length);
			float tempo = Random.Range(min, max);
			yield return new WaitForSeconds(tempo);
			g1[galinha].SetBool("Levantando",true);
			yield return new WaitForSeconds(delayGalinha);
			g1[galinha].SetBool("Sentando",true);
			g1[galinha].SetBool("Levantando",false);
			yield return new WaitForSeconds(0.5f);
			g1[galinha].SetBool("Sentando",false);
			StartCoroutine("Comportamento");
		}
		else if (GameValue == 1)
        {
			int galinha = Random.Range(0, g2.Length);
			int galinha2 = Random.Range(0, g2.Length);
			float tempo = Random.Range(min, max);
			yield return new WaitForSeconds (tempo);
			g2 [galinha].SetBool ("Levantando", true);
			g2 [galinha2].SetBool ("Levantando", true);
			yield return new WaitForSeconds (delayGalinha);
			g2 [galinha].SetBool ("Sentando", true);
			g2 [galinha2].SetBool ("Sentando", true);
			g2 [galinha2].SetBool ("Levantando", false);
			g2 [galinha].SetBool ("Levantando", false);
			yield return new WaitForSeconds (0.5f);
			g2 [galinha].SetBool ("Sentando", false);
			g2 [galinha2].SetBool ("Sentando", false);
			StartCoroutine("Comportamento");
       }
	   else if (GameValue == 2)
	   {
		 	 int galinha = Random.Range(0, g3.Length);
			int galinha2 = Random.Range(0, g3.Length);
			int galinha3 = Random.Range(0, g3.Length);
			float tempo = Random.Range(min, max);
			yield return new WaitForSeconds (tempo);
			g3 [galinha].SetBool ("Levantando", true);
			g3 [galinha2].SetBool ("Levantando", true);
			g3[galinha3].SetBool("Levantando",true);
			yield return new WaitForSeconds (delayGalinha);
			g3 [galinha].SetBool ("Sentando", true);
			g3 [galinha2].SetBool ("Sentando", true);
			g3[galinha3].SetBool("Sentando",true);
			g3[galinha3].SetBool("Levantando",false);
			g3 [galinha2].SetBool ("Levantando", false);
			g3 [galinha].SetBool ("Levantando", false);
			yield return new WaitForSeconds (0.5f);
			g3 [galinha].SetBool ("Sentando", false);
			g3 [galinha2].SetBool ("Sentando", false);
			g3[galinha3].SetBool("Sentando",false);
			StartCoroutine("Comportamento"); 
	   }
	}
	
	public void EndGame()
	{
		
		for(int i = 0; i < g3.Length; i++)
		{
			g3[i].SetBool("Levantando",false);
			g3[i].SetBool("Sentando",false);
			g3[i].enabled = false;
			BarnAnin ();
			StartCoroutine("GameOver");
		}
	}

	void Cronometro()
	{
	    tempo += 1 * Time.deltaTime;
	
	}

	public void BarnAnin(){
		for (int i = 0; i < barnAnims.Length; i++) 
		{
			barnAnims [i].SetBool ("Active", true);
		}
		ExitBoard.SetActive (false);
	}


	IEnumerator GameOver()
	{
		AnaliticsControl.ovosTime = tempo;
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene("Score");
	}

}
