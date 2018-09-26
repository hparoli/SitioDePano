using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class AcertaSequenciaController : MonoBehaviour {


	[SerializeField]
	private Formas[] formas;

	[SerializeField]
	private GameObject[] formasPergunta,formasResposta,formasEscolha;

	[SerializeField]
	private GameObject forma; 

	[SerializeField]
	private Transform pos, posR;

	[SerializeField]
	private int level,ind,qtdFormas,tipos,qtdExtra;

	[SerializeField]
	private Color standard;

	[SerializeField]
	private Text Txt;

	[SerializeField]
	private Button btn;

	void Start () {
		level = 1;
		ind = 1;
		StartGame();
	}
	
	void Update () {
		EscolherForma();
	}

	public void StartGame(){
		if (level == 1){
			qtdFormas = 3;
			tipos = 3;
		} else if(level == 2){
			qtdFormas = 4;
			tipos = 3;
		} else if(level == 3){
			qtdFormas = 4;
			tipos = 4;
		} else if (level == 4){
			qtdFormas = 5;
			tipos = 4;
		} else if(level == 5){
			qtdFormas = 5;
			tipos = 4;
			qtdExtra = 2;
		} else if(level == 6){
			qtdFormas = 6;
			tipos = 4;
			qtdExtra = 2;
		}
		formasPergunta = new GameObject[qtdFormas];
		formasResposta = new GameObject[qtdFormas];
		btn.gameObject.SetActive(false);
		StartCoroutine("MostraSequencia");
	}

	private IEnumerator MostraSequencia(){
		Txt.text = "Memorize a Sequência";
        yield return new WaitForSeconds(0.2f);
        for (float f = 0f; f <= standard.a; f += 0.01f)
        {
            Color c = Txt.color;
			c.a = f;
			Txt.color = c;
			new WaitForSeconds(.2f);
            yield return null;
        }
        yield return new WaitForSeconds(.5f);
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = Txt.color;
			c.a = f;
			Txt.color = c;
			new WaitForSeconds(.2f);
            yield return null;
        }
		yield return new WaitForSeconds(1f);
		int index = -1;
		for(int i = 0; i < qtdFormas; i++){
			formasPergunta[i] = GameObject.Instantiate(forma, new Vector3(pos.position.x - qtdFormas + (i*2),pos.position.y,pos.position.z) ,pos.rotation);
			formasResposta[i] = GameObject.Instantiate(forma, new Vector3(pos.position.x - qtdFormas + (i*2),pos.position.y,pos.position.z) ,pos.rotation);
			if(index < 0) index = UnityEngine.Random.Range(0,tipos);
			formasPergunta[i].GetComponent<SpriteRenderer>().sprite = formas[index].imagem;
			formasPergunta[i].GetComponent<FormasInfos>().SetValues(formas[index].forma,i);
			formasResposta[i].GetComponent<FormasInfos>().SetValues("",i);
			if(i < formas.Length-1){
				if(index < tipos-1) index++;
				else index = 0;
			} else {
				index = UnityEngine.Random.Range(0,4);
			}
			formasPergunta [i].gameObject.tag = "Pergunta";
			formasResposta [i].gameObject.tag = "Resposta";
		}
		//Embaralha("P");
		yield return new WaitForSeconds(5f);
		for(int i = 0; i < formasPergunta.Length; i++){
			formasPergunta[i].GetComponent<SpriteRenderer>().enabled = false;
			formasPergunta[i].transform.position = new Vector3(formasPergunta[i].transform.position.x,formasPergunta[i].transform.position.y-2,formasPergunta[i].transform.position.z);
		}
		StartCoroutine("Responde");

	}

	private void Embaralha(string param)
	{
		var formaList = new List<int> ();

		if(param == "P"){
			int form = formasPergunta [UnityEngine.Random.Range (0, formasPergunta.Length)].GetComponent<FormasInfos>().GetIndex();
			
			for (int i = 0; i < formasPergunta.Length; i++) 
			{
				while (formaList.Contains (form)) 
				{
					form = formasPergunta [UnityEngine.Random.Range (0, formasPergunta.Length)].GetComponent<FormasInfos>().GetIndex();
				}
				formaList.Add (form);
			}
			for(int i = 0; i < formaList.Count; i++){
			formasPergunta [i].GetComponent<SpriteRenderer>().sprite = formasPergunta [formaList[i]].GetComponent<FormasInfos>().GetSprite();
			formasPergunta [i].GetComponent<FormasInfos>().SetValues(formasPergunta [formaList[i]].GetComponent<FormasInfos>().GetForma(),i);
			}
		}

		/*if(param == "R"){
			Sprite form = formasResposta [UnityEngine.Random.Range (0, formasResposta.Length)].GetComponent<SpriteRenderer>().sprite;
			
			for (int i = 0; i < formasResposta.Length; i++) 
			{
				while (formaList.Contains (form)) 
				{
					form = formasResposta [UnityEngine.Random.Range (0, formasResposta.Length)].GetComponent<SpriteRenderer>().sprite;
				}
				formaList.Add (form);
			}
			for(int i = 0; i < formaList.Count; i++){
			formasResposta [i].GetComponent<SpriteRenderer>().sprite = formaList[i];
			formasResposta [i].GetComponent<FormasInfos>().SetValues(formaList[i].name, i);
			}
		}*/
	}

	private IEnumerator Responde(){
		StopCoroutine("GameStart");	
		Txt.text = "Agora coloque as peças na sequência correta";
        yield return new WaitForSeconds(0.2f);
        for (float f = 0f; f <= standard.a; f += 0.01f)
        {
            Color c = Txt.color;
			c.a = f;
			Txt.color = c;
			new WaitForSeconds(.2f);
            yield return null;
        }
        yield return new WaitForSeconds(.5f);
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = Txt.color;
			c.a = f;
			Txt.color = c;
			new WaitForSeconds(.2f);
            yield return null;
        }	
		yield return new WaitForSeconds(1f);

		formasEscolha = new GameObject[formasPergunta.Length + qtdExtra];
		int index = 0;
		for(int i = 0; i < formasPergunta.Length + qtdExtra; i++){
			if(i < 5)
				formasEscolha[i] = GameObject.Instantiate(forma, new Vector3(posR.position.x, posR.position.y - (i*1.8f), posR.position.z) ,posR.rotation);
			else
				formasEscolha[i] = GameObject.Instantiate(forma, new Vector3(posR.position.x + 1.8f, posR.position.y - ((i-5)*2), posR.position.z) ,posR.rotation);
			if(i < formasPergunta.Length){
				formasEscolha[i].GetComponent<SpriteRenderer>().sprite = formasPergunta[i].GetComponent<SpriteRenderer>().sprite;
				formasEscolha[i].GetComponent<FormasInfos>().SetValues(formasPergunta[i].GetComponent<FormasInfos>().GetForma(),i);
			} else{
				index = UnityEngine.Random.Range(0,tipos);
				formasEscolha[i].GetComponent<SpriteRenderer>().sprite = formas[index].imagem;
				formasEscolha[i].GetComponent<FormasInfos>().SetValues(formas[index].forma,i);
			}
			formasEscolha [i].gameObject.tag = "Escolha";
		}
		btn.gameObject.SetActive(true);
		//Embaralha("R");
	}

	void EscolherForma(){
		RaycastHit formaClick = new RaycastHit();
		bool hit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out formaClick);
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("1");
			if (hit) {
				Debug.Log("2");
				//som de click no ingrediente
				if (formaClick.transform.tag == "Escolha") {
					for (int i = 0; i < formasEscolha.Length; i++) {
						if (formaClick.transform.gameObject.GetComponent<FormasInfos> ().GetIndex ()
						   == formasEscolha [i].GetComponent<FormasInfos> ().GetIndex ()) {
							for (int j = 0; j < formasResposta.Length; j++) {
								if (formasResposta [j].GetComponent<FormasInfos> ().GetForma () == "") {
									formasResposta [j].GetComponent<FormasInfos> ().SetValues (formasEscolha [i].GetComponent<FormasInfos> ().GetForma ()
									, formasResposta [j].GetComponent<FormasInfos> ().GetIndex ());
									formasResposta [j].GetComponent<SpriteRenderer> ().sprite = formasEscolha [i].GetComponent<SpriteRenderer> ().sprite;
									formasEscolha [i].GetComponent<FormasInfos> ().SetValues ("", formasEscolha [i].GetComponent<FormasInfos> ().GetIndex ());
									formasEscolha [i].GetComponent<SpriteRenderer> ().sprite = null;
									break;
								}

							}
							Debug.Log (formasEscolha [i].GetComponent<FormasInfos> ().GetIndex ());
						}
					}
				}
				if (formaClick.transform.tag == "Resposta") {
					for (int i = 0; i < formasResposta.Length; i++) {
						if (formaClick.transform.gameObject.GetComponent<FormasInfos> ().GetIndex ()
						   == formasResposta [i].GetComponent<FormasInfos> ().GetIndex ()) {
							for (int j = 0; j < formasEscolha.Length; j++) {
								if (formasEscolha [j].GetComponent<FormasInfos> ().GetForma () == "") {
									formasEscolha [j].GetComponent<FormasInfos> ().SetValues (formasResposta [i].GetComponent<FormasInfos> ().GetForma ()
									, formasEscolha [j].GetComponent<FormasInfos> ().GetIndex ());
									formasEscolha [j].GetComponent<SpriteRenderer> ().sprite = formasResposta [i].GetComponent<SpriteRenderer> ().sprite;
									formasResposta [i].GetComponent<FormasInfos> ().SetValues ("", formasResposta [i].GetComponent<FormasInfos> ().GetIndex ());
									formasResposta [i].GetComponent<SpriteRenderer> ().sprite = null;
									break;
								}

							}
							Debug.Log (formasEscolha [i].GetComponent<FormasInfos> ().GetIndex ());
						}
					}
				}
			}
		}
	}

	public IEnumerator C_Compara(){
		int count = 0;
		//som de click no botão
		for(int i = 0; i < formasPergunta.Length; i++){
			yield return new WaitForSeconds(0.5f);
			formasPergunta[i].GetComponent<SpriteRenderer>().enabled = true;
			if(formasPergunta[i].GetComponent<FormasInfos> ().GetForma() == formasResposta[i].GetComponent<FormasInfos> ().GetForma()){
				count++;
			}
		}
		yield return new WaitForSeconds(1f);
		if(count == formasPergunta.Length){
			Txt.text = "Parabéns! Você conseguiu fazer o Bolo!";
		} else {
			Txt.text = "Que pena! Algo deu errado... Tente novamente";
		}
		yield return new WaitForSeconds(0.2f);
        for (float f = 0f; f <= standard.a; f += 0.01f)
        {
            Color c = Txt.color;
			c.a = f;
			Txt.color = c;
			new WaitForSeconds(.2f);
            yield return null;
        }
        yield return new WaitForSeconds(.5f);
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = Txt.color;
			c.a = f;
			Txt.color = c;
			new WaitForSeconds(.2f);
            yield return null;
        }
		/*if(count == formasPergunta.Length){
			if(ind == 1) {*/
			if(level < 6){
				Txt.text = "Agora vamos para a próxima receita!";
			}
			else {
				Txt.text = "Parabéns! Você completou o nível.";
			}
			yield return new WaitForSeconds(0.2f);
			for (float f = 0f; f <= standard.a; f += 0.01f)
			{
				Color c = Txt.color;
				c.a = f;
				Txt.color = c;
				new WaitForSeconds(.2f);
				yield return null;
			}
			yield return new WaitForSeconds(.5f);
			for (float f = 1f; f >= 0; f -= 0.01f)
			{
				Color c = Txt.color;
				c.a = f;
				Txt.color = c;
				new WaitForSeconds(.2f);
				yield return null;
			}
			/*if(ind == 1) {
				ind++;*/
			if(level < 6){
				level++;
				yield return new WaitForSeconds(2f);
				Clear();
				StartGame();
				StopCoroutine("C_Compara");
			} else {
				yield return new WaitForSeconds(2f);
				SceneManager.LoadScene ("Score");
			}
		/*} else{
				yield return new WaitForSeconds(2f);
				SceneManager.LoadScene ("AcertaSequencia");
		}*/
	}

	public void Compara(){
		StartCoroutine("C_Compara");
		btn.gameObject.SetActive(false);
	}

	private void Clear(){
		for(int i = 0; i < formasPergunta.Length; i++){
			Destroy(formasPergunta[i]);
			Destroy(formasResposta[i]);
		}
		for(int i = 0; i < formasEscolha.Length; i++){
			Destroy(formasEscolha[i]);
		}
		Array.Clear(formasPergunta,0,formasPergunta.Length);
		Array.Clear(formasResposta,0,formasResposta.Length);
		Array.Clear(formasEscolha,0,formasEscolha.Length);
		btn.gameObject.SetActive(true);
	}
}