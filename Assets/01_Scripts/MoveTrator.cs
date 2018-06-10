using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrator : MonoBehaviour {

	public float velX;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (new Vector2 (transform.position.x * velX * Time.deltaTime , 0));
	}
}
