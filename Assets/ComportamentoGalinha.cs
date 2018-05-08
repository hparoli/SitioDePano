using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class ComportamentoGalinha : MonoBehaviour {

	public Animator animator;
	// Use this for initialization
	void Start () {
		animator = this.gameObject.GetComponent<Animator>();
		StartCoroutine("Comportamento");
	}
	
	IEnumerator Comportamento(){
		int tempo = Random.Range(5, 16);
		yield return new WaitForSeconds(tempo);
		animator.SetBool("Levantando",true);
		yield return new WaitForSeconds(2.5f);
		animator.SetBool("Sentando",true);
		animator.SetBool("Levantando",false);
		yield return new WaitForSeconds(0.5f);
		animator.SetBool("Sentando",false);
	}
}
