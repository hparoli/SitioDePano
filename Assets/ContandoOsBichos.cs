using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContandoOsBichos : MonoBehaviour {

	public Transform  spawn;

	public GameObject animal;

	private int countSpawn, idTema, countDestroy, contador, contaCavalo, contaGato, contaCachorro, contaPorco, indexEtapa, acertouEtapas;

	private int[] etapa = {15, 20, 30};
	
	[SerializeField]
	private Text texto, mensagem;

	public GameObject button;
	
	private string tipoAnimal, animalContado;

	// Use this for initialization
	void Start () {
		contador = 0;
		indexEtapa = 0;
		acertouEtapas = 0;
		contador = 0;
		contaPorco = 0;
		contaCavalo = 0;
		contaGato = 0;
		contaCachorro = 0;
		countSpawn = etapa[indexEtapa];
		countDestroy = etapa[indexEtapa];
		idTema = PlayerPrefs.GetInt ("idTema");
		
	}
	
	// Update is called once per frame
	void Update () {
		if(countDestroy == 0){
			Reseta();
		}
	}


	public void StartGame(){
		StartCoroutine("ConteOAnimal");
		button.SetActive(false);
	}

	public IEnumerator AnimalSpawn(){
		GameObject iAnimal = Instantiate(animal, spawn.position, spawn.rotation) as GameObject;
		yield return new WaitForSeconds(2f);
		tipoAnimal = iAnimal.GetComponent<AnimalDisplay>().anim;
		Debug.Log(tipoAnimal);
		if(tipoAnimal == "porco"){
			contaPorco++;
			Debug.Log(contaPorco);
		}
		if(tipoAnimal == "cavalo"){
			contaCavalo++;
			Debug.Log(contaCavalo);
		}
		if(tipoAnimal == "gato"){
			contaGato++;
			Debug.Log(contaGato);
		}
		if(tipoAnimal == "cachorro"){
			contaCachorro++;	
			Debug.Log(contaCachorro);
		}				
		countSpawn--;
		if(countSpawn > 0){
			StartCoroutine("AnimalSpawn");
		} 
	}

	IEnumerator ConteOAnimal(){
		yield return new WaitForSeconds(1f);
		int i = Random.Range(0,3);
		
		if(i == 0) animalContado = "porcos";
		if(i == 1) animalContado = "cavalos";
		if(i == 2) animalContado = "gatos";
		if(i == 3) animalContado = "cachorros";
		
		mensagem.text = "Conte os " + animalContado + " que passarem pelo caminho";
		
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
		StartCoroutine("AnimalSpawn");
	}

	public void Conta(){
		countDestroy--;
	}

	public void SomaAnimal(){
		contador++;
		texto.text = contador.ToString("f0");
	}

	public void SubtraiAnimal(){
		if(contador > 0)
			contador--;
		texto.text = contador.ToString("f0");
	}

	public void Reseta(){
		if(indexEtapa < 2){
			if((animalContado == "porcos" && contaPorco == contador) ||
			   (animalContado == "cavalos" && contaCavalo == contador) || 
			   (animalContado == "gatos" && contaGato == contador) ||
			   (animalContado == "cachorros"  && contaCachorro == contador)){
				   acertouEtapas++;
				   Debug.Log(acertouEtapas);
			   }
			countSpawn--;
			indexEtapa++;
			countSpawn = etapa[indexEtapa];
			countDestroy = etapa[indexEtapa];
			contador = 0;
			contaPorco = 0;
			contaCavalo = 0;
			contaGato = 0;
			contaCachorro = 0;
			texto.text = contador.ToString("f0");
			button.SetActive(true);
		} else {
			GameOver();
		}
	}

	void GameOver(){
		SceneManager.LoadScene ("Score");
	}
}
