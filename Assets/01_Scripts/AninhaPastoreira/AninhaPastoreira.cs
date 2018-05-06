using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AninhaPastoreira : MonoBehaviour {

	public Transform animal, spawn;
	// Use this for initialization
	void Start () {
		StartCoroutine("AnimalSpawn");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator AnimalSpawn(){
		yield return new WaitForSeconds(3f);
		Instantiate(animal, spawn.position, spawn.rotation);
	}
}
