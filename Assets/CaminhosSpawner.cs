using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaminhosSpawner : MonoBehaviour {

	private int numColunas,numLinhas,level;

	private GameObject seta;


	void Start(){
		level = 1;
	}

	private void InicializaLevel(int lvl){
		if (lvl == 1 || lvl == 2 || lvl == 3 || lvl == 4){
			numColunas = 4;
			numLinhas = 4;
		}
		else if (lvl == 5){
			numColunas = 4;
			numLinhas = 5;
		} 
		else if (lvl == 6){
			numColunas = 4;
			numLinhas = 6;
		} 
		else if (lvl == 7){
			numColunas = 4;
			numLinhas = 7;
		}
		else if (lvl == 8){
			numColunas = 4;
			numLinhas = 8;
		}
	}
}
