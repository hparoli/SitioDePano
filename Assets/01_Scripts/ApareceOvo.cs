using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ApareceOvo : MonoBehaviour {

	public GameObject ovo, pintinho;
	public bool temOvo;

	
	// Use this for initialization
	void Start () {
		ovo.SetActive(false);
		pintinho.SetActive(false);
		temOvo = false;
	}
	
	public void Aparece()
	{
		int random = Random.Range(0,11);
		Debug.Log(random);
			if(random < 4){
				ovo.SetActive(true);
				temOvo = true;
			} else if(random < 7){
				pintinho.SetActive(true);
			} 
		}



	public void Desaparece(){
		ovo.SetActive(false);
		pintinho.SetActive(false);
		temOvo = false;
	}

}