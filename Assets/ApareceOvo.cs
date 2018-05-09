using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApareceOvo : MonoBehaviour {

	public GameObject ovo;
	public bool temOvo;
	
	// Use this for initialization
	void Start () {
		ovo.SetActive(false);
		temOvo = false;
	}
	
	public void Aparece(){
		int random = Random.Range(0,11);
		Debug.Log(random);
		if(random < 5){
			ovo.SetActive(true);
			temOvo = true;
		}
	}

	public void Desaparece(){
		ovo.SetActive(false);
		temOvo = false;
	}

}