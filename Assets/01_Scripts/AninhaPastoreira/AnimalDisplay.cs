using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class AnimalDisplay : MonoBehaviour {

	private int random;
	public Animais[] animal;
	public SpriteRenderer sprite;
	public string anim;
	
	// Use this for initialization
	void Start () {
		random = Random.Range(0,4);
		anim = animal[random].animal;
		sprite.sprite = animal[random].sprite;
		this.gameObject.GetComponent<Animator>().runtimeAnimatorController = animal[random].animation;
	}
	
}
