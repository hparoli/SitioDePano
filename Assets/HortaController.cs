using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HortaController : MonoBehaviour {

	private int level;

	[SerializeField]
	private GameObject[] buttons;
	
	[SerializeField]
	private Text[] texts;

	[SerializeField]
	private Text saldo;


	// Use this for initialization
	void Start () {
		level = 1;

		StartGame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void StartGame(){
		if(level == 1){
			for (int i = 0; i < buttons.Length; i++)
			{
				if(i < 3) buttons[i].SetActive(true);
			}
		}
		else if(level > 1){
			for (int i = 0; i < buttons.Length; i++)
			{
				buttons[i].SetActive(true);
			}
		}
		
	}
}
