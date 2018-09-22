using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaminhosSpawner : MonoBehaviour {

	[SerializeField]
	private int numColunas,numLinhas,level,resp;

	[SerializeField]
	private GameObject seta;

	[SerializeField]
	private List<GameObject> setas;

	[SerializeField]
	private Transform pos;

	void Start(){
		level = 1;
		InicializaLevel(level);
	}

	private void InicializaLevel(int lvl){
		if (lvl == 1 || lvl == 2 || lvl == 3 || lvl == 4){
			numColunas = 4;
			numLinhas = 4;
			resp = 1;
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

		int index = 0;
		for (int i = 0; i <= numColunas; i++)
		{
			for (int j = 0; j < numLinhas; j++)
			{
				setas.Add(GameObject.Instantiate(seta, new Vector3(pos.position.x - (i*2), pos.position.y - (j*1.5f), pos.position.z) ,pos.rotation));
				setas[index].GetComponent<SetaBehavior>().x = j;
				setas[index].GetComponent<SetaBehavior>().y = i;
				setas[index].GetComponent<SetaBehavior>().dir = 0;
				setas[index].GetComponent<SetaBehavior>().cor = Color.white;
				setas[index].GetComponent<SetaBehavior>().tipoSeta = "normal";
			}
		}
	}
}
