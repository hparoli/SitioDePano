using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetaOvos : MonoBehaviour {

	private int pegouOvos, erros;
	public GameObject[] galinhas;
	
	public GameObject manager;
	// Use this for initialization
	void Start () {
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
							} else {
								erros++;
								//feedback negativo
								Debug.Log("ERROU");
							}
						}
					}
				}
			}

			if(pegouOvos == 15){
				manager.GetComponent<ComportamentoGalinha>().EndGame();
			}
	}


}
