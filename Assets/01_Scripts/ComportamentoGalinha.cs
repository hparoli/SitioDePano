using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ComportamentoGalinha : MonoBehaviour {
	public GameObject ColetaOvosControl;
	private float min,max,delayGalinha;
	public Animator[] animator;
	public Animator[] animatorG2;

	[SerializeField]
	ApareceOvo ApareceOvo;

	[Header("Celeiro")]
	public Animator[] barnAnims;
	public GameObject ExitBoard;

	[Header("Tutorial")]
	public string [] txtTutorial;
	public Text infoTutorial;
	int indexTutorial = 0;
	[SerializeField]
	GameObject tutorial;
	[SerializeField]
	GameObject[] boardsTutorial;
	[SerializeField]
	GameObject[] imagesTutorial;

	float tempo;
	int GameValue;

	

	// Use this for initialization
	void Start () 
	{	
		int GameValue = ColetaOvosControl.GetComponent<ColetaOvos>().gamelevel;
		Debug.Log(GameValue);
		Time.timeScale = 0;
		min = 1.5f;
		max = 3.5f;
		delayGalinha = 2.5f;
		ApareceOvo = FindObjectOfType <ApareceOvo> ();
		tutorial.SetActive (true);
		infoTutorial.text = txtTutorial [indexTutorial];
		boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (false);boardsTutorial [2].SetActive (false);
		imagesTutorial [0].SetActive (true);imagesTutorial [1].SetActive (false);
	}
    void Update() 
	{
		Cronometro();	
	}

	

	public void ChangeTextTutorialForward(){
		indexTutorial++;
		infoTutorial.text = txtTutorial [indexTutorial];

		if (indexTutorial == 0) {
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (false);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (true);
			imagesTutorial [1].SetActive (false);
		}
		if (indexTutorial == 1) {
			boardsTutorial [0].SetActive (false);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (true);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (true);

		}

	}

	public void ChangeTextTutorialBack(){
		indexTutorial--;
		infoTutorial.text = txtTutorial [indexTutorial];

		if (indexTutorial == 0) 
		{
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (false);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (true);
			imagesTutorial [1].SetActive (false);

		}
		if (indexTutorial == 1) 
		{
			boardsTutorial [0].SetActive (false);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (true);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (true);

		}
	}
	public void StartGame()
	{
		tutorial.SetActive (false);
		Time.timeScale = 1;
		ColetaOvos.work = true;
		StartCoroutine("Comportamento");
	}
	
	IEnumerator Comportamento()
	{
		
		if (GameValue == 0)
		{
			int galinha = Random.Range(0, animator.Length);
			float tempo = Random.Range(min, max);
			yield return new WaitForSeconds(tempo);
			animator[galinha].SetBool("Levantando",true);
			yield return new WaitForSeconds(delayGalinha);
			animator[galinha].SetBool("Sentando",true);
			animator[galinha].SetBool("Levantando",false);
			yield return new WaitForSeconds(0.5f);
			animator[galinha].SetBool("Sentando",false);
			StartCoroutine("Comportamento");
		}
		else if (GameValue == 1)
		{
			int galinha = Random.Range(0, animatorG2.Length);
			float tempo = Random.Range(min, max);
			yield return new WaitForSeconds(tempo);
			animatorG2[galinha].SetBool("Levantando",true);
			yield return new WaitForSeconds(delayGalinha);
			animatorG2[galinha].SetBool("Sentando",true);
			animatorG2[galinha].SetBool("Levantando",false);
			yield return new WaitForSeconds(0.5f);
			animatorG2[galinha].SetBool("Sentando",false);
			StartCoroutine("Comportamento");
		}
		
		
	}
	
	public void EndGame()
	{
		if (GameValue == 0)
		{
			for(int i = 0; i < animator.Length; i++)
			{
			animator[i].SetBool("Levantando",false);
			animator[i].SetBool("Sentando",false);
			animator[i].enabled = false;
			BarnAnin ();
			StartCoroutine("GameOver");
			}
		}
		else if (GameValue == 1)
		{
			for(int i = 0; i < animatorG2.Length; i++)
			{
			animatorG2[i].SetBool("Levantando",false);
			animatorG2[i].SetBool("Sentando",false);
			animatorG2[i].enabled = false;
			BarnAnin ();
			StartCoroutine("GameOver");
			}
		}
		
	}

	void Cronometro()
	{
	    tempo += 1 * Time.deltaTime;
		Debug.Log (tempo);
	}

	public void BarnAnin(){
		for (int i = 0; i < barnAnims.Length; i++) {
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
