using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColecionaveisControl : MonoBehaviour {

	[SerializeField]
	GameObject colect;

	int value;
	int teste = 20;
	// Use this for initialization
	
	void Start ()
	{
		PlayerPrefs.SetInt("piqueCollect",teste);
		value =	PlayerPrefs.GetInt("piqueCollect");
		
		Debug.Log(value);
	}
	
	// Update is called once per frame
	void Update () 
	{
		OpenItens();
		
	}

	public void OpenItens()
	{
	
		if (value >= 20)
		{
			colect.SetActive(true);
		}
	}
}
