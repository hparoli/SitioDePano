using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContaAnimal : MonoBehaviour {

	public GameObject gm;

	// Use this for initialization
	void Start () {
		gm = GameObject.Find("GameManager");
	}
	
	void OnTriggerEnter(Collider col){
		gm.GetComponent<ContandoOsBichos>().Conta();
		Destroy(col.gameObject);
	}

}
