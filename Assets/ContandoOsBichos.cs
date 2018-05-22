using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContandoOsBichos : MonoBehaviour {

	public Transform animal, spawn;

	private int countSpawn, idTema, countDestroy;

	

	// Use this for initialization
	void Start () {
		countSpawn = 20;
		countDestroy = 20;
		StartCoroutine("AnimalSpawn");
		idTema = PlayerPrefs.GetInt ("idTema");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator AnimalSpawn(){
		Instantiate(animal, spawn.position, spawn.rotation);
		yield return new WaitForSeconds(2f);
		countSpawn--;
		if(countSpawn > 0){
			StartCoroutine("AnimalSpawn");
		}
	}

	public void Conta(){
		countDestroy--;
	}
}
