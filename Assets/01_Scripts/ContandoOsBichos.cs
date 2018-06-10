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

	public GameObject button, btnConta, btnConfirma, animal, texto, btnSubtrai;
	
	private string tipoAnimal, animalContado;

	[Header("Celeiro")]
	public Animator[] barnAnims;
	public GameObject ExitBoard;

	[Space(10)]
	int notaFinal;

	[Space(10)]
	[Header("Tutorial")]
	public string [] txtTutorial;
	public Text infoTutorial;
	int indexTutorial = 0;
	[SerializeField]
	GameObject tutorial;
	[SerializeField]
	GameObject[] boardsTutorial;
	[SerializeField]
	GameObject[] imagesTutorial;


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
		infoTutorial.text = txtTutorial [indexTutorial];
		boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (false);boardsTutorial [2].SetActive (false);
		imagesTutorial [0].SetActive (true);imagesTutorial [1].SetActive (false);imagesTutorial [2].SetActive (false);imagesTutorial [3].SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if(countDestroy <= 0 && countSpawn == 0){
			StartCoroutine("Responde");
			countDestroy = 99;
			countSpawn = 99;
		}
	}
	public void ChangeTextTutorialForward(){
		indexTutorial++;
		infoTutorial.text = txtTutorial [indexTutorial];
		if (indexTutorial == 0)
		{
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (false);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (true);
			imagesTutorial [1].SetActive (false);
			imagesTutorial [2].SetActive (false);
			imagesTutorial [3].SetActive (false);

		}
		if (indexTutorial == 1)
		{
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (true);
			imagesTutorial [2].SetActive (false);
			imagesTutorial [3].SetActive (false);
		}
		if (indexTutorial == 2)
		{
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (false);
			imagesTutorial [2].SetActive (true);
			imagesTutorial [3].SetActive (false);
		}
		if (indexTutorial == 3)
		{
			boardsTutorial [0].SetActive (false);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (true);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (false);
			imagesTutorial [2].SetActive (false);
			imagesTutorial [3].SetActive (true);
		}
	}

	public void ChangeTextTutorialBack(){
		indexTutorial--;
		infoTutorial.text = txtTutorial [indexTutorial];
		if (indexTutorial == 0)
		{
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (false);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (true);
			imagesTutorial [1].SetActive (false);
			imagesTutorial [2].SetActive (false);
			imagesTutorial [3].SetActive (false);

		}
		if (indexTutorial == 1)
		{
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (true);
			imagesTutorial [2].SetActive (false);
			imagesTutorial [3].SetActive (false);
		}
		if (indexTutorial == 2)
		{
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (false);
			imagesTutorial [2].SetActive (true);
			imagesTutorial [3].SetActive (false);
		}
		if (indexTutorial == 3)
		{
			boardsTutorial [0].SetActive (false);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (true);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (false);
			imagesTutorial [2].SetActive (false);
			imagesTutorial [3].SetActive (true);
		}
	
	}





	public void StartGame(){
		tutorial.SetActive (false);
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
		yield return new WaitForSeconds(3f);
		
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
		yield return new WaitForSeconds(1f);
		if (acertouEtapas >= 1) {
			notaFinal = 20;
		}
		GameOver();
//		Reseta();
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
			btnSubtrai.SetActive(false);
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
		btnSubtrai.SetActive(true);
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
		PlayerPrefs.SetInt ("notaFinalTemp" + idTema.ToString (), notaFinal);
		StartCoroutine ("WaitGameOver");
	}

	public IEnumerator WaitGameOver(){
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene ("Score");	
	}
}
