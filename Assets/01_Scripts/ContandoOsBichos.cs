using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContandoOsBichos : MonoBehaviour {

	public Transform[]  spawn;

	public GameObject[] waypoints;

	private int countSpawn, idTema, countDestroy, contador, contaCavalo, contaGato, contaCachorro, contaPorco, indexEtapa, acertouEtapas, speed;

	private int[] etapa = {15, 20, 30};
	
	[SerializeField]
	private Text mensagem, resposta;

	public GameObject button, btnConta, btnConfirma, animal, texto;
	
	private string tipoAnimal, animalContado;

	[Header("Celeiro")]
	public Animator[] barnAnims;
	public GameObject ExitBoard;

	// Use this for initialization
	void Start () {
		contador = 0;
		indexEtapa = 0;
		acertouEtapas = 0;
		contaPorco = 0;
		contaCavalo = 0;
		contaGato = 0;
		contaCachorro = 0;
		countSpawn = etapa[indexEtapa];
		countDestroy = etapa[indexEtapa];
		texto.GetComponent<Text>().text = "";
		idTema = PlayerPrefs.GetInt ("idTema");
	}
	
	// Update is called once per frame
	void Update () {
		if(countDestroy <= 0 && countSpawn == 0){
			StartCoroutine("Responde");
			countDestroy = 99;
			countSpawn = 99;
		}
	}


	public void StartGame(){
		StartCoroutine("ConteOAnimal");
		button.SetActive(false);
	}

	public IEnumerator AnimalSpawn(){
		int time = Random.Range(1,3);
		yield return new WaitForSeconds(time);
		int idx = Random.Range(0,3);
		GameObject iAnimal = Instantiate(animal, spawn[idx].position, spawn[idx].rotation) as GameObject;
		
		if(idx == 0){
			speed = 3;
			iAnimal.GetComponent<SpriteRenderer>().sortingOrder = 4;
		}
		else if(idx == 1){
			speed = 4;
			iAnimal.GetComponent<SpriteRenderer>().sortingOrder = 3;
		} 
		else if(idx == 2){
			speed = 6;
			iAnimal.GetComponent<SpriteRenderer>().sortingOrder = 2;
		} 

		yield return new WaitForSeconds(0.5f);
		tipoAnimal = iAnimal.GetComponent<AnimalDisplay>().anim;
		iAnimal.GetComponent<AnimalBehavior>().SetAnimal(waypoints[idx], speed);
		
		if(tipoAnimal == "porco"){
			contaPorco++;
		//	Debug.Log(contaPorco);
		}
		if(tipoAnimal == "cavalo"){
			contaCavalo++;
		//	Debug.Log(contaCavalo);
		}
		if(tipoAnimal == "gato"){
			contaGato++;
		//	Debug.Log(contaGato);
		}
		if(tipoAnimal == "cachorro"){
			contaCachorro++;	
		//	Debug.Log(contaCachorro);
		}				
		countSpawn--;
		Debug.Log(countDestroy + ", " + countSpawn);
		if(countSpawn > 0){
			StartCoroutine("AnimalSpawn");
		} 
	}

	IEnumerator ConteOAnimal(){
		yield return new WaitForSeconds(1f);
		int i = Random.Range(0,3);
		
		if(i == 0) animalContado = "PORCOS";
		if(i == 1) animalContado = "CAVALOS";
		if(i == 2) animalContado = "GATOS";
		if(i == 3) animalContado = "CACHORROS";
		
		mensagem.text = "Rodada " + (indexEtapa+1);
		
		for (float f = 0f; f <= 1; f += 0.02f){
                Color c = mensagem.color;
		    	c.a = f;
		    	mensagem.color = c;
		    	new WaitForSeconds(.5f);
                yield return null;
        }
		
		yield return new WaitForSeconds(1f);

		for (float f = 1f; f > 0; f -= 0.02f){
                Color c = mensagem.color;
		    	c.a = f;
		    	mensagem.color = c;
		    	new WaitForSeconds(.5f);
                yield return null;
        }

		mensagem.text = "Conte os " + animalContado + " que passarem pelo caminho";
		
		for (float f = 0f; f <= 1; f += 0.02f){
                Color c = mensagem.color;
		    	c.a = f;
		    	mensagem.color = c;
		    	new WaitForSeconds(.5f);
                yield return null;
        }
		
		yield return new WaitForSeconds(1f);

		for (float f = 1f; f > 0; f -= 0.02f){
                Color c = mensagem.color;
		    	c.a = f;
		    	mensagem.color = c;
		    	new WaitForSeconds(.5f);
                yield return null;
        }
		mensagem.text = "";
		StartCoroutine("AnimalSpawn");
	}

	public void Conta(){
		countDestroy--;
		Debug.Log(countDestroy);
	}

	public void SomaAnimal(){
		contador++;
		texto.GetComponent<Text>().text = contador.ToString("f0");
	//	Debug.Log("Contador = " + contador);
	}

	public void SubtraiAnimal(){
		if(contador > 0)
			contador--;
		texto.GetComponent<Text>().text = contador.ToString("f0");

	}


	IEnumerator MostraResultado(){
		yield return new WaitForSeconds(1.5f);
		for(int i = 0; i < 4; i++){
			for (float f = 0f; f <= 1; f += 0.02f){
					Color c = resposta.color;
					c.a = f;
					resposta.color = c;
					//new WaitForSeconds(.2f);
					yield return null;
			}
			for (float f = 1f; f > 0; f -= 0.02f){
					Color c = resposta.color;
					c.a = f;
					resposta.color = c;
					//new WaitForSeconds(.2f);
					yield return null;
			}
		}
		
		//Debug.Log("Animal: " + animalContado + " Porco: " + contaPorco + " Cavalo: " + contaCavalo + " Cachorro: " + contaCachorro + " Gato: " + contaGato);

		if(animalContado == "PORCOS") resposta.text = contaPorco.ToString("f0");
		if(animalContado == "CAVALOS") resposta.text = contaCavalo.ToString("f0"); 
		if(animalContado == "GATOS") resposta.text = contaGato.ToString("f0");
		if(animalContado == "CACHORROS") resposta.text = contaCachorro.ToString("f0");
		

		if((animalContado == "PORCOS" && contaPorco == contador) ||
		   (animalContado == "CAVALOS" && contaCavalo == contador) || 
		   (animalContado == "GATOS" && contaGato == contador) ||
		   (animalContado == "CACHORROS"  && contaCachorro == contador)){
			   acertouEtapas++;
			   resposta.color = Color.green;
			   //feedback de acertou
		} else {
			resposta.color = Color.red;
			//feedback de errou
		}
		yield return new WaitForSeconds(2f);
		Reseta();
	}

	public void Reseta(){
		if(indexEtapa < 2){
			countSpawn--;
			indexEtapa++;
			countSpawn = etapa[indexEtapa];
			countDestroy = etapa[indexEtapa];
			contador = 0;
			contaPorco = 0;
			contaCavalo = 0;
			contaGato = 0;
			contaCachorro = 0;
			resposta.color = new Color(0,0,0,0);
			resposta.text = "0";
			texto.GetComponent<Text>().text = "";
			texto.GetComponent<Animator>().SetBool("Anima", false);
			button.SetActive(true);
			btnConta.SetActive(false);
			btnConfirma.SetActive(false);
		} else {
			GameOver();
		}
	}

	IEnumerator Responde(){
		mensagem.text = "Agora marque quantos " + animalContado + " você viu passar";
		
		for (float f = 0f; f <= 1; f += 0.01f){
                Color c = mensagem.color;
		    	c.a = f;
		    	mensagem.color = c;
		    	new WaitForSeconds(.5f);
                yield return null;
        }
		
		yield return new WaitForSeconds(2f);

		for (float f = 1f; f > 0; f -= 0.01f){
                Color c = mensagem.color;
		    	c.a = f;
		    	mensagem.color = c;
		    	new WaitForSeconds(.5f);
                yield return null;
        }
		
		mensagem.text = "";
		texto.GetComponent<Text>().text = contador.ToString("f0");
		btnConta.SetActive(true);
		btnConfirma.SetActive(true);
	}

	public void ConfirmaConta(){
		texto.GetComponent<Animator>().SetBool("Anima", true);
		StartCoroutine("MostraResultado");
		btnConfirma.SetActive(false);
	}

	public void BarnAnin(){
		for (int i = 0; i < barnAnims.Length; i++) {
			barnAnims [i].SetBool ("Active", true);
		}
		ExitBoard.SetActive (false);
	}

	void GameOver(){
		BarnAnin ();
		StartCoroutine ("WaitGameOver");
	}

	public IEnumerator WaitGameOver(){
		yield return new WaitForSeconds (1);
		SceneManager.LoadScene ("Score");	
	}
}
