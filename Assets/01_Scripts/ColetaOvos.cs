using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetaOvos : MonoBehaviour {

	private int pegouOvos, erros;
	public GameObject[] galinhas;

	public AudioClip[] sons;
	private AudioSource fonteAudio;
	
	public GameObject manager;

	private int idTema;
	private int notaFinal;

	// Use this for initialization
	void Start () 
	{
		idTema = PlayerPrefs.GetInt ("idTema");
		fonteAudio = GetComponent<AudioSource> ();
		pegouOvos = 0;
		erros     = 0;
		manager = GameObject.FindWithTag("Manager");
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit galinhaClick = new RaycastHit();
			bool hit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out galinhaClick);
			if (Input.GetMouseButtonDown (0)) {
				if (hit) {
					for(int i = 0; i < galinhas.Length; i++){
						if (galinhaClick.transform.gameObject.name == galinhas[i].name){
							if(galinhas[i].GetComponent<ApareceOvo>().temOvo){
								pegouOvos++;
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

			if(pegouOvos == 10){

			if (erros <= 3f)
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
				Score.infoValue = string.Format ("Você errou {0} vezes!", erros);
				manager.GetComponent<ComportamentoGalinha>().EndGame();
			}
	}


}
