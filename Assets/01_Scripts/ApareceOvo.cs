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

			if(random < 8){
			
				ovo.SetActive(true);
				temOvo = true;
			} 
			 else if(random < 10){
			
				pintinho.SetActive(true);
			} 

	}

	public void Desaparece(){
		ovo.SetActive(false);
		pintinho.SetActive(false);
		temOvo = false;
	}

}