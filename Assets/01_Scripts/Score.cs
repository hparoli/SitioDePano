using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

	private int idTema;

	public Text txtnota;
	public Text txtInfotema;

	[Header("Array Collections")]
	public GameObject[] stars;
	public Animator[] starAnims;
	public int[] scoresTargets;

	[Space(10)]
	public GameObject effect;

	private int notaFinal;
	private int acertos;

	[Header("Debug Values")]
	[SerializeField]
	int debug_score;
	[SerializeField]
	bool useDebug;


	public static string infoValue;

	// Use this for initialization
	void Start () 
	{

		for (int i = 0; i < stars.Length ; i++) 
		{
			stars [i].SetActive (false);
		}

		idTema = PlayerPrefs.GetInt ("idTema");
		notaFinal = PlayerPrefs.GetInt ("notaFinalTemp" + idTema.ToString ());
		acertos = PlayerPrefs.GetInt ("acertosTemp" + idTema.ToString ());


		txtInfotema.text = infoValue;

		#if UNITY_EDITOR
		if (useDebug)
		notaFinal = debug_score;
		#endif

		for (int i = scoresTargets.Length - 1; i >= 0; i--) 
		{
			if (notaFinal >= scoresTargets [i]) 
			{
				if (i >= 3) 
				{
					stars [3].SetActive (true);
					starAnims [3].SetBool ("Active", true);
				} 
				else 
				{
					stars [0].SetActive (i >= 0);
					stars [1].SetActive (i >= 1);
					stars [2].SetActive (i >= 2);

					starAnims [0].SetBool ("Active", i >= 0);
					starAnims [1].SetBool ("Active", i >= 1);
					starAnims [2].SetBool ("Active", i >= 2);
				}

				break;
			}
		}

		//20,10,7,5
		addEffect ();
		
	}
	void Update () {

	}

	public void addEffect (){

		GameObject.Instantiate (effect);

	}

	public void GoToMenu(){
		SceneManager.LoadScene (0);
	}

	public void restart(){

		SceneManager.LoadScene(idTema);
	}
}
	
	// Update is called once per frame

