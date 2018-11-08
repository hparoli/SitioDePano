using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CaminhosSpawner : MonoBehaviour {

	[SerializeField]
	private int numColunas,numLinhas,level,resp,waypoint,btn;

	[SerializeField]
	private GameObject seta,abelha,ab;

	[SerializeField]
	public List<GameObject> setas,botoes,caminhoA,caminhoB,caminhoC,caminhoD;

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

	public bool respondeu,fimCaminho;

	public float moveSpeed;

	void Start(){
		level = 1;
		respondeu = false;
		waypoint = 0;
		InicializaLevel(level);
		fonteAudio = GetComponent<AudioSource> ();
	}

	void Update(){
		if(respondeu && btn == 0) ab.GetComponent<CaminhosManager>().Move(caminhoA);
		if(respondeu && btn == 1) ab.GetComponent<CaminhosManager>().Move(caminhoB);
		if(respondeu && btn == 2) ab.GetComponent<CaminhosManager>().Move(caminhoC);
		if(respondeu && btn == 3) ab.GetComponent<CaminhosManager>().Move(caminhoD);
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
				
				setas[index].GetComponent<SetaBehavior>().tipoSeta = "normal";
				index++;
			}
		}
		OrganizaSetas(index,lvl);
		Debug.Log(index);
	}

	private void OrganizaSetas(int index, int lvl){
		if (lvl == 1){
			setas[0].transform.eulerAngles = new Vector3(0,0,180);
			setas[1].transform.eulerAngles = new Vector3(0,0,180);
			setas[2].transform.eulerAngles = new Vector3(0,0,180);
			setas[3].transform.eulerAngles = new Vector3(0,0,90);
			setas[4].transform.eulerAngles = new Vector3(0,0,90);
			setas[5].transform.eulerAngles = new Vector3(0,0,180);
			setas[6].transform.eulerAngles = new Vector3(0,0,270);
			setas[7].transform.eulerAngles = new Vector3(0,0,0);
			setas[7].GetComponent<SpriteRenderer>().sprite = img;
			setas[7].GetComponentsInChildren<SpriteRenderer>()[1].sprite = null;
			setas[8].transform.eulerAngles = new Vector3(0,0,180);
			setas[9].transform.eulerAngles = new Vector3(0,0,90);
			setas[10].transform.eulerAngles = new Vector3(0,0,180);
			setas[11].transform.eulerAngles = new Vector3(0,0,90);
			setas[12].transform.eulerAngles = new Vector3(0,0,180);
			setas[13].transform.eulerAngles = new Vector3(0,0,180);
			setas[14].transform.eulerAngles = new Vector3(0,0,270);
			setas[15].transform.eulerAngles = new Vector3(0,0,90);
			resp = 2;
			caminhoA.Add(setas[0]);
			caminhoA.Add(setas[1]);
			caminhoA.Add(setas[2]);
			caminhoA.Add(setas[3]);
			
			caminhoB.Add(setas[4]);
			caminhoB.Add(setas[0]);
			caminhoB.Add(setas[1]);
			caminhoB.Add(setas[2]);
			caminhoB.Add(setas[3]);
			
			caminhoC.Add(setas[8]);
			caminhoC.Add(setas[9]);
			caminhoC.Add(setas[5]);
			caminhoC.Add(setas[6]);
			caminhoC.Add(setas[10]);
			caminhoC.Add(setas[11]);
			caminhoC.Add(setas[7]);
			
			caminhoD.Add(setas[12]);
			caminhoD.Add(setas[13]);
			caminhoD.Add(setas[14]);
			
		}
		else if (lvl == 2){
			setas[0].transform.eulerAngles = new Vector3(0,0,180);
			setas[1].transform.eulerAngles = new Vector3(0,0,180);
			setas[2].transform.eulerAngles = new Vector3(0,0,270);
			setas[3].transform.eulerAngles = new Vector3(0,0,180);
			setas[4].transform.eulerAngles = new Vector3(0,0,180);
			setas[5].transform.eulerAngles = new Vector3(0,0,270);
			setas[6].transform.eulerAngles = new Vector3(0,0,270);
			setas[7].transform.eulerAngles = new Vector3(0,0,270);
			setas[8].transform.eulerAngles = new Vector3(0,0,270);
			setas[9].transform.eulerAngles = new Vector3(0,0,0);
			setas[10].transform.eulerAngles = new Vector3(0,0,0);
			setas[10].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[11].transform.eulerAngles = new Vector3(0,0,270);
			setas[12].transform.eulerAngles = new Vector3(0,0,180);
			setas[13].transform.eulerAngles = new Vector3(0,0,180);
			setas[13].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[14].transform.eulerAngles = new Vector3(0,0,180);
			setas[15].transform.eulerAngles = new Vector3(0,0,0);
			setas[15].GetComponent<SpriteRenderer>().sprite = img;
			setas[15].GetComponentsInChildren<SpriteRenderer>()[1].sprite = null;
			resp = 0;

			caminhoA.Add(setas[0]);
			caminhoA.Add(setas[1]);
			caminhoA.Add(setas[2]);
			caminhoA.Add(setas[6]);
			caminhoA.Add(setas[10]);
			caminhoA.Add(setas[11]);
			caminhoA.Add(setas[15]);
			
			caminhoB.Add(setas[4]);
			caminhoB.Add(setas[5]);
			caminhoB.Add(setas[8]);
			caminhoB.Add(setas[9]);
			caminhoB.Add(setas[12]);
			caminhoB.Add(setas[13]);
			caminhoB.Add(setas[12]);
			
			caminhoC.Add(setas[9]);
			caminhoC.Add(setas[12]);
			caminhoC.Add(setas[13]);
			caminhoC.Add(setas[12]);
			
			caminhoD.Add(setas[12]);
			caminhoD.Add(setas[13]);
			caminhoD.Add(setas[12]);
		}
		else if (lvl == 3){
			setas[0].transform.eulerAngles = new Vector3(0,0,180);
			setas[1].transform.eulerAngles = new Vector3(0,0,180);
			setas[2].transform.eulerAngles = new Vector3(0,0,180);
			setas[3].transform.eulerAngles = new Vector3(0,0,270);
			setas[3].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[4].transform.eulerAngles = new Vector3(0,0,0);
			setas[5].transform.eulerAngles = new Vector3(0,0,180);
			setas[6].transform.eulerAngles = new Vector3(0,0,90);
			setas[6].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[7].transform.eulerAngles = new Vector3(0,0,270);
			setas[8].transform.eulerAngles = new Vector3(0,0,180);
			setas[9].transform.eulerAngles = new Vector3(0,0,270);
			setas[9].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[10].transform.eulerAngles = new Vector3(0,0,180);
			setas[11].transform.eulerAngles = new Vector3(0,0,0);
			setas[11].GetComponent<SpriteRenderer>().sprite = img;
			setas[11].GetComponentsInChildren<SpriteRenderer>()[1].sprite = null;
			setas[12].transform.eulerAngles = new Vector3(0,0,180);
			setas[13].transform.eulerAngles = new Vector3(0,0,180);
			setas[14].transform.eulerAngles = new Vector3(0,0,270);
			setas[15].transform.eulerAngles = new Vector3(0,0,0);
			resp = 2;

			caminhoA.Add(setas[0]);
			caminhoA.Add(setas[1]);
			caminhoA.Add(setas[2]);
			caminhoA.Add(setas[3]);
			
			caminhoB.Add(setas[4]);
			
			caminhoC.Add(setas[8]);
			caminhoC.Add(setas[9]);
			caminhoC.Add(setas[5]);
			caminhoC.Add(setas[6]);
			caminhoC.Add(setas[10]);
			caminhoC.Add(setas[11]);
			
			caminhoD.Add(setas[12]);
			caminhoD.Add(setas[13]);
			caminhoD.Add(setas[14]);
		}
		else if (lvl == 4){
			setas[0].transform.eulerAngles = new Vector3(0,0,180);
			setas[1].transform.eulerAngles = new Vector3(0,0,180);
			setas[1].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[2].transform.eulerAngles = new Vector3(0,0,180);
			setas[2].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[3].transform.eulerAngles = new Vector3(0,0,0);
			setas[3].GetComponent<SpriteRenderer>().sprite = img;
			setas[3].GetComponentsInChildren<SpriteRenderer>()[1].sprite = null;
			setas[4].transform.eulerAngles = new Vector3(0,0,90);
			setas[5].transform.eulerAngles = new Vector3(0,0,180);
			setas[6].transform.eulerAngles = new Vector3(0,0,0);
			setas[6].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[7].transform.eulerAngles = new Vector3(0,0,270);
			setas[7].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[8].transform.eulerAngles = new Vector3(0,0,180);
			setas[9].transform.eulerAngles = new Vector3(0,0,270);
			setas[9].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[10].transform.eulerAngles = new Vector3(0,0,0);
			setas[11].transform.eulerAngles = new Vector3(0,0,90);
			setas[12].transform.eulerAngles = new Vector3(0,0,180);
			setas[13].transform.eulerAngles = new Vector3(0,0,270);
			setas[13].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[14].transform.eulerAngles = new Vector3(0,0,180);
			setas[15].transform.eulerAngles = new Vector3(0,0,90);
			resp = 2;

			caminhoA.Add(setas[0]);
			caminhoA.Add(setas[1]);
			caminhoA.Add(setas[2]);
			caminhoA.Add(setas[1]);
			
			caminhoB.Add(setas[4]);
			caminhoB.Add(setas[0]);
			caminhoB.Add(setas[1]);
			caminhoB.Add(setas[2]);
			caminhoB.Add(setas[1]);
			
			caminhoC.Add(setas[8]);
			caminhoC.Add(setas[9]);
			caminhoC.Add(setas[5]);
			caminhoC.Add(setas[6]);
			caminhoC.Add(setas[7]);
			caminhoC.Add(setas[3]);
			
			caminhoD.Add(setas[12]);
			caminhoD.Add(setas[13]);
			
		}
		else if (lvl == 5){
			setas[0].transform.eulerAngles = new Vector3(0,0,180);
			setas[0].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[1].transform.eulerAngles = new Vector3(0,0,90);
			setas[1].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[2].transform.eulerAngles = new Vector3(0,0,180);
			setas[2].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[3].transform.eulerAngles = new Vector3(0,0,180);
			setas[4].transform.eulerAngles = new Vector3(0,0,90);
			setas[4].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[5].transform.eulerAngles = new Vector3(0,0,180);
			setas[6].transform.eulerAngles = new Vector3(0,0,270);
			setas[6].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[7].transform.eulerAngles = new Vector3(0,0,90);
			setas[8].transform.eulerAngles = new Vector3(0,0,90);
			setas[9].transform.eulerAngles = new Vector3(0,0,0);
			setas[9].GetComponent<SpriteRenderer>().sprite = img;
			setas[9].GetComponentsInChildren<SpriteRenderer>()[1].sprite = null;
			setas[10].transform.eulerAngles = new Vector3(0,0,0);
			setas[10].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[11].transform.eulerAngles = new Vector3(0,0,0);
			setas[11].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[12].transform.eulerAngles = new Vector3(0,0,270);
			setas[13].transform.eulerAngles = new Vector3(0,0,270);
			setas[13].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[14].transform.eulerAngles = new Vector3(0,0,180);
			setas[14].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[15].transform.eulerAngles = new Vector3(0,0,180);
			setas[16].transform.eulerAngles = new Vector3(0,0,90);
			setas[17].transform.eulerAngles = new Vector3(0,0,180);
			setas[17].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[18].transform.eulerAngles = new Vector3(0,0,180);
			setas[19].transform.eulerAngles = new Vector3(0,0,90);
			setas[19].GetComponent<SpriteRenderer>().color = Color.yellow;
			resp = 3;

			caminhoA.Add(setas[0]);
			caminhoA.Add(setas[1]);
			
			caminhoB.Add(setas[5]);
			caminhoB.Add(setas[6]);
			caminhoB.Add(setas[1]);
			
			caminhoC.Add(setas[10]);
			
			caminhoD.Add(setas[15]);
			caminhoD.Add(setas[16]);
			caminhoD.Add(setas[11]);
			caminhoD.Add(setas[12]);
			caminhoD.Add(setas[17]);
			caminhoD.Add(setas[18]);
			caminhoD.Add(setas[19]);
			caminhoD.Add(setas[14]);
			caminhoD.Add(setas[13]);
			caminhoD.Add(setas[8]);
			caminhoD.Add(setas[3]);
			caminhoD.Add(setas[4]);
			caminhoD.Add(setas[9]);
		} 
		else if (lvl == 6){
			setas[0].transform.eulerAngles = new Vector3(0,0,180);
			setas[1].transform.eulerAngles = new Vector3(0,0,0);
			setas[1].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[2].transform.eulerAngles = new Vector3(0,0,180);
			setas[3].transform.eulerAngles = new Vector3(0,0,180);
			setas[3].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[4].transform.eulerAngles = new Vector3(0,0,180);
			setas[5].transform.eulerAngles = new Vector3(0,0,270);
			setas[5].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[6].transform.eulerAngles = new Vector3(0,0,180);
			setas[7].transform.eulerAngles = new Vector3(0,0,90);
			setas[7].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[8].transform.eulerAngles = new Vector3(0,0,180);
			setas[9].transform.eulerAngles = new Vector3(0,0,180);
			setas[9].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[10].transform.eulerAngles = new Vector3(0,0,90);
			setas[10].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[11].transform.eulerAngles = new Vector3(0,0,270);
			setas[12].transform.eulerAngles = new Vector3(0,0,180);
			setas[12].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[13].transform.eulerAngles = new Vector3(0,0,0);
			setas[13].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[14].transform.eulerAngles = new Vector3(0,0,90);
			setas[15].transform.eulerAngles = new Vector3(0,0,270);
			setas[16].transform.eulerAngles = new Vector3(0,0,180);
			setas[17].transform.eulerAngles = new Vector3(0,0,0);
			setas[17].GetComponent<SpriteRenderer>().sprite = img;
			setas[17].GetComponentsInChildren<SpriteRenderer>()[1].sprite = null;
			setas[18].transform.eulerAngles = new Vector3(0,0,180);
			setas[19].transform.eulerAngles = new Vector3(0,0,180);
			setas[19].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[20].transform.eulerAngles = new Vector3(0,0,180);
			setas[21].transform.eulerAngles = new Vector3(0,0,0);
			setas[21].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[22].transform.eulerAngles = new Vector3(0,0,180);
			setas[23].transform.eulerAngles = new Vector3(0,0,90);
			setas[23].GetComponent<SpriteRenderer>().color = Color.blue;
			resp = 1;

			caminhoA.Add(setas[0]);
			caminhoA.Add(setas[1]);
			caminhoA.Add(setas[2]);
			caminhoA.Add(setas[3]);
			caminhoA.Add(setas[4]);
			caminhoA.Add(setas[5]);
			
			caminhoB.Add(setas[6]);
			caminhoB.Add(setas[7]);
			caminhoB.Add(setas[13]);
			caminhoB.Add(setas[14]);
			caminhoB.Add(setas[8]);
			caminhoB.Add(setas[9]);
			caminhoB.Add(setas[16]);
			caminhoB.Add(setas[17]);

			caminhoC.Add(setas[12]);
			
			caminhoD.Add(setas[18]);
			caminhoD.Add(setas[19]);
			caminhoD.Add(setas[20]);
			caminhoD.Add(setas[21]);
			caminhoD.Add(setas[22]);
			caminhoD.Add(setas[23]);
		} 
		else if (lvl == 7){
			setas[0].transform.eulerAngles = new Vector3(0,0,180);
			setas[1].transform.eulerAngles = new Vector3(0,0,0);
			setas[1].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[2].transform.eulerAngles = new Vector3(0,0,180);
			setas[2].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[3].transform.eulerAngles = new Vector3(0,0,180);
			setas[4].transform.eulerAngles = new Vector3(0,0,90);
			setas[5].transform.eulerAngles = new Vector3(0,0,90);
			setas[5].GetComponent<SpriteRenderer>().color = Color.red;
			setas[6].transform.eulerAngles = new Vector3(0,0,0);
			setas[7].transform.eulerAngles = new Vector3(0,0,90);
			setas[8].transform.eulerAngles = new Vector3(0,0,180);
			setas[9].transform.eulerAngles = new Vector3(0,0,0);
			setas[9].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[10].transform.eulerAngles = new Vector3(0,0,270);
			setas[11].transform.eulerAngles = new Vector3(0,0,180);
			setas[12].transform.eulerAngles = new Vector3(0,0,90);
			setas[13].transform.eulerAngles = new Vector3(0,0,90);
			setas[13].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[14].transform.eulerAngles = new Vector3(0,0,180);
			setas[15].transform.eulerAngles = new Vector3(0,0,90);
			setas[16].transform.eulerAngles = new Vector3(0,0,180);
			setas[17].transform.eulerAngles = new Vector3(0,0,90);
			setas[17].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[18].transform.eulerAngles = new Vector3(0,0,0);
			setas[18].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[19].transform.eulerAngles = new Vector3(0,0,90);
			setas[20].transform.eulerAngles = new Vector3(0,0,90);
			setas[21].transform.eulerAngles = new Vector3(0,0,90);
			setas[21].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[22].transform.eulerAngles = new Vector3(0,0,90);
			setas[23].transform.eulerAngles = new Vector3(0,0,0);
			setas[24].transform.eulerAngles = new Vector3(0,0,180);
			setas[24].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[25].transform.eulerAngles = new Vector3(0,0,90);
			setas[26].transform.eulerAngles = new Vector3(0,0,0);
			setas[26].GetComponent<SpriteRenderer>().sprite = img;
			setas[26].GetComponentsInChildren<SpriteRenderer>()[1].sprite = null;
			setas[27].transform.eulerAngles = new Vector3(0,0,180);
			setas[27].GetComponent<SpriteRenderer>().color = Color.yellow;
			resp = 2;
		}
		else if (lvl == 8){
			setas[0].transform.eulerAngles = new Vector3(0,0,180);
			setas[1].transform.eulerAngles = new Vector3(0,0,0);
			setas[1].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[2].transform.eulerAngles = new Vector3(0,0,180);
			setas[3].transform.eulerAngles = new Vector3(0,0,270);
			setas[4].transform.eulerAngles = new Vector3(0,0,0);
			setas[4].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[5].transform.eulerAngles = new Vector3(0,0,180);
			setas[6].transform.eulerAngles = new Vector3(0,0,180);
			setas[7].transform.eulerAngles = new Vector3(0,0,90);
			setas[7].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[8].transform.eulerAngles = new Vector3(0,0,270);
			setas[9].transform.eulerAngles = new Vector3(0,0,90);
			setas[10].transform.eulerAngles = new Vector3(0,0,90);
			setas[10].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[11].transform.eulerAngles = new Vector3(0,0,90);
			setas[11].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[12].transform.eulerAngles = new Vector3(0,0,90);
			setas[13].transform.eulerAngles = new Vector3(0,0,0);
			setas[14].transform.eulerAngles = new Vector3(0,0,180);
			setas[15].transform.eulerAngles = new Vector3(0,0,270);
			setas[16].transform.eulerAngles = new Vector3(0,0,180);
			setas[17].transform.eulerAngles = new Vector3(0,0,180);
			setas[17].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[18].transform.eulerAngles = new Vector3(0,0,180);
			setas[18].GetComponent<SpriteRenderer>().color = Color.yellow;
			setas[19].transform.eulerAngles = new Vector3(0,0,180);
			setas[20].transform.eulerAngles = new Vector3(0,0,270);
			setas[20].GetComponent<SpriteRenderer>().color = Color.red;
			setas[21].transform.eulerAngles = new Vector3(0,0,0);
			setas[22].transform.eulerAngles = new Vector3(0,0,90);
			setas[23].transform.eulerAngles = new Vector3(0,0,0);
			setas[23].GetComponent<SpriteRenderer>().sprite = img;
			setas[23].GetComponentsInChildren<SpriteRenderer>()[1].sprite = null;
			setas[24].transform.eulerAngles = new Vector3(0,0,180);
			setas[25].transform.eulerAngles = new Vector3(0,0,180);
			setas[26].transform.eulerAngles = new Vector3(0,0,180);
			setas[27].transform.eulerAngles = new Vector3(0,0,270);
			setas[28].transform.eulerAngles = new Vector3(0,0,0);
			setas[29].transform.eulerAngles = new Vector3(0,0,270);
			setas[29].GetComponent<SpriteRenderer>().color = Color.blue;
			setas[30].transform.eulerAngles = new Vector3(0,0,270);
			setas[31].transform.eulerAngles = new Vector3(0,0,90);
			
			resp = 0;
		}
	}

	public void Responde(int resposta){
		btn = resposta;
		if(resp == resposta){
			texto.text = "Parabéns! Você acertou!";
			fonteAudio.PlayOneShot(sons[0]);
		} 
		else{
			texto.text = "Que pena, você errou!";
			fonteAudio.PlayOneShot(sons[1]);
		}
		//som de click do botão
		respondeu = true;
		ab = GameObject.Instantiate(abelha);
		if(btn == 0){
			ab.transform.position = caminhoA[0].transform.position;
		} else if (btn == 1){
			ab.transform.position = caminhoB[0].transform.position;
		} else if (btn == 2){
			ab.transform.position = caminhoC[0].transform.position;
		} else if (btn == 3){
			ab.transform.position = caminhoD[0].transform.position;
		}
	}


	void Move(){
		Debug.Log(btn);
		if(btn == 0){
			ab.transform.position = Vector2.MoveTowards(ab.transform.position,
			                                            caminhoA[waypoint].transform.position,
														moveSpeed * Time.deltaTime);

			if(ab.transform.position == caminhoA[waypoint].transform.position){
				waypoint++;
			}

			if(waypoint == caminhoA.Count){
				fimCaminho = true;
			}
		} else if (btn == 1){
			ab.transform.position = Vector2.MoveTowards(ab.transform.position,
			                                            caminhoB[waypoint].transform.position,
														moveSpeed * Time.deltaTime);

			if(ab.transform.position == caminhoB[waypoint].transform.position){
				waypoint++;
			}

			if(waypoint == caminhoB.Count){
				fimCaminho = true;
			}
		} else if (btn == 2){
			ab.transform.position = Vector2.MoveTowards(ab.transform.position,
			                                            caminhoC[waypoint].transform.position,
														moveSpeed * Time.deltaTime);

			if(ab.transform.position == caminhoC[waypoint].transform.position){
				waypoint++;
			}

			if(waypoint == caminhoC.Count){
				fimCaminho = true;
			}
		} else if (btn == 3){
			ab.transform.position = Vector2.MoveTowards(ab.transform.position,
			                                            caminhoD[waypoint].transform.position,
														moveSpeed * Time.deltaTime);

			if(ab.transform.position == caminhoD[waypoint].transform.position){
				waypoint++;
			}

			if(waypoint == caminhoD.Count){
				fimCaminho = true;
			}
		}

		if(fimCaminho){
			respondeu = false;
			StartCoroutine("FeedBack");
		}
		
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
		caminhoA.Clear();
		caminhoB.Clear();
		caminhoC.Clear();
		caminhoD.Clear();
		resp = -1;
		Destroy(ab);

	}

	public void GameOver(){
		SceneManager.LoadScene("Score");
	}
}
