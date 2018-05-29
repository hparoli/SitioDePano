using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

	private int idTema;

//	public Text txtnota;
//	public Text txtInfotema;

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


//		txtInfotema.text = infoValue;

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
					stars [0].SetActive (true);
					starAnims [0].SetBool ("MasterPoint", true);
					starAnims [1].SetBool ("MasterPoint", true);
					starAnims [2].SetBool ("MasterPoint", true);
					starAnims [3].SetBool ("MasterPoint", true);
				} 
				else 
				{
					
					stars [0].SetActive (false);
					starAnims [0].SetBool ("NormalPoint", i >= 0);
					starAnims [1].SetBool ("NormalPoint", i >= 1);
					starAnims [2].SetBool ("NormalPoint", i >= 2);
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

