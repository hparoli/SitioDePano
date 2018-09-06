using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectControl : MonoBehaviour {

	public GameObject touchEffect;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		AddEffect ();
	}
	private void AddEffect ()
	{
		Vector3 mousPos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (Input.GetButtonDown("Fire1"))
		{
			Debug.Log(mousPos);
			Instantiate(touchEffect, mousPos, transform.rotation);

		}
	}
}
