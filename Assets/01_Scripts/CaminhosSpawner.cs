using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CaminhosSpawner : MonoBehaviour {

	[SerializeField]
	private int numColunas,numLinhas,level,resp;

	[SerializeField]
	private GameObject seta,btn;

	[SerializeField]
	private List<GameObject> setas,botoes;

	[SerializeField]
	private Transform pos;

	[SerializeField]
	private Sprite img;

	[SerializeField]
	private float marg;

	[SerializeField]
	private Vector3 tam;

	[SerializeField]
	private Text texto;

	public AudioClip[] sons;
	private AudioSource fonteAudio;

	[SerializeField]
	private Color standard;

	void Start(){
		level = 1;
		InicializaLevel(level);
		fonteAudio = GetComponent<AudioSource> ();
	}

	private void InicializaLevel(int lvl){
		if (lvl == 1){
			numColunas = 4;
			numLinhas = 4;
			marg = 1.5f;
		}
		else if (lvl == 2){
			numColunas = 4;
			numLinhas = 4;
			marg = 1.5f;
		}
		else if (lvl == 3){
			numColunas = 4;
			numLinhas = 4;
			marg = 1.5f;
		}
		else if (lvl == 4){
			numColunas = 4;
			numLinhas = 4;
			marg = 1.5f;
		}
		else if (lvl == 5){
			numColunas = 4;
			numLinhas = 5;
			marg = 1.5f;
		} 
		else if (lvl == 6){
			numColunas = 4;
			numLinhas = 6;
			marg = 1.5f;
		} 
		else if (lvl == 7){
			numColunas = 4;
			numLinhas = 7;
			marg = 1.5f;
		}
		else if (lvl == 8){
			numColunas = 4;
			numLinhas = 8;
			marg = 1.5f;
		}

		int index = 0;
		for (int i = 0; i < numColunas; i++)
		{
			for (int j = 0; j < numLinhas; j++)
			{
				setas.Add(GameObject.Instantiate(seta, new Vector3(pos.position.x - (j*marg), pos.position.y - (i*marg), pos.position.z) ,pos.rotation));
				setas[index].GetComponent<SetaBehavior>().x = i;
				setas[index].GetComponent<SetaBehavior>().y = j;
				setas[index].GetComponent<SetaBehavior>().dir = 0;
				setas[index].GetComponent<SetaBehavior>().cor = Color.white;
				setas[index].GetComponent<SetaBehavior>().tipoSeta = "normal";
				index++;
			}
		}
		OrganizaSetas(index,lvl);
		Debug.Log(index);
	}

	private void OrganizaSetas(int index, int lvl){
		if (lvl == 1){
			setas[0].transform.rotation = new Quaternion(setas[0].transform.rotation.x,setas[0].transform.rotation.y,180,setas[0].transform.rotation.w);
			setas[1].transform.rotation = new Quaternion(setas[1].transform.rotation.x,setas[1].transform.rotation.y,180,setas[1].transform.rotation.w);
			setas[2].transform.rotation = new Quaternion(setas[2].transform.rotation.x,setas[2].transform.rotation.y,180,setas[2].transform.rotation.w);
			setas[3].transform.rotation = new Quaternion(setas[3].transform.rotation.x,setas[3].transform.rotation.y,1,setas[3].transform.rotation.w);
			setas[4].transform.rotation = new Quaternion(setas[4].transform.rotation.x,setas[4].transform.rotation.y,1,setas[4].transform.rotation.w);
			setas[5].transform.rotation = new Quaternion(setas[5].transform.rotation.x,setas[5].transform.rotation.y,180,setas[5].transform.rotation.w);
			setas[6].transform.rotation = new Quaternion(setas[6].transform.rotation.x,setas[6].transform.rotation.y,-1,setas[6].transform.rotation.w);
			setas[7].transform.rotation = new Quaternion(setas[7].transform.rotation.x,setas[7].transform.rotation.y,0,setas[7].transform.rotation.w);
			setas[7].GetComponent<SpriteRenderer>().sprite = img;
			setas[7].GetComponentsInChildren<SpriteRenderer>()[1].sprite = null;
			setas[8].transform.rotation = new Quaternion(setas[8].transform.rotation.x,setas[8].transform.rotation.y,180,setas[8].transform.rotation.w);
			setas[9].transform.rotation = new Quaternion(setas[9].transform.rotation.x,setas[9].transform.rotation.y,1,setas[9].transform.rotation.w);
			setas[10].transform.rotation = new Quaternion(setas[10].transform.rotation.x,setas[10].transform.rotation.y,180,setas[10].transform.rotation.w);
			setas[11].transform.rotation = new Quaternion(setas[11].transform.rotation.x,setas[11].transform.rotation.y,1,setas[11].transform.rotation.w);
			setas[12].transform.rotation = new Quaternion(setas[12].transform.rotation.x,setas[12].transform.rotation.y,180,setas[12].transform.rotation.w);
			setas[13].transform.rotation = new Quaternion(setas[13].transform.rotation.x,setas[13].transform.rotation.y,180,setas[13].transform.rotation.w);
			setas[14].transform.rotation = new Quaternion(setas[14].transform.rotation.x,setas[14].transform.rotation.y,-1,setas[14].transform.rotation.w);
			setas[15].transform.rotation = new Quaternion(setas[15].transform.rotation.x,setas[15].transform.rotation.y,1,setas[15].transform.rotation.w);
			resp = 2;
		}
		else if (lvl == 2){
			setas[0].transform.rotation = new Quaternion(setas[0].transform.rotation.x,setas[0].transform.rotation.y,180,setas[0].transform.rotation.w);
			setas[1].transform.rotation = new Quaternion(setas[1].transform.rotation.x,setas[1].transform.rotation.y,180,setas[1].transform.rotation.w);
			setas[2].transform.rotation = new Quaternion(setas[2].transform.rotation.x,setas[2].transform.rotation.y,-1,setas[2].transform.rotation.w);
			setas[3].transform.rotation = new Quaternion(setas[3].transform.rotation.x,setas[3].transform.rotation.y,180,setas[3].transform.rotation.w);
			setas[4].transform.rotation = new Quaternion(setas[4].transform.rotation.x,setas[4].transform.rotation.y,180,setas[4].transform.rotation.w);
			setas[5].transform.rotation = new Quaternion(setas[5].transform.rotation.x,setas[5].transform.rotation.y,-1,setas[5].transform.rotation.w);
			setas[6].transform.rotation = new Quaternion(setas[6].transform.rotation.x,setas[6].transform.rotation.y,-1,setas[6].transform.rotation.w);
			setas[7].transform.rotation = new Quaternion(setas[7].transform.rotation.x,setas[7].transform.rotation.y,-1,setas[7].transform.rotation.w);
			setas[8].transform.rotation = new Quaternion(setas[8].transform.rotation.x,setas[8].transform.rotation.y,-1,setas[8].transform.rotation.w);
			setas[9].transform.rotation = new Quaternion(setas[9].transform.rotation.x,setas[9].transform.rotation.y,0,setas[9].transform.rotation.w);
			setas[10].transform.rotation = new Quaternion(setas[10].transform.rotation.x,setas[10].transform.rotation.y,0,setas[10].transform.rotation.w);
			setas[10].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[11].transform.rotation = new Quaternion(setas[11].transform.rotation.x,setas[11].transform.rotation.y,-1,setas[11].transform.rotation.w);
			setas[12].transform.rotation = new Quaternion(setas[12].transform.rotation.x,setas[12].transform.rotation.y,180,setas[12].transform.rotation.w);
			setas[13].transform.rotation = new Quaternion(setas[13].transform.rotation.x,setas[13].transform.rotation.y,180,setas[13].transform.rotation.w);
			setas[13].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[14].transform.rotation = new Quaternion(setas[14].transform.rotation.x,setas[14].transform.rotation.y,180,setas[14].transform.rotation.w);
			setas[15].transform.rotation = new Quaternion(setas[15].transform.rotation.x,setas[15].transform.rotation.y,0,setas[15].transform.rotation.w);
			setas[15].GetComponent<SpriteRenderer>().sprite = img;
			setas[15].GetComponentsInChildren<SpriteRenderer>()[1].sprite = null;
			resp = 0;
		}
		else if (lvl == 3){
			setas[0].transform.rotation = new Quaternion(setas[0].transform.rotation.x,setas[0].transform.rotation.y,180,setas[0].transform.rotation.w);
			setas[1].transform.rotation = new Quaternion(setas[1].transform.rotation.x,setas[1].transform.rotation.y,180,setas[1].transform.rotation.w);
			setas[2].transform.rotation = new Quaternion(setas[2].transform.rotation.x,setas[2].transform.rotation.y,180,setas[2].transform.rotation.w);
			setas[3].transform.rotation = new Quaternion(setas[3].transform.rotation.x,setas[3].transform.rotation.y,-1,setas[3].transform.rotation.w);
			setas[3].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[4].transform.rotation = new Quaternion(setas[4].transform.rotation.x,setas[4].transform.rotation.y,0,setas[4].transform.rotation.w);
			setas[5].transform.rotation = new Quaternion(setas[5].transform.rotation.x,setas[5].transform.rotation.y,180,setas[5].transform.rotation.w);
			setas[6].transform.rotation = new Quaternion(setas[6].transform.rotation.x,setas[6].transform.rotation.y,1,setas[6].transform.rotation.w);
			setas[6].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[7].transform.rotation = new Quaternion(setas[7].transform.rotation.x,setas[7].transform.rotation.y,-1,setas[7].transform.rotation.w);
			setas[8].transform.rotation = new Quaternion(setas[8].transform.rotation.x,setas[8].transform.rotation.y,180,setas[8].transform.rotation.w);
			setas[9].transform.rotation = new Quaternion(setas[9].transform.rotation.x,setas[9].transform.rotation.y,-1,setas[9].transform.rotation.w);
			setas[9].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[10].transform.rotation = new Quaternion(setas[10].transform.rotation.x,setas[10].transform.rotation.y,180,setas[10].transform.rotation.w);
			setas[11].transform.rotation = new Quaternion(setas[11].transform.rotation.x,setas[11].transform.rotation.y,0,setas[11].transform.rotation.w);
			setas[11].GetComponent<SpriteRenderer>().sprite = img;
			setas[11].GetComponentsInChildren<SpriteRenderer>()[1].sprite = null;
			setas[12].transform.rotation = new Quaternion(setas[12].transform.rotation.x,setas[12].transform.rotation.y,180,setas[12].transform.rotation.w);
			setas[13].transform.rotation = new Quaternion(setas[13].transform.rotation.x,setas[13].transform.rotation.y,180,setas[13].transform.rotation.w);
			setas[14].transform.rotation = new Quaternion(setas[14].transform.rotation.x,setas[14].transform.rotation.y,-1,setas[14].transform.rotation.w);
			setas[15].transform.rotation = new Quaternion(setas[15].transform.rotation.x,setas[15].transform.rotation.y,0,setas[15].transform.rotation.w);
			resp = 2;
		}
		else if (lvl == 4){
			setas[0].transform.rotation = new Quaternion(setas[0].transform.rotation.x,setas[0].transform.rotation.y,180,setas[0].transform.rotation.w);
			setas[1].transform.rotation = new Quaternion(setas[1].transform.rotation.x,setas[1].transform.rotation.y,180,setas[1].transform.rotation.w);
			setas[1].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[2].transform.rotation = new Quaternion(setas[2].transform.rotation.x,setas[2].transform.rotation.y,180,setas[2].transform.rotation.w);
			setas[2].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[3].transform.rotation = new Quaternion(setas[3].transform.rotation.x,setas[3].transform.rotation.y,0,setas[3].transform.rotation.w);
			setas[3].GetComponent<SpriteRenderer>().sprite = img;
			setas[3].GetComponentsInChildren<SpriteRenderer>()[1].sprite = null;
			setas[4].transform.rotation = new Quaternion(setas[4].transform.rotation.x,setas[4].transform.rotation.y,1,setas[4].transform.rotation.w);
			setas[5].transform.rotation = new Quaternion(setas[5].transform.rotation.x,setas[5].transform.rotation.y,180,setas[5].transform.rotation.w);
			setas[6].transform.rotation = new Quaternion(setas[6].transform.rotation.x,setas[6].transform.rotation.y,0,setas[6].transform.rotation.w);
			setas[6].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[7].transform.rotation = new Quaternion(setas[7].transform.rotation.x,setas[7].transform.rotation.y,-1,setas[7].transform.rotation.w);
			setas[7].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[8].transform.rotation = new Quaternion(setas[8].transform.rotation.x,setas[8].transform.rotation.y,180,setas[8].transform.rotation.w);
			setas[9].transform.rotation = new Quaternion(setas[9].transform.rotation.x,setas[9].transform.rotation.y,-1,setas[9].transform.rotation.w);
			setas[9].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[10].transform.rotation = new Quaternion(setas[10].transform.rotation.x,setas[10].transform.rotation.y,0,setas[10].transform.rotation.w);
			setas[11].transform.rotation = new Quaternion(setas[11].transform.rotation.x,setas[11].transform.rotation.y,1,setas[11].transform.rotation.w);
			setas[12].transform.rotation = new Quaternion(setas[12].transform.rotation.x,setas[12].transform.rotation.y,180,setas[12].transform.rotation.w);
			setas[13].transform.rotation = new Quaternion(setas[13].transform.rotation.x,setas[13].transform.rotation.y,-1,setas[13].transform.rotation.w);
			setas[13].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[14].transform.rotation = new Quaternion(setas[14].transform.rotation.x,setas[14].transform.rotation.y,180,setas[14].transform.rotation.w);
			setas[15].transform.rotation = new Quaternion(setas[15].transform.rotation.x,setas[15].transform.rotation.y,1,setas[15].transform.rotation.w);
			resp = 2;
		}
		else if (lvl == 5){
			setas[0].transform.rotation = new Quaternion(setas[0].transform.rotation.x,setas[0].transform.rotation.y,180,setas[0].transform.rotation.w);
			setas[0].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[1].transform.rotation = new Quaternion(setas[1].transform.rotation.x,setas[1].transform.rotation.y,1,setas[1].transform.rotation.w);
			setas[1].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[2].transform.rotation = new Quaternion(setas[2].transform.rotation.x,setas[2].transform.rotation.y,180,setas[2].transform.rotation.w);
			setas[2].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[3].transform.rotation = new Quaternion(setas[3].transform.rotation.x,setas[3].transform.rotation.y,180,setas[3].transform.rotation.w);
			setas[4].transform.rotation = new Quaternion(setas[4].transform.rotation.x,setas[4].transform.rotation.y,1,setas[4].transform.rotation.w);
			setas[4].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[5].transform.rotation = new Quaternion(setas[5].transform.rotation.x,setas[5].transform.rotation.y,180,setas[5].transform.rotation.w);
			setas[6].transform.rotation = new Quaternion(setas[6].transform.rotation.x,setas[6].transform.rotation.y,-1,setas[6].transform.rotation.w);
			setas[6].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[7].transform.rotation = new Quaternion(setas[7].transform.rotation.x,setas[7].transform.rotation.y,1,setas[7].transform.rotation.w);
			setas[8].transform.rotation = new Quaternion(setas[8].transform.rotation.x,setas[8].transform.rotation.y,1,setas[8].transform.rotation.w);
			setas[9].transform.rotation = new Quaternion(setas[9].transform.rotation.x,setas[9].transform.rotation.y,0,setas[9].transform.rotation.w);
			setas[9].GetComponent<SpriteRenderer>().sprite = img;
			setas[9].GetComponentsInChildren<SpriteRenderer>()[1].sprite = null;
			setas[10].transform.rotation = new Quaternion(setas[10].transform.rotation.x,setas[10].transform.rotation.y,0,setas[10].transform.rotation.w);
			setas[10].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[11].transform.rotation = new Quaternion(setas[11].transform.rotation.x,setas[11].transform.rotation.y,0,setas[11].transform.rotation.w);
			setas[11].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[12].transform.rotation = new Quaternion(setas[12].transform.rotation.x,setas[12].transform.rotation.y,-1,setas[12].transform.rotation.w);
			setas[13].transform.rotation = new Quaternion(setas[13].transform.rotation.x,setas[13].transform.rotation.y,-1,setas[13].transform.rotation.w);
			setas[13].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[14].transform.rotation = new Quaternion(setas[14].transform.rotation.x,setas[14].transform.rotation.y,180,setas[14].transform.rotation.w);
			setas[14].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[15].transform.rotation = new Quaternion(setas[15].transform.rotation.x,setas[15].transform.rotation.y,180,setas[15].transform.rotation.w);
			setas[16].transform.rotation = new Quaternion(setas[16].transform.rotation.x,setas[16].transform.rotation.y,1,setas[16].transform.rotation.w);
			setas[17].transform.rotation = new Quaternion(setas[17].transform.rotation.x,setas[17].transform.rotation.y,180,setas[17].transform.rotation.w);
			setas[17].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[18].transform.rotation = new Quaternion(setas[18].transform.rotation.x,setas[18].transform.rotation.y,180,setas[18].transform.rotation.w);
			setas[19].transform.rotation = new Quaternion(setas[19].transform.rotation.x,setas[19].transform.rotation.y,1,setas[19].transform.rotation.w);
			setas[19].GetComponent<SpriteRenderer>().color = Color.yellow;
			resp = 3;
		} 
		else if (lvl == 6){
			setas[0].transform.rotation = new Quaternion(setas[0].transform.rotation.x,setas[0].transform.rotation.y,180,setas[0].transform.rotation.w);
			setas[1].transform.rotation = new Quaternion(setas[1].transform.rotation.x,setas[1].transform.rotation.y,0,setas[1].transform.rotation.w);
			setas[13].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[2].transform.rotation = new Quaternion(setas[2].transform.rotation.x,setas[2].transform.rotation.y,180,setas[2].transform.rotation.w);
			setas[3].transform.rotation = new Quaternion(setas[3].transform.rotation.x,setas[3].transform.rotation.y,180,setas[3].transform.rotation.w);
			setas[3].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[4].transform.rotation = new Quaternion(setas[4].transform.rotation.x,setas[4].transform.rotation.y,180,setas[4].transform.rotation.w);
			setas[5].transform.rotation = new Quaternion(setas[5].transform.rotation.x,setas[5].transform.rotation.y,-1,setas[5].transform.rotation.w);
			setas[5].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[6].transform.rotation = new Quaternion(setas[6].transform.rotation.x,setas[6].transform.rotation.y,180,setas[6].transform.rotation.w);
			setas[7].transform.rotation = new Quaternion(setas[7].transform.rotation.x,setas[7].transform.rotation.y,1,setas[7].transform.rotation.w);
			setas[7].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[8].transform.rotation = new Quaternion(setas[8].transform.rotation.x,setas[8].transform.rotation.y,180,setas[8].transform.rotation.w);
			setas[9].transform.rotation = new Quaternion(setas[9].transform.rotation.x,setas[9].transform.rotation.y,180,setas[9].transform.rotation.w);
			setas[9].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[10].transform.rotation = new Quaternion(setas[10].transform.rotation.x,setas[10].transform.rotation.y,1,setas[10].transform.rotation.w);
			setas[10].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[11].transform.rotation = new Quaternion(setas[11].transform.rotation.x,setas[11].transform.rotation.y,-1,setas[11].transform.rotation.w);
			setas[12].transform.rotation = new Quaternion(setas[12].transform.rotation.x,setas[12].transform.rotation.y,180,setas[12].transform.rotation.w);
			setas[12].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[13].transform.rotation = new Quaternion(setas[13].transform.rotation.x,setas[13].transform.rotation.y,0,setas[13].transform.rotation.w);
			setas[13].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[14].transform.rotation = new Quaternion(setas[14].transform.rotation.x,setas[14].transform.rotation.y,1,setas[14].transform.rotation.w);
			setas[15].transform.rotation = new Quaternion(setas[15].transform.rotation.x,setas[15].transform.rotation.y,-1,setas[15].transform.rotation.w);
			setas[16].transform.rotation = new Quaternion(setas[16].transform.rotation.x,setas[16].transform.rotation.y,180,setas[16].transform.rotation.w);
			setas[17].transform.rotation = new Quaternion(setas[17].transform.rotation.x,setas[17].transform.rotation.y,0,setas[17].transform.rotation.w);
			setas[17].GetComponent<SpriteRenderer>().sprite = img;
			setas[17].GetComponentsInChildren<SpriteRenderer>()[1].sprite = null;
			setas[18].transform.rotation = new Quaternion(setas[18].transform.rotation.x,setas[18].transform.rotation.y,180,setas[18].transform.rotation.w);
			setas[19].transform.rotation = new Quaternion(setas[19].transform.rotation.x,setas[19].transform.rotation.y,180,setas[19].transform.rotation.w);
			setas[19].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[20].transform.rotation = new Quaternion(setas[20].transform.rotation.x,setas[20].transform.rotation.y,180,setas[20].transform.rotation.w);
			setas[21].transform.rotation = new Quaternion(setas[21].transform.rotation.x,setas[21].transform.rotation.y,0,setas[21].transform.rotation.w);
			setas[21].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[22].transform.rotation = new Quaternion(setas[22].transform.rotation.x,setas[22].transform.rotation.y,180,setas[22].transform.rotation.w);
			setas[23].transform.rotation = new Quaternion(setas[23].transform.rotation.x,setas[23].transform.rotation.y,1,setas[23].transform.rotation.w);
			setas[23].GetComponent<SpriteRenderer>().color = Color.blue;
			resp = 1;
		} 
		else if (lvl == 7){
			setas[0].transform.rotation = new Quaternion(setas[0].transform.rotation.x,setas[0].transform.rotation.y,180,setas[0].transform.rotation.w);
			setas[1].transform.rotation = new Quaternion(setas[1].transform.rotation.x,setas[1].transform.rotation.y,0,setas[1].transform.rotation.w);
			setas[1].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[2].transform.rotation = new Quaternion(setas[2].transform.rotation.x,setas[2].transform.rotation.y,180,setas[2].transform.rotation.w);
			setas[2].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[3].transform.rotation = new Quaternion(setas[3].transform.rotation.x,setas[3].transform.rotation.y,180,setas[3].transform.rotation.w);
			setas[4].transform.rotation = new Quaternion(setas[4].transform.rotation.x,setas[4].transform.rotation.y,1,setas[4].transform.rotation.w);
			setas[5].transform.rotation = new Quaternion(setas[5].transform.rotation.x,setas[5].transform.rotation.y,1,setas[5].transform.rotation.w);
			setas[5].GetComponent<SpriteRenderer>().color = Color.red;
			setas[6].transform.rotation = new Quaternion(setas[6].transform.rotation.x,setas[6].transform.rotation.y,0,setas[6].transform.rotation.w);
			setas[7].transform.rotation = new Quaternion(setas[7].transform.rotation.x,setas[7].transform.rotation.y,1,setas[7].transform.rotation.w);
			setas[8].transform.rotation = new Quaternion(setas[8].transform.rotation.x,setas[8].transform.rotation.y,180,setas[8].transform.rotation.w);
			setas[9].transform.rotation = new Quaternion(setas[9].transform.rotation.x,setas[9].transform.rotation.y,0,setas[9].transform.rotation.w);
			setas[9].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[10].transform.rotation = new Quaternion(setas[10].transform.rotation.x,setas[10].transform.rotation.y,-1,setas[10].transform.rotation.w);
			setas[11].transform.rotation = new Quaternion(setas[11].transform.rotation.x,setas[11].transform.rotation.y,180,setas[11].transform.rotation.w);
			setas[12].transform.rotation = new Quaternion(setas[12].transform.rotation.x,setas[12].transform.rotation.y,1,setas[12].transform.rotation.w);
			setas[13].transform.rotation = new Quaternion(setas[13].transform.rotation.x,setas[13].transform.rotation.y,1,setas[13].transform.rotation.w);
			setas[13].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[14].transform.rotation = new Quaternion(setas[14].transform.rotation.x,setas[14].transform.rotation.y,180,setas[14].transform.rotation.w);
			setas[15].transform.rotation = new Quaternion(setas[15].transform.rotation.x,setas[15].transform.rotation.y,1,setas[15].transform.rotation.w);
			setas[16].transform.rotation = new Quaternion(setas[16].transform.rotation.x,setas[16].transform.rotation.y,180,setas[16].transform.rotation.w);
			setas[17].transform.rotation = new Quaternion(setas[17].transform.rotation.x,setas[17].transform.rotation.y,1,setas[17].transform.rotation.w);
			setas[17].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[18].transform.rotation = new Quaternion(setas[18].transform.rotation.x,setas[18].transform.rotation.y,0,setas[18].transform.rotation.w);
			setas[18].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[19].transform.rotation = new Quaternion(setas[19].transform.rotation.x,setas[19].transform.rotation.y,1,setas[19].transform.rotation.w);
			setas[20].transform.rotation = new Quaternion(setas[20].transform.rotation.x,setas[20].transform.rotation.y,1,setas[20].transform.rotation.w);
			setas[21].transform.rotation = new Quaternion(setas[21].transform.rotation.x,setas[21].transform.rotation.y,1,setas[21].transform.rotation.w);
			setas[21].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[22].transform.rotation = new Quaternion(setas[22].transform.rotation.x,setas[22].transform.rotation.y,1,setas[22].transform.rotation.w);
			setas[23].transform.rotation = new Quaternion(setas[23].transform.rotation.x,setas[23].transform.rotation.y,0,setas[23].transform.rotation.w);
			setas[24].transform.rotation = new Quaternion(setas[24].transform.rotation.x,setas[24].transform.rotation.y,180,setas[24].transform.rotation.w);
			setas[24].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[25].transform.rotation = new Quaternion(setas[25].transform.rotation.x,setas[25].transform.rotation.y,1,setas[25].transform.rotation.w);
			setas[26].transform.rotation = new Quaternion(setas[26].transform.rotation.x,setas[26].transform.rotation.y,0,setas[26].transform.rotation.w);
			setas[26].GetComponent<SpriteRenderer>().sprite = img;
			setas[26].GetComponentsInChildren<SpriteRenderer>()[1].sprite = null;
			setas[27].transform.rotation = new Quaternion(setas[27].transform.rotation.x,setas[27].transform.rotation.y,180,setas[27].transform.rotation.w);
			setas[27].GetComponent<SpriteRenderer>().color = Color.yellow;
			resp = 2;
		}
		else if (lvl == 8){
			setas[0].transform.rotation = new Quaternion(setas[0].transform.rotation.x,setas[0].transform.rotation.y,180,setas[0].transform.rotation.w);
			setas[1].transform.rotation = new Quaternion(setas[1].transform.rotation.x,setas[1].transform.rotation.y,0,setas[1].transform.rotation.w);
			setas[1].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[2].transform.rotation = new Quaternion(setas[2].transform.rotation.x,setas[2].transform.rotation.y,180,setas[2].transform.rotation.w);
			setas[3].transform.rotation = new Quaternion(setas[3].transform.rotation.x,setas[3].transform.rotation.y,-1,setas[3].transform.rotation.w);
			setas[4].transform.rotation = new Quaternion(setas[4].transform.rotation.x,setas[4].transform.rotation.y,0,setas[4].transform.rotation.w);
			setas[4].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[5].transform.rotation = new Quaternion(setas[5].transform.rotation.x,setas[5].transform.rotation.y,180,setas[5].transform.rotation.w);
			setas[6].transform.rotation = new Quaternion(setas[6].transform.rotation.x,setas[6].transform.rotation.y,180,setas[6].transform.rotation.w);
			setas[7].transform.rotation = new Quaternion(setas[7].transform.rotation.x,setas[7].transform.rotation.y,1,setas[7].transform.rotation.w);
			setas[7].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[8].transform.rotation = new Quaternion(setas[8].transform.rotation.x,setas[8].transform.rotation.y,-1,setas[8].transform.rotation.w);
			setas[9].transform.rotation = new Quaternion(setas[9].transform.rotation.x,setas[9].transform.rotation.y,1,setas[9].transform.rotation.w);
			setas[10].transform.rotation = new Quaternion(setas[10].transform.rotation.x,setas[10].transform.rotation.y,1,setas[10].transform.rotation.w);
			setas[10].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[11].transform.rotation = new Quaternion(setas[11].transform.rotation.x,setas[11].transform.rotation.y,1,setas[11].transform.rotation.w);
			setas[11].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[12].transform.rotation = new Quaternion(setas[12].transform.rotation.x,setas[12].transform.rotation.y,1,setas[12].transform.rotation.w);
			setas[13].transform.rotation = new Quaternion(setas[13].transform.rotation.x,setas[13].transform.rotation.y,0,setas[13].transform.rotation.w);
			setas[14].transform.rotation = new Quaternion(setas[14].transform.rotation.x,setas[14].transform.rotation.y,180,setas[14].transform.rotation.w);
			setas[15].transform.rotation = new Quaternion(setas[15].transform.rotation.x,setas[15].transform.rotation.y,-1,setas[15].transform.rotation.w);
			setas[16].transform.rotation = new Quaternion(setas[16].transform.rotation.x,setas[16].transform.rotation.y,180,setas[16].transform.rotation.w);
			setas[17].transform.rotation = new Quaternion(setas[17].transform.rotation.x,setas[17].transform.rotation.y,180,setas[17].transform.rotation.w);
			setas[17].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[18].transform.rotation = new Quaternion(setas[18].transform.rotation.x,setas[18].transform.rotation.y,180,setas[18].transform.rotation.w);
			setas[18].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[19].transform.rotation = new Quaternion(setas[19].transform.rotation.x,setas[19].transform.rotation.y,180,setas[19].transform.rotation.w);
			setas[20].transform.rotation = new Quaternion(setas[20].transform.rotation.x,setas[20].transform.rotation.y,-1,setas[20].transform.rotation.w);
			setas[20].GetComponent<SpriteRenderer>().color = Color.red;
			setas[21].transform.rotation = new Quaternion(setas[21].transform.rotation.x,setas[21].transform.rotation.y,0,setas[21].transform.rotation.w);
			setas[22].transform.rotation = new Quaternion(setas[22].transform.rotation.x,setas[22].transform.rotation.y,1,setas[22].transform.rotation.w);
			setas[23].transform.rotation = new Quaternion(setas[23].transform.rotation.x,setas[23].transform.rotation.y,0,setas[23].transform.rotation.w);
			setas[23].GetComponent<SpriteRenderer>().sprite = img;
			setas[23].GetComponentsInChildren<SpriteRenderer>()[1].sprite = null;
			setas[24].transform.rotation = new Quaternion(setas[24].transform.rotation.x,setas[24].transform.rotation.y,180,setas[24].transform.rotation.w);
			setas[25].transform.rotation = new Quaternion(setas[25].transform.rotation.x,setas[25].transform.rotation.y,180,setas[25].transform.rotation.w);
			setas[26].transform.rotation = new Quaternion(setas[26].transform.rotation.x,setas[26].transform.rotation.y,180,setas[26].transform.rotation.w);
			setas[27].transform.rotation = new Quaternion(setas[27].transform.rotation.x,setas[27].transform.rotation.y,-1,setas[27].transform.rotation.w);
			setas[28].transform.rotation = new Quaternion(setas[28].transform.rotation.x,setas[28].transform.rotation.y,0,setas[28].transform.rotation.w);
			setas[29].transform.rotation = new Quaternion(setas[29].transform.rotation.x,setas[29].transform.rotation.y,-1,setas[29].transform.rotation.w);
			setas[29].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[30].transform.rotation = new Quaternion(setas[30].transform.rotation.x,setas[30].transform.rotation.y,-1,setas[30].transform.rotation.w);
			setas[31].transform.rotation = new Quaternion(setas[31].transform.rotation.x,setas[31].transform.rotation.y,1,setas[31].transform.rotation.w);
			
			resp = 0;
		}
	}

	public void Responde(int resposta){
		if(resp == resposta){
			texto.text = "Parabéns! Você acertou!";
			fonteAudio.PlayOneShot(sons[0]);
		} 
		else{
			texto.text = "Que pena, você errou!";
			fonteAudio.PlayOneShot(sons[1]);
		}
		//som de click do botão
		StartCoroutine("FeedBack");
	}

	public IEnumerator FeedBack(){
		yield return new WaitForSeconds(0.5f);
		for (float f = 0f; f <= standard.a; f += 0.01f)
			{
				Color c = texto.color;
				c.a = f;
				texto.color = c;
				new WaitForSeconds(.2f);
				yield return null;
			}
			yield return new WaitForSeconds(.5f);
			for (float f = 1f; f >= 0; f -= 0.01f)
			{
				Color c = texto.color;
				c.a = f;
				texto.color = c;
				new WaitForSeconds(.2f);
				yield return null;
			}
			if(/*level == 1 || level == 3 || level == 5 || level == 7*/level < 6){
				level++;
				Clear();
				InicializaLevel(level);
			} 
			else{
				new WaitForSeconds(.2f);
				GameOver();
			} 
	}

	public void Clear(){
		for (int i = 0; i < setas.Count; i++)
		{
			Destroy(setas[i]);
		}
		setas.Clear();
		resp = -1;
	}

	public void GameOver(){
		SceneManager.LoadScene("Score");
	}
}
