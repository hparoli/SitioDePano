using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AninhaAnimations : MonoBehaviour {

	float time;

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(time >= 5){
			int i = Random.Range(0,4);
			if(i == 0) this.GetComponent<Animator>().SetTrigger("Acenar");
			if(i == 1) this.GetComponent<Animator>().SetTrigger("Palma");
			if(i == 2) this.GetComponent<Animator>().SetTrigger("Danca");
			if(i == 3) this.GetComponent<Animator>().SetTrigger("Rir");
			time = 0;
		}
	}
}
