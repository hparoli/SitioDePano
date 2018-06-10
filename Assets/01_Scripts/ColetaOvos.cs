using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetaOvos : MonoBehaviour {

	private int pegouOvos, erros;
	public GameObject[] galinhas;

	public static bool work;

	public AudioClip[] sons;
	private AudioSource fonteAudio;
	
	public GameObject manager;
	public GameObject[] eggsCollected;

	private int idTema;
	private int notaFinal;

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
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(work){
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
								//feedback negativo
								Debug.Log("ERROU");
								fonteAudio.PlayOneShot(sons[1]);
							}
						}
					}
				}
			}
		}

		if(pegouOvos == 3){

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
//				Score.infoValue = string.Format ("Você errou {0} vezes!", erros);
				manager.GetComponent<ComportamentoGalinha>().EndGame();
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
}
